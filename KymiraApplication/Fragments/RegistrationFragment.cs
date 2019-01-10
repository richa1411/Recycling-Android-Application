using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using KymiraApplication.Model;
using Newtonsoft.Json;

namespace KymiraApplication.Fragments
{
    public class RegistrationFragment : Fragment
    {
        // The class has a private HttpClient for POST and GET requests
        private HttpClient client = new HttpClient();
        private View view;
        //Declare edit text fields that we will need access to
        private EditText etEmail;
        private EditText etPassword;
        private EditText etPhone;
        private EditText etFirstName;
        private EditText etLastName;
        private EditText etAddressLine1;
        private EditText etAddressLine2;
        private EditText etCity;
        private EditText etPostalCode;

        //Declare spinners that we will need access to
        private Spinner birthDateSpinnerMonth;
        private Spinner birthDateSpinnerDay;
        private Spinner birthDateSpinnerYear;
        private Spinner provinceSpinner;

        //Declare check box that we will need access to
        private CheckBox termsCheckbox;

        //Declare boolean to hold value of terms checkbox
        private bool agreeToTerms;

        //Declare variables to hold the values of the selected items from the spinners
        private string month;
        private string day;
        private string year;
        private string province;

        //Declare the button we need access to
        private Button btnSubmit;

        //Declare the Registration object that will get created
        private Registration obRegistration = new Registration();

        //Declare a list to hold the results of validating registration information
        private IList<ValidationResult> validationResults;

        //Variable that holds the programatically calculated years that will appear in the birth year spinner
        private string[] birthYearRange;

        //Array that holds the programatically calculated days in the month that the user selects
        private string[] birthDayRange;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            
            agreeToTerms = false;          

        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            view = inflater.Inflate(Resource.Layout.registration_layout, container, false);

            //Assign UI Controls
            etEmail = view.FindViewById<EditText>(Resource.Id.email_value);
            etPassword = view.FindViewById<EditText>(Resource.Id.password_value);
            etPhone = view.FindViewById<EditText>(Resource.Id.phone_value);
            etFirstName = view.FindViewById<EditText>(Resource.Id.firstName_value);
            etLastName = view.FindViewById<EditText>(Resource.Id.lastName_value);
            etAddressLine1 = view.FindViewById<EditText>(Resource.Id.addressLine1_value);
            etAddressLine2 = view.FindViewById<EditText>(Resource.Id.addressLine2_value);
            etCity = view.FindViewById<EditText>(Resource.Id.city_value);
            etPostalCode = view.FindViewById<EditText>(Resource.Id.postalCode_value);
            termsCheckbox = view.FindViewById<CheckBox>(Resource.Id.termsCheckbox);
            btnSubmit = view.FindViewById<Button>(Resource.Id.btnSubmit);

            createSpinners();

            return view;
        }

        private void createSpinners()
        {
            birthYearRange = new string[120];

            //Create listener and adapter for birth date spinner month
            birthDateSpinnerMonth = view.FindViewById<Spinner>(Resource.Id.birthDateSpinnerMonth);
            birthDateSpinnerMonth.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(birthDateMonthSpinner_ItemSelected);
            var monthAdapter = ArrayAdapter.CreateFromResource(
                    this.Context, Resource.Array.month_array, Android.Resource.Layout.SimpleSpinnerItem);

            monthAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            birthDateSpinnerMonth.Adapter = monthAdapter;

            //Get the current year
            int currentYear = DateTime.Now.Year;

            //Counter to move through array from the beginning
            int counter = 0;

            //Fill the birth year range array based on the value of the current year
            for (int i = currentYear; i > currentYear - 120; i--)
            {
                birthYearRange[counter] = i.ToString();

                counter++;
            }

            //Create listener and adapter for birth date spinner year
            birthDateSpinnerYear = view.FindViewById<Spinner>(Resource.Id.birthDateSpinnerYear);
            birthDateSpinnerYear.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(birthDateYearSpinner_ItemSelected);
            var yearAdapter = new ArrayAdapter<string>(this.Context, Android.Resource.Layout.SimpleSpinnerItem, birthYearRange);
            yearAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            birthDateSpinnerYear.Adapter = yearAdapter;

            //Create listener and adapter for birth day spinner day
            birthDateSpinnerDay = view.FindViewById<Spinner>(Resource.Id.birthDateSpinnerDay);
            birthDateSpinnerDay.Enabled = false;
            birthDateSpinnerDay.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(birthDateDaySpinner_ItemSelected);
            //var dayAdapter = ArrayAdapter.CreateFromResource(
            //this, Resource.Array.birthDateDay_array, Android.Resource.Layout.SimpleSpinnerItem);         

            //dayAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            //birthDateSpinnerDay.Adapter = dayAdapter;

            //Create listener and adapter for province spinner
            provinceSpinner = view.FindViewById<Spinner>(Resource.Id.provinceSpinner);
            provinceSpinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(provinceSpinner_ItemSelected);
            var provinceAdapter = ArrayAdapter.CreateFromResource(
                    this.Context, Resource.Array.province_array, Android.Resource.Layout.SimpleSpinnerItem);

            provinceAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            provinceSpinner.Adapter = provinceAdapter;

        }

        private void calculateDatesOfMonth()
        {
            int birthYear = 0;

            Int32.TryParse(this.year, out birthYear);

            int birthMonth = 1;

            //Currently this is failing because this.month is not set at this point!!!
            Int32.TryParse(this.month, out birthMonth);

            int days = DateTime.DaysInMonth(birthYear, birthMonth);

            for(int i = 1; i <= days; i++)
            {
                birthDayRange[i] = i.ToString();
            }

            var dayAdapter = new ArrayAdapter<string>(this.Context, Android.Resource.Layout.SimpleSpinnerItem, birthDayRange);
            dayAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            birthDateSpinnerDay.Adapter = dayAdapter;
            birthDateSpinnerDay.Enabled = true;
        }

        private void TermsCheckbox_Click(object sender, EventArgs e)
        {
            CheckBox checkbox = (CheckBox)sender;

            //If the user has ticked the termsCheckbox
            if (checkbox.Checked)
            {
                this.agreeToTerms = true;
            }
            else
            {
                this.agreeToTerms = false;
            }
        }

        private async void BtnSubmit_Click(object sender, EventArgs e)
        {
            string strRegBirthDate = this.year + "-" + this.month + "-" + this.day;

            //Before validating, convert postal code to all upper case
            string strPostalCode = etPostalCode.Text.ToString().ToUpper();

            //Create a new Registration object from the populated edit text fields
            obRegistration = new Registration(etEmail.Text.ToString(), etPassword.Text.ToString(), etPhone.Text.ToString(), etFirstName.Text.ToString(), etLastName.Text.ToString(), strRegBirthDate, etAddressLine1.Text.ToString(), etCity.Text.ToString(), provinceSpinner.SelectedItem.ToString(), strPostalCode, this.agreeToTerms);

            //Validate the Registration object
            validationResults = ValidationHelper.Validate(obRegistration);

            //Alter the form of the birth date -- CHANGE THIS
            //obRegistration.birthDate = this.year + "-" + this.month + "-" + this.day;

            //If the validationResults list has anything in it
            if (validationResults.Count > 0)
            {
                //Output the first error message in the list
                Toast.MakeText(this.Context, validationResults[0].ErrorMessage, ToastLength.Long).Show();
            }
            //Otherwise, create a JSON object from the form data and send a post request to the API
            else
            {
                //"http://kymiraapi20181030112027.azurewebsites.net/api/Residents";
                var success = await sendJsonAsync(obRegistration);
                Toast.MakeText(this.Context, success, ToastLength.Short).Show();
            }
        }

        //This method handles sending a serialized Registration json object
        public async Task<String> sendJsonAsync(Registration item)
        {
            //Convert the given string to a URI
            Uri uri = new Uri(Resource.String.UrlResidents.ToString(), UriKind.Absolute);

            // Serialize the Registration item into a JSON object
            var json = JsonConvert.SerializeObject(item);

            // Convert the JSON object to be StringContent
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            // Create an HttpResponseMessage to hold the response of the HttpClient's POST
            HttpResponseMessage response = await client.PostAsync(uri, content);

            // If JSON was sent successfully, return that
            if (response.IsSuccessStatusCode)
            {
                return "Registration successful!";
            }
            // Else, notify user that it failed
            else
            {
                return "Registration failed";
            }
        }

        private void birthDateYearSpinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;

            this.year = spinner.SelectedItem.ToString();
        }

        private void birthDateDaySpinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;

            int result;

            //Parse the item in the spinner to an integer
            Int32.TryParse(spinner.SelectedItem.ToString(), out result);

            //If the birth date day is below the 10th, zero pad the date
            if (result < 10)
            {
                this.day = "0" + spinner.SelectedItem.ToString();
            }
            //Otherwise, just save the birth date data to the class
            else
            {
                this.day = spinner.SelectedItem.ToString();

            }
        }

        private void birthDateMonthSpinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;

            string strMonth = spinner.SelectedItem.ToString();

            //Based on the item selected by the province spinner, set the value of the month from alpha to numeric only
            switch (strMonth)
            {
                case "January":
                    strMonth = "01";
                    break;
                case "February":
                    strMonth = "02";
                    break;
                case "March":
                    strMonth = "03";
                    break;
                case "April":
                    strMonth = "04";
                    break;
                case "May":
                    strMonth = "05";
                    break;
                case "June":
                    strMonth = "06";
                    break;
                case "July":
                    strMonth = "07";
                    break;
                case "August":
                    strMonth = "08";
                    break;
                case "September":
                    strMonth = "09";
                    break;
                case "October":
                    strMonth = "10";
                    break;
                case "November":
                    strMonth = "11";
                    break;
                case "December":
                    strMonth = "12";
                    break;
                default:
                    strMonth = "";
                    break;
            }

            //Set the class variable of month to the month selected by the spinner
            this.month = strMonth;

            calculateDatesOfMonth();
        }

        private void provinceSpinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;

            this.province = spinner.SelectedItem.ToString();
        }
    }
}
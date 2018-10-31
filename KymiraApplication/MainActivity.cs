using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Android;
using Android.App;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Android.Support.V4.Widget;
using Android.Support.V7.App;
using Android.Text;
using Android.Views;
using Android.Widget;
using KymiraApplication.Model;

namespace KymiraApplication
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
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

        //Declare container variables for items selected from the spinners
        private int birthMonth;
        private int birthDay;
        private int birthYear;

        //Declare variables to hold the values of the selected items from the spinners
        private string month;
        private string day;
        private string year;
        private string province;

        //Declare the button we need access to
        private Button btnSubmit;

        //Declare out JSON handler
        private jsonHandler jsonHandler;

        //Declare the Registration object that will get created
        private Registration obRegistration = new Registration();

        //Declare a list to hold the results of validating registration information
        List<ValidationResult> validationResults;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set the content view to our Registration Activity
            SetContentView(Resource.Layout.activity_registration);

            // Assign UI controls
            etEmail = FindViewById<EditText>(Resource.Id.email_value);
            etPassword = FindViewById<EditText>(Resource.Id.password_value);
            etPhone = FindViewById<EditText>(Resource.Id.phone_value);
            etFirstName = FindViewById<EditText>(Resource.Id.firstName_value);
            etLastName = FindViewById<EditText>(Resource.Id.lastName_value);
            etAddressLine1 = FindViewById<EditText>(Resource.Id.addressLine1_value);
            etAddressLine2 = FindViewById<EditText>(Resource.Id.addressLine2_value);
            etCity = FindViewById<EditText>(Resource.Id.city_value);
            etPostalCode = FindViewById<EditText>(Resource.Id.postalCode_value);
            termsCheckbox = FindViewById<CheckBox>(Resource.Id.termsCheckbox);
            btnSubmit = FindViewById<Button>(Resource.Id.btnSubmit);
            createSpinners();
            this.agreeToTerms = false;

            //Create our JSON Handler
            jsonHandler = new jsonHandler();

            //Assign click handler to our resgistration submit button
            btnSubmit.Click += BtnSubmit_Click;

            //Assign checked handler to our terms checkbox
            termsCheckbox.Click += TermsCheckbox_Click;


            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

           

        }

        //Private helper method for assigning listeners and adapters to birth date and province spinners
        private void createSpinners()
        {
            //Create listener and adapter for birth date spinner month
            birthDateSpinnerMonth = FindViewById<Spinner>(Resource.Id.birthDateSpinnerMonth);
            birthDateSpinnerMonth.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(birthDateMonthSpinner_ItemSelected);
            var monthAdapter = ArrayAdapter.CreateFromResource(
                    this, Resource.Array.birthDateMonths_array, Android.Resource.Layout.SimpleSpinnerItem);

            monthAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            birthDateSpinnerMonth.Adapter = monthAdapter;

            //Create listener and adapter for birth day spinner day
            birthDateSpinnerDay = FindViewById<Spinner>(Resource.Id.birthDateSpinnerDay);
            birthDateSpinnerDay.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(birthDateDaySpinner_ItemSelected);
            var dayAdapter = ArrayAdapter.CreateFromResource(
                    this, Resource.Array.birthDateDay_array, Android.Resource.Layout.SimpleSpinnerItem);

            dayAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            birthDateSpinnerDay.Adapter = dayAdapter;

            //Create listener and adapter for birth date spinner year
            birthDateSpinnerYear = FindViewById<Spinner>(Resource.Id.birthDateSpinnerYear);
            birthDateSpinnerYear.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(birthDateYearSpinner_ItemSelected);
            var yearAdapter = ArrayAdapter.CreateFromResource(
                    this, Resource.Array.birthDateYear_array, Android.Resource.Layout.SimpleSpinnerItem);

            yearAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            birthDateSpinnerYear.Adapter = yearAdapter;

            //Create listener and adapter for province spinner
            provinceSpinner = FindViewById<Spinner>(Resource.Id.provinceSpinner);
            provinceSpinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(provinceSpinner_ItemSelected);
            var provinceAdapter = ArrayAdapter.CreateFromResource(
                    this, Resource.Array.province_array, Android.Resource.Layout.SimpleSpinnerItem);

            provinceAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            provinceSpinner.Adapter = provinceAdapter;
        }

        //Click handler for the terms checkbox - sets the private class variable to value of checkbox
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

        //Click handler for the submit registration button
        //Creates a registration object from the values in the edit text fields and calls the json handler to serialize and post it to specified uri
        private async void BtnSubmit_Click(object sender, EventArgs e)
        {
            string strRegBirthDate = this.year + this.month + this.day;

            //Before validating, convert postal code to all upper case
            string strPostalCode = etPostalCode.Text.ToString().ToUpper();

            //Create a new Registration object from the populated edit text fields
            obRegistration = new Registration(etEmail.Text.ToString(), etPassword.Text.ToString(), etPhone.Text.ToString(), etFirstName.Text.ToString(), etLastName.Text.ToString(), strRegBirthDate, etAddressLine1.Text.ToString(), etCity.Text.ToString(), provinceSpinner.SelectedItem.ToString(), strPostalCode, this.agreeToTerms);

            //Alter the form of the birth date
            obRegistration.birthDate = this.year + "-" + this.month + "-" + this.day;

            //Validate the Registration object
            validationResults = ValidationHelper.Validate(obRegistration);

            //If the validationResults list has anything in it
            if (validationResults.Count > 0)
            {
                //Output the first error message in the list
                Toast.MakeText(this, validationResults[0].ErrorMessage, ToastLength.Long).Show();
            }
            //Otherwise, create a JSON object from the form data and send a post request to the API
            else
            {
                var success = await jsonHandler.sendJsonAsync(obRegistration, "http://kymiraapi20181030112027.azurewebsites.net/api/Residents");
                Toast.MakeText(this, success, ToastLength.Short).Show();
            }
        }

        //Birth date year spinner listener
        private void birthDateYearSpinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;

            this.year = spinner.SelectedItem.ToString();
        }

        //Birth date day spinner listener
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

        //Birth date month spinner listener
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

            this.month = strMonth;

        }

        //Province spinner listener
        private void provinceSpinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;

            this.province = spinner.SelectedItem.ToString();
        }

        public override void OnBackPressed()
        {
            //DrawerLayout drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            //if(drawer.IsDrawerOpen(GravityCompat.Start))
            //{
            //drawer.CloseDrawer(GravityCompat.Start);
            //}
            //else
            //{
            //base.OnBackPressed();
            //}
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }


        //private void FabOnClick(object sender, EventArgs eventArgs)
        //{
        //View view = (View) sender;
        //Snackbar.Make(view, "Replace with your own action", Snackbar.LengthLong)
        //.SetAction("Action", (Android.Views.View.IOnClickListener)null).Show();
        //}

        /**
    public bool OnNavigationItemSelected(IMenuItem item)
    {
        int id = item.ItemId;

        if (id == Resource.Id.nav_camera)
        {
            // Handle the camera action
        }
        else if (id == Resource.Id.nav_gallery)
        {

        }
        else if (id == Resource.Id.nav_slideshow)
        {

        }
        else if (id == Resource.Id.nav_manage)
        {

        }
        else if (id == Resource.Id.nav_share)
        {

        }
        else if (id == Resource.Id.nav_send)
        {

        }

        //DrawerLayout drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
        //drawer.CloseDrawer(GravityCompat.Start);
        //return true; 
    } **/
    }
}


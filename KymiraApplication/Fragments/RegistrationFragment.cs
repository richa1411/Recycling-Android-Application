using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
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

namespace KymiraApplication.Fragments
{
    public class RegistrationFragment : Fragment
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
        private List<ValidationResult> validationResults;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            return base.OnCreateView(inflater, container, savedInstanceState);
        }

        private void createSpinners()
        {
            
        }

        private void TermsCheckbox_Click(object sender, EventArgs e)
        {

        }

        private async void BtnSubmit_Click(object sender, EventArgs e)
        {

        }

        //private async Task<String> sendJsonAsync(Registration obReg)
        //{

        //}

        private void birthDateYearSpinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {

        }

        private void birthDateDaySpinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {

        }

        private void birthDateMonthSpinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {

        }

        private void provinceSpinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {

        }
    }
}
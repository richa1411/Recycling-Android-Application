using System;
using Android;
using Android.App;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Android.Support.V4.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace KymiraApplication
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity //, NavigationView.IOnNavigationItemSelectedListener
    {
        Spinner birthDateSpinnerMonth;
        Spinner birthDateSpinnerDay;
        Spinner birthDateSpinnerYear;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set the content view to our Registration Activity
            SetContentView(Resource.Layout.activity_registration);


            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);



            birthDateSpinnerMonth = FindViewById<Spinner>(Resource.Id.birthDateSpinnerMonth);
            birthDateSpinnerMonth.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(birthDateMonthSpinner_ItemSelected);
            var monthAdapter = ArrayAdapter.CreateFromResource(
                    this, Resource.Array.birthDateMonths_array, Android.Resource.Layout.SimpleSpinnerItem);

            monthAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            birthDateSpinnerMonth.Adapter = monthAdapter;




            birthDateSpinnerDay = FindViewById<Spinner>(Resource.Id.birthDateSpinnerDay);
            birthDateSpinnerDay.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(birthDateDaySpinner_ItemSelected);
            var dayAdapter = ArrayAdapter.CreateFromResource(
                    this, Resource.Array.birthDateDay_array, Android.Resource.Layout.SimpleSpinnerItem);

            dayAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            birthDateSpinnerDay.Adapter = dayAdapter;


            birthDateSpinnerYear = FindViewById<Spinner>(Resource.Id.birthDateSpinnerYear);
            birthDateSpinnerYear.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(birthDateYearSpinner_ItemSelected);
            var yearAdapter = ArrayAdapter.CreateFromResource(
                    this, Resource.Array.birthDateYear_array, Android.Resource.Layout.SimpleSpinnerItem);

            yearAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            birthDateSpinnerYear.Adapter = yearAdapter;




        }

        private void birthDateYearSpinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
           //
        }

        private void birthDateDaySpinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            //
        }

        private void birthDateMonthSpinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
           //TODO
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


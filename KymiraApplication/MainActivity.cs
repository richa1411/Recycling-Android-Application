using System;
using Android;
using Android.App;
using Android.Content.Res;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Android.Support.V4.Widget;
using Android.Support.V7.App;
using Android.Views;
using KymiraApplication.Fragments;

namespace KymiraApplication
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity, NavigationView.IOnNavigationItemSelectedListener
    { /*
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            DrawerLayout drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
        }*/
		//variable that will store token generated from LoginAPI on successful login for each user got from LoginFragment(front end)
        public String token;

        //this method creates and sets an instance of main activity and assigns view of this activity
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            //opens view (layout) here it is activity_main
            SetContentView(Resource.Layout.activity_main);
            //instance of toolbar class that creates toolbar on our drawer layout
            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            //an instance of drawer layout is made
            DrawerLayout drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            //toggle button that opens navigational item side bar, instance is applied with toolbar, drawer instances 
            ActionBarDrawerToggle toggle = new ActionBarDrawerToggle(this, drawer, toolbar, Resource.String.navigation_drawer_open, Resource.String.navigation_drawer_close);
            drawer.AddDrawerListener(toggle);
            toggle.SyncState();

            NavigationView navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);
            navigationView.SetNavigationItemSelectedListener(this);
        }
        /*
        public override void OnBackPressed()
        {
            //instance of navigational view
            NavigationView navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);
            navigationView.SetNavigationItemSelectedListener(this);
            
        }*/
        
        //this method handles event for back button press
        public override void OnBackPressed()
        {
            //finds drawer layout, and make it start/close flips it on click of back button
            DrawerLayout drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            if(drawer.IsDrawerOpen(GravityCompat.Start))
            {
                drawer.CloseDrawer(GravityCompat.Start);
            }
            else
            {
                base.OnBackPressed();
            }
        }

        //displays menu items placed just after navigation items that navigates to menu_main layout
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        
        //a method that will switch through each option inside drawer layout (navigational tabs)
        public bool OnNavigationItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                //case for login option navigation
                case Resource.Id.nav_login:
                //on click of login navigation item
                //calls fragment named LoginFragment that will be replaced by framelayout and displays a new layout
                    FragmentManager.BeginTransaction().Replace(Resource.Id.frameContent, new LoginFragment()).Commit();
                    break;
				case Resource.Id.nav_bin_status:
                //calls BinStatus fragment to replace the framelayout and display bin status layout
				    FragmentManager.BeginTransaction().Replace(Resource.Id.frameContent, new BinStatusFragment()).Commit();
					break;
			}

            return base.OnOptionsItemSelected(item);
        }

        

        //Method that will get token from LoginFrgament and assign it to a public variable of Main activity
        //so that all other connected fragments can use it with get and set methods
        public void setToken(String token)
        {
            this.token = token;
        }

        public String getToken()
        {
            return this.token;
        }
        
    }
}


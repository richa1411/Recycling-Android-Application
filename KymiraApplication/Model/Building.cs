using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace KymiraApplication.Model
{
    class Building
    {
        int addressID;
        string addressName; //to be compared to AddressLine1 and AddressLine2 in Resident
        int NBHDID; // neighbourhood number 
    }
}
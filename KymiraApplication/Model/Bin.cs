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
    class Bin
    {
        int binID;
        int addressID;
        int binStatus; //1 -> good, 2 -> blocked, 3 -> Contaminated
        int pickupFrequency; //weekly, bi-weekly, etc.
        int pickupDay; //number (1-5) (Monday-Friday)
    }
}
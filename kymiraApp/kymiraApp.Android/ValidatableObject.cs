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

namespace kymiraApp.Droid
{
    public interface ValidatableObject
    {
        string error { get; set; }
        bool isValid { get; set; }
        void Validate();
    }
}
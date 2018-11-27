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
using KymiraApplication.Model;

namespace KymiraApplication
{
    public class SimBinStatusBackend
    {
        BinStatus[] binArray;

        public SimBinStatusBackend()
        {
            BinStatus bin1 = new BinStatus();
            bin1.binID = 1;
            bin1.binAddress = "123 Test Street";
            bin1.status = 1;

            binArray = new BinStatus[1];

            binArray[0] = bin1;
        }

        public BinStatus checkListOfBins(BinStatus bin)
        {
            for (int i = 0; i < binArray.Length; i++)
            {
                if(binArray[i].binAddress.Equals(bin.binAddress))
                {               
                    return binArray[i];
                }
            }

            BinStatus binStatusNoMatch = new BinStatus();
            binStatusNoMatch.binID = -1;
            binStatusNoMatch.binAddress = "";
            binStatusNoMatch.status = 3;

            return binStatusNoMatch;
        }
    }
}
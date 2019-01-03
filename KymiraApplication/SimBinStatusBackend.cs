using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using KymiraApplication.Models;

namespace KymiraApplication
{
    public class SimBinStatusBackend
    {
        private BinStatus[] binArray;

        /**
         * Constructor for siulating the backend. 
         * (Currently Creates a statis array of BinStatuses to check the address sent against)
         */
        public SimBinStatusBackend()
        {
            //creating the BinStatus objects
            BinStatus bin1 = new BinStatus();
            bin1.binID = 1;
            bin1.binAddress = "123 Test Street";
            bin1.status = 1;

            BinStatus bin2 = new BinStatus();
            bin2.binID = 2;
            bin2.binAddress = "123 Test Street";
            bin2.status = 3;

            binArray = new BinStatus[2];

            //assigning positions in the array
            binArray[0] = bin1;
            binArray[1] = bin2;
        }

        /**
         * This method simulates the backend checking matching bins for the address given.
         * It will return an empty ArrayList if there were no matching bins.
         */
        public ArrayList checkListOfBins(string binAddress)
        {
            ArrayList discoveredBins = new ArrayList();

            //Loops through each BinStatus in the array of BinStatuses
            for (int i = 0; i < binArray.Length; i++)
            {
                //Check if the addresses are the same
                if (binArray[i].binAddress.Equals(binAddress))
                {
                    //Adds the matched BinStatus object to the ArrayList to return to the front end
                    discoveredBins.Add(binArray[i]);
                }
            }

            //Return ArrayList that is either empty or contains BinStatuses
            return discoveredBins;
        }
    }
}
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
using KymiraApplication.Model;

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
         */
        public ArrayList checkListOfBins(BinStatus bin)
        {
            ArrayList discoveredBins = new ArrayList();

            for (int i = 0; i < binArray.Length; i++)
            {
                if(binArray[i].binAddress.Equals(bin.binAddress))
                {
                    //return the matched BinStatus object
                    discoveredBins.Add(binArray[i]);
                }
            }

            //check count of arraylist of matched bins -- if there are none, add one 
            //BinStatus with an id of -1
            //if(discoveredBins.Count == 0)
            //{
                //Setting up and returning a BinStatus with an id of -1 if there was no match
               // BinStatus binStatusNoMatch = new BinStatus();
               // binStatusNoMatch.binID = -1;
               // binStatusNoMatch.binAddress = "";
               // binStatusNoMatch.status = 3;

                //Returns a BinStatus with an id of -1 to indicate that there was no match for this address
               // discoveredBins.Add(binStatusNoMatch);
           // }

            return discoveredBins;
        }
    }
}
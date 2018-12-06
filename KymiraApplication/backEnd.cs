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
    public class backEnd
    {
        BinCollectionDate[] binArray;

        public backEnd()
        {
            BinCollectionDate bin1 = new BinCollectionDate();
            bin1.id = 1;
            bin1.Address = "123 Test Street";
            bin1.collectionDate1 = "1/8/2019";
            bin1.collectionDate2 = "1/11/2019";

            //bin1.collectionDate1 = "";
            //bin1.collectionDate2 = "";

            binArray = new BinCollectionDate[1];

            binArray[0] = bin1;
        }

        public String checkAddress(BinCollectionDate bin)
        {
            for (int i = 0; i < binArray.Length; i++)
            {
                if (binArray[i].Address.Equals(bin.Address))
                {
                    return "Address Found";
                }

            }



            return "Address Not found";
        }

        public String displayDate1(BinCollectionDate bin)
        {
            for (int i = 0; i < binArray.Length; i++)
            {
                if (binArray[i].Address.Equals(bin.Address))
                {
                    if (!binArray[0].collectionDate1.Equals(""))
                    {
                        return (binArray[0].collectionDate1 );
                    }
                    else
                    {
                        return "No dates are associated with this address yet";
                    }
                }

            }



            return "No dates are associated with this address yet";
        }

        public String displayDate2(BinCollectionDate bin)
        {
            for (int i = 0; i < binArray.Length; i++)
            {
                if (binArray[i].Address.Equals(bin.Address))
                {
                    if (!binArray[0].collectionDate1.Equals(""))
                    {
                        return (binArray[0].collectionDate2 );
                    }
                    else
                    {
                        return "No dates are associated with this address yet";
                    }
                }

            }



            return "No dates are associated with this address yet";
        }


    }
}
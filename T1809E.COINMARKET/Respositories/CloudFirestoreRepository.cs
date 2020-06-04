using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using Google.Cloud.Firestore;
using T1809E.COINMARKET.Models.Coins;

namespace T1809E.COINMARKET.Respositories
{
    public class CloudFirestoreRepository
    {
        private FirestoreDb firestoreDb;
        public CloudFirestoreRepository()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + @"coin-market-2020.json";
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);

            this.firestoreDb = FirestoreDb.Create("coin-market-2020");
        }

        public bool CreatOrUpdate(CommonCoin coin)
        {
            try
            {
                DocumentReference document = firestoreDb.Collection("Coins").Document(coin.Symbol);
                document.SetAsync(coin);
                Debug.WriteLine("Added to db!");
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                Debug.WriteLine("Failed to add");
                return false;
            }
        }
    }
}
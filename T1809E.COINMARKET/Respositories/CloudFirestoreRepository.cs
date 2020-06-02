using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Google.Cloud.Firestore;

namespace T1809E.COINMARKET.Respositories
{
    public class CloudFirestoreRepository
    {
      public void GetConnection()
      {
        string path = AppDomain.CurrentDomain.BaseDirectory + @"coin-market-2020.json";
        Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);

        FirestoreDb firestoreDb = FirestoreDb.Create("coin-market-2020");
      }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Google.Cloud.Firestore;

namespace T1809E.COINMARKET.Models.Coins
{
    [FirestoreData]
    public class CommonCoin
    {
        [FirestoreDocumentId]
        [FirestoreProperty]
        public string Symbol { get; set; }
        [FirestoreProperty]
        public string Timestamp { get; set; }
        [FirestoreProperty]
        public string CurrencySymbol { get; set; }
        [FirestoreProperty]
        public double Price { get; set; }
        [FirestoreProperty]
        public double OpenPrice { get; set; }
        [FirestoreProperty]
        public double HighPrice { get; set; }
    }
}
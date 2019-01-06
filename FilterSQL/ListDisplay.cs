using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace FilterSQL
{
    class ListDisplay
    {
        public struct ListItem
        {
            public string ItemID { get; set; }
            public string ItemCategory { get; set; }
            public string ItemDate { get; set; }
            public string ItemCashlessSaldo { get; set; }
            public string ItemMoneySaldo { get; set; }
            public string ItemPurchase { get; set; }
            public string ItemCashReload { get; set; }
            public string ItemAutoReload { get; set; }
        }

        public static ListItem FormListItem (SQLiteDataReader data)
        {
            return new ListItem
            {
                ItemID =            data["MIFARE"].ToString(),
                ItemCategory =      data["category"].ToString(),
                ItemDate =          data["date"].ToString(),
                ItemCashlessSaldo = data.GetFloat(data.GetOrdinal("cashlessMoney")).ToString("0.00"),
                ItemMoneySaldo =    data.GetFloat(data.GetOrdinal("realMoney")).ToString("0.00"),
                ItemPurchase =      data.GetFloat(data.GetOrdinal("payed")).ToString("0.00"),
                ItemCashReload =    data.GetFloat(data.GetOrdinal("enteredMoney")).ToString("0.00"),
                ItemAutoReload =    data.GetFloat(data.GetOrdinal("autoReload")).ToString("0.00")
            };
        }
    }
}

using System;
namespace CurrencyConverter.iOS
{
    public class CurrencyKey
    {
        public CurrencyKey(string name, float sell, float buy)
        {
            CurrencyName = name;
            SellingPrice = sell;
            PurchasePrice = buy;
        }

        public string CurrencyName { get; }
        public float SellingPrice { get; }
        public float PurchasePrice { get; }

    }
}

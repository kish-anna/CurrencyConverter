namespace Portable
{
    public class CurrencyKey
    {
        public CurrencyKey(string name, float sell, float buy)
        {
            CurrencyName = name;
            SellingPrice = sell;
            PurchasePrice = buy;
        }

        public string CurrencyName { get; private set; }
        public float SellingPrice { get; private set; }
        public float PurchasePrice { get; private set; }

    }
}

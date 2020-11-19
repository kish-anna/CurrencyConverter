namespace Portable
{
    public static class CurrencyKeyData
    {
        public static CurrencyKey[] Data => data;

        private static CurrencyKey[] data = {
            new CurrencyKey("RUB/USD", 78.94f, 78.35f),
            new CurrencyKey("RUB/EUR", 92.52f, 91.94f),
            new CurrencyKey("RUB/UAH", 78.94f, 78.35f),
            new CurrencyKey("RUB/BYN", 78.94f, 78.35f)
        };
    }
}
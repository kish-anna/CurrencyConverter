using System.IO;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace Portable
{
    public static class CurrencyKeyData
    {
        // public static CurrencyKey[] GetData()
        // {
        //     var a = GetCurrencies();
        //     
        //     a.Wait();
        //
        //     return a.Result;
        // }

        private static readonly HttpClient Client = new HttpClient();

        public static CurrencyKey[] GetData()
        {
            var bodyAwaitTask = Task.Run(async () => await GetBody());
            var body = bodyAwaitTask.GetAwaiter().GetResult();

            var res = ReadToObject(body);

            return new[]
            {
                new CurrencyKey("RUB/USD", res.Rates.Rub / res.Rates.Usd * 1.1f, res.Rates.Rub / res.Rates.Usd * 0.9f),
                new CurrencyKey("RUB/EUR", res.Rates.Rub / res.Rates.Eur * 1.1f, res.Rates.Rub / res.Rates.Eur * 0.9f),
                new CurrencyKey("RUB/BYN", res.Rates.Rub / res.Rates.Byn * 1.1f, res.Rates.Rub / res.Rates.Byn * 0.9f),
                new CurrencyKey("RUB/AED", res.Rates.Rub / res.Rates.Aed * 1.1f, res.Rates.Rub / res.Rates.Aed * 0.9f)
            };
        }

        private static async Task<string> GetBody()
        {
            var url = "https://openexchangerates.org/api/latest.json?app_id=07165f1a0fc649fba1ebecdde86a57a1";

            // HttpRequestMessage request = new HttpRequestMessage();
            // request.RequestUri = new Uri(url);
            // request.Method = HttpMethod.Get;
            //
            // HttpResponseMessage mes = await Client.SendAsync(request);

            HttpResponseMessage mes = await Client.GetAsync(url);

            // var content = mes.Content.ReadAsStringAsync();
            // string body = await content;

            return await mes.Content.ReadAsStringAsync();
        }

        private static AllCurrency ReadToObject(string json)
        {
            var deserializedUser = new AllCurrency();
            var ms = new MemoryStream(Encoding.UTF8.GetBytes(json));
            var ser = new DataContractJsonSerializer(deserializedUser.GetType());
            deserializedUser = ser.ReadObject(ms) as AllCurrency;
            ms.Close();

            return deserializedUser;
        }
    }
}
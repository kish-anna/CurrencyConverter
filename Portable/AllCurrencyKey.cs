using System.Runtime.Serialization;

namespace Portable
{
    [DataContract]
    internal class AllCurrency
    {
        [DataMember(Name = "disclaimer")] internal string Disclaimer;
        [DataMember(Name = "license")] internal string License;
        [DataMember(Name = "timestamp")] internal int Timestamp;
        [DataMember(Name = "base")] internal string BaseName;
        [DataMember(Name = "rates")] internal Rates Rates;
    }

    [DataContract]
    internal class Rates
    {
        [DataMember(Name = "EUR")] internal float Eur;
        [DataMember(Name = "RUB")] internal float Rub;
        [DataMember(Name = "USD")] internal float Usd;
        [DataMember(Name = "AED")] internal float Aed;
        [DataMember(Name = "BYN")] internal float Byn;
    }
}
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Freshdesk
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ContactTimeZone
    {
        Unknown,

        [EnumMember(Value = "American Samoa")]
        GMTm1100_AmericanSamoa,

        [EnumMember(Value = "International Date Line West")]
        GMTm1100_InternationalDateLineWest,

        [EnumMember(Value = "Midway Island")]
        GMTm1100_MidwayIsland,

        [EnumMember(Value = "Hawaii")]
        GMTm1000_Hawaii,

        [EnumMember(Value = "Alaska")]
        GMTm0900_Alaska,

        [EnumMember(Value = "Pacific Time (US & Canada)")]
        GMTm0800_PacificTimeUSCanada,

        [EnumMember(Value = "Tijuana")]
        GMTm0800_Tijuana,

        [EnumMember(Value = "Arizona")]
        GMTm0700_Arizona,

        [EnumMember(Value = "Chihuahua")]
        GMTm0700_Chihuahua,

        [EnumMember(Value = "Mazatlan")]
        GMTm0700_Mazatlan,

        [EnumMember(Value = "Mountain Time (US & Canada)")]
        GMTm0700_MountainTimeUSCanada,

        [EnumMember(Value = "Central America")]
        GMTm0600_CentralAmerica,

        [EnumMember(Value = "Central Time (US & Canada)")]
        GMTm0600_CentralTimeUSCanada,

        [EnumMember(Value = "Guadalajara")]
        GMTm0600_Guadalajara,

        [EnumMember(Value = "Mexico City")]
        GMTm0600_MexicoCity,

        [EnumMember(Value = "Monterrey")]
        GMTm0600_Monterrey,

        [EnumMember(Value = "Saskatchewan")]
        GMTm0600_Saskatchewan,

        [EnumMember(Value = "Bogota")]
        GMTm0500_Bogota,

        [EnumMember(Value = "Eastern Time (US & Canada)")]
        GMTm0500_EasternTimeUSCanada,

        [EnumMember(Value = "Indiana (East)")]
        GMTm0500_IndianaEast,

        [EnumMember(Value = "Lima")]
        GMTm0500_Lima,

        [EnumMember(Value = "Quito")]
        GMTm0500_Quito,

        [EnumMember(Value = "Atlantic Time (Canada)")]
        GMTm0400_AtlanticTimeCanada,

        [EnumMember(Value = "Caracas")]
        GMTm0400_Caracas,

        [EnumMember(Value = "Georgetown")]
        GMTm0400_Georgetown,

        [EnumMember(Value = "La Paz")]
        GMTm0400_LaPaz,

        [EnumMember(Value = "Santiago")]
        GMTm0400_Santiago,

        [EnumMember(Value = "Newfoundland")]
        GMTm0330_Newfoundland,

        [EnumMember(Value = "Brasilia")]
        GMTm0300_Brasilia,

        [EnumMember(Value = "Buenos Aires")]
        GMTm0300_BuenosAires,

        [EnumMember(Value = "Greenland")]
        GMTm0300_Greenland,

        [EnumMember(Value = "Mid-Atlantic")]
        GMTm0200_MidAtlantic,

        [EnumMember(Value = "Azores")]
        GMTm0100_Azores,

        [EnumMember(Value = "Cape Verde Is.")]
        GMTm0100_CapeVerdeIs,

        [EnumMember(Value = "Casablanca")]
        GMTp0000_Casablanca,

        [EnumMember(Value = "Dublin")]
        GMTp0000_Dublin,

        [EnumMember(Value = "Edinburgh")]
        GMTp0000_Edinburgh,

        [EnumMember(Value = "Lisbon")]
        GMTp0000_Lisbon,

        [EnumMember(Value = "London")]
        GMTp0000_London,

        [EnumMember(Value = "Monrovia")]
        GMTp0000_Monrovia,

        [EnumMember(Value = "UTC")]
        GMTp0000_UTC,

        [EnumMember(Value = "Amsterdam")]
        GMTp0100_Amsterdam,

        [EnumMember(Value = "Belgrade")]
        GMTp0100_Belgrade,

        [EnumMember(Value = "Berlin")]
        GMTp0100_Berlin,

        [EnumMember(Value = "Bern")]
        GMTp0100_Bern,

        [EnumMember(Value = "Bratislava")]
        GMTp0100_Bratislava,

        [EnumMember(Value = "Brussels")]
        GMTp0100_Brussels,

        [EnumMember(Value = "Budapest")]
        GMTp0100_Budapest,

        [EnumMember(Value = "Copenhagen")]
        GMTp0100_Copenhagen,

        [EnumMember(Value = "Ljubljana")]
        GMTp0100_Ljubljana,

        [EnumMember(Value = "Madrid")]
        GMTp0100_Madrid,

        [EnumMember(Value = "Paris")]
        GMTp0100_Paris,

        [EnumMember(Value = "Prague")]
        GMTp0100_Prague,

        [EnumMember(Value = "Rome")]
        GMTp0100_Rome,

        [EnumMember(Value = "Sarajevo")]
        GMTp0100_Sarajevo,

        [EnumMember(Value = "Skopje")]
        GMTp0100_Skopje,

        [EnumMember(Value = "Stockholm")]
        GMTp0100_Stockholm,

        [EnumMember(Value = "Vienna")]
        GMTp0100_Vienna,

        [EnumMember(Value = "Warsaw")]
        GMTp0100_Warsaw,

        [EnumMember(Value = "West Central Africa")]
        GMTp0100_WestCentralAfrica,

        [EnumMember(Value = "Zagreb")]
        GMTp0100_Zagreb,

        [EnumMember(Value = "Athens")]
        GMTp0200_Athens,

        [EnumMember(Value = "Bucharest")]
        GMTp0200_Bucharest,

        [EnumMember(Value = "Cairo")]
        GMTp0200_Cairo,

        [EnumMember(Value = "Harare")]
        GMTp0200_Harare,

        [EnumMember(Value = "Helsinki")]
        GMTp0200_Helsinki,

        [EnumMember(Value = "Istanbul")]
        GMTp0200_Istanbul,

        [EnumMember(Value = "Jerusalem")]
        GMTp0200_Jerusalem,

        [EnumMember(Value = "Kyiv")]
        GMTp0200_Kyiv,

        [EnumMember(Value = "Pretoria")]
        GMTp0200_Pretoria,

        [EnumMember(Value = "Riga")]
        GMTp0200_Riga,

        [EnumMember(Value = "Sofia")]
        GMTp0200_Sofia,

        [EnumMember(Value = "Tallinn")]
        GMTp0200_Tallinn,

        [EnumMember(Value = "Vilnius")]
        GMTp0200_Vilnius,

        [EnumMember(Value = "Baghdad")]
        GMTp0300_Baghdad,

        [EnumMember(Value = "Kuwait")]
        GMTp0300_Kuwait,

        [EnumMember(Value = "Minsk")]
        GMTp0300_Minsk,

        [EnumMember(Value = "Moscow")]
        GMTp0300_Moscow,

        [EnumMember(Value = "Nairobi")]
        GMTp0300_Nairobi,

        [EnumMember(Value = "Riyadh")]
        GMTp0300_Riyadh,

        [EnumMember(Value = "St. Petersburg")]
        GMTp0300_StPetersburg,

        [EnumMember(Value = "Volgograd")]
        GMTp0300_Volgograd,

        [EnumMember(Value = "Tehran")]
        GMTp0330_Tehran,

        [EnumMember(Value = "Abu Dhabi")]
        GMTp0400_AbuDhabi,

        [EnumMember(Value = "Baku")]
        GMTp0400_Baku,

        [EnumMember(Value = "Muscat")]
        GMTp0400_Muscat,

        [EnumMember(Value = "Tbilisi")]
        GMTp0400_Tbilisi,

        [EnumMember(Value = "Yerevan")]
        GMTp0400_Yerevan,

        [EnumMember(Value = "Kabul")]
        GMTp0430_Kabul,

        [EnumMember(Value = "Ekaterinburg")]
        GMTp0500_Ekaterinburg,

        [EnumMember(Value = "Islamabad")]
        GMTp0500_Islamabad,

        [EnumMember(Value = "Karachi")]
        GMTp0500_Karachi,

        [EnumMember(Value = "Tashkent")]
        GMTp0500_Tashkent,

        [EnumMember(Value = "Chennai")]
        GMTp0530_Chennai,

        [EnumMember(Value = "Kolkata")]
        GMTp0530_Kolkata,

        [EnumMember(Value = "Mumbai")]
        GMTp0530_Mumbai,

        [EnumMember(Value = "New Delhi")]
        GMTp0530_NewDelhi,

        [EnumMember(Value = "Sri Jayawardenepura")]
        GMTp0530_SriJayawardenepura,

        [EnumMember(Value = "Kathmandu")]
        GMTp0545_Kathmandu,

        [EnumMember(Value = "Almaty")]
        GMTp0600_Almaty,

        [EnumMember(Value = "Astana")]
        GMTp0600_Astana,

        [EnumMember(Value = "Dhaka")]
        GMTp0600_Dhaka,

        [EnumMember(Value = "Urumqi")]
        GMTp0600_Urumqi,

        [EnumMember(Value = "Rangoon")]
        GMTp0630_Rangoon,

        [EnumMember(Value = "Bangkok")]
        GMTp0700_Bangkok,

        [EnumMember(Value = "Hanoi")]
        GMTp0700_Hanoi,

        [EnumMember(Value = "Jakarta")]
        GMTp0700_Jakarta,

        [EnumMember(Value = "Krasnoyarsk")]
        GMTp0700_Krasnoyarsk,

        [EnumMember(Value = "Novosibirsk")]
        GMTp0700_Novosibirsk,

        [EnumMember(Value = "Beijing")]
        GMTp0800_Beijing,

        [EnumMember(Value = "Chongqing")]
        GMTp0800_Chongqing,

        [EnumMember(Value = "Hong Kong")]
        GMTp0800_HongKong,

        [EnumMember(Value = "Irkutsk")]
        GMTp0800_Irkutsk,

        [EnumMember(Value = "Kuala Lumpur")]
        GMTp0800_KualaLumpur,

        [EnumMember(Value = "Perth")]
        GMTp0800_Perth,

        [EnumMember(Value = "Singapore")]
        GMTp0800_Singapore,

        [EnumMember(Value = "Taipei")]
        GMTp0800_Taipei,

        [EnumMember(Value = "Ulaan Bataar")]
        GMTp0800_UlaanBataar,

        [EnumMember(Value = "Osaka")]
        GMTp0900_Osaka,

        [EnumMember(Value = "Sapporo")]
        GMTp0900_Sapporo,

        [EnumMember(Value = "Seoul")]
        GMTp0900_Seoul,

        [EnumMember(Value = "Tokyo")]
        GMTp0900_Tokyo,

        [EnumMember(Value = "Yakutsk")]
        GMTp0900_Yakutsk,

        [EnumMember(Value = "Adelaide")]
        GMTp0930_Adelaide,

        [EnumMember(Value = "Darwin")]
        GMTp0930_Darwin,

        [EnumMember(Value = "Brisbane")]
        GMTp1000_Brisbane,

        [EnumMember(Value = "Canberra")]
        GMTp1000_Canberra,

        [EnumMember(Value = "Guam")]
        GMTp1000_Guam,

        [EnumMember(Value = "Hobart")]
        GMTp1000_Hobart,

        [EnumMember(Value = "Melbourne")]
        GMTp1000_Melbourne,

        [EnumMember(Value = "Port Moresby")]
        GMTp1000_PortMoresby,

        [EnumMember(Value = "Sydney")]
        GMTp1000_Sydney,

        [EnumMember(Value = "Vladivostok")]
        GMTp1000_Vladivostok,

        [EnumMember(Value = "Magadan")]
        GMTp1100_Magadan,

        [EnumMember(Value = "New Caledonia")]
        GMTp1100_NewCaledonia,

        [EnumMember(Value = "Solomon Is.")]
        GMTp1100_SolomonIs,

        [EnumMember(Value = "Auckland")]
        GMTp1200_Auckland,

        [EnumMember(Value = "Fiji")]
        GMTp1200_Fiji,

        [EnumMember(Value = "Kamchatka")]
        GMTp1200_Kamchatka,

        [EnumMember(Value = "Marshall Is.")]
        GMTp1200_MarshallIs,

        [EnumMember(Value = "Wellington")]
        GMTp1200_Wellington,

        [EnumMember(Value = "Nuku'alofa")]
        GMTp1300_Nukualofa,

        [EnumMember(Value = "Samoa")]
        GMTp1300_Samoa,

        [EnumMember(Value = "Tokelau Is.")]
        GMTp1300_TokelauIs
    }
}
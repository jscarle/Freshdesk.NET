using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Freshdesk.Contacts;

[JsonConverter(typeof(StringEnumConverter))]
public enum ContactTimeZone
{
    Unknown,

    [EnumMember(Value = "American Samoa")]
    GmTm1100AmericanSamoa,

    [EnumMember(Value = "International Date Line West")]
    GmTm1100InternationalDateLineWest,

    [EnumMember(Value = "Midway Island")]
    GmTm1100MidwayIsland,

    [EnumMember(Value = "Hawaii")]
    GmTm1000Hawaii,

    [EnumMember(Value = "Alaska")]
    GmTm0900Alaska,

    [EnumMember(Value = "Pacific Time (US & Canada)")]
    GmTm0800PacificTimeUsCanada,

    [EnumMember(Value = "Tijuana")]
    GmTm0800Tijuana,

    [EnumMember(Value = "Arizona")]
    GmTm0700Arizona,

    [EnumMember(Value = "Chihuahua")]
    GmTm0700Chihuahua,

    [EnumMember(Value = "Mazatlan")]
    GmTm0700Mazatlan,

    [EnumMember(Value = "Mountain Time (US & Canada)")]
    GmTm0700MountainTimeUsCanada,

    [EnumMember(Value = "Central America")]
    GmTm0600CentralAmerica,

    [EnumMember(Value = "Central Time (US & Canada)")]
    GmTm0600CentralTimeUsCanada,

    [EnumMember(Value = "Guadalajara")]
    GmTm0600Guadalajara,

    [EnumMember(Value = "Mexico City")]
    GmTm0600MexicoCity,

    [EnumMember(Value = "Monterrey")]
    GmTm0600Monterrey,

    [EnumMember(Value = "Saskatchewan")]
    GmTm0600Saskatchewan,

    [EnumMember(Value = "Bogota")]
    GmTm0500Bogota,

    [EnumMember(Value = "Eastern Time (US & Canada)")]
    GmTm0500EasternTimeUsCanada,

    [EnumMember(Value = "Indiana (East)")]
    GmTm0500IndianaEast,

    [EnumMember(Value = "Lima")]
    GmTm0500Lima,

    [EnumMember(Value = "Quito")]
    GmTm0500Quito,

    [EnumMember(Value = "Atlantic Time (Canada)")]
    GmTm0400AtlanticTimeCanada,

    [EnumMember(Value = "Caracas")]
    GmTm0400Caracas,

    [EnumMember(Value = "Georgetown")]
    GmTm0400Georgetown,

    [EnumMember(Value = "La Paz")]
    GmTm0400LaPaz,

    [EnumMember(Value = "Santiago")]
    GmTm0400Santiago,

    [EnumMember(Value = "Newfoundland")]
    GmTm0330Newfoundland,

    [EnumMember(Value = "Brasilia")]
    GmTm0300Brasilia,

    [EnumMember(Value = "Buenos Aires")]
    GmTm0300BuenosAires,

    [EnumMember(Value = "Greenland")]
    GmTm0300Greenland,

    [EnumMember(Value = "Mid-Atlantic")]
    GmTm0200MidAtlantic,

    [EnumMember(Value = "Azores")]
    GmTm0100Azores,

    [EnumMember(Value = "Cape Verde Is.")]
    GmTm0100CapeVerdeIs,

    [EnumMember(Value = "Casablanca")]
    GmTp0000Casablanca,

    [EnumMember(Value = "Dublin")]
    GmTp0000Dublin,

    [EnumMember(Value = "Edinburgh")]
    GmTp0000Edinburgh,

    [EnumMember(Value = "Lisbon")]
    GmTp0000Lisbon,

    [EnumMember(Value = "London")]
    GmTp0000London,

    [EnumMember(Value = "Monrovia")]
    GmTp0000Monrovia,

    [EnumMember(Value = "UTC")]
    GmTp0000Utc,

    [EnumMember(Value = "Amsterdam")]
    GmTp0100Amsterdam,

    [EnumMember(Value = "Belgrade")]
    GmTp0100Belgrade,

    [EnumMember(Value = "Berlin")]
    GmTp0100Berlin,

    [EnumMember(Value = "Bern")]
    GmTp0100Bern,

    [EnumMember(Value = "Bratislava")]
    GmTp0100Bratislava,

    [EnumMember(Value = "Brussels")]
    GmTp0100Brussels,

    [EnumMember(Value = "Budapest")]
    GmTp0100Budapest,

    [EnumMember(Value = "Copenhagen")]
    GmTp0100Copenhagen,

    [EnumMember(Value = "Ljubljana")]
    GmTp0100Ljubljana,

    [EnumMember(Value = "Madrid")]
    GmTp0100Madrid,

    [EnumMember(Value = "Paris")]
    GmTp0100Paris,

    [EnumMember(Value = "Prague")]
    GmTp0100Prague,

    [EnumMember(Value = "Rome")]
    GmTp0100Rome,

    [EnumMember(Value = "Sarajevo")]
    GmTp0100Sarajevo,

    [EnumMember(Value = "Skopje")]
    GmTp0100Skopje,

    [EnumMember(Value = "Stockholm")]
    GmTp0100Stockholm,

    [EnumMember(Value = "Vienna")]
    GmTp0100Vienna,

    [EnumMember(Value = "Warsaw")]
    GmTp0100Warsaw,

    [EnumMember(Value = "West Central Africa")]
    GmTp0100WestCentralAfrica,

    [EnumMember(Value = "Zagreb")]
    GmTp0100Zagreb,

    [EnumMember(Value = "Athens")]
    GmTp0200Athens,

    [EnumMember(Value = "Bucharest")]
    GmTp0200Bucharest,

    [EnumMember(Value = "Cairo")]
    GmTp0200Cairo,

    [EnumMember(Value = "Harare")]
    GmTp0200Harare,

    [EnumMember(Value = "Helsinki")]
    GmTp0200Helsinki,

    [EnumMember(Value = "Istanbul")]
    GmTp0200Istanbul,

    [EnumMember(Value = "Jerusalem")]
    GmTp0200Jerusalem,

    [EnumMember(Value = "Kyiv")]
    GmTp0200Kyiv,

    [EnumMember(Value = "Pretoria")]
    GmTp0200Pretoria,

    [EnumMember(Value = "Riga")]
    GmTp0200Riga,

    [EnumMember(Value = "Sofia")]
    GmTp0200Sofia,

    [EnumMember(Value = "Tallinn")]
    GmTp0200Tallinn,

    [EnumMember(Value = "Vilnius")]
    GmTp0200Vilnius,

    [EnumMember(Value = "Baghdad")]
    GmTp0300Baghdad,

    [EnumMember(Value = "Kuwait")]
    GmTp0300Kuwait,

    [EnumMember(Value = "Minsk")]
    GmTp0300Minsk,

    [EnumMember(Value = "Moscow")]
    GmTp0300Moscow,

    [EnumMember(Value = "Nairobi")]
    GmTp0300Nairobi,

    [EnumMember(Value = "Riyadh")]
    GmTp0300Riyadh,

    [EnumMember(Value = "St. Petersburg")]
    GmTp0300StPetersburg,

    [EnumMember(Value = "Volgograd")]
    GmTp0300Volgograd,

    [EnumMember(Value = "Tehran")]
    GmTp0330Tehran,

    [EnumMember(Value = "Abu Dhabi")]
    GmTp0400AbuDhabi,

    [EnumMember(Value = "Baku")]
    GmTp0400Baku,

    [EnumMember(Value = "Muscat")]
    GmTp0400Muscat,

    [EnumMember(Value = "Tbilisi")]
    GmTp0400Tbilisi,

    [EnumMember(Value = "Yerevan")]
    GmTp0400Yerevan,

    [EnumMember(Value = "Kabul")]
    GmTp0430Kabul,

    [EnumMember(Value = "Ekaterinburg")]
    GmTp0500Ekaterinburg,

    [EnumMember(Value = "Islamabad")]
    GmTp0500Islamabad,

    [EnumMember(Value = "Karachi")]
    GmTp0500Karachi,

    [EnumMember(Value = "Tashkent")]
    GmTp0500Tashkent,

    [EnumMember(Value = "Chennai")]
    GmTp0530Chennai,

    [EnumMember(Value = "Kolkata")]
    GmTp0530Kolkata,

    [EnumMember(Value = "Mumbai")]
    GmTp0530Mumbai,

    [EnumMember(Value = "New Delhi")]
    GmTp0530NewDelhi,

    [EnumMember(Value = "Sri Jayawardenepura")]
    GmTp0530SriJayawardenepura,

    [EnumMember(Value = "Kathmandu")]
    GmTp0545Kathmandu,

    [EnumMember(Value = "Almaty")]
    GmTp0600Almaty,

    [EnumMember(Value = "Astana")]
    GmTp0600Astana,

    [EnumMember(Value = "Dhaka")]
    GmTp0600Dhaka,

    [EnumMember(Value = "Urumqi")]
    GmTp0600Urumqi,

    [EnumMember(Value = "Rangoon")]
    GmTp0630Rangoon,

    [EnumMember(Value = "Bangkok")]
    GmTp0700Bangkok,

    [EnumMember(Value = "Hanoi")]
    GmTp0700Hanoi,

    [EnumMember(Value = "Jakarta")]
    GmTp0700Jakarta,

    [EnumMember(Value = "Krasnoyarsk")]
    GmTp0700Krasnoyarsk,

    [EnumMember(Value = "Novosibirsk")]
    GmTp0700Novosibirsk,

    [EnumMember(Value = "Beijing")]
    GmTp0800Beijing,

    [EnumMember(Value = "Chongqing")]
    GmTp0800Chongqing,

    [EnumMember(Value = "Hong Kong")]
    GmTp0800HongKong,

    [EnumMember(Value = "Irkutsk")]
    GmTp0800Irkutsk,

    [EnumMember(Value = "Kuala Lumpur")]
    GmTp0800KualaLumpur,

    [EnumMember(Value = "Perth")]
    GmTp0800Perth,

    [EnumMember(Value = "Singapore")]
    GmTp0800Singapore,

    [EnumMember(Value = "Taipei")]
    GmTp0800Taipei,

    [EnumMember(Value = "Ulaan Bataar")]
    GmTp0800UlaanBataar,

    [EnumMember(Value = "Osaka")]
    GmTp0900Osaka,

    [EnumMember(Value = "Sapporo")]
    GmTp0900Sapporo,

    [EnumMember(Value = "Seoul")]
    GmTp0900Seoul,

    [EnumMember(Value = "Tokyo")]
    GmTp0900Tokyo,

    [EnumMember(Value = "Yakutsk")]
    GmTp0900Yakutsk,

    [EnumMember(Value = "Adelaide")]
    GmTp0930Adelaide,

    [EnumMember(Value = "Darwin")]
    GmTp0930Darwin,

    [EnumMember(Value = "Brisbane")]
    GmTp1000Brisbane,

    [EnumMember(Value = "Canberra")]
    GmTp1000Canberra,

    [EnumMember(Value = "Guam")]
    GmTp1000Guam,

    [EnumMember(Value = "Hobart")]
    GmTp1000Hobart,

    [EnumMember(Value = "Melbourne")]
    GmTp1000Melbourne,

    [EnumMember(Value = "Port Moresby")]
    GmTp1000PortMoresby,

    [EnumMember(Value = "Sydney")]
    GmTp1000Sydney,

    [EnumMember(Value = "Vladivostok")]
    GmTp1000Vladivostok,

    [EnumMember(Value = "Magadan")]
    GmTp1100Magadan,

    [EnumMember(Value = "New Caledonia")]
    GmTp1100NewCaledonia,

    [EnumMember(Value = "Solomon Is.")]
    GmTp1100SolomonIs,

    [EnumMember(Value = "Auckland")]
    GmTp1200Auckland,

    [EnumMember(Value = "Fiji")]
    GmTp1200Fiji,

    [EnumMember(Value = "Kamchatka")]
    GmTp1200Kamchatka,

    [EnumMember(Value = "Marshall Is.")]
    GmTp1200MarshallIs,

    [EnumMember(Value = "Wellington")]
    GmTp1200Wellington,

    [EnumMember(Value = "Nuku'alofa")]
    GmTp1300Nukualofa,

    [EnumMember(Value = "Samoa")]
    GmTp1300Samoa,

    [EnumMember(Value = "Tokelau Is.")]
    GmTp1300TokelauIs
}
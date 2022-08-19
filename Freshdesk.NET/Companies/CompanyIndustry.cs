using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Freshdesk.Companies;

[JsonConverter(typeof(StringEnumConverter))]
public enum CompanyIndustry
{
    [EnumMember(Value = "")]
    Unknown,

    [EnumMember(Value = "Aerospace and Defense")]
    AerospaceAndDefense,

    [EnumMember(Value = "Air Freight and Logistics")]
    AirFreightAndLogistics,

    [EnumMember(Value = "Airlines")]
    Airlines,

    [EnumMember(Value = "Apparel and Luxury Goods")]
    ApparelAndLuxuryGoods,

    [EnumMember(Value = "Automotive")]
    Automotive,

    [EnumMember(Value = "Banks")]
    Banks,

    [EnumMember(Value = "Beverages")]
    Beverages,

    [EnumMember(Value = "Biotechnology")]
    Biotechnology,

    [EnumMember(Value = "Building Materials")]
    BuildingMaterials,

    [EnumMember(Value = "Capital Markets")]
    CapitalMarkets,

    [EnumMember(Value = "Chemicals")]
    Chemicals,

    [EnumMember(Value = "Commercial Services and Supplies")]
    CommercialServicesAndSupplies,

    [EnumMember(Value = "CommunicationsEquipment")]
    CommunicationsEquipment,

    [EnumMember(Value = "Construction and Engineering")]
    ConstructionAndEngineering,

    [EnumMember(Value = "Consumer Durables and Apparel")]
    ConsumerDurablesAndApparel,

    [EnumMember(Value = "Consumer Goods")]
    ConsumerGoods,

    [EnumMember(Value = "Containers and Packaging")]
    ContainersAndPackaging,

    [EnumMember(Value = "Distributors")]
    Distributors,

    [EnumMember(Value = "Diversified Consumer Services")]
    DiversifiedConsumerServices,

    [EnumMember(Value = "Diversified Financial Services")]
    DiversifiedFinancialServices,

    [EnumMember(Value = "Diversified Telecommunication Services")]
    DiversifiedTelecommunicationServices,

    [EnumMember(Value = "Education Services")]
    EducationServices,

    [EnumMember(Value = "Electric Utilities")]
    ElectricalEquipment,

    [EnumMember(Value = "Electrical Equipment")]
    ElectricUtilities,

    [EnumMember(Value = "Electronic Equipment")]
    ElectronicEquipment,

    [EnumMember(Value = "Family Services")]
    FamilyServices,

    [EnumMember(Value = "Food and Staples Retailing")]
    FoodAndStaplesRetailing,

    [EnumMember(Value = "Food Products")]
    FoodProducts,

    [EnumMember(Value = "Gas Utilities")]
    GasUtilities,

    [EnumMember(Value = "Health Care Equipment and Supplies")]
    HealthCareEquipmentAndSupplies,

    [EnumMember(Value = "Health Care Providers and Services")]
    HealthCareProvidersAndServices,

    [EnumMember(Value = "Hotels")]
    Hotels,

    [EnumMember(Value = "Household Durables")]
    HouseholdDurables,

    [EnumMember(Value = "Industrial Conglomerates")]
    IndustrialConglomerates,

    [EnumMember(Value = "Instruments and Components")]
    InstrumentsAndComponents,

    [EnumMember(Value = "Insurance")]
    Insurance,

    [EnumMember(Value = "Internet Software and Services")]
    InternetSoftwareAndServices,

    [EnumMember(Value = "IT Services")]
    ItServices,

    [EnumMember(Value = "Leisure Products")]
    LeisureProducts,

    [EnumMember(Value = "Machinery")]
    Machinery,

    [EnumMember(Value = "Marine")]
    Marine,

    [EnumMember(Value = "Media")]
    Media,

    [EnumMember(Value = "Metals and Mining")]
    MetalsAndMining,

    [EnumMember(Value = "Other")]
    Other,

    [EnumMember(Value = "Paper and Forest Products")]
    PaperAndForestProducts,

    [EnumMember(Value = "Personal Products")]
    PersonalProducts,

    [EnumMember(Value = "Pharmaceuticals")]
    Pharmaceuticals,

    [EnumMember(Value = "Professional Services")]
    ProfessionalServices,

    [EnumMember(Value = "Real Estate")]
    RealEstate,

    [EnumMember(Value = "Renewable Electricity")]
    RenewableElectricity,

    [EnumMember(Value = "Restaurants and Leisure")]
    RestaurantsAndLeisure,

    [EnumMember(Value = "Road and Rail")]
    RoadAndRail,

    [EnumMember(Value = "Software")]
    Software,

    [EnumMember(Value = "Specialized Consumer Services")]
    SpecializedConsumerServices,

    [EnumMember(Value = "Specialty Retail")]
    SpecialtyRetail,

    [EnumMember(Value = "Storage and Peripherals")]
    StorageAndPeripherals,

    [EnumMember(Value = "Technology Hardware")]
    TechnologyHardware,

    [EnumMember(Value = "Textiles")]
    Textiles,

    [EnumMember(Value = "Tobacco")]
    Tobacco,

    [EnumMember(Value = "Trading Companies and Distributors")]
    TradingCompaniesAndDistributors,

    [EnumMember(Value = "Transportation")]
    Transportation,

    [EnumMember(Value = "Utilities")]
    Utilities,

    [EnumMember(Value = "Wireless Telecommunication Services")]
    WirelessTelecommunicationServices
}
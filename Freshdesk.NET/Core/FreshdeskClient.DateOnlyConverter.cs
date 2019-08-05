using Newtonsoft.Json.Converters;

namespace Freshdesk
{
    public partial class FreshdeskClient
    {
        private class DateOnlyConverter : IsoDateTimeConverter
        {
            public DateOnlyConverter()
            {
                DateTimeFormat = "yyyy-MM-dd";
            }
        }
    }
}
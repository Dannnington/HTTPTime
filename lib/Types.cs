using System.Collections.Generic;

namespace Types {
    public sealed class DateTimeAPIObject
    {
        public string abbreviation { get; set; }
        public string client_ip { get; set; }
        public string datetime { get; set; }
        public int day_of_week { get; set; }
        public int day_of_year { get; set; }
        public bool dst { get; set; }
        public string dst_from { get; set; }
        public int dst_offset { get; set; }
        public string dst_until { get; set; }
        public int raw_offset { get; set; }
        public string timezone { get; set; }
        public int unixtime { get; set; }

        public string utc_datetime { get; set; }
        public string utc_offset { get; set; }
        public int week_number { get; set; }
    } 

    public sealed class IPInfoObject
    {
        public string ip { get; set; }
        public string hostname { get; set; }
        public string city {  get; set; }
        public string region { get; set; }
        public string country { get; set; }
        public string loc { get; set; }
        public string org { get; set; }
        public string postal { get; set; }
        public string timezone { get; set; }
        public string readme { get; set; }
    }

    public sealed class WeatherObject
    {
        public string product { get; set; }
        public string init { get; set; }
        public List<WeatherObject.WeatherDataSeriesObject> dataseries { get; set; }
        public sealed class WeatherDataSeriesObject
        {
            public int timepoint { get; set; }
            public int cloudcover { get; set; }
            public int seeing { get; set; }
            public int transparency { get; set; }
            public int lifted_index { get; set; }
            public int rh2m { get; set; }
            public WindObject wind10m { get; set; }


            public sealed class WindObject
            {  
                public string direction { get; set; }
                public int speed { get; set; }
            }
        }
    }
}
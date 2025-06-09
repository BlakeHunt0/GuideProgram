using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuideProgram
{
    public class City
    {
        public int city_id { get; set; }
        public string city_name { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
        public string state { get; set; }
        public bool is_capital { get; set; }
    }
    public class Road
    {
        public int road_id { get; set; }
        public string start_city_id { get; set; }
        public string end_city_id { get; set; }
        public double distance { get; set; }
    }
}

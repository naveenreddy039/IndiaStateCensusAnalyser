using System;
using System.Collections.Generic;
using System.Text;

namespace IndianStateGenerusAnalyzer.POCO
{
    public class CensusdataDAO
    {
        public string state;
        public long population;
        public long area;
        public long density;
        public CensusdataDAO(string state,string population,string area,string density)
        {
            this.state = state;
            this.population = Convert.ToUInt32(population);
            this.area = Convert.ToInt32(area);
            this.density = Convert.ToInt32(density);
        }
    }
}

using IndianStateGenerusAnalyzer.POCO;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndianStateGenerusAnalyzer
{
    public class CensusAnalyser
    {
        public enum Country
        {
            INDIA,USA,BRAZIL
        }
        Dictionary<string, censusDTO> dataMap;

        public Dictionary<string, censusDTO> LoadCensusData(Country country,string csvFilePath, string dataHeader)
        {
            dataMap = new csvAdapterFactory().LoadCsvData(country, csvFilePath, dataHeader);
            return dataMap;
        }

        public class CensusAnalser
        {
            public CensusAnalser()
            {
            }
        }

        //public class CensusAnalyser
        //{
         
        //}
    }
}

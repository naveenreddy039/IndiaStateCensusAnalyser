using IndianStateGenerusAnalyzer.POCO;
using System;
using System.Collections.Generic;
using System.Text;
using static IndianStateGenerusAnalyzer.CensusAnalyser;

namespace IndianStateGenerusAnalyzer
{
    public class csvAdapterFactory
    {
        public Dictionary<string, censusDTO> LoadCsvData(CensusAnalyser.Country country, string csvFilePath, string dataHeader)
        {
            switch(country)
            {
                case (CensusAnalyser.Country.INDIA):
                    return new IndianCensusAdapter().LoadCensusData(csvFilePath, dataHeader);
                //case (CensusAnalyser.Country.USA):
                  //  return new USACensusAdapter().LoadCensusData(csvFilePath, dataHeader);
                default:
                    throw new CensusAnalyserException("No such Country", CensusAnalyserException.ExceptionType.NO_SUCH_COUNTRY);
            }
        }

    }
}

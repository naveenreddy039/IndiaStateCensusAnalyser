using IndianStateGenerusAnalyzer.DTO;
using IndianStateGenerusAnalyzer.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IndianStateGenerusAnalyzer
{
    public class IndianCensusAdapter : CensusAdopter
    {
        string[] censusData;
        Dictionary<string, censusDTO> dataMap;

        public Dictionary<string, censusDTO> LoadCensusData(string csvFilePath, string dataHeader)
        {
            dataMap =new Dictionary<string, censusDTO>();
            censusData = GetCensusData(csvFilePath, dataHeader);
            foreach(string data in censusData.Skip(1))
            {
                if(!data.Contains(","))
                {
                    throw new CensusAnalyserException("Incorrect Delimeter", CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER);
                }
                string[] column = data.Split(",");
                if (csvFilePath.Contains("IndianStateCode.csv"))
                    dataMap.Add(column[1], new censusDTO(new StateCodeDAO(column[0], column[1], column[2], column[3])));
                if(csvFilePath.Contains("IndianStateCensusData.csv"))
                    dataMap.Add(column[0], new censusDTO(new StateCodeDAO(column[0], column[1], column[2], column[3])));

            }
            return dataMap.ToDictionary(p => p.Key, p => p.Value);

        }
    }
}

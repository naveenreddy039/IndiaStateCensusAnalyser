using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace IndianStateGenerusAnalyzer.DTO
{
    public abstract class CensusAdopter
    {
        protected string[] GetCensusData(string csvFilePath,string dataHeader)
        {
            string[] censusData;
            if(!File.Exists(csvFilePath))
            {
                throw new CensusAnalyserException("file not found", CensusAnalyserException.ExceptionType.FILE_NOT_FOUND);
            }
            if(Path.GetExtension(csvFilePath)!=".csv")
            {
                throw new CensusAnalyserException("Invalid file Type", CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE);

            }
            censusData = File.ReadAllLines(csvFilePath);
            if(censusData[0]!= dataHeader)
            {
                throw new CensusAnalyserException ("Incorrect Header in data", CensusAnalyserException.ExceptionType.INCORRECT_HEADER);

            }
            return censusData;
        }

    }
}

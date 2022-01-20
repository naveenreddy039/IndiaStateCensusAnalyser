using IndianStateGenerusAnalyzer;
using IndianStateGenerusAnalyzer.POCO;
using NUnit.Framework;
using System.Collections.Generic;
using static IndianStateGenerusAnalyzer.CensusAnalyser;

namespace CensusAnalyserTests
{
    public class Tests
    {
        static string indianStateCensusHeader = "state,population,AreaInSqKm,DensityPerSqKm";
        static string indianStateCodeHeaders = "SrNo,StateName,TIN,StateCode";
        static string indianStateCensusFilePath = "E:/source/repos/IndianStateGenerusAnalyzer/CensusAnalyserTests/CSVFiles/IndianStateCensusData.csv";
        static string wrongHeaderIndiaCensusFilePath = "E:/source/repos/IndianStateGenerusAnalyzer/CensusAnalyserTests/CSVFiles/wrongIndiaCensusData.csv";
        static string delimeterIndiaCensusFilePath = "E:/source/repos/IndianStateGenerusAnalyzer/CensusAnalyserTests/CSVFiles/delimiterIndiaStateCensusData.csv";
        static string wrongIndiaStateCensusFilePath = "E:/source/repos/IndianStateGenerusAnalyzer/CensusAnalyserTests/CSVFiles/indiaData.csv";
        static string wrongIndiaStateCensusFileType = "E:/source/repos/IndianStateGenerusAnalyzer/CensusAnalyserTests/CSVFiles/IndiaStateCensusData.txt";
        static string indiaStataCodeFilePath = "E:/source/repos/IndianStateGenerusAnalyzer/CensusAnalyserTests/CSVFiles/indiaStateCode.csv";
        static string wrongIndianStateCodeFileType = "E:/source/repos/IndianStateGenerusAnalyzer/CensusAnalyserTests/CSVFiles/IndiaStateCode.txt";
        static string delimiterIndianStateCodeFilePath = "E:/source/repos/IndianStateGenerusAnalyzer/CensusAnalyserTests/CSVFiles/delimiterIndiaStateCode.csv";
        static string wrongHeaderStateCodeFilePath = "E:/source/repos/IndianStateGenerusAnalyzer/CensusAnalyserTests/CSVFiles/wrongIndiaStateCode.csv";

        IndianStateGenerusAnalyzer.CensusAnalyser censusAnalyser;
        Dictionary<string, censusDTO> totalRecord;
        Dictionary<string, censusDTO> stateRecord;
        [SetUp]
        public void Setup()
        {
            censusAnalyser = new IndianStateGenerusAnalyzer.CensusAnalyser();
            totalRecord = new Dictionary<string, censusDTO>();
            stateRecord = new Dictionary<string, censusDTO>();
        }

        [Test]
        public void GivenIndianCensusDataFile_WhenReaded_ShouldReturnCensusDataCount()
        {
            totalRecord = censusAnalyser.LoadCensusData(Country.INDIA, indianStateCensusFilePath, indianStateCensusHeader);
            stateRecord = censusAnalyser.LoadCensusData(Country.INDIA, indiaStataCodeFilePath, indianStateCodeHeaders);
            Assert.AreEqual(29, totalRecord.Count);
            Assert.AreEqual(37, stateRecord.Count);
            Assert.Pass();
        }
        [Test]

        public void GivenWrongIndianCensusDataFile_WhenReaded_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA,wrongIndiaStateCensusFilePath,indianStateCensusHeader));
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, wrongIndiaStateCensusFilePath, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, censusException.eType);
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, stateException.eType);
        }
        [Test]

        public void GivenWrongIndianCensusDataFileType_WhenReaded_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, wrongIndiaStateCensusFilePath, indianStateCensusHeader));
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, wrongHeaderStateCodeFilePath, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, censusException.eType);
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, stateException.eType);
        }
        [Test]

        public void GivenWrongIndianCensusDataFileType_WhenLimiterNotProper_ShouldReturnException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, delimeterIndiaCensusFilePath, indianStateCensusHeader));
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, delimiterIndianStateCodeFilePath, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, censusException.eType);
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, stateException.eType);
        }
        [Test]

        public void GivenWrongIndianCensusDataFileType_WhenHeaderNotProper_ShouldReturnException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, wrongHeaderIndiaCensusFilePath, indianStateCensusHeader));
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, wrongHeaderStateCodeFilePath, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, censusException.eType);
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, stateException.eType);
        }
    }
}
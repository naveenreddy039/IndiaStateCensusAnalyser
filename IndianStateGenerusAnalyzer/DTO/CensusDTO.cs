using IndianStateGenerusAnalyzer.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndianStateGenerusAnalyzer.POCO
{
    public class censusDTO
    {
        public int serialNumber;
        public String StateName;
        public string state;
        public int tin;
        public string stateCode;
        public long area;
        public long population;
        public long density;
        public long housingUnits;
        public double totalArea;
        public double waterArea;
        public double landArea;
        public double populationDensity;
        public double housingDensity;

        public censusDTO(StateCodeDAO stateCodeDao)
        {
            this.serialNumber = stateCodeDao.serialNumber;
            this.StateName = stateCodeDao.stateName;
            this.tin = stateCodeDao.tin;
            this.stateCode = stateCodeDao.stateCode;
        }
        public censusDTO(CensusDataDAO censusDataDao)
        {
            this.state = censusDataDao.state;
            this.population = censusDataDao.population;
            this.density = censusDataDao.density;
            this.area = censusDataDao.area;
        }
        //public censusDTO(USACensusDAO usCensusDAO)
        //{
         //   this.stateCode = usCensusDAO.stateId;
          //  this.StateName = usCensusDAO.stateName;
           // this.population = usCensusDAO.population;
           // this.totalArea = usCensusDAO.totalArea;
           // this.housingUnits = usCensusDAO.housingUnits;
           // this.waterArea = usCensusDAO.waterArea;
           // this.landArea = usCensusDAO.landArea;
           // this.populationDensity = usCensusDAO.populationDensity;
           // this.housingDensity = usCensusDAO.housingDensity;
        //}

        
    }
}

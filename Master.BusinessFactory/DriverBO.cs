using System;
using System.Collections.Generic;
using Master.Contract;
using Master.DataFactory;

namespace Master.BusinessFactory
{
    public class DriverBO
    {
        private DriverDAL driverDAL;
        public DriverBO()
        {
            driverDAL = new DriverDAL();
        }

        public List<Driver> GetList()
        {
            return driverDAL.GetList();
        }

        public bool SaveDriver(Driver newItem)
        {

            return driverDAL.Save(newItem);
        }

        public bool DeleteDriver(Driver item)
        {
            return driverDAL.Delete(item);
        }

        public Driver GetDriver(Driver item)
        {
            return (Driver)driverDAL.GetItem<Driver>(item);
        }

        public bool UpdateDriverDevice(string driverID, string deviceID)
        {
            return driverDAL.UpdateDriverDevice(driverID, deviceID);
        }

        public List<Driver> GetDriverByName(Driver status)
        {
            return (List<Driver>)driverDAL.GetDriverByName<Driver>(status);
        }
    }
}

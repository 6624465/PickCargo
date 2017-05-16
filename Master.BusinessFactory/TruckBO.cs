using System;
using System.Collections.Generic;
using Master.Contract;
using Master.DataFactory;
using PickC.Services.DTO;
namespace Master.BusinessFactory
{
  public  class TruckBO
    {
        private TruckDAL truckDAL;
        public TruckBO()
        {
            truckDAL = new TruckDAL();
        }
        public List<TruckList> GetList()
        {
            return truckDAL.GetList();
        }
    }
}

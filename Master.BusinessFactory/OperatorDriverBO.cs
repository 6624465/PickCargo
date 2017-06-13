using System;
using System.Collections.Generic;
using PickC.Services.DTO;
using Master.DataFactory;
using Master.Contract;

namespace Master.BusinessFactory
{
  public  class OperatorDriverBO
    {
        private OperatorDriverDAL operatorDriverDAL;
        public OperatorDriverBO()
        {
            operatorDriverDAL = new OperatorDriverDAL();
        }
        public List<OperatorDriver> GetList()
        {
            return operatorDriverDAL.GetList();
        }
        public List<OperatorVehuicleAttachedNo> GetVehicleNoList()
        {
            return operatorDriverDAL.GetVehicleNoList();
        }
        public bool SaveOperatorDriver(OperatorDriverList operatorDriverList)
        {
            return operatorDriverDAL.Save(operatorDriverList);
        }
        public bool UpdateOperatorDriverTruckAttachment(OperatorDriverTruckAttachment operatorDriverTruckAttachment)
        {
            return operatorDriverDAL.Update(operatorDriverTruckAttachment);
        }
        public List<OperatorDriverList> GetOperatorDriverList()
        {
            return operatorDriverDAL.GetOperatorDriverList();
        }

    }
}

using System;
using System.Collections.Generic;
using PickC.Services.DTO;
using Master.DataFactory;
using Master.Contract;

namespace Master.BusinessFactory
{
    public class OperatorBO
    {
        private OperatorDAL operatorDAL;
        public OperatorBO()
        {
            operatorDAL = new OperatorDAL();
        }
        public List<Operator> GetList()
        {
            return operatorDAL.GetList();
        }
        public bool SaveOperator(Operator newItem)
        {
            return operatorDAL.Save(newItem);
        }
        public bool DeleteOperator(Operator operatorID)
        {
            return operatorDAL.Delete(operatorID);
        }
        public Operator GetOperator(Operator item)
        {
            return (Operator)operatorDAL.GetItem<Operator>(item);
        }
        public bool SaveAttachment(OperatorAttachmentDTO attachment)
        {
            return operatorDAL.SaveAttachment(attachment);
        }        
    }
}

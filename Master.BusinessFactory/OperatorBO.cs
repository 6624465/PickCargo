﻿using System;
using System.Collections.Generic;
using PickC.Services.DTO;
using Master.DataFactory;
using Master.Contract;
using Operation.Contract;

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
        public Operator GetOperatorDetails(string operatorID)
        {
            return operatorDAL.GetOperatorDetails(operatorID);
        }
        public bool UpdateOperatorPassword(OperatorPasssword item)
        {
            return operatorDAL.UpdateOperatorPassword(item);
        }
        public bool SaveOperatorNotifications(OperatorNotifications newItem)
        {

            return operatorDAL.SaveOperatorNotifications(newItem);
        }
        //public bool DeleteOperatorLogIn(OperatorLogIn item)
        //{
        //    return operatorDAL.DeleteOperatorLogIn(item);
        //}

        //public bool SaveAttachment(OperatorAttachment attachment)
        //{
        //    return operatorDAL.SaveAttachment(attachment);
        //}  
        public List<OperatorBankDetails> GetOperatorWiseBankList(string MobileNo)
        {
            return operatorDAL.GetOperatorWiseBankList(MobileNo);
        }
    }
}

using System;
using System.Collections.Generic;
using Operation.Contract;
using Operation.DataFactory;

namespace Operation.BusinessFactory
{
    public class TripBO
    {
        private TripDAL tripDAL;
        public TripBO()
        {
            tripDAL = new TripDAL();
        }

        public List<Trip> GetList()
        {
            return tripDAL.GetList();
        }

        public bool SaveTrip(Trip newItem)
        {

            return tripDAL.Save(newItem);
        }

        public bool DeleteTrip(Trip item)
        {
            return tripDAL.Delete(item);
        }

        public bool EndTrip(TripEndDTO tripEndDTO,decimal distance)
        {
            return tripDAL.EndTrip(tripEndDTO,distance);
        }

        public Trip GetTrip(Trip item)
        {
            return (Trip)tripDAL.GetItem<Trip>(item);
        }

        public Trip CustomerCurrentTrip(string mobileNo)
        {
            return tripDAL.CustomerCurrentTrip(mobileNo);
        }

        public Trip DriverCurrentTrip(string driverID)
        {
            return tripDAL.DriverCurrentTrip(driverID);
        }

        public bool TripUpdateTravelledDistance(string tripID, decimal distanceTravelled)
        {
            return tripDAL.TripUpdateTravelledDistance(tripID, distanceTravelled);
        }

    }
}

using System;
using Ex03.GarageLogic.Enums;
using Ex03.GarageLogic.Vehicles;

namespace Ex03.GarageLogic.Garage
{
    public class GarageVehicle
    {
        private readonly Vehicle r_Vehicle;
        private readonly string r_OwnerName;
        private readonly string r_OwnerPhone;
        private eVehicleStatus m_Status;

        public Vehicle Vehicle
        {
            get
            {
                return r_Vehicle;
            }
        }

        public string OwnerName
        {
            get
            {
                return r_OwnerName;
            }
        }

        public string OwnerPhone
        {
            get
            {
                return r_OwnerPhone;
            }
        }

        public eVehicleStatus Status
        {
            get
            {
                return m_Status;
            }
            set
            {
                m_Status = value;
            }
        }

        public GarageVehicle(
            Vehicle i_Vehicle,
            string i_OwnerName,
            string i_OwnerPhone)
        {
            r_Vehicle = i_Vehicle;
            r_OwnerName = i_OwnerName;
            r_OwnerPhone = i_OwnerPhone;

            m_Status = eVehicleStatus.InRepair;
        }

        public string GetGarageVehicleInfo()
        {
            string garageVehicleInfo =
                $"Owner Name: {r_OwnerName}{Environment.NewLine}" +
                $"Owner Phone: {r_OwnerPhone}{Environment.NewLine}" +
                $"Status: {m_Status}{Environment.NewLine}" +
                r_Vehicle.GetVehicleInfo();

            return garageVehicleInfo;
        }
    }
}
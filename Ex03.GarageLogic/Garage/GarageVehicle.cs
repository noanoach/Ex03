using Ex03.GarageLogic.Enums;
using Ex03.GarageLogic.Vehicles;

namespace Ex03.GarageLogic.Garage
{
    public class GarageVehicle
    {
        private readonly Vehicle m_Vehicle;

        private readonly string m_OwnerName;
        private readonly string m_OwnerPhone;

        private eVehicleStatus m_Status;

        public Vehicle Vehicle
        {
            get
            {
                return m_Vehicle;
            }
        }

        public string OwnerName
        {
            get
            {
                return m_OwnerName;
            }
        }

        public string OwnerPhone
        {
            get
            {
                return m_OwnerPhone;
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
            m_Vehicle = i_Vehicle;
            m_OwnerName = i_OwnerName;
            m_OwnerPhone = i_OwnerPhone;

            m_Status = eVehicleStatus.InRepair;
        }


        public string GetGarageVehicleInfo()
        {
            return
                $"Owner Name: {m_OwnerName}{Environment.NewLine}" +
                $"Owner Phone: {m_OwnerPhone}{Environment.NewLine}" +
                $"Status: {m_Status}{Environment.NewLine}" +
                m_Vehicle.GetVehicleInfo();
        }
    }
}
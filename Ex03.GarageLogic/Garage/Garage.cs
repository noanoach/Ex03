using System.Collections.Generic;
using Ex03.GarageLogic.Enums;

namespace Ex03.GarageLogic.Garage
{
    public class Garage
    {
        private readonly Dictionary<string, GarageVehicle> m_Vehicles;

        public Garage()
        {
        }

        public void AddVehicle(
            GarageVehicle i_GarageVehicle)
        {
        }

        public bool ContainsVehicle(
            string i_LicenseNumber)
        {
            return false;
        }

        public GarageVehicle GetVehicle(
            string i_LicenseNumber)
        {
            return null;
        }

        public List<string> GetAllLicenseNumbers()
        {
            return null;
        }

        public List<string> GetLicenseNumbersByStatus(
            eVehicleStatus i_Status)
        {
            return null;
        }

        public void ChangeVehicleStatus(
            string i_LicenseNumber,
            eVehicleStatus i_NewStatus)
        {
        }

        public void InflateVehicleWheelsToMax(
            string i_LicenseNumber)
        {
        }

        public void RefuelVehicle(
            string i_LicenseNumber,
            eFuelType i_FuelType,
            float i_FuelAmount)
        {
        }

        public void ChargeVehicle(
            string i_LicenseNumber,
            float i_HoursToAdd)
        {
        }

        public string GetVehicleDetails(
            string i_LicenseNumber)
        {
            return string.Empty;
        }
    }
}
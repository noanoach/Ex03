using System.Collections.Generic;
using Ex03.GarageLogic.Enums;

namespace Ex03.GarageLogic.Garage
{
    public class Garage
    {
        private readonly Dictionary<string, GarageVehicle> m_Vehicles;

        public Garage()
        {
            m_Vehicles = new Dictionary<string, GarageVehicle>();
        }

        public void AddVehicle(
            GarageVehicle i_GarageVehicle)
        {
            m_Vehicles.Add(
                i_GarageVehicle.Vehicle.LicenseNumber,
                i_GarageVehicle);
        }

        public bool ContainsVehicle(
            string i_LicenseNumber)
        {
            return m_Vehicles.ContainsKey(
                i_LicenseNumber);
        }

        public GarageVehicle GetVehicle(
            string i_LicenseNumber)
        {
            return m_Vehicles[i_LicenseNumber];
        }

        public List<string> GetAllLicenseNumbers()
        {
            return new List<string>(
                m_Vehicles.Keys);
        }

        public List<string> GetLicenseNumbersByStatus(
            eVehicleStatus i_Status)
        {
            List<string> licenseNumbers =
                new List<string>();

            foreach (GarageVehicle garageVehicle in m_Vehicles.Values)
            {
                if (garageVehicle.Status == i_Status)
                {
                    licenseNumbers.Add(
                        garageVehicle.Vehicle.LicenseNumber);
                }
            }

            return licenseNumbers;
        }

        public void ChangeVehicleStatus(
            string i_LicenseNumber,
            eVehicleStatus i_NewStatus)
        {
            m_Vehicles[i_LicenseNumber].Status =
                i_NewStatus;
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
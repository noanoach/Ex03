using System;
using Ex03.GarageLogic.Enums;
using Ex03.GarageLogic.EnergySources;

namespace Ex03.GarageLogic.Vehicles
{
    public class FuelTruck : Truck
    {
        private const float k_MaxFuelCapacity = 125f;

        public FuelTruck(
            string i_LicenseNumber,
            string i_ModelName)
            : base(
                i_LicenseNumber,
                i_ModelName)
        {
            m_NumberOfWheels = 14;
            m_MaxWheelPressure = 28f;

            m_EnergySource = new FuelEnergySource(0, k_MaxFuelCapacity, eFuelType.Soler);
        }

        public override string GetVehicleInfo()
        {
            return
                GetBaseVehicleInfo() +
                Environment.NewLine +
                GetTruckInfo();
        }
    }
}
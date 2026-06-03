using System;
using Ex03.GarageLogic.Enums;
using Ex03.GarageLogic.EnergySources;

namespace Ex03.GarageLogic.Vehicles
{
    public class FuelTruck : Truck
    {
        private const float k_MaxFuelCapacity = 125f;

        private const int k_NumberOfWheels = 14;
        private const float k_MaxWheelPressure = 29f;

        public FuelTruck(
            string i_LicenseNumber,
            string i_ModelName)
            : base(
                i_LicenseNumber,
                i_ModelName)
        {
            m_EnergySource = new FuelEnergySource(
                0,
                k_MaxFuelCapacity,
                eFuelType.Soler);
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
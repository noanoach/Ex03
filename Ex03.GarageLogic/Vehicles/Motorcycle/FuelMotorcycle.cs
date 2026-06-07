using System;
using Ex03.GarageLogic.Enums;
using Ex03.GarageLogic.EnergySources;

namespace Ex03.GarageLogic.Vehicles
{
    public class FuelMotorcycle : Motorcycle
    {
        private const float k_MaxFuelCapacity = 5.6f;

        public FuelMotorcycle(
            string i_LicenseNumber,
            string i_ModelName)
            : base(
                i_LicenseNumber,
                i_ModelName)
        {
            m_NumberOfWheels = 2;
            m_MaxWheelPressure = 30f;

            m_EnergySource = new FuelEnergySource(0, k_MaxFuelCapacity, eFuelType.Octan98);
        }

        public override string GetVehicleInfo()
        {
            string vehicleInfo =
                GetBaseVehicleInfo() +
                Environment.NewLine +
                GetMotorcycleInfo();

            return vehicleInfo;
        }
    }
}
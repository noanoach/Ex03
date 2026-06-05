using System;
using Ex03.GarageLogic.EnergySources;

namespace Ex03.GarageLogic.Vehicles
{
    public class ElectricMotorcycle : Motorcycle
    {
        private const float k_MaxBatteryHours = 3.0f;

        public ElectricMotorcycle(
            string i_LicenseNumber,
            string i_ModelName)
            : base(
                i_LicenseNumber,
                i_ModelName)
        {
            m_NumberOfWheels = 2;
            m_MaxWheelPressure = 30f;

            m_EnergySource = new ElectricEnergySource(
                0,
                k_MaxBatteryHours);
        }

        public override string GetVehicleInfo()
        {
            return
                GetBaseVehicleInfo() +
                Environment.NewLine +
                GetMotorcycleInfo();
        }
    }
}
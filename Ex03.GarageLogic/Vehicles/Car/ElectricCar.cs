using System;
using Ex03.GarageLogic.EnergySources;

namespace Ex03.GarageLogic.Vehicles.Car
{
    public class ElectricCar : Car
    {
        private const float k_MaxBatteryHours = 4.6f;

        public ElectricCar(
            string i_LicenseNumber,
            string i_ModelName)
            : base(
                i_LicenseNumber,
                i_ModelName)
        {
            m_NumberOfWheels = 5;
            m_MaxWheelPressure = 31f;

            m_EnergySource = new ElectricEnergySource(
                0,
                k_MaxBatteryHours);
        }

        public override string GetVehicleInfo()
        {
            return
                GetBaseVehicleInfo() +
                Environment.NewLine +
                GetCarInfo();
        }
    }
}
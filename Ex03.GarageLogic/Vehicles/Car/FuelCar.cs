using System;
using Ex03.GarageLogic.Enums;
using Ex03.GarageLogic.EnergySources;

namespace Ex03.GarageLogic.Vehicles.Car
{
    public class FuelCar : Car
    {
        private const float k_MaxFuelCapacity = 51f;

        public FuelCar(
            string i_LicenseNumber,
            string i_ModelName)
            : base(
                i_LicenseNumber,
                i_ModelName)
        {
            m_NumberOfWheels = 5;
            m_MaxWheelPressure = 31f;

            m_EnergySource = new FuelEnergySource(
                0,
                k_MaxFuelCapacity,
                eFuelType.Octan95);
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
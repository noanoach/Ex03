using Ex03.GarageLogic.Enums;
using Ex03.GarageLogic.EnergySources;

namespace Ex03.GarageLogic.Vehicles.Car
{
    public class FuelCar : Car
    {
        private const float k_MaxFuelCapacity = 51f;

        private const int k_NumberOfWheels = 5;
        private const float k_MaxWheelPressure = 31f;

        public FuelCar(
            string i_LicenseNumber,
            string i_ModelName)
            : base(
                i_LicenseNumber,
                i_ModelName)
        {
            m_EnergySource = new FuelEnergySource(
                0,
                k_MaxFuelCapacity,
                eFuelType.Octan95);
        }
    }
}
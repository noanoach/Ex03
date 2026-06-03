using Ex03.GarageLogic.Enums;
using Ex03.GarageLogic.EnergySources;

namespace Ex03.GarageLogic.Vehicles
{
    public class FuelMotorcycle : Motorcycle
    {
        private const float k_MaxFuelCapacity = 5.6f;

        public FuelMotorcycle(
            string i_LicenseNumber,
            string i_ModelName,
            eLicenseType i_LicenseType,
            int i_EngineVolume
            )
            : base(
                i_LicenseNumber,
                i_ModelName,
                i_LicenseType,
                i_EngineVolume)
        {
            m_EnergySource = new FuelEnergySource(
                0,
                k_MaxFuelCapacity,
                eFuelType.Octan98);
        }
    }
}
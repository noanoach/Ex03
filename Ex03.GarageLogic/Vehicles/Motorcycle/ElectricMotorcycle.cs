using Ex03.GarageLogic.EnergySources;
using Ex03.GarageLogic.Enums;

namespace Ex03.GarageLogic.Vehicles
{
    public class ElectricMotorcycle : Motorcycle
    {
        private const float k_MaxBatteryHours = 3.0f;

        public ElectricMotorcycle(
            string i_LicenseNumber,
            string i_ModelName,
            eLicenseType i_LicenseType,
            int i_EngineVolume)
            : base(
                i_LicenseNumber,
                i_ModelName,
                i_LicenseType,
                i_EngineVolume
                )
        {
            m_EnergySource = new ElectricEnergySource(
                0,
                k_MaxBatteryHours);
        }
    }
}
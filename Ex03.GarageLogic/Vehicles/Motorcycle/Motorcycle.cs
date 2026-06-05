using Ex03.GarageLogic.Enums;

namespace Ex03.GarageLogic.Vehicles
{
    public abstract class Motorcycle : Vehicle
    {
        protected eLicenseType m_LicenseType;
        protected int m_EngineVolume;

        public eLicenseType LicenseType
        {
            get
            {
                return m_LicenseType;
            }
        }

        public int EngineVolume
        {
            get
            {
                return m_EngineVolume;
            }
        }

        protected Motorcycle(
            string i_LicenseNumber,
            string i_ModelName)
            : base(
                i_LicenseNumber,
                i_ModelName)
        {
        }

        public void InitializeMotorcycleDetails(
            eLicenseType i_LicenseType,
            int i_EngineVolume)
        {
            m_LicenseType = i_LicenseType;
            m_EngineVolume = i_EngineVolume;
        }

        protected string GetMotorcycleInfo()
        {
            return
                $"License Type: {m_LicenseType}{System.Environment.NewLine}" +
                $"Engine Volume: {m_EngineVolume} cc";
        }
    }
}
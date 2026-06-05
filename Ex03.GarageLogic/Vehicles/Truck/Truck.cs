using System;

namespace Ex03.GarageLogic.Vehicles
{
    public abstract class Truck : Vehicle
    {
        protected bool m_IsCoolingCargo;
        protected float m_CargoVolume;

        public bool IsCoolingCargo
        {
            get
            {
                return m_IsCoolingCargo;
            }
        }

        public float CargoVolume
        {
            get
            {
                return m_CargoVolume;
            }
        }

        protected Truck(
            string i_LicenseNumber,
            string i_ModelName)
            : base(
                i_LicenseNumber,
                i_ModelName)
        {
        }

        public void InitializeTruckDetails(
            bool i_IsCoolingCargo,
            float i_CargoVolume)
        {
            m_IsCoolingCargo = i_IsCoolingCargo;
            m_CargoVolume = i_CargoVolume;
        }

        protected string GetTruckInfo()
        {
            return
                $"Cooling Cargo: {m_IsCoolingCargo}{Environment.NewLine}" +
                $"Cargo Volume: {m_CargoVolume}";
        }
    }
}


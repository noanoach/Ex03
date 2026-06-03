using System;

namespace Ex03.GarageLogic.Vehicles.Truck
{
    public abstract class Truck : Vehicle
    {
        protected bool m_ContainsDangerousMaterials;
        protected float m_CargoVolume;

        public bool ContainsDangerousMaterials
        {
            get
            {
                return m_ContainsDangerousMaterials;
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

        protected string GetTruckInfo()
        {
            return
                $"Dangerous Materials: {m_ContainsDangerousMaterials}{Environment.NewLine}" +
                $"Cargo Volume: {m_CargoVolume}";
        }
    }
}
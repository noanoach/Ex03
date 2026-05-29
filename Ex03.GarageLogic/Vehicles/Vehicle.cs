using System.Collections.Generic;
using Ex03.GarageLogic.Components;
using Ex03.GarageLogic.EnergySources;

namespace Ex03.GarageLogic.Vehicles
{
    public abstract class Vehicle
    {
        protected string m_ModelName;
        protected string m_LicenseNumber;

        protected readonly List<Wheel> m_Wheels;

        protected EnergySource m_EnergySource;

        public string ModelName
        {
            get
            {
                return m_ModelName;
            }
        }

        public string LicenseNumber
        {
            get
            {
                return m_LicenseNumber;
            }
        }

        public List<Wheel> Wheels
        {
            get
            {
                return m_Wheels;
            }
        }

        public EnergySource EnergySource
        {
            get
            {
                return m_EnergySource;
            }
        }

        protected Vehicle(
            string i_LicenseNumber,
            string i_ModelName)
        {
            m_LicenseNumber = i_LicenseNumber;
            m_ModelName = i_ModelName;

            m_Wheels = new List<Wheel>();
        }

        public abstract string GetVehicleInfo();
    }
}
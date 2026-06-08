using System;
using System.Collections.Generic;
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

        public override List<string> GetSpecificFieldNames()
        {
            return new List<string>{"LicenseType", "EngineVolume"};
        }

        public override void InitializeSpecificDetails(
            Dictionary<string, string> i_Data)
        {
            InitializeMotorcycleDetails(
                (eLicenseType)Enum.Parse(
                    typeof(eLicenseType),
                    i_Data["LicenseType"]),
                int.Parse(
                    i_Data["EngineVolume"]));
        }

        protected string GetMotorcycleInfo()
        {
            string motorcycleInfo =
                $"License Type: {m_LicenseType}{System.Environment.NewLine}" +
                $"Engine Volume: {m_EngineVolume} cc";

            return motorcycleInfo;
        }
    }
}
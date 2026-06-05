using System.Collections.Generic;
using Ex03.GarageLogic.Components;
using Ex03.GarageLogic.EnergySources;

namespace Ex03.GarageLogic.Vehicles
{
    public abstract class Vehicle
    {
        protected string m_ModelName;
        protected string m_LicenseNumber;
        protected int m_NumberOfWheels;
        protected float m_MaxWheelPressure;

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

        public int NumberOfWheels
        {
            get
            {
                return m_NumberOfWheels;
            }
        }

        public float MaxWheelPressure
        {
            get
            {
                return m_MaxWheelPressure;
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

        public float RemainingEnergyPercentage
        {
            get
            {
                return m_EnergySource.RemainingPercentage;
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

        protected string GetBaseVehicleInfo()
        {
            return
                $"License Number: {m_LicenseNumber}{Environment.NewLine}" +
                $"Model Name: {m_ModelName}{Environment.NewLine}" +
                $"Remaining Energy: {RemainingEnergyPercentage:F1}%";
        }

        public void AddWheel(
            Wheel i_Wheel)
        {
            m_Wheels.Add(i_Wheel);
        }
    }
}
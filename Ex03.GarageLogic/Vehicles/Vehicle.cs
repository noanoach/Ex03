using System;
using System.Collections.Generic;
using Ex03.GarageLogic.Components;
using Ex03.GarageLogic.EnergySources;

namespace Ex03.GarageLogic.Vehicles
{
    public abstract class Vehicle
    {
        protected string m_ModelName;
        protected string m_LicenseNumber;
        protected EnergySource? m_EnergySource;
        protected readonly List<Wheel> r_Wheels;
        protected int m_NumberOfWheels;
        protected float m_MaxWheelPressure;

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
                return r_Wheels;
            }
        }

        public EnergySource EnergySource
        {
            get
            {
                return m_EnergySource!;
            }
        }

        public float RemainingEnergyPercentage
        {
            get
            {
                return m_EnergySource!.RemainingPercentage;
            }
        }

        protected Vehicle(string i_LicenseNumber, string i_ModelName)
        {
            m_LicenseNumber = i_LicenseNumber;
            m_ModelName = i_ModelName;
            r_Wheels = new List<Wheel>();
        }

        public abstract string GetVehicleInfo();

        protected string GetBaseVehicleInfo()
        {
            string baseVehicleInfo =
                $"License Number: {m_LicenseNumber}{Environment.NewLine}" +
                $"Model Name: {m_ModelName}{Environment.NewLine}" +
                $"Remaining Energy: {RemainingEnergyPercentage:F1}%{Environment.NewLine}" +
                GetWheelsInfo() + Environment.NewLine +
                GetEnergySourceInfo();

            return baseVehicleInfo;
        }

        private string GetWheelsInfo()
        {
            string wheelsInfo;

            if (r_Wheels.Count == 0)
            {
                wheelsInfo = "Wheels: No wheels information";
            }
            else
            {
                Wheel firstWheel = r_Wheels[0];

                wheelsInfo =
                    $"Wheels Amount: {r_Wheels.Count}{Environment.NewLine}" +
                    $"Wheel Manufacturer: {firstWheel.ManufacturerName}{Environment.NewLine}" +
                    $"Current Wheel Pressure: {firstWheel.CurrentAirPressure}{Environment.NewLine}" +
                    $"Max Wheel Pressure: {firstWheel.MaxAirPressure}";
            }

            return wheelsInfo;
        }

        private string GetEnergySourceInfo()
        {
            string energySourceInfo;

            if (m_EnergySource is FuelEnergySource fuelEnergySource)
            {
                energySourceInfo = fuelEnergySource.GetFuelInfo();
            }
            else if (m_EnergySource is ElectricEnergySource electricEnergySource)
            {
                energySourceInfo = electricEnergySource.GetElectricInfo();
            }
            else
            {
                energySourceInfo = "Energy Source: No energy information";
            }

            return energySourceInfo;
        }

        public abstract List<string> GetSpecificFieldNames();

        public abstract void InitializeSpecificDetails(Dictionary<string, string> i_Data);

        public void AddWheel(Wheel i_Wheel)
        {
            r_Wheels.Add(i_Wheel);
        }
    }
}
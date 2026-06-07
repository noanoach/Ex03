using Ex03.GarageLogic.Components;
using Ex03.GarageLogic.EnergySources;
using Ex03.GarageLogic.Enums;
using Ex03.GarageLogic.FileLoader;
using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic.Garage
{
    public class Garage
    {
        private readonly Dictionary<string, GarageVehicle> r_Vehicles;

        public Garage()
        {
            r_Vehicles = new Dictionary<string, GarageVehicle>();
        }

        public void AddVehicle(GarageVehicle i_GarageVehicle)
        {
            r_Vehicles.Add(i_GarageVehicle.Vehicle.LicenseNumber, i_GarageVehicle);
        }

        public bool ContainsVehicle(string i_LicenseNumber)
        {
            bool containsVehicle = r_Vehicles.ContainsKey(i_LicenseNumber);

            return containsVehicle;
        }

        public GarageVehicle GetVehicle(string i_LicenseNumber)
        {
            GarageVehicle garageVehicle = r_Vehicles[i_LicenseNumber];

            return garageVehicle;
        }

        public List<string> GetAllLicenseNumbers()
        {
            List<string> licenseNumbers = new List<string>(r_Vehicles.Keys);

            return licenseNumbers;
        }

        public List<string> GetLicenseNumbersByStatus(eVehicleStatus i_Status)
        {
            List<string> licenseNumbers = new List<string>();

            foreach (GarageVehicle garageVehicle in r_Vehicles.Values)
            {
                if (garageVehicle.Status == i_Status)
                {
                    licenseNumbers.Add(garageVehicle.Vehicle.LicenseNumber);
                }
            }

            return licenseNumbers;
        }

        public void ChangeVehicleStatus(string i_LicenseNumber, eVehicleStatus i_NewStatus)
        {
            r_Vehicles[i_LicenseNumber].Status = i_NewStatus;
        }

        public void InflateVehicleWheelsToMax(string i_LicenseNumber)
        {
            GarageVehicle garageVehicle = r_Vehicles[i_LicenseNumber];

            foreach (Wheel wheel in garageVehicle.Vehicle.Wheels)
            {
                wheel.InflateToMax();
            }
        }

        public void RefuelVehicle(string i_LicenseNumber, eFuelType i_FuelType, float i_FuelAmount)
        {
            FuelEnergySource? fuelEnergySource = r_Vehicles[i_LicenseNumber].Vehicle.EnergySource as FuelEnergySource;

            if (fuelEnergySource == null)
            {
                throw new ArgumentException("Vehicle is not fuel based.");
            }

            fuelEnergySource.Refuel(
                i_FuelAmount,
                i_FuelType);
        }

        public void ChargeVehicle(string i_LicenseNumber, float i_HoursToAdd)
        {
            ElectricEnergySource? electricEnergySource = r_Vehicles[i_LicenseNumber].Vehicle.EnergySource as ElectricEnergySource;

            if (electricEnergySource == null)
            {
                throw new ArgumentException("Vehicle is not electric.");
            }

            electricEnergySource.Charge(i_HoursToAdd);
        }

        public string GetVehicleDetails(string i_LicenseNumber)
        {
            string vehicleDetails = r_Vehicles[i_LicenseNumber].GetGarageVehicleInfo();

            return vehicleDetails;
        }

        public void LoadVehiclesFromFile(string i_FilePath)
        {
            List<GarageVehicle> vehicles = VehicleFileLoader.LoadVehicles(i_FilePath);

            foreach (GarageVehicle garageVehicle in vehicles)
            {
                AddVehicle(garageVehicle);
            }
        }
    }
}
using Ex03.GarageLogic.Components;
using Ex03.GarageLogic.Garage;
using Ex03.GarageLogic.Vehicles;
using System;
using System.Collections.Generic;


namespace Ex03.GarageLogic.FileLoader
{
    internal static class VehicleFileLoader
    {
        public static List<GarageVehicle> LoadVehicles(string i_FilePath)
        {
            List<GarageVehicle> vehicles = new List<GarageVehicle>();

            string[] lines = File.ReadAllLines(i_FilePath);

            foreach (string line in lines)
            {
                if (!string.IsNullOrWhiteSpace(line))
                {
                    vehicles.Add(ParseVehicle(line));
                }
            }

            return vehicles;
        }

        private static GarageVehicle ParseVehicle(string i_Line)
        {
            string[] fields = i_Line.Split(',');

            Vehicle vehicle = VehicleCreator.CreateVehicle(fields[0],fields[1],fields[2]);

            InitializeVehicleEnergy(vehicle,float.Parse(fields[3]));

            InitializeVehicleWheels(vehicle, fields[4], float.Parse(fields[5]));

            InitializeVehicleSpecificDetails(vehicle, fields);

            GarageVehicle garageVehicle = new GarageVehicle(vehicle, fields[6], fields[7]);

            return garageVehicle;
        }

        private static void InitializeVehicleSpecificDetails(Vehicle i_Vehicle, string[] i_Fields)
        {
            Dictionary<string, string> specificData = new Dictionary<string, string>();

            List<string> fieldNames =
                i_Vehicle.GetSpecificFieldNames();

            for (int i = 0; i < fieldNames.Count; i++)
            {
                specificData[fieldNames[i]] =
                    i_Fields[8 + i];
            }

            i_Vehicle.InitializeSpecificDetails(specificData);
        }

        private static void InitializeVehicleEnergy(Vehicle i_Vehicle, float i_EnergyPercentage)
        {
            i_Vehicle.EnergySource.SetRemainingPercentage(i_EnergyPercentage);
        }

        private static void InitializeVehicleWheels(Vehicle i_Vehicle, string i_ManufacturerName, float i_CurrentPressure)
        {
            for (int i = 0; i < i_Vehicle.NumberOfWheels; i++)
            {
                i_Vehicle.AddWheel(new Wheel(i_ManufacturerName, i_CurrentPressure, i_Vehicle.MaxWheelPressure));
            }
        }
    }
}

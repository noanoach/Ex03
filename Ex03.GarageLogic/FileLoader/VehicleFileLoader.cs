using Ex03.GarageLogic.Components;
using Ex03.GarageLogic.Enums;
using Ex03.GarageLogic.Garage;
using Ex03.GarageLogic.Vehicles;
using Ex03.GarageLogic.Vehicles.Car;
using System;
using System.Collections.Generic;
using System.Text;


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
            if (i_Vehicle is Car car)
            {
                car.InitializeCarDetails((eCarColor)Enum.Parse(typeof(eCarColor), i_Fields[8]), (eDoorsAmount)int.Parse(i_Fields[9]));
            }
            else if (i_Vehicle is Motorcycle motorcycle)
            {
                motorcycle.InitializeMotorcycleDetails((eLicenseType)Enum.Parse(typeof(eLicenseType), i_Fields[8]), int.Parse(i_Fields[9]));
            }
            else if (i_Vehicle is Truck truck)
            {
                truck.InitializeTruckDetails(bool.Parse(i_Fields[8]), float.Parse(i_Fields[9]));
            }
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

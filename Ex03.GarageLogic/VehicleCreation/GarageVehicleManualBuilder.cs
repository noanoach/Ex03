using System.Collections.Generic;
using Ex03.GarageLogic.Components;
using Ex03.GarageLogic.Garage;
using Ex03.GarageLogic.Vehicles;

namespace Ex03.GarageLogic.VehicleCreation
{
    public static class GarageVehicleManualBuilder
    {
        public static GarageVehicle Build(
            string i_VehicleType,
            string i_LicenseNumber,
            string i_ModelName,
            float i_EnergyPercentage,
            string i_WheelManufacturer,
            float i_CurrentWheelPressure,
            string i_OwnerName,
            string i_OwnerPhone,
            Dictionary<string, string> i_SpecificData)
        {
            Vehicle vehicle =
                VehicleCreator.CreateVehicle(
                    i_VehicleType,
                    i_LicenseNumber,
                    i_ModelName);

            vehicle.EnergySource.SetRemainingPercentage(i_EnergyPercentage);

            for (int i = 0; i < vehicle.NumberOfWheels; i++)
            {
                vehicle.AddWheel(
                    new Wheel(
                        i_WheelManufacturer,
                        i_CurrentWheelPressure,
                        vehicle.MaxWheelPressure));
            }

            vehicle.InitializeSpecificDetails(i_SpecificData);

            return new GarageVehicle(
                vehicle,
                i_OwnerName,
                i_OwnerPhone);
        }
    }
}
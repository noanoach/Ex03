using Ex03.GarageLogic.Components;
using Ex03.GarageLogic.Enums;
using Ex03.GarageLogic.Garage;
using Ex03.GarageLogic.Vehicles;
using Ex03.GarageLogic.Vehicles.Car;

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
            eCarColor i_CarColor = default,
            eDoorsAmount i_DoorsAmount = default,
            eLicenseType i_LicenseType = default,
            int i_EngineVolume = default,
            bool i_CarriesCooledCargo = default,
            float i_CargoVolume = default)
        {
            Vehicle vehicle = VehicleCreator.CreateVehicle(i_VehicleType, i_LicenseNumber, i_ModelName);

            vehicle.EnergySource.SetRemainingPercentage(i_EnergyPercentage);

            for (int i = 0; i < vehicle.NumberOfWheels; i++)
            {
                vehicle.AddWheel(new Wheel(
                    i_WheelManufacturer,
                    i_CurrentWheelPressure,
                    vehicle.MaxWheelPressure));
            }

            if (vehicle is Car car)
            {
                car.InitializeCarDetails(i_CarColor, i_DoorsAmount);
            }
            else if (vehicle is Motorcycle motorcycle)
            {
                motorcycle.InitializeMotorcycleDetails(i_LicenseType, i_EngineVolume);
            }
            else if (vehicle is Truck truck)
            {
                truck.InitializeTruckDetails(i_CarriesCooledCargo, i_CargoVolume);
            }

            return new GarageVehicle(
                vehicle,
                i_OwnerName,
                i_OwnerPhone);
        }
    }
}
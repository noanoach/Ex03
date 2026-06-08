using Ex03.ConsoleUI.Menus;
using Ex03.GarageLogic;
using Ex03.GarageLogic.Enums;
using Ex03.GarageLogic.Garage;
using Ex03.GarageLogic.VehicleCreation;
using Ex03.GarageLogic.Vehicles;
using System;
using System.Collections.Generic;

namespace Ex03.ConsoleUI.UI
{
    public class ConsoleUI
    {
        private readonly Garage m_Garage;

        public ConsoleUI()
        {
            m_Garage = new Garage();
        }

        public void Run()
        {
            bool exitRequested = false;

            while (!exitRequested)
            {
                MainMenu.Show();

                try
                {
                    int choice = InputHandler.ReadMenuChoice();

                    if (choice == 9)
                    {
                        exitRequested = true;
                        Console.WriteLine("Exiting the application. Goodbye!");
                    }
                    else
                    {
                        handleMenuChoice(choice);
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: {0}", ex.Message);
                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();

            }
        }

        private void handleMenuChoice(int i_Choice)
        {
            switch (i_Choice)
            {
                case 1:
                    loadVehiclesFromFile();
                    break;
                case 2:
                    insertNewVehicle();
                    break;

                case 3:
                    showLicenseNumbers();
                    break;

                case 4:
                    changeVehicleStatus();
                    break;

                case 5:
                    inflateWheelsToMax();
                    break;

                case 6:
                    refuelVehicle();
                    break;

                case 7:
                    chargeVehicle();
                    break;

                case 8:
                    showVehicleDetails();
                    break;

                default:
                    throw new ArgumentException("Invalid menu choice.");

            }
        }

        private void loadVehiclesFromFile()
        {
            Console.WriteLine("Enter file name:");
            string fileName = Console.ReadLine();

            m_Garage.LoadVehiclesFromFile(fileName);

            Console.WriteLine("Vehicles were loaded successfully.");
        }

        private void insertNewVehicle()
        {
            string licenseNumber = InputHandler.ReadLicenseNumber();

            if (m_Garage.ContainsVehicle(licenseNumber))
            {
                m_Garage.ChangeVehicleStatus(
                    licenseNumber,
                    eVehicleStatus.InRepair);

                Console.WriteLine(
                    "Vehicle already exists. Status changed to InRepair.");
            }
            else
            {
                Console.WriteLine("Choose vehicle type:");

                for (int i = 0; i < VehicleCreator.SupportedTypes.Count; i++)
                {
                    Console.WriteLine(
                        $"{i + 1}. {VehicleCreator.SupportedTypes[i]}");
                }

                int vehicleTypeChoice =
                    InputHandler.ReadMenuChoice();

                if (vehicleTypeChoice < 1 ||
                    vehicleTypeChoice > VehicleCreator.SupportedTypes.Count)
                {
                    throw new ArgumentException(
                        "Invalid vehicle type.");
                }

                string vehicleType =
                    VehicleCreator.SupportedTypes[
                        vehicleTypeChoice - 1];

                Console.WriteLine("Enter model name:");
                string modelName = Console.ReadLine();

                Console.WriteLine("Enter remaining energy percentage:");
                float energyPercentage =
                    float.Parse(Console.ReadLine());

                Console.WriteLine("Enter wheel manufacturer:");
                string wheelManufacturer =
                    Console.ReadLine();

                Console.WriteLine("Enter current wheel pressure:");
                float currentWheelPressure =
                    float.Parse(Console.ReadLine());

                Console.WriteLine("Enter owner name:");
                string ownerName =
                    Console.ReadLine();

                Console.WriteLine("Enter owner phone:");
                string ownerPhone =
                    Console.ReadLine();

                Vehicle vehicle =
                    VehicleCreator.CreateVehicle(
                        vehicleType,
                        licenseNumber,
                        modelName);

                Dictionary<string, string> specificData =
                    new Dictionary<string, string>();

                foreach (string fieldName in vehicle.GetSpecificFieldNames())
                {
                    Console.WriteLine($"Enter {fieldName}:");

                    string value = Console.ReadLine();

                    specificData[fieldName] = value;
                }

                GarageVehicle garageVehicle =
                    GarageVehicleManualBuilder.Build(
                        vehicleType,
                        licenseNumber,
                        modelName,
                        energyPercentage,
                        wheelManufacturer,
                        currentWheelPressure,
                        ownerName,
                        ownerPhone,
                        specificData);

                m_Garage.AddVehicle(
                    garageVehicle);

                Console.WriteLine(
                    "Vehicle was added successfully.");
            }
        }

        private string getVehicleTypeByChoice(int i_Choice)
        {
            string vehicleType = string.Empty;

            switch (i_Choice)
            {
                case 1:
                    vehicleType = "FuelCar";
                    break;

                case 2:
                    vehicleType = "ElectricCar";
                    break;

                case 3:
                    vehicleType = "FuelMotorcycle";
                    break;

                case 4:
                    vehicleType = "ElectricMotorcycle";
                    break;

                case 5:
                    vehicleType = "FuelTruck";
                    break;

                default:
                    throw new ArgumentException("Invalid vehicle type.");
            }

            return vehicleType;
        }

        private void showLicenseNumbers()
        {
            Console.WriteLine("Filter by status? y/n");
            string answer = Console.ReadLine();

            if (answer != "y" &&
                answer != "Y" &&
                answer != "n" &&
                answer != "N")
            {
                throw new ArgumentException("Please enter y or n.");
            }

            List<string> licenseNumbers;

            if (answer == "y" || answer == "Y")
            {
                eVehicleStatus status = readVehicleStatus();
                licenseNumbers = m_Garage.GetLicenseNumbersByStatus(status);
            }
            else
            {
                licenseNumbers = m_Garage.GetAllLicenseNumbers();
            }

            foreach (string licenseNumber in licenseNumbers)
            {
                Console.WriteLine(licenseNumber);
            }
        }

        private void changeVehicleStatus()
        {
            string licenseNumber = InputHandler.ReadLicenseNumber();
            eVehicleStatus status = readVehicleStatus();

            m_Garage.ChangeVehicleStatus(licenseNumber, status);

            Console.WriteLine("Vehicle status was changed.");
        }

        private void inflateWheelsToMax()
        {
            string licenseNumber = InputHandler.ReadLicenseNumber();

            m_Garage.InflateVehicleWheelsToMax(licenseNumber);

            Console.WriteLine("Wheels were inflated to maximum.");
        }

        private void refuelVehicle()
        {
            string licenseNumber = InputHandler.ReadLicenseNumber();

            Console.WriteLine("Choose fuel type:");
            Console.WriteLine("1. Soler");
            Console.WriteLine("2. Octan95");
            Console.WriteLine("3. Octan96");
            Console.WriteLine("4. Octan98");

            int fuelChoice = InputHandler.ReadMenuChoice();

            if (fuelChoice < 1 || fuelChoice > 4)
            {
                throw new ArgumentException("Invalid fuel type.");
            }

            eFuelType[] fuelMap =
            {
                eFuelType.Soler,
                eFuelType.Octan95,
                eFuelType.Octan96,
                eFuelType.Octan98
            };

            eFuelType fuelType = fuelMap[fuelChoice - 1];

            Console.WriteLine("Enter fuel amount:");
            float fuelAmount = float.Parse(Console.ReadLine());

            m_Garage.RefuelVehicle(licenseNumber, fuelType, fuelAmount);

            Console.WriteLine("Vehicle was refueled.");
        }

        private void chargeVehicle()
        {
            string licenseNumber = InputHandler.ReadLicenseNumber();

            Console.WriteLine("Enter charging time in minutes:");
            float minutes = float.Parse(Console.ReadLine());

            m_Garage.ChargeVehicle(licenseNumber, minutes / 60f);

            Console.WriteLine("Vehicle was charged.");
        }

        private void showVehicleDetails()
        {
            string licenseNumber = InputHandler.ReadLicenseNumber();

            Console.WriteLine(m_Garage.GetVehicleDetails(licenseNumber));
        }

        private eVehicleStatus readVehicleStatus()
        {
            Console.WriteLine("Choose vehicle status:");
            Console.WriteLine("1. InRepair");
            Console.WriteLine("2. Repaired");
            Console.WriteLine("3. Paid");

            int statusChoice = InputHandler.ReadMenuChoice();

            if (statusChoice < 1 || statusChoice > 3)
            {
                throw new ArgumentException("Invalid vehicle status.");
            }

            return (eVehicleStatus)(statusChoice - 1);
        }

    }

}
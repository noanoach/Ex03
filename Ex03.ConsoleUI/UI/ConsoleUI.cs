using System;
using System.Collections.Generic;
using Ex03.GarageLogic.Garage;
using Ex03.ConsoleUI.Menus;
using Ex03.GarageLogic.Enums;

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
                m_Garage.ChangeVehicleStatus(licenseNumber, eVehicleStatus.InRepair);
                Console.WriteLine("Vehicle already exists. Status changed to InRepair.");
            }
            else
            {
                Console.WriteLine("Insert new vehicle is not completed yet.");
            }
        }


        private void showLicenseNumbers()
        {
            Console.WriteLine("Filter by status? y/n");
            string answer = Console.ReadLine();

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
            eFuelType fuelType = (eFuelType)(fuelChoice - 1);

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
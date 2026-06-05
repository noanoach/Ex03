namespace Ex03.ConsoleUI.Menus
{
    public static class MainMenu
    {
        public static void Show()
        {
            Console.WriteLine();
            Console.WriteLine("Welcome to the Garage Management System!");
            Console.WriteLine("Please select an option:");
            Console.WriteLine("1. Load vehicles from file");
            Console.WriteLine("2. Insert new vehicle");
            Console.WriteLine("3. Show license numbers");
            Console.WriteLine("4. Change vehicle status");
            Console.WriteLine("5. Inflate wheels to maximum");
            Console.WriteLine("6. Refuel vehicle");
            Console.WriteLine("7. Charge electric vehicle");
            Console.WriteLine("8. Show vehicle details");
            Console.WriteLine("9. Exit");
            Console.WriteLine();

        }

    }

}
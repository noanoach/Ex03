namespace Ex03.ConsoleUI.Menus
{
    public static class InputHandler
    {
        public static int ReadMenuChoice()
        {
            Console.WriteLine("Please enter your choice:");
            string input = Console.ReadLine();

            if(!int.TryParse(input, out int choice) || choice < 1)
            {
                throw new FormatException("Invalid input. Please enter a valid number.");
            }
           return choice;
        }

        public static string ReadLicenseNumber()
        {
            Console.WriteLine("Please enter the license number:");
            string licenseNumber = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(licenseNumber))
            {
                throw new ArgumentException("License number cannot be empty.");
            }


            return licenseNumber.Trim();
        
        }

        public static string ReadOwnerName()
        {
            Console.WriteLine("Please enter the owner's name:");
            string ownerName = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(ownerName))
            {
                throw new ArgumentException("Owner's name cannot be empty.");

            }
            return ownerName.Trim();
        }

        public static string ReadOwnerPhone()
        {
            Console.WriteLine("Please enter the owner's phone number:");
            string ownerPhone = Console.ReadLine().Trim(); 

            if (string.IsNullOrWhiteSpace(ownerPhone))
            {
                throw new ArgumentException("Owner's phone number cannot be empty.");
            }

            foreach (char ch in ownerPhone)
            {
                if (!char.IsDigit(ch) && ch != '-')
                {
                    throw new FormatException(
                        "Phone number may contain only digits and dashes.");
                }
            }
            return ownerPhone;
        }
    }
}
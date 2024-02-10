using ModernAppliances.Entities;
using ModernAppliances.Entities.Abstract;
using ModernAppliances.Helpers;

namespace ModernAppliances
{
    /// <summary>
    /// Manager class for Modern Appliances
    /// </summary>
    /// <remarks>Author: </remarks>
    /// <remarks>Date: </remarks>
    internal class MyModernAppliances : ModernAppliances
    {
        /// <summary>
        /// Option 1: Performs a checkout
        /// </summary>
        public override void Checkout()
        {
            Console.WriteLine("\nEnter the item number of an appliance: ");
            long itemNum;
            itemNum = long.Parse(Console.ReadLine());

            Appliance? foundAppliance = null;

            foreach(Appliance app in Appliances)
            {
                if (app.ItemNumber == itemNum)
                {
                    foundAppliance = app;
                    if (app.IsAvailable)
                    {
                        app.Checkout();
                        Console.WriteLine($"Appliance {app.ItemNumber} has been checked out. ");
                    }
                    else
                    {
                        Console.WriteLine("The appliance is not available to be checked out. ");
                    }
                    break;
                }
            }
            if (foundAppliance == null)
            {
                Console.WriteLine("No appliances found with that item number. ");
            }
        }

        /// <summary>
        /// Option 2: Finds appliances
        /// </summary>
        public override void Find()
        {
            Console.WriteLine("\nEnter brand to search for: ");
            string userInput = Console.ReadLine();

            List<Appliance> foundAppliances = new List<Appliance>();

            foreach(Appliance app in Appliances)
            {
                if (app.Brand == userInput)
                {
                    foundAppliances.Add(app);
                }
            }

            DisplayAppliancesFromList(foundAppliances, 0);
        }

        /// <summary>
        /// Displays Refrigerators
        /// </summary>
        public override void DisplayRefrigerators()
        {
            Console.WriteLine("\nPossible options: ");
            Console.WriteLine("0 - Any ");
            Console.WriteLine("2 - Double doors ");
            Console.WriteLine("3 - Three doors ");
            Console.WriteLine("4 - Four doors ");

            Console.WriteLine("\nEnter number of doors: ");

            int numDoors = int.Parse(Console.ReadLine());

            List<Appliance> foundAppliances = new List<Appliance>();

            foreach(Appliance app in Appliances )
            {
                if (app.Type == Appliance.ApplianceTypes.Refrigerator)
                {
                    Refrigerator refrigerator = (Refrigerator)app;
                    if (numDoors == 0 || numDoors == refrigerator.Doors)
                    {
                        foundAppliances.Add(refrigerator);
                    }
                }
            }

            DisplayAppliancesFromList(foundAppliances, 0);
        }

        /// <summary>
        /// Displays Vacuums
        /// </summary>
        /// <param name="grade">Grade of vacuum to find (or null for any grade)</param>
        /// <param name="voltage">Vacuum voltage (or 0 for any voltage)</param>
        public override void DisplayVacuums()
        {
            Console.WriteLine("\nPossible options: ");
            Console.WriteLine("0 - Any ");
            Console.WriteLine("1 - Residential ");
            Console.WriteLine("2 - Commercial ");
            Console.WriteLine("Enter grade: ");

            string userGrade = Console.ReadLine();

            string grade;

            switch (userGrade)
            {
                case "0":
                    grade = "Any";
                    break;
                case "1":
                    grade = "Residential";
                    break;
                case "2":
                    grade = "Commercial";
                    break;
                default:
                    Console.WriteLine("Invalid option. ");
                    return;
            }

            Console.WriteLine("\nPossible options: ");
            Console.WriteLine("0 - Any ");
            Console.WriteLine("1 - 18 Volt ");
            Console.WriteLine("2 - 24 Volt ");
            Console.WriteLine("Enter voltage: ");

            string userVoltage = Console.ReadLine();
            int voltage;

            switch (userVoltage)
            {
                case "0":
                    voltage = 0;
                    break;
                case "1":
                    voltage = 18;
                    break;
                case "2":
                    voltage = 24;
                    break;
                default:
                    Console.WriteLine("Invalid option. ");
                    return;
            }

            List<Appliance> foundAppliances = new List<Appliance>();

            foreach(Appliance app in Appliances)
            {
                if (app.Type == Appliance.ApplianceTypes.Vacuum)
                {
                    Vacuum vacuum = (Vacuum)app;
                    if (vacuum.Grade == "Any" || vacuum.Grade == userGrade && vacuum.BatteryVoltage == 0 || vacuum.BatteryVoltage == voltage)
                    {
                        foundAppliances.Add(vacuum);
                    }
                }
            }

            DisplayAppliancesFromList(foundAppliances, 0);
        }

        /// <summary>
        /// Displays microwaves
        /// </summary>
        public override void DisplayMicrowaves()
        {
            Console.WriteLine("\nPossible options: ");
            Console.WriteLine("0 - Any ");
            Console.WriteLine("1 - Kitchen ");
            Console.WriteLine("2 - Work Site");

            Console.WriteLine("\nEnter room type: ");

            string userRoomType = Console.ReadLine();
            char roomType;

            switch (userRoomType)
            {
                case "0":
                    roomType = 'A';
                    break;
                case "1":
                    roomType = 'K';
                    break;
                case "2":
                    roomType = 'W';
                    break;
                default:
                    Console.WriteLine("Invalid option. ");
                    return;
            }

            List<Appliance> foundAppliances = new List<Appliance>();

            foreach(Appliance app in Appliances)
            {
                if (app.Type == Appliance.ApplianceTypes.Microwave)
                {
                    Microwave microwave = (Microwave)app;
                    if (roomType == 'A' || roomType == microwave.RoomType)
                    {
                        foundAppliances.Add(microwave);
                    }
                }
            }

            DisplayAppliancesFromList(foundAppliances, 0);
        }

        /// <summary>
        /// Displays dishwashers
        /// </summary>
        public override void DisplayDishwashers()
        {
            Console.WriteLine("\nPossible options: ");
            Console.WriteLine("0 - Any ");
            Console.WriteLine("1 - Quietest ");
            Console.WriteLine("2 - Quieter ");
            Console.WriteLine("3 - Quiet ");
            Console.WriteLine("4 - Moderate ");

            Console.WriteLine("Enter sound rating: ");

            string userSoundRating = Console.ReadLine();
            string soundRating;

            switch (userSoundRating)
            {
                case "0":
                    soundRating = "Any";
                    break;
                case "1":
                    soundRating = "Qt";
                    break;
                case "2":
                    soundRating = "Qr";
                    break;
                case "3":
                    soundRating = "Qu";
                    break;
                case "4":
                    soundRating = "M";
                    break;
                default:
                    Console.WriteLine("Invalid option. ");
                    return;
            }

            List<Appliance> foundAppliances = new List<Appliance>();

            foreach(Appliance app in Appliances)
            {
                if (app.Type == Appliance.ApplianceTypes.Dishwasher)
                {
                    Dishwasher dishwasher = (Dishwasher)app;
                    if (soundRating == "Any" || soundRating == dishwasher.SoundRating)
                    {
                        foundAppliances.Add(dishwasher);
                    }
                }
            }

            DisplayAppliancesFromList(foundAppliances, 0);
        }

        /// <summary>
        /// Generates random list of appliances
        /// </summary>
        public override void RandomList()
        {
            Console.WriteLine("\nAppliance Types: ");
            Console.WriteLine("0 - Any ");
            Console.WriteLine("1 - Refrigerators ");
            Console.WriteLine("2 - Vacuums ");
            Console.WriteLine("3 - Microwaves ");
            Console.WriteLine("4 - Dishwashers ");

            Console.WriteLine("\nEnter type of appliance: ");

            int userAppliance = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter number of appliances: ");
            int userNum = int.Parse(Console.ReadLine());

            List<Appliance> foundAppliances = new List<Appliance>();

            foreach (Appliance app in Appliances)
            {
                switch (userAppliance)
                {
                    case 0:
                        foundAppliances.Add(app);
                        break;
                    case 1:
                        if (app.Type == Appliance.ApplianceTypes.Refrigerator)
                        {
                            foundAppliances.Add(app);
                        }
                        break;
                    case 2:
                        if (app.Type == Appliance.ApplianceTypes.Vacuum)
                        {
                            foundAppliances.Add(app);
                        }
                        break;
                    case 3:
                        if (app.Type == Appliance.ApplianceTypes.Microwave)
                        {
                            foundAppliances.Add(app);
                        }
                        break;
                    case 4:
                        if (app.Type == Appliance.ApplianceTypes.Dishwasher)
                        {
                            foundAppliances.Add(app);
                        }
                        break;
                }
            }

            foundAppliances.Sort(new RandomComparer());

            DisplayAppliancesFromList(foundAppliances, userNum);
        }
    }
}
using ModernAppliances.Entities;
using ModernAppliances.Entities.Abstract;
using ModernAppliances.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;

namespace ModernAppliances
{
    /// Description: Manager class for Modern Appliances.
    ///     - Method for checking out an item with checks against item number and available stock.
    ///     - Display methods to display the different appliance types and sort by parameters
    ///     - Search by brand method, to return all results from brand specified by user
    ///     - Method to return a random number of appliances based on user number input.
    /// Authors: Jacqueline Duong, Josh Larue, Kris Senger and Michelle Tran
    /// Date: February 10, 2024
    internal class MyModernAppliances : ModernAppliances
    {
        /// <summary>
        /// Option 1: Performs a checkout
        /// </summary>
        public override void Checkout()
        {
            // Write "Enter the item number of an appliance: "
            Console.WriteLine("\nEnter the item number of an appliance: ");

            // Create long variable to hold item number
            long itemNumber;

            // Get user input as string and assign to variable.
            string userInput = Console.ReadLine();
            Console.WriteLine();
            // Convert user input from string to long and store as item number variable.
            itemNumber = long.Parse(userInput);

            // Create 'foundAppliance' variable to hold appliance with item number
            // Assign null to foundAppliance (foundAppliance may need to be set as nullable)
            Appliance? foundAppliance = null;

            // Loop through Appliances
            // Test appliance item number equals entered item number
            // Assign appliance in list to foundAppliance variable
            // Break out of loop (since we found what need to)
            foreach (Appliance appliance in Appliances)
            {
                if (appliance.ItemNumber == itemNumber)
                {
                    foundAppliance = appliance;
                    break;
                }
            }

            // Test appliance was not found (foundAppliance is null)
            // Write "No appliances found with that item number."
            if (foundAppliance == null)
            {
                Console.WriteLine("No appliances found with that item number.\n");
            }
            // Otherwise (appliance was found)
            // Test found appliance is available
            // Checkout found appliance
            // Write "Appliance has been checked out."
            // Otherwise (appliance isn't available)
            // Write "The appliance is not available to be checked out."
            else if (foundAppliance.IsAvailable)
            {
                foundAppliance.Checkout();
                Console.WriteLine($"Appliance \"{foundAppliance.ItemNumber}\" has been checked out.\n");
            }
            else if(!foundAppliance.IsAvailable)
            {
                Console.WriteLine("The appliance is not available to be checked out.\n");
            }
        }

        /// <summary>
        /// Option 2: Finds appliances
        /// </summary>
        public override void Find()
        {
            // Write "Enter brand to search for:"
            Console.WriteLine("\nEnter brand to search for: ");

            // Create string variable to hold entered brand
            // Get user input as string and assign to variable.
            string userBrand = Console.ReadLine();
            Console.WriteLine();

            // Create list to hold found Appliance objects
            List<Appliance> foundAppliancesList = new List<Appliance>();

            // Iterate through loaded appliances
            // Test current appliance brand matches what user entered
            // Add current appliance in list to found list
            foreach (Appliance appliance in Appliances)
            {
                if (userBrand == appliance.Brand)
                {
                    foundAppliancesList.Add(appliance);
                }
            }

            // Display found appliances
            // DisplayAppliancesFromList(found, 0);
            DisplayAppliancesFromList(foundAppliancesList, 0);
        }

        /// <summary>
        /// Displays Refridgerators
        /// </summary>
        public override void DisplayRefrigerators()
        {
            // Write "Enter number of doors: "
            // *** Adjusted this display to match expected output of assignment file
            Console.WriteLine("Enter number of doors: 2 (double door), 3 (three doors) or 4 (four doors): ");

            // Create variable to hold entered number of doors
            // Get user input as string and assign to variable
            // Convert user input from string to int and store as number of doors variable.
            int numDoors = int.Parse(Console.ReadLine());
            Console.WriteLine();

            // Create list to hold found Appliance objects
            List<Appliance> foundFridgeList = new List<Appliance>();

            // Iterate/loop through Appliances
            // Test that current appliance is a refrigerator
            // Down cast Appliance to Refrigerator
            // Refrigerator refrigerator = (Refrigerator) appliance;
            // Test user entered 0 or refrigerator doors equals what user entered.
            // Add current appliance in list to found list
            foreach (Appliance appliance in Appliances)
            {
                if (appliance is Refrigerator)
                {
                    Refrigerator refrigerator = (Refrigerator)appliance;

                    if (numDoors == 0 || numDoors == refrigerator.Doors)
                    {
                        foundFridgeList.Add(appliance);
                    }
                }
            }

            // Display found appliances
            // DisplayAppliancesFromList(found, 0);
            DisplayAppliancesFromList(foundFridgeList, 0);
        }

        /// <summary>
        /// Displays Vacuums
        /// </summary>
        /// <param name="grade">Grade of vacuum to find (or null for any grade)</param>
        /// <param name="voltage">Vacuum voltage (or 0 for any voltage)</param>
        public override void DisplayVacuums()
        {
            Console.WriteLine("Enter battery voltage value. 18 V (low) or 24 V (high)");
            // Get user input as string
            // Create variable to hold voltage
            string userVolt = Console.ReadLine();
            int voltage;
            Console.WriteLine();

            if(userVolt != "18" && userVolt !="24")
            {
                Console.WriteLine("Invalid option.");
                return;
            }
            
            // Create found variable to hold list of found appliances.
            List<Appliance> foundVacList = new List<Appliance>();

            // Loop through Appliances
            // Check if current appliance is vacuum
            // Down cast current Appliance to Vacuum object
            // Vacuum vacuum = (Vacuum)appliance;
            // Test grade is "Any" or grade is equal to current vacuum grade and voltage is 0 or voltage is equal to current vacuum voltage
            // Add current appliance in list to found list
            foreach (Appliance appliance in Appliances)
            {
                if (appliance.Type == Appliance.ApplianceTypes.Vacuum)
                {
                    Vacuum vacuum = (Vacuum)appliance;

                    if (int.Parse(userVolt) == vacuum.BatteryVoltage)
                    {
                        foundVacList.Add(appliance);
                    }
                }
            }

            // Display found appliances
            // DisplayAppliancesFromList(found, 0);
            DisplayAppliancesFromList(foundVacList, 0);
        }

        /// <summary>
        /// Displays microwaves
        /// </summary>
        public override void DisplayMicrowaves()
        {
            Console.WriteLine("Room where the microwave will be installed: K (kitchen) or W (work site):");

            // Get user input as string and assign to variable
            string userRoom = Console.ReadLine();
            Console.WriteLine();

            if (userRoom != "K" && userRoom != "W")
            {
                Console.WriteLine("Invalid Option.");
                return;
            }

            // Create variable that holds list of 'found' appliances
            List<Appliance> foundMwList = new List<Appliance>();

            // Loop through Appliances
            // Test current appliance is Microwave
            // Down cast Appliance to Microwave
            // Test room type equals 'A' or microwave room type
            // Add current appliance in list to found list
            foreach (Appliance appliance in Appliances)
            {
                if (appliance.Type == Appliance.ApplianceTypes.Microwave)
                {
                    Microwave microwave = (Microwave)appliance;

                    if (char.Parse(userRoom) == microwave.RoomType)
                    {
                        foundMwList.Add(appliance);
                    }
                }
            }

            // Display found appliances
            // DisplayAppliancesFromList(found, 0);
            DisplayAppliancesFromList(foundMwList, 0);
        }

        /// <summary>
        /// Displays dishwashers
        /// </summary>
        public override void DisplayDishwashers()
        {
            Console.WriteLine("Enter the sound rating of the dishwasher: Qt (Quietest), Qr (Quieter), Qu(Quiet) or \r\nM (Moderate):");

            // Get user input as string and assign to variable
            string userSound = Console.ReadLine();
            Console.WriteLine();

            // Create variable that holds sound rating
            string soundRating = null;

            if (userSound != "Qt" && userSound != "Qr" && userSound != "Qu" && userSound != "M")
            {
                Console.WriteLine("Invalid option.");
                return;
            }

            // Create variable that holds list of found appliances
            List<Appliance> foundDishList = new List<Appliance>();

            // Loop through Appliances
            // Test if current appliance is dishwasher
            // Down cast current Appliance to Dishwasher
            // Test sound rating is "Any" or equals soundrating for current dishwasher
            // Add current appliance in list to found list
            foreach (Appliance appliance in Appliances)
            {
                if (appliance.Type == Appliance.ApplianceTypes.Dishwasher)
                {
                    Dishwasher dishwasher = (Dishwasher)appliance;

                    if (userSound == dishwasher.SoundRating)
                    {
                        foundDishList.Add(appliance);
                    }
                }
            }

            // Display found appliances (up to max. number inputted)
            // DisplayAppliancesFromList(found, 0);
            DisplayAppliancesFromList(foundDishList, 0);
        }

        /// <summary>
        /// Generates random list of appliances
        /// </summary>
        public override void RandomList()
        {
            // Write "Enter number of appliances: "
            Console.WriteLine("\nEnter Number of appliances:");

            // Get user input as string and assign to variable
            string userNum = Console.ReadLine();
            Console.WriteLine();

            // Convert user input from string to int
            int uNum = int.Parse(userNum);

            // Create variable to hold list of found appliances
            List<Appliance> randomAppList = new List<Appliance>();

            foreach(Appliance appliance in Appliances) 
            { 
                randomAppList.Add(appliance);
            }

            // Randomize list of found appliances
            // found.Sort(new RandomComparer());
            randomAppList.Sort(new RandomComparer());

            // Display found appliances (up to max. number inputted)
            // DisplayAppliancesFromList(found, num);
            DisplayAppliancesFromList(randomAppList, uNum);
        }
    }
}

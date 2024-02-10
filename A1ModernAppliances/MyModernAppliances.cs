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
            // Write "Possible options:"
            // Write "0 - Any"
            // Write "2 - Double doors"
            // Write "3 - Three doors"
            // Write "4 - Four doors"
            Console.WriteLine("Possible options:");
            Console.WriteLine("0 - Any");
            Console.WriteLine("2 - Double doors");
            Console.WriteLine("3 - Three doors");
            Console.WriteLine("4 - Four doors\n");

            // Write "Enter number of doors: "
            Console.WriteLine("Enter number of doors: ");

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
            // Write "Possible options:"
            // Write "0 - Any"
            // Write "1 - Residential"
            // Write "2 - Commercial"
            // Write "Enter grade:"
            Console.WriteLine("Possible options:");
            Console.WriteLine("0 - Any");
            Console.WriteLine("1 - Residential");
            Console.WriteLine("2 - Commercial\n");
            Console.WriteLine("Enter grade:");

            // Get user input as string and assign to variable
            string userType = Console.ReadLine();
            Console.WriteLine();

            // Create grade variable to hold grade to find (Any, Residential, or Commercial)
            string grade = null;

            // Test input is "0"
            // Assign "Any" to grade
            // Test input is "1"
            // Assign "Residential" to grade
            // Test input is "2"
            // Assign "Commercial" to grade
            // Otherwise (input is something else)
            // Write "Invalid option."
            // Return to calling (previous) method
            // return;
            if (userType == "0")
            {
                grade = "Any";
            }
            else if(userType == "1") 
            {
                grade = "Residential";
            }
            else if(userType == "2") 
            {
                grade = "Commercial";
            }
            else 
            {
                Console.WriteLine("Invlid option.");
                return;
            }

            // Write "Possible options:"
            // Write "0 - Any"
            // Write "1 - 18 Volt"
            // Write "2 - 24 Volt"
            // Write "Enter voltage:"
            Console.WriteLine("Possible options:");
            Console.WriteLine("0 - Any");
            Console.WriteLine("1 - 18 Volt");
            Console.WriteLine("2 - 24 Volt\n");
            Console.WriteLine("Enter voltage:");
            // Get user input as string
            // Create variable to hold voltage
            string userVolt = Console.ReadLine();
            int voltage;
            Console.WriteLine();

            // Test input is "0"
            // Assign 0 to voltage
            // Test input is "1"
            // Assign 18 to voltage
            // Test input is "2"
            // Assign 24 to voltage
            // Otherwise
            // Write "Invalid option."
            // Return to calling (previous) method
            // return;
            if(userVolt == "0") 
            {
                voltage = 0;
            }
            else if(userVolt == "1") 
            {
                voltage = 18;
            }
            else if (userVolt == "2") 
            {
                voltage = 24;
            }
            else 
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

                    if ((grade == "Any" || grade == vacuum.Grade) && (voltage == 0 || voltage == vacuum.BatteryVoltage))
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
            // Write "Possible options:"
            // Write "0 - Any"
            // Write "1 - Kitchen"
            // Write "2 - Work site"
            // Write "Enter room type:"
            Console.WriteLine("0 - Any");
            Console.WriteLine("1 - Kitchen");
            Console.WriteLine("2 - Work site\n");
            Console.WriteLine("Enter room type:");

            // Get user input as string and assign to variable
            string userRoom = Console.ReadLine();
            Console.WriteLine();

            // Create character variable that holds room type
            char roomType = ' ';

            // Test input is "0"
            // Assign 'A' to room type variable
            // Test input is "1"
            // Assign 'K' to room type variable
            // Test input is "2"
            // Assign 'W' to room type variable
            // Otherwise (input is something else)
            // Write "Invalid option."
            // Return to calling method
            // return;
            if(userRoom == "0")
            {
                roomType = 'A';
            }
            else if(userRoom == "1") 
            {
                roomType = 'K';
            }
            else if( userRoom == "2") 
            {
                roomType = 'W';
            }
            else 
            {
                Console.WriteLine("Invalid Option.");
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

                    if (roomType == 'A' || roomType == microwave.RoomType)
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
            // Write "Possible options:"
            // Write "0 - Any"
            // Write "1 - Quietest"
            // Write "2 - Quieter"
            // Write "3 - Quiet"
            // Write "4 - Moderate"
            // Write "Enter sound rating:"
            Console.WriteLine("0 - Any");
            Console.WriteLine("1 - Quietest");
            Console.WriteLine("2 - Quieter");
            Console.WriteLine("3 - Quiet");
            Console.WriteLine("4 - Moderate\n");
            Console.WriteLine("Enter sound rating");

            // Get user input as string and assign to variable
            string userSound = Console.ReadLine();
            Console.WriteLine();

            // Create variable that holds sound rating
            string soundRating = null;

            // Test input is "0"
            // Assign "Any" to sound rating variable
            // Test input is "1"
            // Assign "Qt" to sound rating variable
            // Test input is "2"
            // Assign "Qr" to sound rating variable
            // Test input is "3"
            // Assign "Qu" to sound rating variable
            // Test input is "4"
            // Assign "M" to sound rating variable
            // Otherwise (input is something else)
            // Write "Invalid option."
            // Return to calling method
            if(userSound == "0")
            {
                soundRating = "Any";
            }
            else if(userSound == "1") 
            {
                soundRating = "Qt";
            }
            else if(userSound == "2") 
            {
                soundRating = "Qr";
            }
            else if(userSound == "3") 
            {
                soundRating = "Qu";
            }
            else if(userSound == "4")
            {
                soundRating = "M";
            }
            else
            {
                Console.WriteLine("Invalid option.");
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

                    if (soundRating == "A" || soundRating == dishwasher.SoundRating)
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
            // Write "Appliance Types"

            // Write "0 - Any"
            // Write "1 – Refrigerators"
            // Write "2 – Vacuums"
            // Write "3 – Microwaves"
            // Write "4 – Dishwashers"

            // Write "Enter type of appliance:"
            Console.WriteLine("\nAppliance Types");
            Console.WriteLine("0 - Any");
            Console.WriteLine("1 - Refrigerators");
            Console.WriteLine("2 - Vacuums");
            Console.WriteLine("3 - Microwaves");
            Console.WriteLine("4 - Dishwashers");

            // Get user input as string and assign to appliance type variable
            string userAppType = Console.ReadLine();

            // Write "Enter number of appliances: "
            Console.WriteLine("\nEnter Number of appliances:");

            // Get user input as string and assign to variable
            string userNum = Console.ReadLine();
            Console.WriteLine();

            // Convert user input from string to int
            int uNum = int.Parse(userNum);

            // Create variable to hold list of found appliances
            List<Appliance> randomAppList = new List<Appliance>();

            // Loop through appliances
            // Test inputted appliance type is "0"
            // Add current appliance in list to found list
            // Test inputted appliance type is "1"
            // Test current appliance type is Refrigerator
            // Add current appliance in list to found list
            // Test inputted appliance type is "2"
            // Test current appliance type is Vacuum
            // Add current appliance in list to found list
            // Test inputted appliance type is "3"
            // Test current appliance type is Microwave
            // Add current appliance in list to found list
            // Test inputted appliance type is "4"
            // Test current appliance type is Dishwasher
            // Add current appliance in list to found list
            foreach(Appliance appliance in Appliances)
            {
                if(userAppType == "0")
                {
                    randomAppList.Add(appliance);
                }
                else if(userAppType == "1") 
                { 
                    if(appliance.Type == Appliance.ApplianceTypes.Refrigerator) 
                    {
                        randomAppList.Add(appliance);
                    }
                }
                else if (userAppType == "2") 
                {
                    if (appliance.Type == Appliance.ApplianceTypes.Vacuum)
                    {
                        randomAppList.Add(appliance);
                    }
                }
                else if (userAppType == "3")
                {
                    if (appliance.Type == Appliance.ApplianceTypes.Microwave)
                    {
                        randomAppList.Add(appliance);
                    }
                }
                else if (userAppType == "4")
                {
                    if (appliance.Type == Appliance.ApplianceTypes.Dishwasher)
                    {
                        randomAppList.Add(appliance);
                    }
                }
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

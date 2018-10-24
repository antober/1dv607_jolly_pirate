using System;
using System.Collections.Generic;
using System.IO;

namespace jolly_pirate
{
    class View
    {
        public void ShowStartMenu()
        {
            Console.WriteLine("╔════════════════════════════════════════════════╗");
            Console.WriteLine("║                                                ║");
            Console.WriteLine("║             Jolly Pirate Boat Club             ║");
            Console.WriteLine("║                                                ║");
            Console.WriteLine("╚════════════════════════════════════════════════╝");
            Console.ResetColor();
            Console.WriteLine(" 0 - Exit\n 1 - Register\n 2 - Select Member \n 3 - View Members List (Compact)\n 4 - View Members List (Verbose)");
            Console.WriteLine("==================================================");
            Console.Write("Enter your choice [0-4]:");
        }

        public string GetInputSSN()
        {
            Console.WriteLine("Enter Social security number:"); 
            string inputNumber = Console.ReadLine();

            return inputNumber;
        }

        public string GetInputName()
        {
            Console.WriteLine("Enter a full name:");
            string inputName = Console.ReadLine();

            return inputName;
        }
        public void ShowSuccessMessage()
        {
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("You are successfully saved!");
            Console.ResetColor();
            System.Console.WriteLine("Press Enter to return to previous menu");
        }

        public void ShowEnterID()
        {
            Console.WriteLine("Enter your ID:");
        }

        public int GetMemberID()
        {
            int inputNumber = Convert.ToInt32(Console.ReadLine());
            return inputNumber;
        }

        public void ShowErrorMessageMenu()
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("You need to enter a number between the given options!\nPress any key to continue, ESC exits ");
            Console.ResetColor();
        }

        public void ShowRegisterError(string error)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(error);
            Console.ResetColor();
        }

///////////////////////////////////// Member Menu ////////////////////////////////////////////////////

        public void ShowMemberMenu()
        {
            Console.ResetColor();
            Console.WriteLine(" 0 - Exit\n 1 - Add Boat\n 2 - Change Boat \n 3 - Delete Boat\n 4 - Change Memberinfo\n 5 - Delete Member");
            Console.WriteLine("==================================================");
            Console.Write("Enter your choice [0-5]:");
        }

        public void ShowBoatIsSaved(Boat boat)
        {
            System.Console.WriteLine("Saved:");
            System.Console.Write("type:  " + boat.Type + " | ");
            System.Console.Write("length:  " + boat.Length + " | ");
            System.Console.Write("id:  " + boat.Id);
        }

        public void ShowSavedMember(Member member)
        {
            System.Console.WriteLine("Saved:");
            System.Console.Write("Name:  " + member.Name + " | ");
            System.Console.Write("Social security number:  " + member.SSN + " | ");
            System.Console.Write("id:  " + member.Id);
            System.Console.WriteLine();
        }

        public int GetBoatTypes()
        {
            Console.WriteLine("Choose a boat type:");
            Console.WriteLine(" 0 - Kayak_or_Canoe\n 1 - Motorsailer\n 2 - Sailboat\n 3 - Other");
            int input;
            
            int.TryParse(Console.ReadLine(), out input);

            return input;
            
        }

        public int GetBoatLength()
        {
            Console.WriteLine("Type in legnth of boat:");
            int input;
            
            int.TryParse(Console.ReadLine(), out input);

            return input;
        }

        public int ChangeBoatInfoByID()
        {
          Console.WriteLine("Choose the ID of boat you would like to change:");
            int input;

            int.TryParse(Console.ReadLine(), out input);

            return input;
        }

        public int DeleteBoatByID()
        {
            Console.WriteLine("Enter the ID of boat:");
            int input;

            int.TryParse(Console.ReadLine(), out input);

            return input;
        }

        public string ChangeToInput()
        {
            Console.WriteLine("Plese enter new information:");
            string newInfo = Console.ReadLine();

            return newInfo;
        }

        public int DeleteMemberByID()
        {
            Console.WriteLine("Choose your memberID:");
            int input;

            int.TryParse(Console.ReadLine(), out input);

            return input;
        }

        public void ShowVerboseListOfMembers (List<Member> memberList) 
        {
            string boats = "";

            foreach (Member member in memberList) 
            {
                foreach(Boat boat in member.BoatList) 
                {
                    boats += "  Boat type: " + boat.Type + "  Length: " + boat.Length + "  Id: " + boat.Id;
                }
                Console.WriteLine ($"Name: {member.Name}, Social security number: {member.SSN}, MemberID: {member.Id},\nBoat list: {boats} \n");
            }
        }

        public void ShowCompactListOfMembers (List<Member> memberList) 
        {
            foreach (Member member in memberList) 
            {

                Console.WriteLine ($"Name: {member.Name}, Social security number: {member.SSN}, MemberID: {member.Id}, Number of boats: {member.BoatList.Count}");
            }
        }

        public void ShowBoatList(List<Boat> boatList)
        {
            foreach (Boat boat in boatList)
            {
                Console.Write(" {0} - " + "Id: {1} " + "Type: {2} " + "Length: {3}\n",
                boatList.IndexOf(boat), boat.Id, boat.Type, boat.Length);
            }
        }
    }
}
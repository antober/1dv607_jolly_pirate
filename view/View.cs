using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace jolly_pirate
{
    class View
    {

        public enum StartMenuAction 
        {
            Exit,
            Register,
            SelectMember,
            ViewCompactList,
            ViewVerboseList
        }

        public enum MemberMenuAction 
        {
            Exit,
            AddBoat,
            ChangeBoat,
            DeleteBoat,
            ChangeMemberInfo,
            DeleteMember
        }

        public StartMenuAction AskStartMenuAction() {
        
            const int min = 0;
            const int max = 4;

            int rawInput = AskForInt((input) => (input < min) || (input > max), (rawInputString) => "Try again.");

            switch (rawInput) 
            {
                case 0: return StartMenuAction.Exit;
                case 1: return StartMenuAction.Register;
                case 2: return StartMenuAction.SelectMember;
                case 3: return StartMenuAction.ViewCompactList;
                case 4: return StartMenuAction.ViewVerboseList;
                default: throw new ArgumentOutOfRangeException("Invalid menu choice.");
            }
        }

        public MemberMenuAction AskMemberMenuAction() 
        {
            const int min = 0;
            const int max = 5;

            int rawInput = AskForInt((input) => (input < min) || (input > max), (rawInputString) => "Try again.");

            switch (rawInput) 
            {
                case 0: return MemberMenuAction.Exit;
                case 1: return MemberMenuAction.AddBoat;
                case 2: return MemberMenuAction.ChangeBoat;
                case 3: return MemberMenuAction.DeleteBoat;
                case 4: return MemberMenuAction.ChangeMemberInfo;
                case 5: return MemberMenuAction.DeleteMember;
                default: throw new ArgumentOutOfRangeException("Invalid menu choice.");
            }
        }


        public void ShowStartMenu()
        {
            Console.WriteLine("╔════════════════════════════════════════════════╗\n" +
                              "║                                                ║\n" +
                              "║             Jolly Pirate Boat Club             ║\n" +
                              "║                                                ║\n" +
                              "╚════════════════════════════════════════════════╝");
            Console.ResetColor();
            Console.WriteLine(" 0 - Exit\n 1 - Register\n 2 - Select Member \n 3 - View Members List (Compact)\n 4 - View Members List (Verbose)");
            Console.WriteLine("==================================================");
            Console.Write("Enter your choice [0-4]:");
        }


        public string GetInputSSN()
        {
            Console.WriteLine("Enter Social security number (yymmddxxxx):"); 
            string inputNumber = Console.ReadLine();

            return inputNumber;
        }


        public string GetInputName()
        {
            Console.WriteLine("Enter a full name, between 3-16 charecters:");
            string inputName = Console.ReadLine();

            return inputName;
        }


        public void ShowSuccessMessage()
        {
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("You are successfully saved!");
            Console.ResetColor();
            Console.WriteLine("Press Enter to return to previous menu");
        }

        public void ShowEnterID()
        {
            Console.WriteLine("Enter your ID:");
        }

           public void ShowVerboseListOfMembers (List<Member> memberList) 
        {

              List<string[]> rows = new List<string[]>(new [] {
                new [] { "NAME", "SSN", "ID", "BOATS" }, });

            foreach (Member member in memberList) 
            {
                string boats = "";

                foreach(Boat boat in member.BoatList) 
                {
                    boats += "  Type: " + boat.Type + "  Length: " + boat.Length + "  Id: " + boat.Id;
                }
        
                rows.Add(new [] { member.Name, member.SSN, member.Id.ToString(), boats.ToString() });
            }

            string[] rendered = rows.Select(row => $"| {row[0],-15}| {row[1],-15}| {row[2],-15}| {row[3],-35}|").ToArray();
                        Console.WriteLine(rendered[0]);

            Console.WriteLine("".PadLeft(rendered[0].Count(), '-'));
            
            for (int i = 1; i < rendered.Count(); i++)
            {
                Console.WriteLine(rendered[i]);
            }
        }

        public void ShowCompactListOfMembers (List<Member> members) 
        {
            List<string[]> rows = new List<string[]>(new [] {
                new [] { "NAME", "SSN", "ID", "BOATS" },
            });

            foreach (Member member in members) {
                rows.Add(new [] { member.Name, member.SSN, member.Id.ToString(), member.BoatList.Count.ToString() });
            };

            string[] rendered = rows.Select(row => $"| {row[0],-15}| {row[1],-15}| {row[2],-15}| {row[3],-15}|").ToArray();

            Console.WriteLine(rendered[0]);

            Console.WriteLine("".PadLeft(rendered[0].Count(), '-'));
            
            for (int i = 1; i < rendered.Count(); i++)
            {
                Console.WriteLine(rendered[i]);
            }
        }

        public void ShowErrorMessageMenu()
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("You need to enter a number between the given options!\nPress any key to continue, ESC exits ");
            Console.ResetColor();
        }


///////////////////////////////////////////////////// Member Menu /////////////////////////////////////////////////////////////////////////

        public void ShowMemberMenu()
        {
            Console.ResetColor();
            Console.WriteLine(" 0 - Exit\n 1 - Add Boat\n 2 - Change Boat \n 3 - Delete Boat\n 4 - Change Memberinfo\n 5 - Delete Member\n" +
                              "==================================================\n" +
                              "Enter your choice [0-5]:");
        }

        public void ShowBoatIsSaved(Boat boat)
        {
            Console.WriteLine("Saved:\n" +
                                "type:  " + boat.Type + " | " +
                                "length:  " + boat.Length + " | " +
                                "id:  " + boat.Id);
        }

        public void ShowGetBoatTypes() 
        {
            Console.WriteLine("Choose a boat type:\n" +
                              " 0 - Kayak/Canoe\n 1 - Motorsailer\n 2 - Sailboat\n 3 - Other");
        }

        public int AskForInt(Func<int,bool> IsInvalid, Func<string,string> GenerateErrorMessage)
        {
            int input;
            string rawStringInput = Console.ReadLine();
            
            while (!int.TryParse(rawStringInput, out input) || IsInvalid(input))
            {
                Console.WriteLine(GenerateErrorMessage(rawStringInput));
                rawStringInput = Console.ReadLine();
            }
            return input;
        }

        public int AskForIntBetween(int min, int max) 
        {
            return AskForInt( (input) => (input < min) || (input > max), 
                (rawString) => $"{rawString} is not valid. Please enter an integer between {min} and {max}");
        }

        public int AskForInt()
        {
            return AskForInt((input) => false, (rawString) => "Not an integer. Try again.");
        }

        public void ShowGetBoatLength()
        {
            Console.WriteLine("Type in length of boat, between 1-20 m :");
        }

        public void ShowGetBoatByID()
        {
            Console.WriteLine("Choose the ID of boat you would like to change:");
        }

        public void ShowDeleteBoatByID()
        {
            Console.WriteLine("Enter the ID of the boat to delete it:");
        }

        public void ShowDeleteMemberByID()
        {
            Console.WriteLine("Choose your ID:");
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
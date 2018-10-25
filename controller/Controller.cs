using System;
using System.Collections.Generic;
using System.Linq;

namespace jolly_pirate 
{
    class Controller 
    {
        MemberDAL memberDAL;
        View view;

        RegisterModel registerModel;

        public Controller (MemberDAL memberDAL, View view, RegisterModel registerModel) 
        {
            this.memberDAL = memberDAL;
            this.view = view;
            this.registerModel = registerModel;
        }
        public void InitStartMenu () 
        {
            do 
            {
                Console.Clear();
                view.ShowStartMenu();
                int input;
                try 
                {
                    if (int.TryParse(Console.ReadLine(), out input) && input >= 0 && input <= 4) 
                    {
                        switch (input) 
                        {
                            case 0: 
                                return;
                            case 1:
                                registerModel.TryRegisterMember(view.GetInputSSN(), view.GetInputName());
                                // view.ShowSavedMember();
                                memberDAL.SaveToFile();
                                view.ShowSuccessMessage();

                                break;
                            case 2:
                                view.ShowEnterID();
                                Member member = memberDAL.GetMemberByID(view.GetMemberID());
                                view.ShowMemberMenu();
                                InitMemberMenu(member);
                                break;
                            case 3:
                                view.ShowCompactListOfMembers(memberDAL.GetMemberList());
                                break;
                            case 4:
                                view.ShowVerboseListOfMembers(memberDAL.GetMemberList());
                                break;
                        }
                    } 
                    else 
                    {
                        view.ShowErrorMessageMenu();
                    }
                } 
                catch (Exception e) 
                {
                    Console.WriteLine ("{0} Exception caught.", e);
                }
            }
            while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }


        public void InitMemberMenu(Member member)
        {
            int memberMenuInput;

            try 
            {
                if (int.TryParse(Console.ReadLine(), out memberMenuInput) && memberMenuInput >= 0 && memberMenuInput <= 5) 
                {
                    switch (memberMenuInput) 
                    {
                        case 0: 
                            return;

                        case 1:
                            view.ShowGetBoatTypes();
                            int givenBoatType = view.GetBoatTypes();
                            view.ShowGetBoatLentgh();
                            int givenBoatLength = view.GetBoatLength();

                            member.AddBoat(registerModel.CreateBoat(member, givenBoatType, givenBoatLength));
                            memberDAL.SaveToFile();
                            view.ShowBoatIsSaved(registerModel.CreateBoat(member, givenBoatType, givenBoatLength));

                            break;

                        case 2:
                            // Case Change Boat
                            view.ShowBoatList(member.BoatList);
                            view.ShowGetBoatByID();
                            int givenBoatID = view.BoatID();
                            view.ShowGetBoatTypes();
                            int boatType = view.GetBoatTypes();
                            view.ShowGetBoatLentgh();
                            int boatLength = view.GetBoatLength();

                            registerModel.ChangeBoat(member, givenBoatID, boatType, boatLength);
                            memberDAL.SaveToFile();
                            view.ShowBoatIsSaved(registerModel.CreateBoat(member, boatType, boatLength));

                            break;

                        case 3:
                            view.ShowBoatList(member.BoatList);
                            int boatID = view.DeleteBoatByID();
                            member.DeleteBoat(boatID);
                            memberDAL.SaveToFile();

                            break;
                        case 4:
                            view.ShowEnterID();
                            int oldMemberID = this.view.GetMemberID();
                            Member memberToUpdate = memberDAL.GetMemberByID(oldMemberID);
                            memberDAL.UpdateMember(member,this.view.GetInputName(), this.view.GetInputSSN());
                            memberDAL.SaveToFile();
                            view.ShowSuccessMessage();

                            break;
                        case 5:
                            memberDAL.DeleteMember(view.DeleteMemberByID());
                            memberDAL.SaveToFile();   

                            break;
                    }
                } 
                else 
                {
                    view.ShowErrorMessageMenu();
                }
            } 
            catch (Exception e) 
            {
                Console.WriteLine("{0} Exception caught.", e.Message);
            }
        }
    }
}
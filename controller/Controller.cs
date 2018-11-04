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
        public bool InitStartMenu () 
        {
            Console.Clear();
            view.ShowStartMenu();
            View.StartMenuAction input = view.AskStartMenuAction();
            
            switch (input) 
            {
                case View.StartMenuAction.Exit: 
                    return false;
                case View.StartMenuAction.Register:
                    registerModel.createMember(view.GetInputSSN(), view.GetInputName());
                    //TODO: Show register confirm
                    // view.ShowSavedMember();
                    memberDAL.SaveToFile();
                    view.ShowSuccessMessage();
                     return true;
                case View.StartMenuAction.SelectMember:
                    view.ShowEnterID();
                    Member member = memberDAL.GetMemberByID(view.GetMemberID());
                    view.ShowMemberMenu();
                    InitMemberMenu(member);
                     return true;
                case View.StartMenuAction.ViewCompactList:
                    view.ShowCompactListOfMembers(memberDAL.GetMemberList());
                     return true;
                case View.StartMenuAction.ViewVerboseList:
                    view.ShowVerboseListOfMembers(memberDAL.GetMemberList());
                     return true;
                default:
                    return false;
            }

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
                            int givenBoatType = view.AskForIntBetween(0,3);
                            view.ShowGetBoatLength();
                            int givenBoatLength = view.AskForIntBetween(1,20);

                            member.AddBoat(registerModel.CreateBoat(member, givenBoatType, givenBoatLength));
                            memberDAL.SaveToFile();
                            view.ShowBoatIsSaved(registerModel.CreateBoat(member, givenBoatType, givenBoatLength));

                            break;

                        case 2:
                            // Case Change Boat
                            view.ShowBoatList(member.BoatList);
                            view.ShowGetBoatByID();
                            int givenBoatID = view.AskForInt();
                            view.ShowGetBoatTypes();
                            int boatType = view.AskForIntBetween(0,3);
                            view.ShowGetBoatLength();
                            int boatLength = view.AskForIntBetween(1,20);

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
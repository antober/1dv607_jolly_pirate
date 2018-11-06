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
                    registerModel.CreateMember(view.GetInputSSN(), view.GetInputName());
                    //TODO: Show register confirm
                    memberDAL.SaveToFile();
                    view.ShowSuccessMessage();

                    return true;

                case View.StartMenuAction.SelectMember:
                    view.ShowEnterID();
                    Member member = memberDAL.GetMemberByID(view.AskForInt());
                    // view.ShowMemberMenu();
                    //InitMemberMenu(member);
                    while(InitMemberMenu(member)) 
                    {
                        Console.ReadKey(false);
                    };
                    
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


        public bool InitMemberMenu(Member member)
        {
            view.ShowMemberMenu();
            View.MemberMenuAction input = view.AskMemberMenuAction();
            switch (input) 
            {
                case View.MemberMenuAction.Exit: 

                    return false;

                case View.MemberMenuAction.AddBoat:
                    view.ShowGetBoatTypes();
                    int givenBoatType = view.AskForIntBetween(0,3);
                    view.ShowGetBoatLength();
                    int givenBoatLength = view.AskForIntBetween(1,20);

                    member.AddBoat(registerModel.CreateBoat(member, givenBoatType, givenBoatLength));
                    memberDAL.SaveToFile();
                    view.ShowBoatIsSaved(registerModel.CreateBoat(member, givenBoatType, givenBoatLength));

                    return true;

                case View.MemberMenuAction.ChangeBoat:
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

                    return true;

                case View.MemberMenuAction.DeleteBoat:
                    view.ShowBoatList(member.BoatList);
                    view.ShowDeleteBoatByID();
                    int boatID = view.AskForInt();
                    member.DeleteBoat(boatID);
                    memberDAL.SaveToFile();

                    return true;

                case View.MemberMenuAction.ChangeMemberInfo:
                    view.ShowEnterID();
                    int oldMemberID = view.AskForInt();
                    Member memberToUpdate = memberDAL.GetMemberByID(oldMemberID);
                    memberDAL.UpdateMember(member,this.view.GetInputName(), this.view.GetInputSSN());
                    memberDAL.SaveToFile();
                    view.ShowSuccessMessage();

                    return true;

                case View.MemberMenuAction.DeleteMember:
                    view.ShowDeleteMemberByID();
                    memberDAL.DeleteMember(view.AskForInt());
                    memberDAL.SaveToFile();   

                    return true;
                    default: return false;
            }
        }
    }
}
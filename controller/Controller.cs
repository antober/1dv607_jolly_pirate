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

        public Controller () 
        {
            memberDAL = new MemberDAL();
            view = new View();
            registerModel = new RegisterModel(memberDAL, view);
        }
        public void InitController () 
        {
            do 
            {
                Console.Clear();
                view.StartMenu();
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
                                registerModel.TryRegister(view.RegNumber(), view.RegFullName());
                                break;
                            case 2:
                                view.ShowEnterID();
                                Member member = memberDAL.GetMemberByID(view.SelectMemberWithID());
                                view.MemberMenu();
                                MemberMenuController(member);
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
                        view.ErrorMessageMenu();
                    }
                } 
                catch (Exception e) 
                {
                    Console.WriteLine ("{0} Exception caught.", e);
                }
            }
            while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }


        public void MemberMenuController(Member member)
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
                            registerModel.AddBoat();
                            memberDAL.SaveToFile();
                            break;

                        case 2:
                            view.ShowBoatList(member.BoatList);
                            registerModel.ChangeBoat(member);
                            break;

                        case 3:
                            view.ShowBoatList(member.BoatList);
                            int boatID = view.DeleteBoatByID();
                            member.DeleteBoat(boatID);
                            memberDAL.SaveToFile();

                            break;
                        case 4:
                            int oldMemberID = this.view.SelectMemberWithID();
                            Member memberToUpdate = memberDAL.GetMemberByID(oldMemberID);
                            memberDAL.UpdateMember(member,this.view.RegFullName(), this.view.RegNumber());
                            memberDAL.SaveToFile();

                            break;
                        case 5:
                            memberDAL.DeleteMember(view.DeleteMember());
                            memberDAL.SaveToFile();   

                            break;
                    }
                } 
                else 
                {
                    view.ErrorMessageMenu();
                }
            } 
            catch (Exception e) 
            {
                Console.WriteLine ("{0} Exception caught.", e);
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace jolly_pirate {
    class MemberDAL {
        public List<Member> memberList;
        private static string fileName = "members.json";

        /* Contrsuctor to have read oroginalfile at start,
            before inserting new data. */
        public MemberDAL () 
        {
            string originalData = File.ReadAllText (fileName);

            if (originalData == "") 
            {
                memberList = new List<Member> ();
            } 
            else 
            {
                memberList = JsonConvert.DeserializeObject<List<Member>> (originalData);
            }

        }

        public void SaveToFile () 
        {
            using (StreamWriter file = File.CreateText (fileName)) 
            {
                string json = JsonConvert.SerializeObject (memberList, Formatting.Indented);
                file.Write (json);
            }
        }

        public void AddMember (Member member)
        {
            memberList.Add(member);
        }

        public void DeleteMember(int memberID)
        {
            Member member = memberList.SingleOrDefault(x => x.Id == memberID);
            if (member != null)
            memberList.Remove(member);
            // SELECT MEMBER WHERE ID : get index 
        }
        public Member GetMemberByID(int Id) 
        {
            return memberList.Find(x => x.Id == Id);
        }

        public void CompactListOfMembers () 
        {
            foreach (Member member in memberList) 
            {

                Console.WriteLine ($"Name: {member.Name}, Social security number: {member.SSN}, memberID: {member.Id}, Number of boats: {member.BoatList.Count}");
            }
        }

        public void VerboseListOfMembers () 
        {
            string boats = "";

            foreach (Member member in memberList) 
            {
                foreach(Boat boat in member.BoatList) 
                {
                    boats += "  boat type: " + boat.Type + "  length: " + boat.Length + "  Id: " + boat.Id;
                
                }
                Console.WriteLine ($"name: {member.Name}, social security number: {member.SSN}, memberID: {member.Id},\nBoat list: {boats} \n");
            }
        }
    }
}
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
                this.memberList = new List<Member> ();
            } 
            else 
            {
                this.memberList = JsonConvert.DeserializeObject<List<Member>> (originalData);
            }

        }

        public void SaveToFile () 
        {
            using (StreamWriter file = File.CreateText (fileName)) 
            {
                string json = JsonConvert.SerializeObject (this.memberList, Formatting.Indented);
                file.Write (json);
            }
        }

        public void AddMember (Member member)
        {
            this.memberList.Add(member);
        }

        public void DeleteMember(int memberID)
        {
            var item = memberList.SingleOrDefault(x => x.Id == memberID);
            if (item != null)
            memberList.Remove(item);
            // SELECT MEMBER WHERE ID : get index 
        }
        public Member GetMemberByID(int Id) 
        {
            return this.memberList.Find(x => x.Id == Id);
        }

        public void CompactListOfMembers () 
        {
            foreach (var item in this.memberList) 
            {

                Console.WriteLine ($"Name: {item.Name}, Social security number: {item.SSN}, memberID: {item.Id}, Number of boats: {item.boatList.Count}");
            }
        }

        public void VerboseListOfMembers () 
        {
            string boats = "";

            foreach (var member in this.memberList) 
            {
                foreach(var boat in member.boatList) 
                {
                    boats += "  boat type: " + boat.Type + "  length: " + boat.Length + "  Id: " + boat.Id;
                
                }
                Console.WriteLine ($"name: {member.Name}, social security number: {member.SSN}, memberID: {member.Id},\nBoat list: {boats} \n");
            }
        }
    }
}
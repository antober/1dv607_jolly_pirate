using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace jolly_pirate 
{
    class MemberDAL 
    {
        public List<Member> memberList;
        private static string fileName = "members.json";

        /* Constructor to have read originalfile at start,
            before inserting new data. */
        public MemberDAL () 
        {
            string originalData = File.ReadAllText(fileName);

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


        public void UpdateMember(Member memberToUpdate, string newMemberName, string newSsn)
        {
            memberToUpdate.Name = newMemberName;
            memberToUpdate.SSN = newSsn;
        }


        public void DeleteMember(int memberID)
        {
            Member member = memberList.SingleOrDefault(x => x.Id == memberID);
            if (member != null)
            memberList.Remove(member);
        }

        
        public Member GetMemberByID(int Id) 
        {
            return memberList.Find(x => x.Id == Id);
        }


        public List<Member> GetMemberList()
        {
            return memberList;
        }
    }
}
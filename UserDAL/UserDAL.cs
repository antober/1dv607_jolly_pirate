using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace jolly_pirate {
    class UserDAL {
        public List<User> userInfo;
        private static string fileName = "users.json";

        // Contrsuctor to make oroginalfile read at start.
        public UserDAL () 
        {
            string originalData = File.ReadAllText (fileName);

            if (originalData == "") 
            {
                this.userInfo = new List<User> ();
            } 
            else 
            {
                this.userInfo = JsonConvert.DeserializeObject<List<User>> (originalData);
            }

        }

        public void SaveToFile () 
        {
            using (StreamWriter file = File.CreateText (fileName)) 
            {
                string json = JsonConvert.SerializeObject (this.userInfo, Formatting.Indented);
                file.Write (json);
            }
        }

        public void AddUser (User user)
        {
            this.userInfo.Add (user);
        }

        public void CompactListOfMembers () 
        {
            foreach (var item in this.userInfo) 
            {

                Console.WriteLine ($"Name: {item.fullName}, Social security number: {item.SSN}, memberID: {item.id}, Number of boats: {item.boatList.Count}");
            }
        }
        public void VerboseListOfMembers () 
        {
            string boats = "";

            foreach (var user in this.userInfo) 
            {
                foreach(var boat in user.boatList) 
                {
                    boats += boat;
                
                }
                Console.WriteLine ($"Name: {user.fullName}, Social security number: {user.SSN}, MemberID: {user.id}, Boat list: {boats}");
            }
        }
    }
}
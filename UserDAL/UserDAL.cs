using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace jolly_pirate {
    class UserDAL {
        public List<User> userInfo;
        private string fileName = "users.json";
        private User user;

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

        public void saveToFile () 
        {
            using (StreamWriter file = File.CreateText (fileName)) 
            {
                string json = JsonConvert.SerializeObject (this.userInfo, Formatting.Indented);
                file.Write (json);
            }
        }

        public void addUser (User user)
        {
            this.userInfo.Add (user);
        }

        public void compactListOfMembers () 
        {
            foreach (var item in this.userInfo) 
            {

                Console.WriteLine ($"Name: {item.fullName}, Social security number: {item.SSN}, memberID: {item.id}, Number of boats: {item.boatList.Count}");
            }
        }
        public void verboseListOfMembers () 
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
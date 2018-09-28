using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace jolly_pirate 
{
    class UserDAL 
    {
        public List<User> userInfo;
        private string fileName = "users.json"; 

        // Contrsuctor to make oroginalfile read at start.
        public UserDAL() {
            string originalData = File.ReadAllText(fileName);
             if (originalData == "") {
                this.userInfo = new List<User>();
            } else {
                this.userInfo = JsonConvert.DeserializeObject<List<User>>(originalData);
            }
        }


        public void addToFile(User user)
        {
            using (StreamWriter file = File.CreateText(fileName)) 
            {
                userInfo.Add(user);
                JsonConvert.SerializeObject(userInfo);               
                string json = JsonConvert.SerializeObject(userInfo);
                file.Write(json);
            }
        }

    }
}
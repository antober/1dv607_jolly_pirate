using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace jolly_pirate 
{
// TODO: Filen nollställs efter omstart av program. Ända det.
    class UserDAL 
    {
        public List<User> userInfo;

        // contrsuctor to make oroginalfile read at start.
        public UserDAL() {

            string originalData = File.ReadAllText("users.json");
            this.userInfo = JsonConvert.DeserializeObject<List<User>>(originalData);

        }
        public void addToFile(User user) 
        {
            using (StreamWriter file = File.CreateText("users.json")) 
            {
                
                userInfo.Add(user);
                
                JsonConvert.SerializeObject(userInfo);               
                string json = JsonConvert.SerializeObject(userInfo);
                
                file.Write(json);
            }
        }
    }
}
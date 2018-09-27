using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace jolly_pirate 
{
// TODO: Filen nollställs efter omstart av program. Ända det.
    class UserDAL 
    {
        public List<User> userInfo = new List<User>{};

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

        public void getAllUsers()
        {    
            string json = File.ReadAllText("users.json");
            List<string> deserializeUserInfo = JsonConvert.DeserializeObject<List<string>>(json);

            Console.WriteLine(deserializeUserInfo);
        }
    }
}
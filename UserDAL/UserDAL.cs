using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace jolly_pirate 
{

    class UserDAL 
    {
        private List<String> userInfo = new List<string> {};
        public void addToFile(User user) {

            using (StreamWriter file = File.CreateText ("users.json")) {
                
                userInfo.Add(user.getId ().ToString ());
                userInfo.Add(user.getSocialSecurityNumber());
                userInfo.Add(user.getFullName());
                
                JsonSerializer serializer = new JsonSerializer ();
                serializer.Serialize (file, userInfo);
            }
        }

        public void getAllUsers() 
        {    
            string json = File.ReadAllText("users.json");
            List<string> userinfo = JsonConvert.DeserializeObject<List<string>>(json);
            System.Console.WriteLine(string.Join(", ", userinfo));
        }
    }
}
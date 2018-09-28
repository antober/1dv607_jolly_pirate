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
            this.userInfo = JsonConvert.DeserializeObject<List<User>>(originalData);
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

        public List<User> getAllUsers(){

            //string originalData2 = File.ReadAllText(fileName);

            // var userInfo3 = JsonConvert.DeserializeObject<JArray>(originalData2);
            // int indexOfLast = userInfo3.Count - 1;


            // Console.WriteLine(userInfo3[indexOfLast]["id"]);
            // return;
            Console.WriteLine(this.userInfo);
            return this.userInfo;


        }
    }
}
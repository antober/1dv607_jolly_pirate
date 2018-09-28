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
            int indexOfLast = this.userInfo.Count - 1;
            // Console.WriteLine()


            Console.WriteLine(this.userInfo[indexOfLast].id);
            // return;
            return this.userInfo;

        }
    }
}
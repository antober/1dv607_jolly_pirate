using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace jolly_pirate {
    class UserDAL {
        public void addToFile (User user) 
        {
            
            using (StreamWriter file = File.CreateText("users.json")) 
            {
                
                JsonSerializer serializer = new JsonSerializer ();
                //serialize object directly into file stream
                
                serializer.Serialize(file, user);
            }        
        }

        public void getAllUsers () 
        {
            throw new Exception ("Not yet implemented");
        }
    }
}
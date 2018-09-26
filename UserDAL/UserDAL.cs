using System;
using System.Collections.Generic;
using System.IO;

namespace jolly_pirate
{
    class UserDAL
    {
        public void add(User user)
        {
            using (StreamWriter streamWriter = File.AppendText("users.txt"))
            {
                streamWriter.WriteLine(user.getSocialSecurityNumber());
            }
            

        }
    }
}   
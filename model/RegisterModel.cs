using System;

namespace jolly_pirate
{
    class RegisterModel
    {
        public void TryRegister(string number, string password)
        {
            if(number.Length != 10)
            {
                throw new Exception("Social number must contain 10 digits!");
            }

            if(password.Length < 6)
            {
                throw new Exception("Password must contain more than 6 characters");
            }
            
            else
            {
                User user = new User(number, password, 1);
                Console.WriteLine(user.getSocialSecurityNumber());
            }
        }
    }
}
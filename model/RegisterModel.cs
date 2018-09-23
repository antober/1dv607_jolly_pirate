using System;

namespace jolly_pirate
{
    class RegisterModel
    {
        private UserDAL _userDAL;
        public RegisterModel(UserDAL uDAL)
        {
            this._userDAL = uDAL;
        }
        public void TryRegister(string number, string password)
        {
            try
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
                    //Console.WriteLine(user.getSocialSecurityNumber());
                    this._userDAL.add(user);
                }
            }
            
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
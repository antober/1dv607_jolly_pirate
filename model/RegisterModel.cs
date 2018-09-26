using System;

namespace jolly_pirate
{
    class RegisterModel
    {
        private UserDAL _userDAL;
        private RegisterView _rv;
        public RegisterModel(UserDAL uDAL, RegisterView rv)
        {
            this._userDAL = uDAL;
            this._rv = rv;
        }
        public void TryRegister(string number)
        {
            try
            {
                if(number.Length != 10)
                {
                    throw new Exception("Social number must contain 10 digits!");
                }
                
                else
                {
                    User user = new User(number, "Joppe", 1);
                    this._userDAL.addToFile(user);
                    this._rv.regSuccess();
                    this._userDAL.getAllUsers();
                }
            }
            
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
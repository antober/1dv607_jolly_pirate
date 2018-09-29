using System;

namespace jolly_pirate
{
    class RegisterModel
    {
        private UserDAL _userDAL;
        private View _view;
        public RegisterModel(UserDAL uDAL, View view)
        {
            this._userDAL = uDAL;
            this._view = view;
        }
        public void TryRegister(string number, string name)
        {
            try
            {
                // Console.Write(numberOfDigits);

                if(number.Length != 10)
                {
                    throw new Exception("Social number must contain 10 digits!");
                }

                if(name.Length < 3)
                {
                    throw new Exception("Full name must have atleast 3 characters");
                }
                
                else
                {
                    User user = new User(number, name, GenerateID());
                    this._userDAL.addUser(user);
                    this._userDAL.saveToFile();
                    this._view.RegSuccess();

                }
            }
            
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        private int GenerateID()
        {
            if(this._userDAL.userInfo.Count == 0) {
               return 1;
            } else {
            int indexOfLast = this._userDAL.userInfo.Count - 1;
            return this._userDAL.userInfo[indexOfLast].id + 1;
            }
        }


    }
}
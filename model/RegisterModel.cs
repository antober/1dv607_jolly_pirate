using System;

namespace jolly_pirate
{
    class RegisterModel
    {
        private UserDAL _userDAL;
        private View _v;
        public RegisterModel(UserDAL uDAL, View v)
        {
            this._userDAL = uDAL;
            this._v = v;
        }
        public void TryRegister(string number, string name)
        {
            try
            {
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
                    User user = new User(number, name, GenerateID(0));
                    
                    this._userDAL.addToFile(user);
                    this._v.RegSuccess();
                    // this._userDAL.getAllUsers();

                    //System.Console.WriteLine(this._userDAL.getAllUsers().ToArray().Length);

                    // foreach (User u in this._userDAL.getAllUsers().ToArray())
                    // {
                    //     System.Console.WriteLine(u);
                    // }
                }
            }
            
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private int GenerateID(int id)
        {
            if(id == 0)
            {
                id = 1;
            }
            else
            {
                id ++;
            }

            return id;
        }

        public void SelectBoatType()
        {
            throw new Exception("Not yet implemented");
        }
    }
}
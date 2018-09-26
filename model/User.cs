using System;

namespace jolly_pirate
{
    class User
    {
        private string _socialSecurityNumber;
        private string _password;

        private int _id;

        public User(string socialSecurityNumber, string password, int id)
        {
            this._socialSecurityNumber = socialSecurityNumber;
            this._password = password;
            this._id = id;
        }

        private void setSocialSecurityNumber()
        {
            throw new Exception("Not yet implemented");
        }
        
        private void setPassword()
        {
            throw new Exception("Not yet implemented");
        }

        private void setId()
        {
            throw new Exception("Not yet implemented");
        }

        public string getSocialSecurityNumber()
        {
            return this._socialSecurityNumber;
        }
        

    }
}
using System;

namespace jolly_pirate
{
    class User
    {
        private string _socialSecurityNumber;
        private string _fullName;
        private int _id;

        // TODO: Have some type of way to Collect boats here.
        // TODO: Remove/ Add method as well.

        public User(string socialSecurityNumber, string fullName, int id)
        {
            this._socialSecurityNumber = socialSecurityNumber;
            this._fullName = fullName;
            this._id = id;
        }

<<<<<<< HEAD
        private void setSocialSecurityNumber()
        {
            throw new Exception("Not yet implemented");
        }
        
        private void setPassword()
        {
            throw new Exception("Not yet implemented");
        }
=======
/// i see dead people. 
>>>>>>> 2c17bd4866b219fb19e2ecfbfd1c6731ef0929df

        private int Id
        {
            get { return _id; }
        }

        public string SocialSecurityNumber
        {
           get { return this._socialSecurityNumber; }
           set 
           { 
               if(String.IsNullOrWhiteSpace(value) || value.Length != 10) 
               {
                   throw new Exception("Not valid social secirity number, enter 10 digits.");
               }
               _socialSecurityNumber = value;
           }
        }
         public string Name
        {
           get { return this._fullName; }
           set 
           {
               if(String.IsNullOrWhiteSpace(value)) 
               {
                   throw new Exception("No name given. Please enter a full name.");
               }
               _fullName = value;
            }
        } 
    }
}
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

/// i see dead people. 

        private void setId()
        {
            throw new Exception("Not yet implemented");
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
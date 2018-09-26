using System;
using System.Collections.Generic;

namespace jolly_pirate
{
    class User
    {
        private string _socialSecurityNumber;
        private string _fullName;
        private int _id;

        private List<Boat> _boatList;
        //= new List<Boat>();

        // TODO: Have some type of way to Collect boats here.
        // TODO: Remove/ Add method as well.

        public User(string socialSecurityNumber, string fullName, int id)
        {
            this._socialSecurityNumber = socialSecurityNumber;
            this._fullName = fullName;
            this._id = id;
        }

        public string getSocialSecurityNumber()
        {
            return this._socialSecurityNumber;
        }
        
        public string getFullName()
        {
            return this._fullName;
        }
        
        public int getId()
        {
            return this._id;
        }

        public List<Boat> getBoatList()
        {
            return this._boatList;
        }

        public void addBoat(Boat boat)
        {
            this._boatList.Add(boat);
        }
        //   public void removeBoat(/*ID*/)
        // {
        //     this._boatList.Remove(/*ID*/);
        // }
    }
}
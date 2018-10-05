using System;
namespace jolly_pirate
{

    class Boat
    {
        public int _id;
        private BoatType _type;
        private int _length;
        
        public Boat(int id, BoatType boatType, int length) 
        {
            Id = id;
            Type = boatType;
            Length = length;
        }
        public enum BoatType
        {
            Kayak_or_Canoe,
            Motorsailer,
            Sailboat,
            Other
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public BoatType Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public int Length
        {
            get { return _length; }
            set { _length = value; }
        }
    }
}
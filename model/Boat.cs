using System;
namespace jolly_pirate
{

    class Boat
    {
        public BoatType boatType;
        public int length;
        public int id;
        
        public Boat(int id, BoatType boatType, int length) 
        {
            this.boatType = boatType;
            this.length = length;
            this.id = id;
        }
        public enum BoatType
        {
            Kayak_or_Canoe,
            Motorsailer,
            Sailboat,
            Other
        }
    }
}
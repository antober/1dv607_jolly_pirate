using System;
namespace jolly_pirate
{

    class Boat
    {
        public BoatType boatType;
        public int boatLength;
        public int id;
        
        public Boat(int id, BoatType boatType, int boatLength) 
        {
            this.boatType = boatType;
            this.boatLength = boatLength;
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
using System;
namespace jolly_pirate
{

    class Boat
    {
        public BoatType boatType;
        public int boatLength;
        public string boatName;
        
        public Boat(string boatName, BoatType boatType, int boatLength) 
        {
            this.boatType = boatType;
            this.boatLength = boatLength;
            this.boatName = boatName;
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
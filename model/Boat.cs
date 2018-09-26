using System;
namespace jolly_pirate
{

    class Boat
    {
        private BoatType _boatType;
        private int _boatLength;
        private string _boatName;
        
        public Boat(BoatType boatType, int boatLength, string boatName) 
        {
            this._boatType = boatType;
            this._boatLength = boatLength;
            this._boatName = boatName;
        }
        public enum BoatType
        {
            Kayak_or_Canoe,
            Motorsailer,
            Salilboat,
            Other
        }

        public BoatType BoatTypeValidation
        {
            get { return _boatType; }
            set {
                //TODO: - Check if Enum has the type before setting.
                _boatType = value;
            }
        }

        public int BoatLengthInMeters 
        {

            get { return _boatLength; }
            set {
                if (value < 1 || value > 50) {

                    throw new Exception("Boatlength is not valid.");

                }
                _boatLength = value;
            }
        }
    }
}
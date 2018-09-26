using System;
namespace jolly_pirate
{

    class Boat
    {
        private BoatType _BoatType;
        private int _boatLength;
        
        
        
        public enum BoatType
        {
            Kayak_or_Canoe,
            Motorsailer,
            Salilboat,
            Other
        }

        public BoatType BoatTypeValidation
        {
            get { return _BoatType; }
            set {
                //TODO: - Check if Enum has the type before setting.
                _BoatType = value;
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
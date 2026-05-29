using Ex03.GarageLogic.Enums;

namespace Ex03.GarageLogic.Vehicles
{
    public abstract class Car : Vehicle
    {
        protected eCarColor m_Color;
        protected eDoorsAmount m_DoorsAmount;

        public eCarColor Color
        {
            get
            {
                return m_Color;
            }
        }

        public eDoorsAmount DoorsAmount
        {
            get
            {
                return m_DoorsAmount;
            }
        }

        protected Car(
            string i_LicenseNumber,
            string i_ModelName)
            : base(
                i_LicenseNumber,
                i_ModelName)
        {
        }

        public override string GetVehicleInfo()
        {
            return string.Empty;
        }
    }
}
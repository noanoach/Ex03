using Ex03.GarageLogic.Enums;

namespace Ex03.GarageLogic.Vehicles.Car
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

        public void InitializeCarDetails(
            eCarColor i_Color,
            eDoorsAmount i_DoorsAmount)
        {
            m_Color = i_Color;
            m_DoorsAmount = i_DoorsAmount;
        }

        protected string GetCarInfo()
        {
            return
                $"Color: {m_Color}{Environment.NewLine}" +
                $"Doors: {(int)m_DoorsAmount}";
        }
    }
}
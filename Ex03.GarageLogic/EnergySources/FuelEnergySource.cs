using Ex03.GarageLogic.Enums;

namespace Ex03.GarageLogic.EnergySources
{
    public class FuelEnergySource : EnergySource
    {
        private readonly eFuelType m_FuelType;

        public eFuelType FuelType
        {
            get
            {
                return m_FuelType;
            }
        }

        public FuelEnergySource(
            float i_CurrentAmount,
            float i_MaxAmount,
            eFuelType i_FuelType)
            : base(
                i_CurrentAmount,
                i_MaxAmount)
        {
            m_FuelType = i_FuelType;
        }

        public void Refuel(float i_FuelToAdd, eFuelType i_FuelType)
        {
            if (i_FuelToAdd < 0)
            {
                throw new ArgumentOutOfRangeException("Fuel to add must be non-negative.");
            }
            if (i_FuelType != m_FuelType)
            {
                throw new ArgumentException("Wrong fuel type.");
            }
            if(CurrentAmount + i_FuelToAdd > MaxAmount)
            {
                throw new ValueOutOfRangeException("Fuel amount would exceed maximum capacity.");
            }

            m_CurrentAmount += i_FuelToAdd;
        }
    }
}
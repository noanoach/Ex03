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
        }

        public void Refuel(
            float i_FuelToAdd,
            eFuelType i_FuelType)
        {
        }
    }
}
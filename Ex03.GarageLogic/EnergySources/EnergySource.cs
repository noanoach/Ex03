namespace Ex03.GarageLogic.EnergySources
{
    public abstract class EnergySource
    {
        protected float m_CurrentAmount;
        protected float m_MaxAmount;

        public float CurrentAmount
        {
            get
            {
                return m_CurrentAmount;
            }
        }

        public float MaxAmount
        {
            get
            {
                return m_MaxAmount;
            }
        }

        public float RemainingPercentage
        {
            get
            {
                return (m_CurrentAmount / m_MaxAmount) * 100f;
            }
        }

        protected EnergySource(
            float i_CurrentAmount,
            float i_MaxAmount)
        {
            m_CurrentAmount = i_CurrentAmount;
            m_MaxAmount = i_MaxAmount;
        }
    }
}
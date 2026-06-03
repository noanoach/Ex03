using System;
using System.Collections.Generic;
using System.Text;

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

        protected EnergySource(float i_CurrentAmount, float i_MaxAmount)
        {
            if(i_MaxAmount <= 0)
            {
                throw new ArgumentException("Max amount must be greater than zero.");
            }
            if(i_CurrentAmount < 0 || i_CurrentAmount > i_MaxAmount)
            {
                throw new ArgumentException("Current amount is out of bounds.");
            }
            m_CurrentAmount = i_CurrentAmount;
            m_MaxAmount = i_MaxAmount;
        }
    }
}

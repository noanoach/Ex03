using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic.Exceptions;

namespace Ex03.GarageLogic.EnergySources
{
    public class ElectricEnergySource : EnergySource
    {
        public ElectricEnergySource(float i_CurrentAmount, float i_MaxAmount)
            : base(i_CurrentAmount, i_MaxAmount)
        {
        }

        public void Charge(float i_HoursToAdd)
        {
            if (i_HoursToAdd < 0)
            {
                throw new ArgumentOutOfRangeException("Hours to add must be non-negative.");
            }
            if (m_CurrentAmount + i_HoursToAdd > m_MaxAmount)
            {
                throw new ValueRangeException("Charging would exceed maximum capacity.", 0, m_MaxAmount - m_CurrentAmount);
            }

            m_CurrentAmount += i_HoursToAdd;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic.EnergySources
{
    public class ElectricEnergySource : EnergySource
    {
        public ElectricEnergySource(
            float i_CurrentAmount,
            float i_MaxAmount)
            : base(
                i_CurrentAmount,
                i_MaxAmount)
        {
        }

        public void Charge(float i_HoursToAdd)
        {
        }
    }
}
using System;
using Ex03.GarageLogic.Enums;
using Ex03.GarageLogic.Exceptions;

namespace Ex03.GarageLogic.EnergySources
{
    public class FuelEnergySource : EnergySource
    {
        private readonly eFuelType r_FuelType;

        public eFuelType FuelType
        {
            get
            {
                return r_FuelType;
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
            r_FuelType = i_FuelType;
        }

        public void Refuel(float i_FuelToAdd, eFuelType i_FuelType)
        {
            if (i_FuelToAdd <= 0)
            {
                throw new ValueRangeException(
                    "Fuel amount must be positive.",
                    0,
                    MaxAmount - CurrentAmount);
            }

            if (i_FuelType != r_FuelType)
            {
                throw new ArgumentException("Wrong fuel type.");
            }

            if (CurrentAmount + i_FuelToAdd > MaxAmount)
            {
                throw new ValueRangeException(
                    "Fuel amount would exceed maximum capacity.",
                    0,
                    MaxAmount - CurrentAmount);
            }

            m_CurrentAmount += i_FuelToAdd;
        }

        public string GetFuelInfo()
        {
            string fuelInfo =
                $"Fuel Type: {r_FuelType}{Environment.NewLine}" +
                $"Current Fuel Amount: {CurrentAmount}{Environment.NewLine}" +
                $"Max Fuel Amount: {MaxAmount}";

            return fuelInfo;
        }
    }
}
using System;
using Ex03.GarageLogic.Exceptions;

namespace Ex03.GarageLogic.Components
{
    public class Wheel
    {
        private readonly string r_ManufacturerName;
        private float m_CurrentAirPressure;
        private readonly float r_MaxAirPressure;

        public string ManufacturerName
        {
            get
            {
                return r_ManufacturerName;
            }
        }

        public float CurrentAirPressure
        {
            get
            {
                return m_CurrentAirPressure;
            }
        }

        public float MaxAirPressure
        {
            get
            {
                return r_MaxAirPressure;
            }
        }

        public Wheel(
            string i_ManufacturerName,
            float i_CurrentAirPressure,
            float i_MaxAirPressure)
        {
            if (i_CurrentAirPressure < 0 || i_CurrentAirPressure > i_MaxAirPressure)
            {
                throw new ValueRangeException(
                    0,
                    i_MaxAirPressure);
            }

            r_ManufacturerName = i_ManufacturerName;
            m_CurrentAirPressure = i_CurrentAirPressure;
            r_MaxAirPressure = i_MaxAirPressure;
        }

        public void Inflate(float i_AirToAdd)
        {
            if (i_AirToAdd <= 0)
            {
                throw new ArgumentException("Air amount must be positive.");
            }

            if (m_CurrentAirPressure + i_AirToAdd > r_MaxAirPressure)
            {
                throw new ValueRangeException(
                    0,
                    r_MaxAirPressure);
            }

            m_CurrentAirPressure += i_AirToAdd;
        }

        public void InflateToMax()
        {
            m_CurrentAirPressure = r_MaxAirPressure;
        }
    }
}
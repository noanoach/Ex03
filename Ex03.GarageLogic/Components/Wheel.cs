using System;
using Ex03.GarageLogic.Exceptions;

namespace Ex03.GarageLogic.Components
{
    public class Wheel
    {
        private readonly string m_ManufacturerName;
        private float m_CurrentAirPressure;
        private readonly float m_MaxAirPressure;

        public string ManufacturerName
        {
            get
            {
                return m_ManufacturerName;
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
                return m_MaxAirPressure;
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

            m_ManufacturerName = i_ManufacturerName;
            m_CurrentAirPressure = i_CurrentAirPressure;
            m_MaxAirPressure = i_MaxAirPressure;
        }

        public void Inflate(float i_AirToAdd)
        {
            if (i_AirToAdd <= 0)
            {
                throw new ArgumentException("Air amount must be positive.");
            }

            if (m_CurrentAirPressure + i_AirToAdd > m_MaxAirPressure)
            {
                throw new ValueRangeException(
                    0,
                    m_MaxAirPressure);
            }

            m_CurrentAirPressure += i_AirToAdd;
        }

        public void InflateToMax()
        {
            m_CurrentAirPressure = m_MaxAirPressure;
        }
    }
}
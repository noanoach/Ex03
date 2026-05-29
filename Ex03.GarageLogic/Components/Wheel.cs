using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic.Components
{
    public class Wheel
    {
        private string m_ManufacturerName;
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
        }

        public void Inflate(float i_AirToAdd)
        {
        }

        public void InflateToMax()
        {
        }
    }
}
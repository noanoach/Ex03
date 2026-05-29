using System;

namespace Ex03.GarageLogic.Exceptions
{
    public class ValueRangeException : Exception
    {
        private readonly float m_MinValue;
        private readonly float m_MaxValue;

        public float MinValue
        {
            get
            {
                return m_MinValue;
            }
        }

        public float MaxValue
        {
            get
            {
                return m_MaxValue;
            }
        }

        public ValueRangeException(float i_MinValue, float i_MaxValue)
        {
        }

        public ValueRangeException(
            string i_Message,
            float i_MinValue,
            float i_MaxValue)
            : base(i_Message)
        {
        }
    }
}
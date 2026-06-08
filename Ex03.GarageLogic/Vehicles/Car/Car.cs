using System;
using System.Collections.Generic;
using Ex03.GarageLogic.Enums;

namespace Ex03.GarageLogic.Vehicles.Car
{
    public abstract class Car : Vehicle
    {
        protected eCarColor m_Color;
        protected eDoorsAmount m_DoorsAmount;

        public eCarColor Color
        {
            get
            {
                return m_Color;
            }
        }

        public eDoorsAmount DoorsAmount
        {
            get
            {
                return m_DoorsAmount;
            }
        }

        protected Car(
            string i_LicenseNumber,
            string i_ModelName)
            : base(
                i_LicenseNumber,
                i_ModelName)
        {
        }

        public void InitializeCarDetails(eCarColor i_Color, eDoorsAmount i_DoorsAmount)
        {
            m_Color = i_Color;
            m_DoorsAmount = i_DoorsAmount;
        }

        public override List<string> GetSpecificFieldNames()
        {
            return new List<string>{"Color", "Doors"};
        }

        public override void InitializeSpecificDetails(
            Dictionary<string, string> i_Data)
        {
            InitializeCarDetails(
                (eCarColor)Enum.Parse(
                    typeof(eCarColor),
                    i_Data["Color"]),
                (eDoorsAmount)int.Parse(
                    i_Data["Doors"]));
        }

        protected string GetCarInfo()
        {
            string carInfo =
                $"Color: {m_Color}{Environment.NewLine}" +
                $"Doors: {(int)m_DoorsAmount}";

            return carInfo;
        }
    }
}
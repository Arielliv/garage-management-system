﻿using System.Text;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private string m_ManifacturerName;
        private float m_MaxAirPressure;
        private float m_CurrentAirPressure = 0;

        internal Wheel(float i_MaxAirPressure)
        {
            this.m_MaxAirPressure = i_MaxAirPressure;
        }

        internal void SetCurrentAirPressure(float i_CurrentAirPressure)
        {
            if(i_CurrentAirPressure > this.m_MaxAirPressure || i_CurrentAirPressure < 0)
            {
                throw new ValueOutOfRangeException(0, this.m_MaxAirPressure);
            }
            else
            {
                this.m_CurrentAirPressure = i_CurrentAirPressure;
            }
        }

        internal float MaxAirPressure
        {
            get { return this.m_MaxAirPressure; }
            set { this.m_MaxAirPressure = value; }
        }

        internal string ManifacturerName
        {
            set { this.m_ManifacturerName = value; }
        }

        internal void InflateToMax()
        {
            this.inflate(this.MaxAirPressure - this.m_CurrentAirPressure);
        }

        private void inflate(float i_AirAmount)
        {
            float potentialAirPressure = this.m_CurrentAirPressure + i_AirAmount;

            if (potentialAirPressure <= this.m_MaxAirPressure && potentialAirPressure >= 0)
            {
                this.m_CurrentAirPressure = potentialAirPressure;
            }
            else
            {
                throw new ValueOutOfRangeException(0, this.m_MaxAirPressure);
            }
        }

        public override string ToString()
        {
            StringBuilder info = new StringBuilder();

            info.Append($"The manifacturer name is: {m_ManifacturerName}\n");
            info.Append($"The current air pressure is: {m_CurrentAirPressure}\n");

            return info.ToString();
        }
    }
}

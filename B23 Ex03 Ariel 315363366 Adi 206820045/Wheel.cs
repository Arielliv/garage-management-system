using System.Text;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private string m_ManifacturerName;
        private float m_MaxAirPressure;
        private float m_CurrentAirPressure = 0;

        public Wheel(float i_MaxAirPressure)
        {
            this.m_MaxAirPressure = i_MaxAirPressure;
        }

        public void setCurrentAirPressure(float i_CurrentAirPressure)
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

        public float MaxAirPressure
        {
            get { return this.m_MaxAirPressure; }
            set { this.m_MaxAirPressure = value; }
        }

        public string ManifacturerName
        {
            set { this.m_ManifacturerName = value; }
        }

        internal void InflateToMax()
        {
            this.Inflate(this.MaxAirPressure - this.m_CurrentAirPressure);
        }

        internal void Inflate(float i_AirAmount)
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

        public string GetManifacturerNameAndCurrentAirPressure()
        {
            StringBuilder info = new StringBuilder();

            info.Append($"The manifacturer name is: {m_ManifacturerName}\n");
            info.Append($"The current air pressure is: {m_CurrentAirPressure}\n");

            return info.ToString();
        }
    }
}

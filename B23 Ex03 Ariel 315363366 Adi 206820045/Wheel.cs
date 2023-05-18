using System.Text;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private string m_ManifacturerName;
        private float m_MaxAirPressure;
        private float m_CurrentAirPressure;

        public float MaxAirPressure
        {
            get { return this.m_MaxAirPressure; }
            set { this.m_MaxAirPressure = value; }
        }
        internal void inflate(float i_AirAmount)
        {
            float potentialAirPressure = this.m_CurrentAirPressure + i_AirAmount;

            if (potentialAirPressure <= this.m_MaxAirPressure)
            {
                this.m_CurrentAirPressure = potentialAirPressure;
            }
        }

        public Wheel(float i_MaxAirPressure)
        {
            this.m_MaxAirPressure = i_MaxAirPressure;
            this.m_CurrentAirPressure = i_MaxAirPressure;
        }

        public string GetManifacturerNameAndCurrentAirPressure()
        {
            StringBuilder info = new StringBuilder();

            info.Append($"The manifacturer name is: {m_ManifacturerName}");
            info.Append($"The current air pressure is: {m_CurrentAirPressure}");

            return info.ToString();
        }
    }
}

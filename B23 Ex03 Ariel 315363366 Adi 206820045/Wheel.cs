namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private readonly string r_ManifacturerName;
        private float r_MaxAirPressure;
        private float m_CurrentAirPressure;

        internal void inflate(float i_AirAmount)
        {
            float potentialAirPressure = this.m_CurrentAirPressure + i_AirAmount;

            if (potentialAirPressure <= this.r_MaxAirPressure)
            {
                this.m_CurrentAirPressure = potentialAirPressure;
            }
        }

        public Wheel(string i_ManifacturerName, float i_MaxAirPressure, float i_CurrentAirPressure)
        {
            this.r_ManifacturerName = i_ManifacturerName;
            this.r_MaxAirPressure = i_MaxAirPressure;
            this.m_CurrentAirPressure = i_CurrentAirPressure;
        }
    }
}

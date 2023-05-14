namespace Ex03.GarageLogic
{
    class Wheel
    {
        private readonly string r_ManifacturerName;
        private readonly float r_MaxAirPressure;
        private float m_CurrentAirPressure;

        internal void inflate(float i_AirAmount)
        {
            float potentialAirPressure = this.m_CurrentAirPressure + i_AirAmount;

            if (potentialAirPressure <= this.r_MaxAirPressure)
            {
                this.m_CurrentAirPressure = potentialAirPressure;
            }
        }
    }
}

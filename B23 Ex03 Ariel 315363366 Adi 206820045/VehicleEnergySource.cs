namespace Ex03.GarageLogic
{
    public abstract class VehicleEnergySource
    {
        private float m_CurrentEnergyAmount;
        private float m_MaxEnergyAmount;

        public float CurrentEnergyAmount
        {
            get { return this.m_CurrentEnergyAmount; }
            set { this.m_CurrentEnergyAmount = value; }
        }

        public float MaxEnergyAmount
        {
            get { return this.m_MaxEnergyAmount; }
            set { this.m_MaxEnergyAmount = value; }
        }

        public abstract string GetInfo();
    }
}

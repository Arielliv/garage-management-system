using System;
using System.Text;

namespace Ex03.GarageLogic
{
    public class ElectricEnergySource : VehicleEnergySource
    {
        public void ChargeEnergy(float i_MinutesToCharge)
        {
            float potentialMinutes = base.CurrentEnergyAmount + i_MinutesToCharge;

            if (potentialMinutes > base.MaxEnergyAmount)
            {
                throw new ArgumentException("The given minutes are passing the max");
            }
            else
            {
                base.CurrentEnergyAmount = potentialMinutes;
            }
        }

        public override string GetInfo()
        {
            StringBuilder info = new StringBuilder();

            info.Append($"The current energy minutes is: {base.CurrentEnergyAmount}\n");

            return info.ToString();
        }
    }
}

using System;
using System.Text;

namespace Ex03.GarageLogic
{
    public class FuelEnergySource : VehicleEnergySource
    {
        private readonly eFuelTypes m_FuelType;

        public FuelEnergySource(eFuelTypes i_FuelType): base()
        {
            this.m_FuelType = i_FuelType;
        }

        public void FillFuel(float i_AmountToFill, eFuelTypes i_FuelType)
        {
            if(i_FuelType != this.m_FuelType)
            {
                throw new ArgumentException("The given fuel type is invalid for the selected vehicle");
            }

            float potentialFuelAmount = base.CurrentEnergyAmount + i_AmountToFill;

            if (potentialFuelAmount > base.MaxEnergyAmount)
            {
                throw new ArgumentException("The given amount to fill is passing the max");
            } 
            else
            {
                base.CurrentEnergyAmount = potentialFuelAmount;
            }
        }

        public override string GetInfo()
        {
            StringBuilder info = new StringBuilder();

            info.Append($"The current fuel amount is: {base.CurrentEnergyAmount}");
            info.Append($"The fuel type is: {this.m_FuelType}");

            return info.ToString();
        }
    }
}

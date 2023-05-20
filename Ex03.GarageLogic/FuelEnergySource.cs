using System;
using System.Text;

namespace Ex03.GarageLogic
{
    internal class FuelEnergySource : VehicleEnergySource
    {
        private readonly eFuelTypes r_FuelType;

        internal FuelEnergySource(eFuelTypes i_FuelType): base()
        {
            this.r_FuelType = i_FuelType;
        }

        internal void FillFuel(float i_AmountToFill, eFuelTypes i_FuelType)
        {
            float potentialFuelAmount;

            if (i_FuelType != this.r_FuelType)
            {
                throw new ArgumentException("The given fuel type is invalid for the selected vehicle");
            }

            potentialFuelAmount = base.CurrentEnergyAmount + i_AmountToFill;
            if (potentialFuelAmount > base.MaxEnergyAmount)
            {
                throw new ValueOutOfRangeException(0, base.MaxEnergyAmount);
            } 
            else
            {
                base.CurrentEnergyAmount = potentialFuelAmount;
            }
        }

        public override string ToString()
        {
            StringBuilder info = new StringBuilder();

            info.Append($"The current fuel amount is: {base.CurrentEnergyAmount}\n");
            info.Append($"The fuel type is: {this.r_FuelType}\n");

            return info.ToString();
        }
    }
}

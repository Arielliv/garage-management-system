using System.Collections.Generic;
using System.Text;
using System;

namespace Ex03.GarageLogic
{
    internal class Car : Vehicle
    {
        private eCarColors m_CarColor;
        private eCarDoorsAmounts m_CarDoorsAmount;
        private const int k_WheelsAmount = 5;
        private const int k_WheelsMaxAirPressure = 33;
        private const float k_MaxFuelAmount = 46;
        private const float k_MaxEnergyAmount = 5.2f;
        private const eFuelTypes k_FuelType = eFuelTypes.Octan95;

        internal Car(string i_ModelName, string i_LicenseNumber) : 
            base(i_ModelName, i_LicenseNumber, k_WheelsAmount, k_WheelsMaxAirPressure) {}

        public override bool SetSpecificInformation(string i_Message, int i_SpecificInformationNumber)
        {
            bool isSuccessful = false;

            if (i_SpecificInformationNumber == (int)eCarSpecificInformation.Color)
            {
                eCarColors carColor;

                if (Enum.TryParse(i_Message, out carColor)
                    && Enum.IsDefined(typeof(eCarColors), carColor))
                {
                    isSuccessful = true;
                    this.m_CarColor = carColor;
                }
            }
            else if (i_SpecificInformationNumber == (int)eCarSpecificInformation.DoorsNumber)
            {
                eCarDoorsAmounts carDoorsAmount;

                if (Enum.TryParse(i_Message, out carDoorsAmount)
                    && Enum.IsDefined(typeof(eCarDoorsAmounts), carDoorsAmount))
                {
                    isSuccessful = true;
                    this.m_CarDoorsAmount = carDoorsAmount;
                }
            }

            return isSuccessful;
        }
        public override string GetInfo()
        {
            StringBuilder info = new StringBuilder();

            info.Append($"This is a Car");
            info.Append(base.GetInfo());
            info.Append($"Its color is: {this.getCarColor()}");
            info.Append($"Its doors amount is: {this.getCarDoorsAmount()}");

            return info.ToString();
        }

        private string getCarColor()
        {
            string carColor = null;

            switch (this.m_CarColor)
            {
                case eCarColors.Black:
                    carColor = "black";
                    break;
                case eCarColors.Red:
                    carColor = "red";
                    break;
                case eCarColors.White:
                    carColor = "white";
                    break;
                case eCarColors.Yellow:
                    carColor = "yellow";
                    break;
                default:
                    break;
            }

            return carColor;
        }

        private string getCarDoorsAmount()
        {
            string carDoorAmount = null;

            switch (this.m_CarDoorsAmount)
            {
                case eCarDoorsAmounts.Two:
                    carDoorAmount = "two";
                    break;
                case eCarDoorsAmounts.Three:
                    carDoorAmount = "three";
                    break;
                case eCarDoorsAmounts.Four:
                    carDoorAmount = "four";
                    break;
                case eCarDoorsAmounts.Five:
                    carDoorAmount = "five";
                    break;
                default:
                    break;
            }

            return carDoorAmount;
        }

        public override void SetVehicleEnergyAsFuel()
        {
            base.VehicleEnergySource = new FuelEnergySource(k_FuelType);
            base.VehicleEnergySource.MaxEnergyAmount = k_MaxFuelAmount;
        }

        public override void SetVehicleEnergyAsElectric()
        {
            base.VehicleEnergySource = new ElectricEnergySource();
            base.VehicleEnergySource.MaxEnergyAmount = k_MaxEnergyAmount;
        }
    }
}

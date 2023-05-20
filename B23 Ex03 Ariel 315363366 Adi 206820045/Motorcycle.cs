using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    internal class Motorcycle : Vehicle
    {
        private eLicenseTypes m_LicenseType;
        private int m_EngineCapacity;
        private const int k_WheelsAmount = 2;
        private const int k_WheelsMaxAirPressure = 31;
        private const float k_MaxFuelAmount = 6.4f;
        private const float k_MaxEnergyAmount = 2.6f;
        private const eFuelTypes k_FuelType = eFuelTypes.Octan98;

        internal Motorcycle(string i_ModelName, string i_LicenseNumber) :
    base(i_ModelName, i_LicenseNumber, k_WheelsAmount, k_WheelsMaxAirPressure) { }

        public override string GetInformation()
        {
            StringBuilder info = new StringBuilder();

            info.Append($"This is a Car\n");
            info.Append(base.GetInformation()).Append("\n");
            info.Append($"Its license type is: {this.getLicenseTypes()}\n");
            info.Append($"Its engine capacity is: {this.m_EngineCapacity}\n");

            return info.ToString();
        }

        private string getLicenseTypes()
        {
            string licenseType = null;

            switch (this.m_LicenseType)
            {
                case eLicenseTypes.A1:
                    licenseType = "A1";
                    break;
                case eLicenseTypes.A2:
                    licenseType = "A2";
                    break;
                case eLicenseTypes.AA:
                    licenseType = "AA";
                    break;
                case eLicenseTypes.B1:
                    licenseType = "B1";
                    break;
                default:
                    break;
            }

            return licenseType;
        }

        public override bool SetSpecificInformation(string i_Message, int i_SpecificInformationNumber)
        {
            bool isSuccessful = false;

            if (i_SpecificInformationNumber == (int)eMotorcycleSpecificInformation.EngineCapacity)
            {
                int engineCapacity;

                if (int.TryParse(i_Message, out engineCapacity))
                {
                    isSuccessful = true;
                    this.m_EngineCapacity = engineCapacity;
                }
            }
            else if (i_SpecificInformationNumber == (int)eMotorcycleSpecificInformation.LicenseType)
            {
                eLicenseTypes licenseType;

                if (Enum.TryParse(i_Message, out licenseType)
                    && Enum.IsDefined(typeof(eLicenseTypes), licenseType))
                {
                    isSuccessful = true;
                    this.m_LicenseType = licenseType;
                }
            }

            return isSuccessful;
        }

        public override void SetSpecificInformationMessages()
        {
            base.r_SpecificInformationMessages.Add((int)eMotorcycleSpecificInformation.EngineCapacity,
                "the motocycle's engine capacity: ");
            base.r_SpecificInformationMessages.Add((int)eMotorcycleSpecificInformation.LicenseType,
                "the motorcycle license type, press " +
                "0 - A1, 1 - A2, 2 - AA, 3 - B1: ");
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

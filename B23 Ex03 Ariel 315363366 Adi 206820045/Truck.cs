using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    internal class Truck : Vehicle
    {
        private bool m_TransportsHazardousMaterials;
        private float m_CargoVolume;
        private const int k_WheelsAmount = 14;
        private const int k_WheelsMaxAirPressure = 26;
        private const float k_MaxFuelAmount = 135;
        private const eFuelTypes k_FuelType = eFuelTypes.Soler;

        internal Truck(string i_ModelName, string i_LicenseNumber) :
            base(i_ModelName, i_LicenseNumber, k_WheelsAmount, k_WheelsMaxAirPressure) { }


        public override bool SetSpecificInformation(string i_Message, int i_SpecificInformationNumber)
        {
            bool isSuccessful = false;

            if (i_SpecificInformationNumber == (int)eTruckSpecificInformation.TransportsHazardousMaterials)
            {
                bool transportsHazardousMaterials;

                if (bool.TryParse(i_Message, out transportsHazardousMaterials))
                {
                    isSuccessful = true;
                    this.m_TransportsHazardousMaterials = transportsHazardousMaterials;
                }
            }
            else if (i_SpecificInformationNumber == (int)eTruckSpecificInformation.CargoVolume)
            {
                float cargoVolume;

                if (Enum.TryParse(i_Message, out cargoVolume))
                {
                    isSuccessful = true;
                    this.m_CargoVolume = cargoVolume;
                }
            }

            return isSuccessful;
        }

        public override string GetInfo()
        {
            StringBuilder info = new StringBuilder();

            info.Append($"This is a Truck");
            info.Append(base.GetInfo());
            info.Append(this.m_TransportsHazardousMaterials ? "It transports hazardous materials": "It doesn`t transport hazardous materials");
            info.Append($"The cargo volume is: {this.m_CargoVolume}");

            return info.ToString();
        }

        public override void SetVehicleEnergyAsFuel()
        {
            base.VehicleEnergySource = new FuelEnergySource(k_FuelType);
            base.VehicleEnergySource.MaxEnergyAmount = k_MaxFuelAmount;
        }

        public override void SetVehicleEnergyAsElectric()
        {
            base.VehicleEnergySource = new ElectricEnergySource();
        }
    }
}

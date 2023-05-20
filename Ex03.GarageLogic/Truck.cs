using System;
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
            bool transportsHazardousMaterials;
            bool isSuccessful = false;
            float cargoVolume;

            if (i_SpecificInformationNumber == (int)eTruckSpecificInformation.TransportsHazardousMaterials)
            {
                if (bool.TryParse(i_Message, out transportsHazardousMaterials))
                {
                    isSuccessful = true;
                    this.m_TransportsHazardousMaterials = transportsHazardousMaterials;
                }
            }
            else if (i_SpecificInformationNumber == (int)eTruckSpecificInformation.CargoVolume)
            {
                if (float.TryParse(i_Message, out cargoVolume))
                {
                    isSuccessful = true;
                    this.m_CargoVolume = cargoVolume;
                }
            }

            return isSuccessful;
        }

        public override void SetSpecificInformationMessages()
        {
            base.r_SpecificInformationMessages.Add((int)eTruckSpecificInformation.CargoVolume,
                "the trucks's cargo volume: ");
            base.r_SpecificInformationMessages.Add((int)eTruckSpecificInformation.TransportsHazardousMaterials,
                "does your truck transport hazardous materials? (True/False): ");
        }

        public override string ToString()
        {
            StringBuilder info = new StringBuilder();

            info.Append($"This is a Truck\n");
            info.Append(base.ToString());
            info.Append(this.m_TransportsHazardousMaterials ? "It transports hazardous materials": "It doesn`t transport hazardous materials\n");
            info.Append($"The cargo volume is: {this.m_CargoVolume}\n");

            return info.ToString();
        }

        public override void SetVehicleEnergyAsFuel()
        {
            base.VehicleEnergySource = new FuelEnergySource(k_FuelType);
            base.VehicleEnergySource.MaxEnergyAmount = k_MaxFuelAmount;
        }

        public override void SetVehicleEnergyAsElectric()
        {
            throw new Exception("Unfortunately we don't support electric truck");
        }
    }
}

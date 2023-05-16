using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    internal class Truck : Vehicle
    {
        private readonly bool r_TransportsHazardousMaterials;
        private readonly float r_CargoVolume;

        internal Truck(string i_ModelName, string i_LicenseNumber, float i_LeftEnergyPercentage,
            List<Wheel> i_Wheels, eVehicleEnergyTypes i_VehicleEnergyType, VehicleEnergySource i_VehicleEnergySource,
            VehicleInfo i_VehicleInfo, bool i_TransportsHazardousMaterials, float i_CargoVolume) : base(i_ModelName,
                i_LicenseNumber, i_LeftEnergyPercentage, new List<Wheel>(), i_VehicleEnergyType, i_VehicleEnergySource,
            i_VehicleInfo)
        {
            this.r_TransportsHazardousMaterials = i_TransportsHazardousMaterials;
            this.r_CargoVolume = i_CargoVolume;
        }
    }
}

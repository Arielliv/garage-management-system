using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    internal class Motorcycle : Vehicle
    {
        private readonly eLicenseTypes r_LicenseType;
        private readonly int r_EngineCapacity;

        internal Motorcycle(string i_ModelName, string i_LicenseNumber, float i_LeftEnergyPercentage,
            List<Wheel> i_Wheels, eVehicleEnergyTypes i_VehicleEnergyType, VehicleEnergySource i_VehicleEnergySource,
            VehicleInfo i_VehicleInfo, eLicenseTypes i_LicenseType, int i_EngineCapacity) : base(i_ModelName,
                i_LicenseNumber, i_LeftEnergyPercentage, new List<Wheel>(), i_VehicleEnergyType, i_VehicleEnergySource,
            i_VehicleInfo)
        {
            this.r_LicenseType = i_LicenseType;
            this.r_EngineCapacity = i_EngineCapacity;
        }
    }
}

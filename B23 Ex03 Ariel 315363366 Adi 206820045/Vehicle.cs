using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        private readonly string r_ModelName;
        private readonly string r_LicenseNumber;
        private float m_LeftEnergyPercentage;
        private readonly List<Wheel> r_Wheels;
        private readonly eVehicleEnergyTypes r_VehicleEnergyType;
        private readonly VehicleEnergySource r_VehicleEnergySource;
        private readonly VehicleInfo r_VehicleInfo;

        public string LicenseNumber
        {
            get { return this.r_LicenseNumber; }
        }

        public Vehicle(string i_ModelName, string i_LicenseNumber, float i_LeftEnergyPercentage,
            List<Wheel> i_Wheels, eVehicleEnergyTypes i_VehicleEnergyType, VehicleEnergySource i_VehicleEnergySource,
            VehicleInfo i_VehicleInfo)
        {
            this.r_ModelName = i_ModelName;
            this.r_LicenseNumber = i_LicenseNumber;
            this.m_LeftEnergyPercentage = i_LeftEnergyPercentage;
            this.r_Wheels = i_Wheels;
            this.r_VehicleEnergyType = i_VehicleEnergyType;
            this.r_VehicleEnergySource = i_VehicleEnergySource;
            this.r_VehicleInfo = i_VehicleInfo;
        }
    }
}

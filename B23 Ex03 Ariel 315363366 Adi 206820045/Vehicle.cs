using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    class Vehicle
    {
        private readonly string r_ModelName;
        private readonly string r_LicenseNumber;
        private float m_LeftEnergyPercentage;
        private List<Wheel> m_Wheels;
        private eVehicleEnergyTypes m_VehicleEnergySource;
    }
}

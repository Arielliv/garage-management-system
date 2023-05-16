using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    internal class Car : Vehicle
    {
        private readonly eCarColors r_CarColor;
        private readonly eCarDoorsAmounts r_CarDoorsAmount;

        internal Car(string i_ModelName, string i_LicenseNumber, float i_LeftEnergyPercentage,
            List<Wheel> i_Wheels, eVehicleEnergyTypes i_VehicleEnergyType, VehicleEnergySource i_VehicleEnergySource,
            VehicleInfo i_VehicleInfo, eCarColors i_CarColor, eCarDoorsAmounts i_CarDoorsAmount) : base(i_ModelName,
                i_LicenseNumber, i_LeftEnergyPercentage, new List<Wheel>(), i_VehicleEnergyType, i_VehicleEnergySource,
            i_VehicleInfo)
        {
            this.r_CarColor = i_CarColor;
            this.r_CarDoorsAmount = i_CarDoorsAmount;
        }

    }
}

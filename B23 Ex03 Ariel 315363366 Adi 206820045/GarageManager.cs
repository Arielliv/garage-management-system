using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class GarageManager
    {
        private readonly Dictionary<string, Vehicle> r_CarsInGarage = new Dictionary<string, Vehicle>();

        public Vehicle GetVehicleFromGarage(string i_LicenseNumber)
        {
            return this.r_CarsInGarage[i_LicenseNumber];
        }

        public void AddNewVehicle(Vehicle i_Vehicle)
        {
            this.r_CarsInGarage.Add(i_Vehicle.LicenseNumber, i_Vehicle);
        }

        public bool IsVehicleExistInGarage(string i_LicenseNumber)
        {
            return this.r_CarsInGarage.ContainsKey(i_LicenseNumber);
        }
    }
}

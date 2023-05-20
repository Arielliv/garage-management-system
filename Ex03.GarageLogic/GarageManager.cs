using System.Collections.Generic;
using System;

namespace Ex03.GarageLogic
{
    public class GarageManager
    {
        private readonly Dictionary<string, Vehicle> r_VehiclesInGarage = new Dictionary<string, Vehicle>();

        private Vehicle getVehicleFromGarage(string i_LicenseNumber)
        {
            return this.r_VehiclesInGarage[i_LicenseNumber];
        }

        public void AddNewVehicle(Vehicle i_Vehicle)
        {
            this.r_VehiclesInGarage.Add(i_Vehicle.LicenseNumber, i_Vehicle);
        }

        public bool IsVehicleExistInGarage(string i_LicenseNumber)
        {
            return this.r_VehiclesInGarage.ContainsKey(i_LicenseNumber);
        }

        public List<string> GetLicenseNumbersByFilter(eFilterVehicleByStatuses i_FilterVehicleByStatuses)
        {
            List<string> licenseNumbers = new List<string>();

            foreach(KeyValuePair<string, Vehicle> pair in this.r_VehiclesInGarage)
            {
                if(i_FilterVehicleByStatuses == eFilterVehicleByStatuses.All
                    || (int)pair.Value.VehicleStatus == (int)i_FilterVehicleByStatuses)
                {
                    licenseNumbers.Add(pair.Key);
                }
            }

            return licenseNumbers;
        }

        public void SetVehicleStatus(string i_LicenseNumber, eVehicleStatuses i_NewVehicleStatus)
        {
            this.getVehicleFromGarage(i_LicenseNumber).VehicleStatus = i_NewVehicleStatus;
        }

        public void InflateVehicleWheels(string i_LicenseNumber)
        {
            this.getVehicleFromGarage(i_LicenseNumber).InflateWheelsToMax();
        }

        public eVehicleEnergyTypes GetVehicleEnergyType(string i_LicenseNumber)
        {
            if(this.getVehicleFromGarage(i_LicenseNumber).VehicleEnergySource is ElectricEnergySource)
            {
                return eVehicleEnergyTypes.Electric;
            }
            else
            {
                return eVehicleEnergyTypes.Fuel;
            }
        }

        public void FillVehicleFuel(string i_LicenseNumber, float i_FuelAmountToFill, eFuelTypes i_FuelType)
        {
            try
            {
                ((FuelEnergySource)this.getVehicleFromGarage(i_LicenseNumber).VehicleEnergySource).FillFuel(i_FuelAmountToFill, i_FuelType);

            }
            catch (InvalidCastException)
            {
                throw new ArgumentException("Vehicle energy source is not fuel");
            }
        }

        public void ChargeVehicleEnergy(string i_LicenseNumber, float i_MinutesToCharge)
        {
            try
            {
                ((ElectricEnergySource)this.getVehicleFromGarage(i_LicenseNumber).VehicleEnergySource).ChargeEnergy(i_MinutesToCharge);

            }
            catch (InvalidCastException)
            {
                throw new ArgumentException("Vehicle energy source is not electric");
            }
        }

        public string GetFullVehicleInformation(string i_LicenseNumber)
        {
            return this.getVehicleFromGarage(i_LicenseNumber).ToString();   
        }
    }
}

namespace Ex03.GarageLogic
{
    public static class VehicleCreator
    {
        public static Vehicle CreateVehicle(string i_Model, string i_LicenseNumber, eVehicleTypes i_VehicleType)
        {
            Vehicle newVehicle = null;
            
            switch(i_VehicleType)
            {
                case (eVehicleTypes.Car):
                {
                    newVehicle = new Car(i_Model, i_LicenseNumber);
                    break;
                }
                case (eVehicleTypes.Truck):
                {
                    newVehicle = new Truck(i_Model, i_LicenseNumber);
                    break;
                }
                case (eVehicleTypes.Motorcycle):
                    {
                        newVehicle = new Motorcycle(i_Model, i_LicenseNumber);
                        break;
                    }
            }

            return newVehicle;
        }
    }
}

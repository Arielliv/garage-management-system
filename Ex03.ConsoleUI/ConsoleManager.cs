using System;
using Ex03.GarageLogic;
using System.Collections.Generic;

namespace Ex03.ConsoleUI
{
    public class ConsoleManager
    {
        private readonly GarageManager r_GarageManager = new GarageManager();

        public void GarageManager()
        {
            Console.WriteLine("Welcome to the garage!!");
            bool stayInTheGarage = true;

            while (stayInTheGarage)
            {
                try
                {
                    showGarageMenu();
                    eGarageMenuOptions userChoice = (eGarageMenuOptions)Enum.Parse(typeof(eGarageMenuOptions), Console.ReadLine());
                    switch (userChoice)
                    {
                        case eGarageMenuOptions.AddNewVehicle:
                            //AddNewVehicleToTheGarage();
                            break;
                        /*case eGarageMenuOptions.ShowVehicleLicenseNumbers:
                            showVehicleLicenseNumber();
                            break;
                        case eGarageMenuOptions.UpdateVehicleStatus:
                            updateVehicleStatus(GetLicenseNumber());
                            break;
                        case eGarageMenuOptions.InflateWheels:
                            inflateWheels(GetLicenseNumber());
                            break;
                        case eGarageMenuOptions.FillFuelVehicle:
                            fillFuelVehicle(GetLicenseNumber());
                            break;
                        case eGarageMenuOptions.ChargeElectricVehicle:
                            chargeElectricVehicle(GetLicenseNumber());
                            break;
                        case eGarageMenuOptions.ShowFullVehicleInformation:
                            showFullVehicleInformation(GetLicenseNumber());
                            break;
                        case eGarageMenuOptions.Exit:
                            stayInTheGarage = false;
                            Console.WriteLine("Goodbye, Thank you for choosing our garage");
                            break;*/
                        default:
                            Console.WriteLine("Invalid number! Please try again");
                            break;
                    }
                }
               /* catch (ValueOutOfRangeException exception)
                {
                    Console.WriteLine(exception.Message);
                }*/
                catch (ArgumentNullException exception)
                {
                    Console.WriteLine(exception.Message);
                }
                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);
                }
                catch (FormatException exception)
                {
                    Console.WriteLine(exception.Message);
                }
                catch (NullReferenceException exception)
                {
                    Console.WriteLine(exception.Message);
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }
        }

        private void showGarageMenu()
        {
            Console.WriteLine(string.Format(@"Please enter your choice number: 
1. Add a new vehicle to the garage
2. Show vehicle license numbers 
3. Change vehicle status 
4. Inflate air pressure to max
5. Fuel vehicle
6. Charge electric vehicle
7. Print vehicle information according to license number
8. Exit menu
"));
        }
/*
        private string GetLicenseNumber()
        {
            Console.WriteLine("Please enter your vehicle license number: ");
            string licenseNumber = Console.ReadLine();
            bool isExist = r_GarageManager.IsVehicleExistInGarage(licenseNumber);
            if (!isExist)
            {
                throw new ArgumentException("The vehicle has not been registered in the garage (yet)!");
            }

            return licenseNumber;
        }

        private void getVehicleEnergySource()
        {
            int numberOfInputOptions = Enum.GetNames(typeof(eVehicleEnergyTypes)).Length;
            bool isValidInput = false;
            while (!isValidInput)
            {
                Console.WriteLine(string.Format(@"Please enter the vehicle appropriate energy source:
0 - Fuel
1 - Electric
"));
                int vehicleEnergySource = Validator.ValidateUserInput(Console.ReadLine(), numberOfInputOptions);
                if (vehicleEnergySource != ConstValues.k_InValid)
                {
                    bool isFuel = vehicleEnergySource == (int)eVehicleEnergyTypes.Fuel;
                    bool isElectricity = vehicleEnergySource == (int)eVehicleEnergyTypes.Electric;
                    if ((isFuel && !m_NewVehicle.FuelEnergySource) || (isElectricity && !m_NewVehicle.ElectricityEnergySource))
                    {
                        Console.WriteLine("Unfortunately our garage doesn't accept such vehicles");
                        continue;
                    }

                    isValidInput = true;
                    m_NewVehicle.EnergySourceType = (eVehicleEnergyTypes)vehicleEnergySource;
                }
                else
                {
                    Console.WriteLine("Invalid input of energy source");
                }
            }
        }

        private void SetMaximalEnergySourceValue()
        {
            if (eVehicleEnergyTypes.Fuel.Equals(m_NewVehicle.EnergySourceType))
            {
                m_NewVehicle.SetFuelMaximalQuantity();
            }
            else
            {
                m_NewVehicle.SetElectricMaximalQuantity();
            }
        }

        private float GetCurrentEnergySourceQuantity()
        {
            bool isValidInput = false;
            float energySourceQuantity = 0f;
            while (!isValidInput)
            {
                Console.WriteLine("Please enter your current energy source quantity: ");
                bool isSuccessfulParse = Validator.IsFloatInput(Console.ReadLine(), ref energySourceQuantity);
                if (isSuccessfulParse)
                {
                    float maximalEnergySourceQuantity = m_NewVehicle.EnergySource.MaximalEnergySourceQuantity;
                    if (energySourceQuantity <= maximalEnergySourceQuantity && energySourceQuantity >= ConstValues.k_MinValue)
                    {
                        isValidInput = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Input!");
                    }
                }
                else
                {
                    Console.WriteLine("Please make sure to insert a float number!");
                }
            }

            return energySourceQuantity;
        }

        private void SetMinimalEnergySourceValue()
        {
            m_NewVehicle.SetCurrentEnergySourceQuantity(GetCurrentEnergySourceQuantity());
        }

        private void SetRegistrationInformation()
        {
            Console.WriteLine("Please enter your name: ");
            string ownerName = Console.ReadLine();
            string ownerPhoneNumber = string.Empty;
            bool isValidInput = false;
            while (!isValidInput)
            {
                Console.WriteLine("Please enter your phone number: ");
                ownerPhoneNumber = Console.ReadLine();
                if (Validator.NumbersOnlyInput(ownerPhoneNumber))
                {
                    isValidInput = true;
                }
                else
                {
                    Console.WriteLine("Please make sure that your phone number contains numbers only!");
                }
            }

            m_NewVehicle.SetRegistrationInformation(ownerName, ownerPhoneNumber);
        }

        private void SetWheelsInformation()
        {
            foreach (Wheel wheel in m_NewVehicle.WheelCollection)
            {
                bool isValidInput = false;
                while (!isValidInput)
                {
                    Console.WriteLine("Please enter the wheel's current air pressure: ");
                    float airPressure = 0f;
                    bool isSuccessfulParse = Validator.IsFloatInput(Console.ReadLine(), ref airPressure);
                    if (isSuccessfulParse)
                    {
                        if (airPressure <= wheel.MaxAirPressure && airPressure >= ConstValues.k_MinValue)
                        {
                            isValidInput = true;
                            wheel.CurrentAirPressure = airPressure;
                        }
                        else
                        {
                            Console.WriteLine("Invalid Input!");
                            continue;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid Input ! please insert a float");
                    }
                }

                Console.WriteLine("Please enter the wheel's manufacturer:");
                string manufacturerName = Console.ReadLine();
                wheel.ManufacturerName = manufacturerName;
            }
        }

        private void SetUniqueProperties(Dictionary<int, string> i_Messages)
        {
            foreach (KeyValuePair<int, string> pair in i_Messages)
            {
                bool isValidInput = false;
                while (!isValidInput)
                {
                    Console.WriteLine($"Please enter {pair.Value}");
                    string userInput = Console.ReadLine();
                    isValidInput = m_NewVehicle.SetUniqueInformation(userInput, pair.Key);
                    if (!isValidInput)
                    {
                        Console.WriteLine("Invalid Input!");
                    }
                }
            }
        }

        private void showVehicleLicenseNumber()
        {
            List<string> licenseNumbers;
            Console.WriteLine(string.Format(@"Please filter which vehicles you would like to see:
0 - In repair vehicles
1 - Repaired vehicles
2 - Paid vehicles
3 - All vehicles
"));
            int numberOfInputOptions = Enum.GetNames(typeof(eFilterByStatus)).Length;
            int filterByStatus = Validator.ValidateUserInput(Console.ReadLine(), numberOfInputOptions);
            if (filterByStatus == ConstValues.k_InValid)
            {
                throw new FormatException("Format exception has occurred");
            }

            licenseNumbers = r_GarageManager.SetLicenseNumbersList((eFilterByStatus)filterByStatus);
            if (licenseNumbers.Count == 0)
            {
                Console.WriteLine(
                    filterByStatus == (int)eFilterByStatus.AllVehicles
                        ? "There are no vehicles in the garage"
                        : "There are no vehicles in the chosen status");
            }
            else
            {
                Console.WriteLine("The vehicles are:");
                foreach (string licenseNumber in licenseNumbers)
                {
                    Console.WriteLine(licenseNumber);
                }
            }
        }

        private void updateVehicleStatus(string i_LicenseNumber)
        {
            Console.WriteLine(string.Format(@"Please enter your new desired car status: 
0 - In repair vehicle
1 - Repaired vehicle
2 - Paid vehicle
"));
            int numberOfInputOptions = Enum.GetNames(typeof(eVehicleStatus)).Length;
            int filterByStatus = Validator.ValidateUserInput(Console.ReadLine(), numberOfInputOptions);
            if (filterByStatus == ConstValues.k_InValid)
            {
                throw new FormatException("Format exception has occurred");
            }

            r_Garage.SetVehicleStatus(i_LicenseNumber, (eVehicleStatus)filterByStatus);
        }

        private void inflateWheels(string i_LicenseNumber)
        {
            this.r_GarageManager.InflateWheelToMax(i_LicenseNumber);
        }

        private void fillFuelVehicle(string i_LicenseNumber)
        {
            if (this.r_GarageManager.RegisteredGarageVehicles[i_LicenseNumber].EnergySource is Electric)
            {
                Console.WriteLine("The vehicle's energy source is not Fuel!");

                return;
            }

            Console.WriteLine("Please enter the required Fuel quantity: ");
            float fuelDesiredQuantity = 0f;
            bool isSuccessfulParse = Validator.IsFloatInput(Console.ReadLine(), ref fuelDesiredQuantity);
            if (!isSuccessfulParse)
            {
                throw new FormatException("Format exception has occurred");
            }

            eFuelTypes fuelType = (this.r_GarageManager.RegisteredGarageVehicles[i_LicenseNumber].EnergySource as FuelEnergySource).FuelType;
            r_Garage.Fueling(i_LicenseNumber, fuelType, fuelDesiredQuantity);
        }

        private void chargeElectricVehicle(string i_LicenseNumber)
        {
            if (this.r_GarageManager.RegisteredGarageVehicles[i_LicenseNumber].EnergySource is FuelEnergySource)
            {
                Console.WriteLine("The vehicle's energy source is not electricity!");

                return;
            }

            Console.WriteLine("Please enter the time (in minutes) charging the vehicle");
            float chargingMinutes = 0f;
            bool isSuccessfulParse = Validator.IsFloatInput(Console.ReadLine(), ref chargingMinutes);
            if (!isSuccessfulParse)
            {
                throw new FormatException("Format exception has occurred");
            }

            float chargingHours = (float)(chargingMinutes / ConstValues.k_MinutesInHour);
            this.r_GarageManager.ElectricCharging(i_LicenseNumber, chargingHours);
        }

        private void showFullVehicleInformation(string i_LicenseNumber)
        {
            Console.WriteLine(this.r_GarageManager.VehicleString(i_LicenseNumber));
        }
*/    }
}
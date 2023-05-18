using System;
using Ex03.GarageLogic;
using System.Collections.Generic;

namespace Ex03.ConsoleUI
{
    public class ConsoleManager
    {
        private readonly GarageManager r_GarageManager = new GarageManager();
        private Vehicle m_NewVehicle;

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
                            AddNewVehicleToTheGarage();
                            break;
                        case eGarageMenuOptions.ShowVehicleLicenseNumbers:
                            this.showVehicleLicenseNumber();
                            break;
                        case eGarageMenuOptions.UpdateVehicleStatus:
                            this.updateVehicleStatusInGarage();
                            break;
                        case eGarageMenuOptions.InflateWheels:
                            this.inflateWheels();
                            break;
                        case eGarageMenuOptions.FillFuelVehicle:
                            this.fillFuelVehicle();
                            break;
                        case eGarageMenuOptions.ChargeElectricVehicle:
                            this.chargeElectricVehicle();
                            break;
                        case eGarageMenuOptions.ShowFullVehicleInformation:
                            this.showFullVehicleInformation();
                            break;
                        case eGarageMenuOptions.Exit:
                            stayInTheGarage = false;
                            Console.WriteLine("Goodbye, Thank you for choosing our garage");
                            break;
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
        private void setVehicleEnergySource()
        {
            bool isValidInput = false;

            while (!isValidInput)
            {
                Console.WriteLine(string.Format(@"Please enter the vehicle energy source:
        0 - Fuel
        1 - Electric
        "));
                string vehicleEnergySourceInput = Console.ReadLine();
                eVehicleEnergyTypes vehicleEnergyType;

                if (!(Enum.TryParse(vehicleEnergySourceInput, out vehicleEnergyType)
                && Enum.IsDefined(typeof(eVehicleEnergyTypes), vehicleEnergyType)))
                {
                    Console.WriteLine("Invalid input of energy source");
                } 
                else
                {
                    isValidInput = true;
                    if (vehicleEnergyType == eVehicleEnergyTypes.Fuel)
                    {
                        this.m_NewVehicle.SetVehicleEnergyAsFuel();
                    } 
                    else
                    {
                        this.m_NewVehicle.SetVehicleEnergyAsElectric();
                    }
                }
            }
        }

        private void setCurrentEnergySourceQuantity()
        {
            bool isValidInput = false;

            while (!isValidInput)
            {
                Console.WriteLine("Please enter your current energy source quantity: ");
                string energySourceQuantityInput = Console.ReadLine();
                float energySourceQuantity = 0f;

                if (!(float.TryParse(energySourceQuantityInput, out energySourceQuantity) &&  energySourceQuantity <= this.m_NewVehicle.VehicleEnergySource.MaxEnergyAmount && energySourceQuantity > 0))
                {
                    Console.WriteLine("Invalid amount of energy source");
                }
                else
                {
                    isValidInput = true;
                    this.m_NewVehicle.VehicleEnergySource.CurrentEnergyAmount = energySourceQuantity;
                }
            }
        }

        private void SetVehicleInformation()
        {
            Console.WriteLine("Please enter your name: ");
            string ownerName = Console.ReadLine();
            string ownerPhoneNumberInput = null;
            int ownerPhoneNumber;
            bool isValidInput = false;

            while (!isValidInput)
            {
                Console.WriteLine("Please enter your phone number: ");
                ownerPhoneNumberInput = Console.ReadLine();
                if (!int.TryParse(ownerPhoneNumberInput, out ownerPhoneNumber))
                {
                    Console.WriteLine("Please make sure that your phone number contains numbers only!");
                }
                else
                {
                    isValidInput = true;
                }
            }

            m_NewVehicle.SetRegistrationInformation(ownerName, ownerPhoneNumber);
        }


        /*


       

                
                

               

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
        */
        private void showVehicleLicenseNumber()
        {
            List<string> licenseNumbers;
            Console.WriteLine(string.Format(@"Please filter which vehicles you would like to see:
0 - In repair vehicles
1 - Repaired vehicles
2 - Paid vehicles
3 - All vehicles
"));
            //int numberOfInputOptions = Enum.GetNames(typeof(eFilterVehicleByStatuses)).Length;
            string filterVehicleByStatusesInput = Console.ReadLine();
            eFilterVehicleByStatuses filterVehicleByStatuses;

            if (!(Enum.TryParse(filterVehicleByStatusesInput, out filterVehicleByStatuses)
                && Enum.IsDefined(typeof(eFilterVehicleByStatuses), filterVehicleByStatuses)))
            {
                throw new FormatException("Selected filter in not defined");
            }

            licenseNumbers = r_GarageManager.GetLicenseNumbersByFilter(filterVehicleByStatuses);
            if (licenseNumbers.Count == 0)
            {
                Console.WriteLine("No vehicles were found for the selected filter");
            }
            else
            {
                Console.WriteLine("The founded vehicle license numbers are:");
                foreach (string licenseNumber in licenseNumbers)
                {
                    Console.WriteLine(licenseNumber);
                }
            }
        }

        private void updateVehicleStatusInGarage()
        {
            string licenseNumber = getLicenseNumberFromUser();

            Console.WriteLine(string.Format(@"Please enter the new vehicle status: 
        0 - In repair
        1 - Repaired
        2 - Paid
        "));
            string newVehicleStatusInput = Console.ReadLine();
            eVehicleStatuses newVehicleStatus;

            if (!(Enum.TryParse(newVehicleStatusInput, out newVehicleStatus)
                && Enum.IsDefined(typeof(eVehicleStatuses), newVehicleStatus)))
            {
                throw new FormatException("Selected status in not defined");
            }

            this.r_GarageManager.SetVehicleStatus(licenseNumber, newVehicleStatus);
        }

        private string getLicenseNumberFromUser()
        {
            Console.Write("Please enter the vehicle's license number: ");
            string licenseNumber = Console.ReadLine();
            bool isCarExistInGarage = this.r_GarageManager.IsVehicleExistInGarage(licenseNumber);

            if(!isCarExistInGarage)
            {
                throw new ArgumentException("No vehicle's found with the given license number");
            }

            return licenseNumber;
        }

        private void inflateWheels()
        {
            string licenseNumber = getLicenseNumberFromUser();
            this.r_GarageManager.InflateVehicleWheels(licenseNumber);
        }

        private void fillFuelVehicle()
        {
            string licenseNumber = getLicenseNumberFromUser();

            if (this.r_GarageManager.GetVehicleEnergyType(licenseNumber) != eVehicleEnergyTypes.Fuel)
            {
                throw new ArgumentException("The vehicle's energy source is not fuel");
            }

            Console.WriteLine(@"Please enter the Fuel type: 
        0 - Soler,
        1 - Octan95,
        2 - Octan96,
        3 - Octan98");
            string fuelTypeInput = Console.ReadLine();
            eFuelTypes fuelType;

            if (!(Enum.TryParse(fuelTypeInput, out fuelType)
                && Enum.IsDefined(typeof(eFuelTypes), fuelType)))
            {
                throw new FormatException("Selected fuel in not defined");
            }

            Console.WriteLine("Please enter the fuel amount to fill: ");
            float fuelAmount;

            if (!float.TryParse(Console.ReadLine(), out fuelAmount))
            {
                throw new FormatException("The given input is not a number");
            }

            this.r_GarageManager.FillVehicleFuel(licenseNumber, fuelAmount, fuelType);
        }

        private void chargeElectricVehicle()
        {
            string licenseNumber = getLicenseNumberFromUser();

            if (this.r_GarageManager.GetVehicleEnergyType(licenseNumber) != eVehicleEnergyTypes.Electric)
            {
                throw new ArgumentException("The vehicle's energy source is not electric");
            }

            Console.WriteLine("Please enter the minutes to charge: ");
            float fuelAmount;

            if (!float.TryParse(Console.ReadLine(), out fuelAmount))
            {
                throw new FormatException("The given input is not a number");
            }

            this.r_GarageManager.ChargeVehicleEnergy(licenseNumber, fuelAmount);
        }

        private void showFullVehicleInformation()
        {
            string licenseNumber = getLicenseNumberFromUser();

            Console.WriteLine(this.r_GarageManager.getFullVehicleInformation(licenseNumber));
        }
    }
}
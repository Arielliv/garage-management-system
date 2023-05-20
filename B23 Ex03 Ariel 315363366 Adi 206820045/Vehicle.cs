using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        private readonly string r_ModelName;
        private readonly string r_LicenseNumber;
        private readonly List<Wheel> r_Wheels;
        private VehicleEnergySource m_VehicleEnergySource;
        private VehicleInformation m_VehicleInformation;
        private eVehicleStatuses m_VehicleStatus;
        protected readonly Dictionary<int, string> r_SpecificInformationMessages = new Dictionary<int, string>();

        public VehicleEnergySource VehicleEnergySource
        {
            get { return this.m_VehicleEnergySource; }
            set { this.m_VehicleEnergySource = value; }
        }

        public Vehicle(string i_ModelName, string i_LicenseNumber, int i_WheelsAmount, int i_WheelsMaxAirPressure)
        {
            this.r_ModelName = i_ModelName;
            this.r_LicenseNumber = i_LicenseNumber;
            this.r_Wheels = new List<Wheel>();
            for (int i = 0; i < i_WheelsAmount; i++)
            {
                this.r_Wheels.Add(new Wheel(i_WheelsMaxAirPressure));
            }
        }

        public string LicenseNumber
        {
            get { return this.r_LicenseNumber; }
        }

        public eVehicleStatuses VehicleStatus
        {
            get { return this.m_VehicleStatus; }
            set { this.m_VehicleStatus = value; }
        }

        public abstract void SetVehicleEnergyAsFuel();

        public abstract void SetVehicleEnergyAsElectric();

        public void InflateWheelsToMax()
        {
            foreach (Wheel wheel in this.r_Wheels)
            {
                wheel.InflateToMax();
            }
        }
        
        public void SetVehicleInformation(string i_OwnerName, string i_OwnerPhone)
        {
            this.m_VehicleInformation = new VehicleInformation(i_OwnerName, i_OwnerPhone);
        }

        public virtual string GetInformation()
        {
            StringBuilder info = new StringBuilder();

            info.Append($"The license number is: {r_LicenseNumber}\n");
            info.Append($"The model name is: {r_ModelName}\n");
            info.Append(this.m_VehicleInformation.GetOwnerNameAndVehicleStatus()).Append("\n");
            foreach (Wheel wheel in this.r_Wheels)
            {
                info.Append(wheel.GetManifacturerNameAndCurrentAirPressure()).Append("\n");
            }

            info.Append(this.VehicleEnergySource.GetInfo()).Append("\n");
            info.Append($"The wheels amount is: {this.r_Wheels.Count}\n");

            return info.ToString();
        }

        public void SetWheelsCurrentAirPressure(float i_CurrentAirPressure)
        {
            foreach(Wheel wheel in this.r_Wheels)
            {
                wheel.setCurrentAirPressure(i_CurrentAirPressure);
            }
        }

        public void SetWheelsManifacturerName(string i_ManifacturerName)
        {
            foreach (Wheel wheel in this.r_Wheels)
            {
                wheel.ManifacturerName = i_ManifacturerName;
            }
        }

        public void SetNewVehicleStatus()
        {
            this.m_VehicleStatus = eVehicleStatuses.InRepair;
        }

        public abstract void SetSpecificInformationMessages();

        public abstract bool SetSpecificInformation(string i_Message, int i_SpecificInformationNumber);

        public Dictionary<int, string> GetSpecificInformation()
        {
            return this.r_SpecificInformationMessages;
        }
    }
}

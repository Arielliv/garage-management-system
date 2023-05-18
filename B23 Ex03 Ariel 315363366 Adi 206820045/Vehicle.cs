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
        //////////////////////////////private readonly VehicleInfo r_VehicleInfo;
        private eVehicleStatuses m_VehicleStatus;

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
                wheel.inflate(wheel.MaxAirPressure);
            }
        }
        
        public void setVehicleInfo()
        {

        }

        public virtual string GetInfo()
        {
            StringBuilder info = new StringBuilder();

            info.Append($"The license number is: {r_LicenseNumber}");
            info.Append($"The model name is: {r_ModelName}");
            info.Append(this.r_VehicleInfo.GetOwnerNameAndVehicleStatus());
            foreach (Wheel wheel in this.r_Wheels)
            {
                info.Append(wheel.GetManifacturerNameAndCurrentAirPressure());
            }

            info.Append(this.VehicleEnergySource.GetInfo());
            info.Append($"The wheels amount is: {this.r_Wheels.Count}");

            return info.ToString();
        }

        public abstract bool SetSpecificInformation(string i_Message, int i_SpecificInformationNumber);
    }
}

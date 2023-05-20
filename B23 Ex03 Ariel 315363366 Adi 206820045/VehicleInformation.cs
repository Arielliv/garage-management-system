using System.Text;

namespace Ex03.GarageLogic
{
    public class VehicleInformation
    {
        private string m_OwnerName;
        private string m_OwnerPhone;
        private eVehicleStatuses m_VehicleStatus;

        public VehicleInformation(string i_OwnerName, string i_OwnerPhone)
        {
            this.m_OwnerName = i_OwnerName;
            this.m_OwnerPhone = i_OwnerPhone;
        }

        public eVehicleStatuses VehicleStatus
        {
            get { return this.m_VehicleStatus; }
            set { this.m_VehicleStatus = value; }
        }

        public string GetOwnerNameAndVehicleStatus()
        {
            StringBuilder info = new StringBuilder();

            info.Append($"The owner name is: {m_OwnerName}\n");
            info.Append($"The vehicle statuse is: {m_VehicleStatus}\n");

            return info.ToString();
        }
    }
}

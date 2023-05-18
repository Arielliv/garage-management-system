using System.Text;

namespace Ex03.GarageLogic
{
    public class VehicleInfo
    {
        private string m_OwnerName;
        private string m_OwnerPhone;
        private eVehicleStatuses m_VehicleStatus; 

        public string GetOwnerNameAndVehicleStatus()
        {
            StringBuilder info = new StringBuilder();

            info.Append($"The owner name is: {m_OwnerName}");
            info.Append($"The vehicle statuse is: {m_VehicleStatus}");

            return info.ToString();
        }
    }
}

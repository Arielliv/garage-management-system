using System.Text;

namespace Ex03.GarageLogic
{
    public class VehicleInformation
    {
        private string m_OwnerName;
        private string m_OwnerPhone;

        public VehicleInformation(string i_OwnerName, string i_OwnerPhone)
        {
            this.m_OwnerName = i_OwnerName;
            this.m_OwnerPhone = i_OwnerPhone;
        }

        public override string ToString()
        {
            StringBuilder info = new StringBuilder();

            info.Append($"The owner name is: {this.m_OwnerName}\n");

            return info.ToString();
        }
    }
}

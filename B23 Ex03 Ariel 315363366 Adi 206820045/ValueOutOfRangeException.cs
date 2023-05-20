using System;

namespace Ex03.GarageLogic
{
    public class ValueOutOfRangeException : Exception
    {
        private readonly float r_MinValue;
        private readonly float r_MaxValue;

        public ValueOutOfRangeException(float i_MinValue, float i_MaxValue) : 
            base($"The value is out of range. The range is between {i_MinValue} and {i_MaxValue}.")
        {
            this.r_MinValue = i_MinValue;
            this.r_MaxValue = i_MaxValue;
        }
    }
}

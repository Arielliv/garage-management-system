using System;

namespace Ex03.GarageLogic
{
    public class ValueOutOfRangeException : Exception
    {
        public ValueOutOfRangeException(float i_MinValue, float i_MaxValue) : 
            base($"The value is out of range. The range is between {i_MinValue} and {i_MaxValue}.")
        { }
    }
}

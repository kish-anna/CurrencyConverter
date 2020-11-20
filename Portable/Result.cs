using System;

namespace Portable
{
    public class Result : ICalc
    {
        private float GetInput(string Input)
        {
            float userInputFloat = 0;
            
            try
            {
                userInputFloat = Convert.ToSingle(Input);
            }
            catch (Exception _)
            {
                // ignored
            }

            return userInputFloat;
        }
        
        public float GetResult(float PriceValue, string Input)
        {
            float userInputFloat = GetInput(Input);

            var result = userInputFloat * PriceValue;                                                 
            
            return result;
        }
    }
}
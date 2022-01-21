
using AlfabetizaAPI.Services.Interfaces;

namespace AlfabetizaAPI.Services.Work
{
    public class Calculate : ICalculate
    {
        public int Sum(int number_one, int number_two)
        {
            return number_one + number_two;
        }
    }
}

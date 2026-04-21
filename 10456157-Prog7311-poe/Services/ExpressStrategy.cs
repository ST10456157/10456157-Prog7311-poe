namespace _10456157_Prog7311_poe.Services
{
    public class ExpressStrategy : ICostStrategy
    {
        public double Calculate(double baseCost) => baseCost * 1.5;
    }
}

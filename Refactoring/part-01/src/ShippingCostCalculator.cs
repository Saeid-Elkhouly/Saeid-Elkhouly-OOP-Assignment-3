// I  want to calculate the shipping cost based on the carrier and weight of the package.
// I have same behaviour for different carriers, but the cost per kilogram is different for each carrier and i don't want to change the code of the ShippingCostCalculator class every time I want to add a new carrier  i open class and modify this violate OCP
// Different statrtegy for each carrie , I want way when I Use ShippingCostCalculator class to calculate the shipping cost I don't care about which carrier , so I deside to use Strategy pattern to implement this behaviour.


// startegt interface
namespace part_01.src
{
    public interface IShippingCostStrategy
    {
        decimal CalculateShippingCost(decimal weightKg);
    }
    // concreate strategies
    public class AramexShippingCostStrategy : IShippingCostStrategy
    {
        public decimal CalculateShippingCost(decimal weightKg)
        {
            return weightKg * 12m;
        }
    }
    public class FedExShippingCostStrategy : IShippingCostStrategy
    {
        public decimal CalculateShippingCost(decimal weightKg)
        {
            return weightKg * 15m;
        }
    }
    public class DHLShippingCostStrategy : IShippingCostStrategy
    {
        public decimal CalculateShippingCost(decimal weightKg)
        {
            return weightKg * 18m;
        }
    }
    public class UPSShippingCostStrategy : IShippingCostStrategy
    {
        public decimal CalculateShippingCost(decimal weightKg)
        {
            return weightKg * 20m;
        }
    }
    //context class
    public class ShippingCostCalculator
    {
        private readonly IShippingCostStrategy _strategy; // dependency inversion principle, we depend on abstraction not on concrete implementation

        public ShippingCostCalculator(IShippingCostStrategy strategy)
        {
            _strategy = strategy;    // inject the strategy through constructor injection, so we can change the strategy at runtime without changing the code of the ShippingCostCalculator class
        }

        public decimal Calculate(decimal weightKg)
        {
            return _strategy.CalculateShippingCost(weightKg);
        }
    }
}
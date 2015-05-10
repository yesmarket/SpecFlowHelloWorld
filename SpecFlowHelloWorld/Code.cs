using System;

namespace SpecFlowHelloWorld
{
    public interface IRule
    {
        decimal Calculate(Request request);
    }

    public class LvrRule : IRule
    {
        private readonly IRepository<Coefficient> _repository;

        public LvrRule(IRepository<Coefficient> repository)
        {
            _repository = repository;
        }

        public decimal Calculate(Request request)
        {
            var coefficient = _repository.GetByCode("test");

            return (request.LoanAmount/Math.Min(request.PropertyPrice, request.PropertyValue))*coefficient.Value;
        }
    }

    public interface IRepository<out T>
    {
        T GetByCode(string code);
    }

    public class CoefficientRepository : IRepository<Coefficient>
    {
        public Coefficient GetByCode(string code)
        {
            return new Coefficient
            {
                Code = "test",
                Value = 1.3234M
            };
        }
    }

    public class Coefficient
    {
        public string Code { get; set; }
        public decimal Value { get; set; }
    }

    public struct Request
    {
        public decimal PropertyValue { get; set; }
        public decimal PropertyPrice { get; set; }
        public decimal LoanAmount { get; set; }
    }
}

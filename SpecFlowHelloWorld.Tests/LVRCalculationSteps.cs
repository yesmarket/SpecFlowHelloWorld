using System;
using NSubstitute;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace SpecFlowHelloWorld.Tests
{
    [Binding]
    public class LVRCalculationSteps
    {
        private decimal _lvrCoefficient;
        private decimal _propertyPrice;
        private decimal _propertyValue;
        private decimal _loanAmount;
        private LvrRule _sut;
        private decimal _lvrScore;

        [Given(@"a LVR coefficient of (.*)")]
        public void GivenALVRCoefficientOf(Decimal lvrCoefficient)
        {
            _lvrCoefficient = lvrCoefficient;
        }

        [Given(@"a property price of (.*)")]
        public void GivenAPropertyPriceOf(Decimal propertyPrice)
        {
            _propertyPrice = propertyPrice;
        }

        [Given(@"a property value of (.*)")]
        public void GivenAPropertyValueOf(Decimal propertyValue)
        {
            _propertyValue = propertyValue;
        }

        [Given(@"a loan amount of (.*)")]
        public void GivenALoanAmountOf(Decimal loanAmount)
        {
            _loanAmount = loanAmount;
        }

        [When(@"we calculate the LVR score")]
        public void WhenWeCalculateTheLVRScore()
        {
            var repository = Substitute.For<IRepository<Coefficient>>();
            repository.GetByCode(Arg.Any<string>()).Returns(new Coefficient {Code = "test", Value = _lvrCoefficient});
            _sut = new LvrRule(repository);
            _lvrScore = _sut.Calculate(new Request
            {
                LoanAmount = _loanAmount,
                PropertyPrice = _propertyPrice,
                PropertyValue = _propertyValue
            });
        }
        
        [Then(@"the result is (.*)")]
        public void ThenTheResultIs(Decimal lvrScore)
        {
            Assert.AreEqual(lvrScore, _lvrScore);
        }
    }
}

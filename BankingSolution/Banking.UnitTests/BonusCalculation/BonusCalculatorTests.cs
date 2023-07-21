using Banking.Domain;
using System.Runtime.InteropServices;

namespace Banking.UnitTests.BonusCalculation
{
    public class BonusCalculatorTests
    {
        [Theory]
        [InlineData(100, 10)]
        [InlineData(200, 20)]
        public void HasSufficientBalance(decimal amountOfDeposit, decimal expectedBonus)
        {
            var bonusCalculator = new StandardBonusCalculator();
            var balanceOnAccount = 5000M;
            decimal bonus = bonusCalculator.CalculateBonusForDeposit(balanceOnAccount, amountOfDeposit);

            Assert.Equal(expectedBonus, bonus);
        }

        [Theory]
        [InlineData(100, 0)]
        [InlineData(200, 0)]
        public void HasInsufficientBalance(decimal amountOfDeposit, decimal expectedBonus)
        {
            var bonusCalculator = new StandardBonusCalculator();
            var balanceOnAccount = 4999.99M;
            decimal bonus = bonusCalculator.CalculateBonusForDeposit(balanceOnAccount, amountOfDeposit);

            Assert.Equal(expectedBonus, bonus);
        }

    [Fact]

    public void BonusCalculatorIsUsedAndBonusAppliedToBalance()

        {

            // Given

            var stubbedBonusCalculator = new Mock<ICanCalculateBonusesForBankAccountDeposits>();

            var account = new BankAccount(stubbedBonusCalculator.Object);



            var openingBalance = account.GetBalance();

            var amountToDeposit = 112.23M;

            var amountOfBonusToReturn = 69.23M;

            stubbedBonusCalculator.Setup(b => b.CalculateBonusForDeposit(

                openingBalance,

                amountToDeposit)

            ).Returns(amountOfBonusToReturn);





            // When

            account.Deposit(amountToDeposit);



            // Then

            Assert.Equal(

                openingBalance +

                amountOfBonusToReturn +

                amountToDeposit,

                account.GetBalance()

                );



        }

    }
}

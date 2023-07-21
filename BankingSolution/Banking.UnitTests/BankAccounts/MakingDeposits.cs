using Banking.Domain;

namespace Banking.UnitTests.BankAccounts
{
    public class MakingDeposits
    {
        [Fact]
        public void DepositsIncreaseTheBalance()
        {
            // Given
            //var account = new BankAccount(new DummyBonusCalculator());
            var account = new BankAccount(new Mock<ICanCalculateBonusesForBankAccountDeposits>().Object);
            var openingBalance = account.GetBalance();
            var amountToDeposit = 100.23M;

            // When
            account.Deposit(amountToDeposit);

            // Then
            Assert.Equal(openingBalance + amountToDeposit, account.GetBalance());
        }
    }
}

// this is a test double!
public class DummyBonusCalculator : ICanCalculateBonusesForBankAccountDeposits
{
    public decimal CalculateBonusesForBankAccountDeposits(BankAccount bankAccount)
    {
        return 0;
    }
}
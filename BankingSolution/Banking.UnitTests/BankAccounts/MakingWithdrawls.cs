using Banking.Domain;
namespace Banking.UnitTests.BankAccounts
{
    public class MakingWithdrawls
    {
        [Fact]
        public void MakingAWithdrawlDecreasesTheBalance()
        {
            var account = new BankAccount(new Mock<ICanCalculateBonusesForBankAccountDeposits>().Object);
            var openingBalance = account.GetBalance();
            var amountToWithdraw = 1.01M;

            account.Withdraw(amountToWithdraw);

            Assert.Equal(openingBalance - amountToWithdraw, account.GetBalance());
        }
        [Theory]
        [InlineData(80)]
        public void ExploreWithdrawls(decimal amountToWithdraw)
        {
            var account = new BankAccount(new Mock<ICanCalculateBonusesForBankAccountDeposits>().Object);
            var openingBalance = account.GetBalance();

            account.Withdraw(amountToWithdraw);

            Assert.Equal(openingBalance - amountToWithdraw, account.GetBalance());
        }
        [Fact]
        public void CanTakeEntireBalance()
        {
            var account = new BankAccount(new Mock<ICanCalculateBonusesForBankAccountDeposits>().Object);

        }
        /*[Theory]
        [InlineData(-0.1)]
        [InlineData(0)]
        public void InvalidAmountsAreNotAllowed(decimal amount)
        {
            var account = new BankAccount();
            var openingBalance = account.GetBalance();
            Assert.Throws<InvalidBankAccountTransactionAmountException>(() =>
            {
                account.Withdraw(amount);
            });
            Assert.Equal(openingBalance, account.GetBalance());
        }*/
    }
}

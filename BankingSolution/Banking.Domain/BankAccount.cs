using Banking.UnitTests.BonusCalculation;

namespace Banking.Domain
{
    public class BankAccount
    {
        private readonly ICanCalculateBonusesForBankAccountDeposits _bonusCalculator;

        // Ctrl + . to create a constructor for the interface
        public BankAccount(ICanCalculateBonusesForBankAccountDeposits bonusCalculator)
        {
            _bonusCalculator = bonusCalculator;
        }

        private decimal _balance = 5000;

        public void Deposit(decimal amountToDeposit)
        {
            GuardCorrectTransactionAmount(amountToDeposit);
            var bonusCalculator = new StandardBonusCalculator();
            var bonus = bonusCalculator.CalculateBonusForDeposit(_balance, amountToDeposit);
            _balance += amountToDeposit;
        }

        public decimal GetBalance()
        {
            return _balance;
        }

        public void Withdraw(decimal amountToWithdraw)
        {
            GuardCorrectTransactionAmount(amountToWithdraw);
            GuardHasSufficentBalance(amountToWithdraw);
            _balance -= amountToWithdraw;
        }

        private void GuardHasSufficentBalance(decimal amountToWithdraw)
        {
            if (amountToWithdraw > _balance)
            {
                throw new AccountOverdraftException();
            }
        }

        private void GuardCorrectTransactionAmount(decimal amountToWithdraw)
        {
            if (amountToWithdraw <= 0)
            {
                throw new AccountOverdraftException();
            }
        }
    }
}

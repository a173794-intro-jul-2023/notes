namespace Banking.Domain
{
    public interface ICanCalculateBonusesForBankAccountDeposits
    {
        decimal CalculateBonusesForBankAccountDeposits(BankAccount bankAccount);
        void CalculateBonusForDeposit(decimal openingBalance, decimal amountToDeposit);
    }
}
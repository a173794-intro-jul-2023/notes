using Banking.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.UnitTests.BankAccounts
{
    public class Overdrafts
    {
        [Fact]
        public void DoesNotDecreaseTheBalance()
        {
            var account = new BankAccount();
            var openingBalance = account.GetBalance();
            var amountToWithdraw = openingBalance + .01M;
            var caught = false;

            try
            {
            account.Withdraw(amountToWithdraw);
            } catch (AccountOverdraftException)
            {
                caught = true;
            }
            Assert.True(caught);
            Assert.Equal(openingBalance, account.GetBalance());
        }
    }
}

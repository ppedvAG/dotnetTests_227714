namespace TddBank.Tests
{
    public class BankAccountTests
    {
        ///Bankkonto
        ///- Kontostand abfragen
        ///- Betrag einzahlen(nicht Negativ)
        ///- Betrag abheben(nicht Negativ)
        ///     - Darf nicht unter 0 fallen
        ///- Neues Konto hat 0 als Kontostand
        [Fact]
        public void New_account_should_have_zero_as_Balance()
        {
            var ba = new BankAccount();

            Assert.Equal(0m, ba.Balance);
        }

        [Fact]
        public void Deposit_should_add_to_Balance()
        {
            var ba = new BankAccount();

            ba.Deposit(4m);
            ba.Deposit(4m);

            Assert.Equal(8m, ba.Balance);
        }

        [Fact]
        public void Withdraw_should_substract_from_Balance()
        {
            var ba = new BankAccount();
            ba.Deposit(12m);

            ba.Withdraw(4m);

            Assert.Equal(8m, ba.Balance);
        }

        [Fact]
        public void Withdraw_below_zero_should_throw()
        {
            var ba = new BankAccount();
            ba.Deposit(12m);

            Assert.Throws<InvalidOperationException>(() => ba.Withdraw(13m));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-0.01)]
        public void Deposit_a_negative_or_zero_value_should_throw(decimal value)
        {
            var ba = new BankAccount();

            Assert.Throws<ArgumentException>(() => ba.Deposit(value));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-0.01)]
        public void Withdraw_a_negative_or_zero_value_should_throw(decimal value)
        {
            var ba = new BankAccount();
            ba.Deposit(4m);

            Assert.Throws<ArgumentException>(() => ba.Withdraw(value));
        }

    }
}
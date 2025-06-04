using Bank.Domain;
using System;
using Xunit;

namespace Bank.Domain.Tests;
public class BankAccountTests
{
    [Theory]
    [InlineData(11.99, 4.55, 7.44)]
    [InlineData(12.3, 5.2, 7.1)]
    public void MultiDebit_WithValidAmount_UpdatesBalance(
        double beginningBalance, double debitAmount, double expected )
    {
        // Arrange
        BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);
        // Act
        account.Debit(debitAmount);
        // Assert
        double actual = account.Balance;
        Assert.Equal(Math.Round(expected,2), Math.Round(actual,2));
    }

    [Fact]
    public void Debit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange()
    {
        // Arrange
        double beginningBalance = 11.99;
        double debitAmount = -100.00;
        BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);
        // Act and assert
        Assert.Throws<System.ArgumentOutOfRangeException>(() => account.Debit(debitAmount));
    }

    [Fact]
    public void Debit_WhenAmountIsMoreThanBalance_ShouldThrowArgumentOutOfRange()
    {
        // Arrange
        double beginningBalance = 11.99;
        double debitAmount = 20.0;
        BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);
        // Act
        try
        {
            account.Debit(debitAmount);
        }
        catch (System.ArgumentOutOfRangeException e)
        {
            // Assert
            Assert.Contains(BankAccount.DebitAmountExceedsBalanceMessage, e.Message);
        }
    }

    [Theory]
    [InlineData(11.99, 5.0, 16.99)]
    [InlineData(0.0, 100.0, 100.0)]
    public void Credit_WithValidAmount_UpdatesBalance(
        double beginningBalance, double creditAmount, double expected)
    {
        // Arrange
        BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);
        
        // Act
        account.Credit(creditAmount);
        
        // Assert
        double actual = account.Balance;
        Assert.Equal(Math.Round(expected, 2), Math.Round(actual, 2));
    }

    [Fact]
    public void Credit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange()
    {
        // Arrange
        double beginningBalance = 11.99;
        double creditAmount = -100.00;
        BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);
        
        // Act and assert
        var exception = Assert.Throws<System.ArgumentOutOfRangeException>(() => account.Credit(creditAmount));
        Assert.Equal("amount", exception.ParamName);
    }

    [Fact]
    public void CustomerName_WhenCalled_ReturnCustomerName()
    {
        // Arrange
        string expectedName = "Mr. Bryan Walton";
        BankAccount account = new BankAccount(expectedName, 11.99);
        
        // Act
        string actualName = account.CustomerName;
        
        // Assert
        Assert.Equal(expectedName, actualName);
    }
}
/// <summary>
/// Represents a bank account with basic debit and credit operations.
/// </summary>
public class BankAccount
{
    /// <summary>
    /// Message displayed when a debit amount exceeds the account balance.
    /// </summary>
    public const string DebitAmountExceedsBalanceMessage = "Debit amount exceeds balance";
    
    /// <summary>
    /// Message displayed when a debit amount is less than zero.
    /// </summary>
    public const string DebitAmountLessThanZeroMessage = "Debit amount is less than zero";
    
    /// <summary>
    /// The customer name associated with this account.
    /// </summary>
    private readonly string m_customerName;
    
    /// <summary>
    /// The current balance of the account.
    /// </summary>
    private double m_balance;
    
    /// <summary>
    /// Private default constructor.
    /// </summary>
    private BankAccount() { }
    
    /// <summary>
    /// Initializes a new instance of the BankAccount class with specified customer name and balance.
    /// </summary>
    /// <param name="customerName">The name of the customer who owns the account.</param>
    /// <param name="balance">The initial balance of the account.</param>
    public BankAccount(string customerName, double balance)
    {
        m_customerName = customerName;
        m_balance = balance;
    }
    
    /// <summary>
    /// Gets the name of the customer who owns this account.
    /// </summary>
    public string CustomerName { get { return m_customerName; } }
    
    /// <summary>
    /// Gets the current balance of the account.
    /// </summary>
    public double Balance { get { return m_balance; }  }
    
    /// <summary>
    /// Debits the specified amount from the account.
    /// </summary>
    /// <param name="amount">The amount to debit from the account.</param>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Thrown when amount is greater than the balance or when amount is less than zero.
    /// </exception>
    public void Debit(double amount)
    {
        if (amount > m_balance)
            throw new ArgumentOutOfRangeException("amount", amount, DebitAmountExceedsBalanceMessage);
        if (amount < 0)
            throw new ArgumentOutOfRangeException("amount", amount, DebitAmountLessThanZeroMessage);
        m_balance -= amount; 
    }
    
    /// <summary>
    /// Credits the specified amount to the account.
    /// </summary>
    /// <param name="amount">The amount to credit to the account.</param>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Thrown when amount is less than zero.
    /// </exception>
    public void Credit(double amount)
    {
        if (amount < 0)
            throw new ArgumentOutOfRangeException("amount");
        m_balance += amount;
    }
}
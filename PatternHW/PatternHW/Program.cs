public interface IPaymentService
{
    public void Pay(int amount) { }
}

public class PaymentService : IPaymentService
{
    public void Pay(int amount)
    {
        Console.WriteLine($"You paid {amount}");
    }
}

public class Proxy : IPaymentService
{
    private PaymentService paymentService = new();
    public Proxy(int amount, bool result)
    {
        paymentService = new();
        Amount = amount;
        Result = result;
    }
    public int Amount { get; set; }
    public bool Result { get; set; }
    public void Pay(int amount)
    {
        Console.WriteLine($"You paid {amount}");
    }
    public void CheckAcces(bool result)
    {
        if (result)
        {
            paymentService.Pay(Amount);
        }
    }
}
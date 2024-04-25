namespace StockOnliner;

internal class StockExchangeMonitor
{
    public delegate void PriceChange(int price);

    public PriceChange PriceChangeHandler { get; set; }             //Prop. for registering a reference to the method

    public void Start()
    {
        while(true) 
        {
            int bankOfAmericaPrice = new Random().Next(100);

            PriceChangeHandler(bankOfAmericaPrice);

            Thread.Sleep(2000);
        }
    }
}

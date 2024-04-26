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

            PriceChangeHandler(bankOfAmericaPrice);                 //Notification of the new price to all interested parties

            Thread.Sleep(2000);
        }
    }
}

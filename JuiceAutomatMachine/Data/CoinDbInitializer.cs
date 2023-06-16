using JuiceAutomatMachine.Models;

namespace JuiceAutomatMachine.Data
{
    public static class CoinDbInitializer
    {
        public static void Initialize(CoinDbContext coinDbContext)
        {
            coinDbContext.Database.EnsureCreated();
            if (coinDbContext.Coins.Any())
            {
                return;
            }

            var coins = new Coin[]
            {
                new Coin(0, 10, false),
                new Coin(1, 5, true),
                new Coin(2, 2, false),
                new Coin(3, 1, false)
            };
            foreach (var coin in coins)
            {
                coinDbContext.Coins.Add(coin);
            }
            //coinDbContext.ChangeTracker.Clear();
            coinDbContext.SaveChanges();
        }

    }
}

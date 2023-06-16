namespace JuiceAutomatMachine.Models
{
    public class Coin
    {
        public int CoinId { get; set; }
        public int Nominal { get; set; }
        public bool Blocked { get; set; }

        public Coin(int coinId, int nominal, bool blocked)
        {
            CoinId = coinId;
            Nominal = nominal;
            Blocked = blocked;
        }

        public override bool Equals(object? obj)
        {
            if (obj is not Coin) return false;

            Coin difCoin = (Coin)obj;
            bool eqId = this.CoinId == difCoin.CoinId;
            bool eqNominal = this.Nominal == difCoin.Nominal;
            bool eqBlocked = this.Blocked == difCoin.Blocked;

            if (eqId && eqNominal && eqBlocked) return true;

            return false;
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
}

namespace JuiceAutomatMachine.Models
{
    public struct Coin
    {
        public int Id { get; set; }
        public int Nominal { get; set; }
        public bool Blocked { get; set; }

        public Coin(int id, int nominal, bool blocked)
        {
            Id = id;
            Nominal = nominal;
            Blocked = blocked;
        }
    }
}

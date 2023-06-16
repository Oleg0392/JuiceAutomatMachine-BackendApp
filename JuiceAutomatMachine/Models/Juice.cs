namespace JuiceAutomatMachine.Models
{
    public class Juice
    {
        public int JuiceId { get; set; } 
        public string Title { get; set; }   
        public decimal Price { get; set; }  
        public int Rest { get; set; }
        public string ImgUrl { get; set; }

        public Juice(int juiceId, string title, decimal price, int rest, string imgUrl)
        {
            JuiceId = juiceId;
            Title = title;
            Price = price;
            Rest = rest;
            ImgUrl = imgUrl;
        }

        public override bool Equals(object? obj)
        {
            if (obj is not Juice) return false;

            Juice difJuice = (Juice)obj;
            bool eqId = this.JuiceId == difJuice.JuiceId;
            bool eqTitle = this.Title == difJuice.Title;
            bool eqPrice = this.Price == difJuice.Price;
            bool eqRest = this.Rest == difJuice.Rest;
            bool eqImgUrl = this.ImgUrl == difJuice.ImgUrl;

            if (eqId && eqTitle && eqPrice && eqRest && eqImgUrl) return true;
            
            return false;
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
}

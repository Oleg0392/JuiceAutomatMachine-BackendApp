namespace JuiceAutomatMachine.Models
{
    public class Juice
    {
        public int Id { get; set; } 
        public string Title { get; set; }   
        public decimal Price { get; set; }  
        public int Rest { get; set; }

        public string ImgUrl { get; set; }

        public Juice(int id, string title, decimal price, int rest, string imageUrl)
        {
            Id = id;
            Title = title;
            Price = price;
            Rest = rest;
            ImgUrl = imageUrl;
        }
    }
}

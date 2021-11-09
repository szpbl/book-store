
namespace BookShop.Models
{
    public class Book
    {
        #region Properties

        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Edition { get; set; }
        public string Publisher { get; set; }
        public string ISBN { get; set; }

        #endregion
    }
}

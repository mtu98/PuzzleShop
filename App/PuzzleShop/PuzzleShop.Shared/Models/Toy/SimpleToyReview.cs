namespace PuzzleShop.Shared.Models.Toy {
    public class SimpleToyReview {
        public string Toyid { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int Star { get; set; }
        public SimpleToyReview() {

        }

        public SimpleToyReview(Toy toy, Review review) {
            Toyid = toy._id;
            Username = review.Name;
            Email = review.Email;
            Title = review.Title;
            Content = review.Content;
            Star = review.Star;
        }
    }
}

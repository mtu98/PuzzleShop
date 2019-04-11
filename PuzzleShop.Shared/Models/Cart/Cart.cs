using System.Collections.Generic;

namespace PuzzleShop.Shared.Models.Cart
{
    public class Cart : Dictionary<Toy.Toy, int>
    {
        public Cart()
        {
        }

        public Cart(Dictionary<Toy.Toy, int> dict) : base(dict)
        {
        }
    }
}
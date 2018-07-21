using Newtonsoft.Json;

namespace PuzzleShop.Shared.Models.Toy {
    public class Toy {
        public string _id { get; set; }

        public string ToyName { get; set; }

        public string ToyType { get; set; }

        public string Producer { get; set; }

        public int SizeX { get; set; }

        public int SizeY { get; set; }

        public int SizeZ { get; set; }

        public double Price { get; set; }

        public int Quantity { get; set; }

        public int YearOfManufacture { get; set; }

        public string Description { get; set; }

        public string PhotoURL { get; set; }

        public Review[] Review { get; set; }

        public override string ToString() {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        // override object.Equals
        public override bool Equals(object obj) {
            if (obj == null || GetType() != obj.GetType()) {
                return false;
            }

            var toy = obj as Toy;
            return toy._id.Equals(this._id);
        }

        // override object.GetHashCode
        public override int GetHashCode() {
            return this._id.GetHashCode();
        }

    }

    public class Review {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int Star { get; set; }
        public string Date { get; set; }
        public override string ToString() {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }

}

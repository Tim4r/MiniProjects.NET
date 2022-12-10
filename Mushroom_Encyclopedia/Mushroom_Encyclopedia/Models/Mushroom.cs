using System.Collections.Generic;

namespace Mushroom_Encyclopedia.Models
{
    internal partial class Mushroom : Type
    {
        public int ID { get; set; }
        public string NameMushroom { get; set; }
        public string Edibility { get; set; }
        public int Weight { get; set; }
        public int Cost { get; set; }
    }
}

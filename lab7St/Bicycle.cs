using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace lab7St
{
    public class Bicycle
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int FrameSize { get; set; }
        public int WheelSize { get; set; }
        public string Color { get; set; }
        public bool IsElectric { get; set; }
        public decimal Price { get; set; }
        public decimal DiscountedPrice { get; private set; } 

        public const decimal DiscountPercentage = 10.0m;


        public Bicycle() { }

        public Bicycle(string brand, string model, int frameSize, int wheelSize, string color, bool isElectric, decimal price)
        {
            Brand = brand;
            Model = model;
            FrameSize = frameSize;
            WheelSize = wheelSize;
            Color = color;
            IsElectric = isElectric;
            Price = price;
            DiscountedPrice = CalculateDiscountedPrice();
        }

        public decimal CalculateDiscountedPrice()
        {
            decimal discountAmount = Price * (DiscountPercentage / 100);
            return Price - discountAmount;
        }
    }

}




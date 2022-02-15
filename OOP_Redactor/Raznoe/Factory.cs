using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Redactor
{
    public class Factory
    {
        public IShape createShape(string a)
        {
            switch (a)
            {
                case "C":
                    return new Circle(0, 0, 0, 0);
                case "S":
                    return new Square(0, 0, 0, 0);
                case "L":
                    return new Line(0, 0, 0, 0);
                case "G":
                    return new Group();
                default:
                    return new Line(0, 0, 0, 0);
            }
        }
    }
}

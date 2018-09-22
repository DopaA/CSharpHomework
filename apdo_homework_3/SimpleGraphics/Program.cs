using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGraphics
{
    public enum GrapgicsType
    {
        unknown = -1,
        Triangle,
        Circular,
        Square,
        Rectangle
    }
    public abstract class Graphics
    {
        protected double Area = 0;
        public double AreaNum
        {
            get { return Area; }
        }
    }
    //三角形
    public class Triangle : Graphics
    {
        private double edge1 = 0, edge2 = 0, edge3 = 0;
        public Triangle(int edge1 = 0, int edge2 = 0, int edge3 = 0)
        {
            this.edge1 = edge1;
            this.edge2 = edge2;
            this.edge3 = edge3;
            AreaNumt();
        }
        public void AreaNumt()
        {
            double p = (edge1 + edge2 + edge3) / 2;
            Area = Math.Sqrt(p * (p - edge1) * (p - edge2) * (p - edge3));
        }
    }
    //圆形
    public class Circular : Graphics
    {
        private double r = 0, pi = 3.14;
        public Circular(int r = 0)
        {
            this.r = r;
            AreaNumt();
        }
        public void AreaNumt()
        {
            Area = pi * r * r;
        }
    }
    //正方形
    public class Square : Graphics
    {
        private double edge = 0;
        public Square(int edge = 0)
        {
            this.edge = edge;
            AreaNumt();
        }
        public void AreaNumt()
        {
            Area = edge * edge;
        }
    }
    //长方形
    public class Rectangle : Graphics
    {
        private double edge1 = 0, edge2 = 0;
        public Rectangle(int edge1 = 0, int edge2 = 0)
        {
            this.edge1 = edge1;
            this.edge2 = edge2;
            AreaNumt();
        }
        public void AreaNumt()
        {
            Area = edge1 * edge2;
        }
    }
    public static class GraphicsFactory
    {
        public static Graphics CreateGraphics(GrapgicsType type)
        {
            Graphics graphics = null;
            switch (type)
            {
                case GrapgicsType.Triangle:
                    graphics = new Triangle(3, 4, 5);
                    break;
                case GrapgicsType.Circular:
                    graphics = new Circular(5);
                    break;
                case GrapgicsType.Square:
                    graphics = new Square(6);
                    break;
                case GrapgicsType.Rectangle:
                    graphics = new Rectangle(2,8);
                    break;
                default:
                    throw new UnKnowGraphs();
            }
            return graphics;
        }
    }
    public class UnKnowGraphs : Exception{
        public UnKnowGraphs() : base("No such graph") { }
       }
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Graphics graph1 = GraphicsFactory.CreateGraphics(GrapgicsType.Triangle);
                Console.WriteLine("the area of tritangle is " + graph1.AreaNum);

                Graphics graph2 = GraphicsFactory.CreateGraphics(GrapgicsType.Circular);
                Console.WriteLine("the area of circular is " + graph2.AreaNum);

                Graphics graph3 = GraphicsFactory.CreateGraphics(GrapgicsType.Square);
                Console.WriteLine("the area of square is " + graph3.AreaNum);

                Graphics graph4 = GraphicsFactory.CreateGraphics(GrapgicsType.Rectangle);
                Console.WriteLine("the area of rectangle is " + graph4.AreaNum);
            }
            catch
            {
                Console.WriteLine("unknown error!");
            }
            Console.ReadLine();
        }
    }
}

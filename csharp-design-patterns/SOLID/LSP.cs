using static System.Console;

namespace csharp_design_patterns.SOLID.LSP
{
    public class Rectangle
    {
        public virtual int Width { get; set; }
        public virtual int Height { get; set; }
        public Rectangle()
        {

        }
        public Rectangle(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public override string ToString()
        {
            return $"{nameof(Width)}: {Width}, {nameof(Height)}: {Height}";
        }
    }

    public class Square : Rectangle
    {
        /* -- DON'T --
        public new int Width
        {
            set { base.Width = base.Height = value; }
        }
        public new int Height
        {
            set { base.Width = base.Height = value; }
        }
        */

        public override int Width
        {
            set { base.Width = base.Height = value; }
        }
        public override int Height
        {
            set { base.Width = base.Height = value; }
        }
    }

    public class Demo
    {
        static public int Area(Rectangle r) => r.Height * r.Width;
        static void Main(string[] args)
        {
            Rectangle rc = new Rectangle();
            WriteLine($"{rc} has area {Area(rc)}");

            Square sq1 = new Square();
            sq1.Width = 5;
            WriteLine($"{sq1} has area {Area(sq1)}");

            // base class reference to derived class
            Rectangle sq2 = new Square();
            sq2.Width = 7;
            WriteLine($"{sq2} has area {Area(sq2)}");

        }
    }


}


/*
 Notes:
    - In simple terms, A derived class must be substitutable for its base class
    - Have a look at vtables and vptr on how they work under the hood (good blog to understand - https://pnguyen.io/) 
 */
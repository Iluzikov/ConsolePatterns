using System;
using System.Security.Cryptography;
using static System.Console;

namespace SOLID
{
  // using a classic example
  public class Rectangle
  {
    //public int Width { get; set; }
    //public int Height { get; set; }

    public virtual int Width { get; set; }
    public virtual int Height { get; set; }

    public Rectangle() {}

    public Rectangle(int width, int height)
    {
      Width = width;
      Height = height;
    }

    public bool IsSquare => Width == Height;

    public int Area => Width * Height;

    public override string ToString()
    {
      return $"{nameof(Width)}: {Width}, {nameof(Height)}: {Height}";
    }
  }

  public class Square : Rectangle
  {
    public Square()
    {
    }

    public Square(int side)
    {
      Width = Height = side;
    }

    //public new int Width
    //{
    //  set
    //  {
    //    base.Width = base.Height = value;
    //  }
    //}

    //public new int Height
    //{
    //  set { base.Width = base.Height = value; }
    //}

    public override int Width // nasty side effects
    {
      set => base.Width = base.Height = value;
    }

    public override int Height
    {
      set => base.Width = base.Height = value;
    }
  }

}

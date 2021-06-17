using System;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace SOLID
{

    class Program
    {
        static void Main(string[] args)
        {

            #region Single responsebility

            //var j = new Journal();
            //j.AddEntry("I cried today.");
            //j.AddEntry("I ate a bug.");
            //Console.WriteLine(j);
            //-------------------
            //var p = new PersistenceManager();
            //var filename = @"c:\temp\journal.txt";
            //p.SaveToFile(j, filename);

            //var psi = new ProcessStartInfo();
            //psi.FileName = filename;
            //psi.UseShellExecute = true;
            //Process.Start(psi);
            #endregion


            #region Open close

            //var apple = new Product("Apple", Color.Green, Size.Small);
            //var tree = new Product("Tree", Color.Green, Size.Large);
            //var house = new Product("House", Color.Blue, Size.Large);
            //var car = new Product("Car", Color.Red, Size.Medium);
            //var table = new Product("Table", Color.Blue, Size.Medium);

            //Product[] products = { apple, tree, house, car, table};

            //Console.WriteLine("All products");
            //foreach (var p in products)
            //{
            //    Console.WriteLine($"Name = {p.Name}, color = {p.Color}, size = {p.Size}");
            //}

            //var bf = new BetterFilter();
            //Console.WriteLine("\nLarge products");
            //var largeSpec = new SizeSpecification(Size.Large);
            //foreach (var p in bf.Filter(products, largeSpec))
            //{
            //    Console.WriteLine($"{p.Name} - is Laarge");
            //}

            //Console.WriteLine("\nBlue products:");
            //var colorSpec = new ColorSpecification(Color.Blue);
            //foreach (var p in bf.Filter(products, colorSpec))
            //{
            //    Console.WriteLine($"{p.Name} - is blue");
            //}


            //Console.WriteLine("\nLarge & Blue products:");
            //var andspec = colorSpec & largeSpec;


            //foreach (var p in bf.Filter(products, andspec))
            //{
            //    Console.WriteLine($"{p.Name} - is large & blue");
            //}


            #endregion


            #region Builder

            {
                // if we want to build a simple HTML paragraph...
                //var hello = "hello";
                //var text = "";
                //text += "<p>"; // <p> → text
                //text += hello; // <p>hello → text
                //text += "</p>"; // <p>hello</p> → text
                //Console.WriteLine(text);

                //// now we want an HTML list with 2 words in it
                //var sb = new StringBuilder();
                //var words = new[] { "hello", "world" };
                //sb.Clear();
                //sb.Append("<ul>");
                //foreach (var word in words)
                //{
                //    sb.AppendFormat("<li>{0}</li>", word);
                //}

                //sb.Append("</ul>");
                //Console.WriteLine(sb);




                // ordinary non-fluent builder
                var builder = new HtmlBuilder("ul");
                //builder.AddChild("li", "hello");
                //builder.AddChild("li", "world");
                //Console.WriteLine(builder.ToString());

                //// fluent builder
                ////sb.Clear();
                //builder.Clear(); // disengage builder from the object it's building, then...
                builder.AddChildFluent("li", "hello").AddChildFluent("li", "world");
                Console.WriteLine(builder);
            }

            // with factory method
            //{
            //    var builder = HtmlElement.Create("ul");
            //    builder.AddChildFluent("li", "hello")
            //      .AddChildFluent("li", "world");
            //    Console.WriteLine(builder);
            //}

            //// with implicit operator
            //{
            //    var root = HtmlElement
            //      .Create("ul")
            //      .AddChildFluent("li", "hello")
            //      .AddChildFluent("li", "world");
            //    Console.WriteLine(root);
            //}
            #endregion


            Console.ReadLine();
        }
    }
}

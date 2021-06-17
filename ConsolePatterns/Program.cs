using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePatterns
{
    class Program
    {
        static void Main(string[] args)
        {

            var str = "8-888-123-45-67; 8988-123-56-78; 8-987-654-32-10";

            var splitstr = str.Split(';');
            
            foreach (var s in splitstr)
            {
                Console.Write(s.Trim() +" - ");
                Console.WriteLine(s.Trim().Replace("-",""));
            }

            Console.WriteLine(new string('-',10));

            var phones = new[] { "89881235678", "+79876543210" };

            foreach (var p in phones)
            {
                Console.WriteLine($"Ищем номер {p}");

                var findPhone = str.Split(';').Where(s => s.Trim().Replace("-", "").Contains(p.Replace("+7","8")));

                Console.WriteLine($"Найден в строке - {findPhone.FirstOrDefault()}");

            }

            Console.ReadLine();
        }
    }


    class Field
    {
        public string Type, Name;

        public override string ToString()
        {
            return $"public {Type} {Name}";
        }
    }

    class Class
    {
        public string Name;
        public List<Field> Fields = new List<Field>();

        public Class() { }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"public class {Name}").AppendLine("{");
            foreach (var f in Fields)
                sb.AppendLine($"  {f};");
            sb.AppendLine("}");
            return sb.ToString();
        }
    }

    public class CodeBuilder
    {
        public CodeBuilder(string rootName)
        {
            theClass.Name = rootName;
        }

        public CodeBuilder AddField(string name, string type)
        {
            theClass.Fields.Add(new Field { Name = name, Type = type });
            return this;
        }

        public override string ToString()
        {
            return theClass.ToString();
        }

        private Class theClass = new Class();
    }
}


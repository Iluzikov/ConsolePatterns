using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID
{
    public enum Color
    {
        Red, Green, Blue
    }
    public enum Size
    {
        Small, Medium, Large, Yuge
    }
    public class Product
    {
        public readonly string Name;
        public readonly Color Color;
        public readonly Size Size;

        public Product(string name, Color color, Size size)
        {
            Name = name ?? throw new ArgumentNullException(paramName: nameof(name));
            Color = color;
            Size = size;
        }
    }

    public abstract class Specification<T>
    {
        public abstract bool IsSatisfied(T item);
        public static Specification<T> operator &(Specification<T> first, Specification<T> second)
        {
            return new AndSpecification<T>(first, second);
        }
    }

    public class ColorSpecification : Specification<Product>
    {
        private readonly Color _color;
        public ColorSpecification(Color color)
        {
            _color = color;
        }
        public override bool IsSatisfied(Product item)
        {
            return item.Color == _color;
        }
    }

    public class SizeSpecification : Specification<Product>
    {
        private readonly Size _size;
        public SizeSpecification(Size size)
        {
            _size = size;
        }
        public override bool IsSatisfied(Product item)
        {
            return item.Size == _size;
        }
    }

    public interface IFilter<T>
    {
        IEnumerable<T> Filter(IEnumerable<T> items, Specification<T> spec);
    }

    public class BetterFilter : IFilter<Product>
    {
        public IEnumerable<Product> Filter(
            IEnumerable<Product> items,
            Specification<Product> spec)
        {
            return items.Where(i => spec.IsSatisfied(i));
        }
    }

    public class AndSpecification<T> : CompositeSpecification<T>
    {
        public AndSpecification(params Specification<T>[] items) : base(items)
        {
        }

        public override bool IsSatisfied(T t)
        {
            // Any -> OrSpecification
            return items.All(i => i.IsSatisfied(t));
        }
    }

    public abstract class CompositeSpecification<T> : Specification<T>
    {
        protected readonly Specification<T>[] items;

        public CompositeSpecification(params Specification<T>[] items)
        {
            this.items = items;
        }
    }

    class OpenClose
    {

    }
}

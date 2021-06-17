using System;

namespace MultiBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            var pb = new PersonBuilder();
            Person person = pb
                .Lives
                    .At("Буденовский 55")
                    .In("Ростов-на-Дону")
                    .WithPostcode("344000")
                .Woks
                    .At("IT отдел")
                    .AsA("Инженер программист")
                    .Earning(800000);


            Console.WriteLine(person);
            Console.ReadLine();
        }
    }


    public class Person
    {
        public string StreetAddress, Postcode, City;
        public string CompanyName, Position;
        public int AnnualIncome;

        public override string ToString()
        {
            return $"Lives:\nAddress: {StreetAddress}, Post code: {Postcode}, City: {City},\nWorks:\n" +
                $"Company name: {CompanyName}, Position: {Position}, Annual income = {AnnualIncome}";
        }
    }

    public class PersonBuilder
    {
        protected Person person;
        public PersonBuilder()
        {
            person = new Person();
        }
        public PersonBuilder(Person person)
        {
            this.person = person;
        }

        public PersonAddressBuilder Lives => new PersonAddressBuilder(person);
        public PersonJobBuilder Woks => new PersonJobBuilder(person);

        public static implicit operator Person(PersonBuilder pb)
        {
            return pb.person;
        }
    }

    public class PersonAddressBuilder : PersonBuilder
    {
        public PersonAddressBuilder(Person person):base(person)
        {
        }

        public PersonAddressBuilder At(string streetAddress)
        {
            person.StreetAddress = streetAddress;
            return this;
        }
        public PersonAddressBuilder WithPostcode(string postcode)
        {
            person.Postcode = postcode;
            return this;
        }
        public PersonAddressBuilder In(string city)
        {
            person.City = city;
            return this;
        }

    }

    public class PersonJobBuilder : PersonBuilder
    {
        public PersonJobBuilder(Person person): base(person)
        {
        }

        public PersonJobBuilder At(string companyName)
        {
            person.CompanyName = companyName;
            return this;
        }
        public PersonJobBuilder AsA(string position)
        {
            person.Position = position;
            return this;
        }
        public PersonJobBuilder Earning(int annualIncome)
        {
            person.AnnualIncome = annualIncome;
            return this;
        }

    }


}

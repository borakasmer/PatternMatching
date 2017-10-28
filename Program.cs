using System;

namespace patternmatching
{
    class Program
    {
        static void Main(string[] args)
        {
            object[] data = { null, 39, DateTime.Now, null, new Person("Bora", "Kasmer", new DateTime(1978, 6, 3)), 78, new Person("Duru", "Kasmer", new DateTime(2012, 2, 27)) };
            foreach (var item in data)
            {
                //IsPattern(item);
                SwitchPattern(item);
            }
        }
        static int counter=0;
        public static void IsPattern(object o)
        {
            if (o is null) Console.WriteLine("Bu bir const patterndir"); 
            if (o is 78) Console.WriteLine("Bu bir 78'dir :)");    
            if (o is int i) Console.WriteLine($"Bu değer int tipine uymaktadır==> {i}");
            if (o is Person p) Console.WriteLine($"Bu kişi : {p.Name} dizi içerisinde bulunmaktadır.");
            if (o is Person p && p.Name.StartsWith("Bo"))             
            Console.WriteLine($"Adı Bo ile başlayan kişi ==> {p.Name} {p.Surname}'dir.");
            counter++;
            if (o is var x) Console.WriteLine($"{counter}. nesnenin türü {x?.GetType()?.Name}'dır.");
      
        }
        public static void SwitchPattern(object o)
        {
            switch (o)
            {
                case null:
                    Console.WriteLine("Gelen null bir değerdir.");
                    break;
                case int i:
                    Console.WriteLine("Integer tipinde bir sayıdır.");
                    break;
                case Person p when p.Name.StartsWith("Bo"):
                    Console.WriteLine($"Bo bir person {p.Name} dır.");
                    break;
                case Person p:
                    Console.WriteLine($"Başka bir person {p.Name} dır.");
                    break;
                case var x:
                    Console.WriteLine($"Sıradaki objenin [{x}] türü {x?.GetType().Name} dir ");
                    break;
                default:
                    break;
            }
        }
    }
    public class Person
    {
        public Person(string name, string surname, DateTime birthDate)
        {
            this.Name = name;
            this.Surname = surname;
            this.Birthdate = birthDate;
        }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthdate { get; set; }
    }
}

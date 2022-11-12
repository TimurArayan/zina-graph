using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zina_graph
{
    public struct Person
    {
        public string name;
        public int schet;
        public string problem;
        public byte temperament;
        public byte mind;

        public Person(string name, int schet, string problem, byte temperament, byte mind)
        {
            this.name = name;
            this.schet = schet;
            this.problem = problem;
            this.temperament = temperament;
            this.mind = mind;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Задание 3. Очередь в ЖЭК");
            Console.WriteLine();
            Random random = new Random();
            List<Person> turn1 = new List<Person>();
            List<Person> turn2 = new List<Person>();
            List<Person> turn3 = new List<Person>();
            Stack<Person> Sina = new Stack<Person>();
            List<Person> Sina_temp = new List<Person>
        {
            new Person("Николай", 9014, "подключение отопления", 8, 1),
            new Person("Валентина", 8479, "оплата отопления", 3, 0),
            new Person("Петр", 2981, "слишком высокие цены", 9, 1),
            new Person("Константин", 5695, "оплата отопления", 5, 0),
            new Person("Наташа", 2958, "подключение отопления", 3, 1),
            new Person("Владислав", 9124, "подключение отопления", 6, 1)
        };
            for (int i = Sina_temp.Count - 1; i != -1; i--)
            {
                Sina.Push(Sina_temp[i]);
            }
            foreach (Person x in Sina)
            {
                if (x.problem == "подключение отопления")
                {
                    if (x.mind == 0)
                    {
                        int num1 = random.Next(2, 3);
                        if (num1 == 2)
                        {
                            turn2.Add(x);
                        }
                        else
                        {
                            turn3.Add(x);
                        }
                    }
                    else
                    {
                        turn1.Add(x);
                    }
                }
                else if (x.problem == "оплата отопления")
                {
                    if (x.mind == 0)
                    {
                        int num2 = random.Next(1, 3);
                        if (num2 == 1)
                        {
                            turn1.Add(x);
                        }
                        else if (num2 == 2)
                        {
                            turn1.Add(x);
                        }
                        else
                        {
                            turn3.Add(x);
                        }
                    }
                    else
                    {
                        turn2.Add(x);
                    }
                }
                else
                {
                    if (x.mind == 0)
                    {
                        int num3 = random.Next(1, 2);
                        if (num3 == 1)
                        {
                            turn1.Add(x);
                        }
                        else
                        {
                            turn2.Add(x);
                        }
                    }
                    else
                    {
                        turn3.Add(x);
                    }
                }
            }
            for (int i = 1; i < turn1.Count; i++)
            {
                if (turn1[i].temperament >= 5)
                {
                    var temp = turn1[i];
                    Console.WriteLine($"{turn1[i].name} скандалист, введите сколько людей он/она обгонит (можно обогнать {i} людей)");
                    byte num = byte.Parse(Console.ReadLine());
                    while (temp.name != turn1[i - num].name)
                    {
                        for (int j = i; j > i - num; j--)
                        {
                            (turn1[j], turn1[j - 1]) = (turn1[j - 1], turn1[j]);
                        }
                    }
                }
            }

            for (int i = 1; i < turn2.Count; i++)
            {
                if (turn2[i].temperament >= 5)
                {
                    var temp = turn2[i];
                    Console.WriteLine($"{turn2[i].name} скандалист, введите сколько людей он/она обгонит (можно обогнать {i} людей)");
                    byte num = byte.Parse(Console.ReadLine());
                    while (temp.name != turn2[i - num].name)
                    {
                        for (int j = i; j > i - num; j--)
                        {
                            (turn2[j], turn2[j - 1]) = (turn2[j - 1], turn2[j]);
                        }
                    }
                }
            }

            for (int i = 1; i < turn3.Count; i++)
            {
                if (turn3[i].temperament >= 5)
                {
                    var temp = turn3[i];
                    Console.WriteLine($"{turn3[i].name} скандалист, введите сколько людей он/она обгонит (можно обогнать {i} людей)");
                    byte num = byte.Parse(Console.ReadLine());
                    while (temp.name != turn3[i - num].name)
                    {
                        for (int j = i; j > i - num; j--)
                        {
                            (turn3[j], turn3[j - 1]) = (turn3[j - 1], turn3[j]);
                        }
                    }
                }
            }
        }
    }
}

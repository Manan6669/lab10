using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace Lab_10
{
    class Program
    {
        class  Person : IComparable
        {
            public Person(string name, int age)
            {
                Name = name;
                Age = age;
            }
            public int CompareTo(object o)
            {
                Person p = o as Person;
                if (p != null)
                    return this.Name.CompareTo(p.Name);
                else
                    throw new Exception("Error");
            }

            public Person() { }
            public string Name { get; set; }
            public int Age { get; set; }
            public override string ToString()
            {
                return "Name: " + Name + " Age: " + Age;
            }

        }
        static void Main(string[] args)
        {
            Console.WriteLine("-------------Task 1-------------");
            
            
        ArrayList test = new ArrayList();  //необощенная коллекция
            Random r = new Random();
            for (int i = 0; i <= 5; i++)  
            {
                test.Add(r.Next(0, 10));
            }
            test.Add("queueewq"); // строку

            test.Add(new Person("Mikle", 19)); // добавили student
            test.RemoveAt(4); // удалили элемент
            Console.WriteLine("Kol-vo elementov: " + test.Count);
            Console.WriteLine("Cout");
            foreach (var item in test)  //поиск
            {
                Console.WriteLine(item);
            }

            if (test.Contains("queueewq"))
            {
                Console.WriteLine("srting here");
            }
            else
            {
                Console.WriteLine("no string");
            }

            

            Console.WriteLine("-------------Task 2-------------");
            List<int> test1 = new List<int>(); // collection
            for (int i = 0; i < 5; i++)
            {
                test1.Add(r.Next(0, 100));
            }
            foreach (int i in test1)  
            {
                Console.WriteLine(i);
            }

            test1.RemoveAt(2);

            Console.WriteLine(); 

            foreach (int i in test1)  
            {
                Console.WriteLine(i);
            }

            for (int i = 0; i < 5; i++)
            {
                test1.Add(r.Next(0, 50));

            }

            Console.WriteLine();
            foreach (int i in test1)  
            {
                Console.WriteLine(i);
            }

            
            Dictionary<int, int> test2 = new Dictionary<int, int>() { };//.....2 collection.........
            Console.WriteLine("\ncollection 2");
            int a = test1.Count;
            for (int i = 0; i < a; i++)
            {
                test2.Add(i, test1.Count);
            }
            foreach (int item in test2.Values)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Key: " + 3);
            if (test2.ContainsKey(3))
            {
                Console.WriteLine("Key 3 here");
            }
            else
            {
                Console.WriteLine("No key 3");
            }
            
            Console.WriteLine("--------------------------------Task 3--------------------------");
            List<Person> test3 = new List<Person>();

            test3.Add(new Person("Jim", 24));
            test3.Add(new Person("Fhhg", 91));
            test3.Add(new Person("jbhj", 3));
            test3.Add(new Person("Pittt", 43));
            test3.Add(new Person("Cola", 15));

           

            foreach (Person i in test3)
            {
                Console.WriteLine(i);
            }

            test1.RemoveAt(2);

            Console.WriteLine();

            foreach (int i in test1)
            {
                Console.WriteLine(i);
            }

            test3.Add(new Person("Dfl", 4));
            test3.Add(new Person("Hjkk", 65));

           Dictionary<Person, Person> test4 = new Dictionary<Person, Person>() { };
            Console.WriteLine("\nNew collection");
            a = test3.Count;
            Person h = new Person();

            
            for (int i = 0; i < a; i++)
            {
                test2.Add(i, test1.Count);
            }
            foreach (int item in test2.Values)
            {
                Console.WriteLine(item);
            }


            foreach (Person item in test4.Values)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Key: ");

            if (test4.ContainsKey(new Person("Cola", 15)))
            {
                Console.WriteLine("Key Cola,15 here");
            }
            else
            {
                Console.WriteLine("no key Cola, no 15");
            }
           
            Console.WriteLine("--------------------------------Task 4--------------------------");

            ObservableCollection<Person> test5 = new ObservableCollection<Person>() 
            {
            new Person ("w",12),
            new Person ("ewe",2),
            new Person ("vvdfd", 9)
            };

            test5.CollectionChanged += Users_CollectionChanged;

            test5.Add(new Person("dds", 06));
            test5.RemoveAt(1);
            test5[0] = new Person("www", 71);


        }
        private static void Users_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add: // add
                   Person newStudent = e.NewItems[0] as Person;
                    Console.WriteLine($"Add new obj: {newStudent.Name}");
                    break;
                case NotifyCollectionChangedAction.Remove: // если удаление
                    Person oldStudent = e.OldItems[0] as Person;
                    Console.WriteLine($"Delete obj: {oldStudent.Name}");
                    break;
                case NotifyCollectionChangedAction.Replace: // если замена
                    Person replacedStudent = e.OldItems[0] as Person;
                    Person replacingStudent = e.NewItems[0] as Person;
                    Console.WriteLine($"Obj {replacedStudent.Name} replace by {replacingStudent.Name}");
                    break;
            }
        }
    }
}

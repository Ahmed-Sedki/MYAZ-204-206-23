//Here we will know how to create a list of objects and how to use it.


namespace ListOfObjectsBasics
{
    class Program
    {
        static void Main(string[] args)
        {
            //here we will create a list of objects with type Fruit
            List<Fruit> fruits = new List<Fruit>();

            //here we created objects of type Fruit
            Fruit fruit1 = new Fruit("Apple", "Red", 2);
            Fruit fruit2 = new Fruit("Orange", "Orange", 3);
            Fruit fruit3 = new Fruit("Banana", "Yellow", 1);

            //here we will add the objects to the list
            fruits.Add(fruit1);
            fruits.Add(fruit2);
            fruits.Add(fruit3);

            //here we will print the list
            foreach (Fruit fruit in fruits)
            {
                Console.WriteLine(fruit.Name + " " + fruit.Color + " " + fruit.Price + "$");
            }


        }
    }
    
    class Fruit
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public int Price { get; set; }

        //create a constructor
        public Fruit(string name, string color, int price)
        {
            Name = name;
            Color = color;
            Price = price;
        }

    }
}
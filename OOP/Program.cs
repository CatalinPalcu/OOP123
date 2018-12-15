using System;

namespace OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            // class Animal
            //Problem1();

            // class Rabbit
            //Problem2();

            // class Products
            //Problem3();
        }

        public static void Problem1()
        {
            Animal dog = new Animal();
            dog.Name = "Rex";
            dog.CanWalk = true;
            dog.CanSwim = true;
            dog.MaxSpeedWalking = 20;
            dog.MaxSpeedSwimming = 5;
            dog.MaxSpeedFlying = 30;

            Console.WriteLine("The flying speed of the dog is:{0}", dog.MaxSpeedFlying);

            Console.WriteLine("\n" + dog);

            Animal cat = new Animal("Tiger", Animal.AnimalCategories.Mammal, false, true, false, true);
            cat.MaxSpeedCrawling = 3;
            cat.MaxSpeedWalking = 15;

            Console.WriteLine("\n" + cat);

            cat.CanCrawl = false;
            Console.WriteLine("The cat can't crawl anymore");
            Console.WriteLine("The max speed of crawling of the cat is:{0}", cat.MaxSpeedCrawling);
            Console.WriteLine("\n" + cat);

            Animal duck = new Animal("Donald Duck", Animal.AnimalCategories.Bird, true, true, true, false);
            duck.MaxSpeedFlying = 50;
            duck.MaxSpeedSwimming = 5;
            duck.MaxSpeedWalking = 4;
            Console.WriteLine("\n" + duck);

            duck.CanFly = false;
            Console.WriteLine("{0} just broke a wing, so the maximum flying speed is now: {1}", duck.Name, duck.MaxSpeedFlying);

            Console.WriteLine("\n" + duck);
        }

        public static void Problem2()
        {
            Rabbit iepure1 = new Rabbit();
            iepure1.Name = "Tomy";
            iepure1.IsSleeping = true;
            iepure1.FurColor = Rabbit.RabbitFurColor.Grey;
            iepure1.EyeColor = Rabbit.RabbitEyeColor.Red;
            Console.WriteLine(iepure1);
            Console.WriteLine();

            DateTime birthDay = DateTime.Now.AddMonths(-26);
            Rabbit iepure2 = new Rabbit(birthDay, Gender.Female, Rabbit.RabbitFurColor.Black, Rabbit.RabbitEyeColor.Black);
            iepure2.Name = "Lisa";
            iepure2.IsSleeping = false;
            iepure2.AddFavoriteFood("carrots, cabbage ");
            Console.WriteLine(iepure2);
        }

        public static void Problem3()
        {
            Product apple = new Product();
            apple.Name = "apple";
            apple.Weight = 350;
            apple.Producer = "Marul de aur";

            Console.WriteLine(apple+"\n");

            Product cheese = new Product(Product.ProductCategory.Dairy, "cheese", 450, DateTime.Now.AddDays(-2), "Alpro");
            Console.WriteLine(cheese+"\n");

            Product baguette = new Product(Product.ProductCategory.Bread, "baguette", 250, DateTime.Now.AddDays(-5), "Brutaria Veche");
            Console.WriteLine(baguette +"\n");

            Product wine = new Product(Product.ProductCategory.Beverages, "Busuioaca de Bohotin", 75, DateTime.Now.AddMonths(-20), "Crama Husi");
            Console.WriteLine(wine);


        }
    }
}

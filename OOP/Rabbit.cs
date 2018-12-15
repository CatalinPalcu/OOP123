using System;
using System.Collections.Generic;
using System.Text;

namespace OOP
{
    public enum Gender
    {
        Male=1,
        Female
    }

    public class Rabbit
    {
        public enum RabbitEyeColor
        {
            Blue,
            Red,
            Black
        }
        public enum RabbitFurColor
        {
            White,
            Brown,
            Black,
            Grey
        }

        private RabbitEyeColor eyeColor;
        private RabbitFurColor furColor;
        private readonly Gender gender;
        private readonly DateTime birthDay;
        private string favoriteFood;
        private bool isSleeping = false;

        public string Name { get; set; }

        public RabbitEyeColor EyeColor
        {
            get { return eyeColor; }
            set { eyeColor = value; }
        }

        public RabbitFurColor FurColor
        {
            get { return furColor; }
            set { furColor = value; }
        }

        public string FavoriteFood
        {
            get { return favoriteFood;}
            set { favoriteFood = value; }
        }

        public int Age // returnam numarul de luni
        {
            get
            {
                DateTime now = DateTime.Now;

                return (now.Year - birthDay.Year) * 12 + (now.Month - birthDay.Month);
            }
        }

        public bool IsSleeping
        {
            get { return this.isSleeping; }
            set { this.isSleeping = value; }
        }

        public Rabbit()
        {
            Name = "[no name]";
            birthDay = DateTime.Now;
            int g;
            do
            {
                Console.WriteLine("Give the gender of the rabbit: 1-Male; 2-Female");
            } while (!Int32.TryParse(Console.ReadLine(), out g) || g < 1 || g > 2);
            gender = (Gender)g;
            this.EyeColor = RabbitEyeColor.Black;
            this.FurColor = RabbitFurColor.White;
            favoriteFood = "milk";
        }

        public Rabbit(DateTime birthDay, Gender gender, RabbitFurColor furColor = RabbitFurColor.White, RabbitEyeColor eyeColor=RabbitEyeColor.Black)
        {
            Name = "[no name]";
            DateTime now = DateTime.Now;
            if (now.CompareTo(birthDay) > 0)
                this.birthDay = birthDay;
            else
                this.birthDay = now;

            this.gender = gender;
            this.FurColor = furColor;
            this.EyeColor = eyeColor;
            this.FavoriteFood = "";
        }

        public void AddFavoriteFood(string newFavoriteFood)
        {
            this.FavoriteFood += newFavoriteFood;
        }

        public void ChangeFavoriteFood(string favoriteFood)
        {
            this.FavoriteFood = favoriteFood;
        }

        public string Move()
        {
            if(!IsSleeping)
                return String.Format("the rabbit {0} hops on the field.",Name);

            return String.Format("the rabbit {0} is sleeping. Wake it up to be able to move.", Name);
        }

        private string AgeToLongFormat()
        {
            int age = this.Age;
            string output="";
            if (age >= 24)
                output += (age / 12).ToString() + " years";
            else if (age >= 12)
                output += "one year";

            if (age % 12 > 1)
            {
                if (output != "")
                    output += " and ";
                output += (age % 12).ToString() + " months old";
            }  else if (age %12 ==1)
            {
                if (output != "")
                    output += " and ";
                output += "one month old";
            }
            else
            {
                if (output != "")
                    output += " old";
                else
                    output = "a baby rabbit, less than one month old";
            }


            return output;
        }

        public override string ToString()
        {
            string output = String.Format("Information about the rabbit {0}:\n",Name);
            output += String.Format("\t- it is {0} with {1} fur and {2} eyes\n", this.gender, this.FurColor, this.EyeColor);
            output += String.Format("\t- it is {0}\n\t- its favourite food is {1}\n",this.AgeToLongFormat(),this.FavoriteFood);
            output += String.Format("\t- right now, {0}",this.Move());

            return output;
        }


    }
}

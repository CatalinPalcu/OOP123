using System;
using System.Collections.Generic;
using System.Text;

namespace OOP
{

    class Animal
    {
        public enum AnimalCategories
        {
            Mammal,
            Fish,
            Bird,
            Reptile,
            Insect
        }

        private string name = "[no name]";
        private double[] maxSpeed = { 0,0,0,0};
        private readonly AnimalCategories category;
        private bool canFly = false;
        private bool canSwim = false;
        private bool canWalk = false;
        private bool canCrawl = false;

        public bool CanFly
        {   get { return canFly; }
            set
            {
                if (!value)
                    MaxSpeedFlying = 0;
                canFly = value;
            }
        }

        public bool CanWalk
        {
            get { return canWalk; }
            set
            {
                if (!value)
                    MaxSpeedWalking = 0;
                canWalk = value;
            }
        }

        public bool CanSwim
        {
            get { return canSwim; }
            set
            {
                if (!value)
                    MaxSpeedSwimming = 0;
                canSwim = value;
            }
        }

        public bool CanCrawl
        {
            get { return canCrawl; }
            set
            {
                if (!value)
                    MaxSpeedCrawling = 0;
                canCrawl = value;
            }
        }

        public string Name
        {
            get { return this.name; }
            set { name = (value.Length > 0 ? value : name); }
        }

        public double MaxSpeedFlying
        {
            get { return maxSpeed[0]; }
            set { maxSpeed[0] = ((value >= 0 && CanFly )? value: maxSpeed[0]); }
        }

        public double MaxSpeedWalking
        {
            get { return maxSpeed[1]; }
            set { maxSpeed[1] = ((value >= 0 && CanWalk) ? value : maxSpeed[1]); }
        }

        public double MaxSpeedSwimming
        {
            get { return maxSpeed[2]; }
            set { maxSpeed[2] = ((value >= 0 && CanSwim) ? value : maxSpeed[2]); }
        }

        public double MaxSpeedCrawling
        {
            get { return maxSpeed[3]; }
            set { maxSpeed[3] = ((value >= 0 && CanCrawl) ? value : maxSpeed[3]); }
        }

        public Animal()
        {
            this.category = AnimalCategories.Mammal;
        }

        public Animal(string _name, AnimalCategories _cartegory, bool fly = false, bool walk = false, bool swim = false, bool crawl = false)
        {
            this.Name = _name;
            this.category = _cartegory;
            this.CanFly = fly;
            this.CanWalk = walk;
            this.CanSwim = swim;
            this.CanCrawl = crawl;
        }

        public override string ToString()
        {
            string output = String.Format("{0} is a {1} and has the following abilities:", Name, category.ToString());

            if (CanFly)
                output += String.Format("\n\t- can fly and the maximum speed of flying is : {0}", MaxSpeedFlying);
            if (CanWalk)
                output += String.Format("\n\t- can walk and the maximum speed of walking is : {0}", MaxSpeedWalking);
            if (CanSwim)
                output += String.Format("\n\t- can swim and the maximum speed of swimming is : {0}", MaxSpeedSwimming);
            if (CanCrawl)
                output += String.Format("\n\t- can crawl, and the maximum speed of crawling is : {0}", MaxSpeedCrawling);

            return output;
        }
    }
}

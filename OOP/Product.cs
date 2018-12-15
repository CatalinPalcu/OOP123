using System;
using System.Collections.Generic;
using System.Text;

namespace OOP
{
    class Product
    {
        public enum ProductCategory
        {
            Dairy = 1,
            Fruit,
            Beverages,
            Bread
        }

        private double weight;
        private string name = "[no name]";
        private readonly DateTime productionDate;
        private string producer = "[no name]";
        private readonly ProductCategory category;

        public double Weight
        {
            get { return this.weight; }
            set { this.weight = (value > 0)? value:0; }
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = (value.Length > 0) ? value : this.name; }
        }

        public string Producer
        {
            get { return this.producer; }
            set { this.producer = (value.Length > 0) ? value : this.producer; }
        }

        public DateTime ProductionDate
        {
            get { return this.productionDate; }
        }

        public DateTime ExpirationDate
        {
            get
            {
                switch (this.category)
                {
                    case ProductCategory.Dairy:
                        return productionDate.AddDays(7);
                    case ProductCategory.Fruit:
                        return productionDate.AddDays(2);
                    case ProductCategory.Beverages:
                        return productionDate.AddYears(3);
                    default :
                        return productionDate.AddDays(4);
                }
            }
        }

        public ProductCategory Category
        {
            get { return this.category; }
        }

        public Product()
        {   
            int productCategory;
            do
            {
                Console.WriteLine("Give the category of the product:\n\t1-Dairy\n\t2-Fruit\n\t3-Beverages\n\t4-Bread");
            } while (!Int32.TryParse(Console.ReadLine(), out productCategory) || productCategory < 1 || productCategory > 4);

            this.category = (ProductCategory)productCategory;

            this.productionDate = DateTime.Now;
            this.weight = 0;
        }

        public Product (ProductCategory _category, string _name, double _weight, DateTime _productionDate, string _producer = "")
        {
            this.category = _category;
            this.Name = _name;
            this.Weight = _weight;
            DateTime now = DateTime.Now;

            this.productionDate = (now.CompareTo(_productionDate) < 0)?now:_productionDate;

            this.Producer = _producer;
        }

        public bool IsSafeToUse()
        {
            DateTime now = DateTime.Now;
            return (now.CompareTo(this.ExpirationDate) <= 0) ? true : false;
        }

        public int ExpireIn()
        {
            DateTime now = DateTime.Now;
            if (this.category != ProductCategory.Beverages)
                 return this.ExpirationDate.Subtract(now).Days;
            return this.ExpirationDate.Subtract(now).Days/30;
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.Append(String.Format("{0}, weight: {1}, belongs to the category of products: {2}", Name, Weight , this.Category.ToString()));
            output.Append(String.Format("\n was made by {0} on {1}", Producer, ProductionDate.ToLongDateString()));

            if (IsSafeToUse())
            {
                if (this.category != ProductCategory.Beverages)
                    output.Append(String.Format("\n can be used another {0} days", ExpireIn()));
                else
                {
                    int expire = ExpireIn();
                    if (expire > 0)
                        output.Append(String.Format("\n can be used another {0} months", expire));
                    else
                    {
                        DateTime now = DateTime.Now;
                        output.Append(String.Format("\n can be used another {0} days", this.ExpirationDate.Subtract(now).Days));
                    }
                }
            }
            else
            {
                output.Append(String.Format("\n it expired on {0} ", ExpirationDate.ToLongDateString()));
            }

           return output.ToString();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Day3_Ex4
{
    class Person
    {
        private string name;
        private int money;
        private List<Product> bagOfProducts;

        public Person(string name, int money)
        {
            this.Name = name;
            this.Money = money;
            this.BagOfProducts = new List<Product>();
        }

        public Person()
        {

        }

        public string Name
        {
            get
            {
                return this.name;
            }
            protected set
            {
                if(string.IsNullOrWhiteSpace(value) || value == string.Empty)
                {
                    throw new ArgumentException("Name cannot be empty");
                }

                this.name = value;
            }
        }

        public int Money
        {
            get
            {
                return this.money;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }

                this.money = value;
            }
        }

        public List<Product> BagOfProducts
        {
            get
            {
                return this.bagOfProducts;
            }
            set
            {
                this.bagOfProducts = value;
            }
        }


    }
}

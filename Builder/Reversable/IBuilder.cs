using System;
using System.Collections.Generic;

namespace Builder.Reversable
{
    public interface IBuilder<T>
    {
        T BuildUp();
        T TearDown();
    }

    public class Product
    {
        public int Count;
        public List<int> Items;

    }
    public class ProductBuilder : IBuilder<Product>
    {
         Product product = new Product();

        Random random=new Random();
        public Product BuildUp()
        {
            product.Count = 0;
            product.Items=new List<int>();
            for (int i = 0; i < 5; i++)
            {
                product.Items.Add(random.Next());
                product.Count ++;
            }
            return product;
        }

        public Product TearDown()
        {
            while (product.Count>0)
            {
                var num = product.Items[0];
                product.Items.Remove(num);
                product.Count--;
            }
            return product;
        }
    }
}

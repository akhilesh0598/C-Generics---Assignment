using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericAssignment1
{
    class InventryList
    {
        private List<Product> _products;
        public int Count { get {
                return _products.Count;
            } }
        
        public InventryList()
        {
            _products = new List<Product>();
        }
        public void Add(Product product)
        {
            _products.Add(product);
            
        }
        public List<Product> GetAll()
        {
            return _products;
        }
        public List<Product>GetByType(string type)
        {
            return _products.Where(x => x.Type == type).ToList();
        }
        public void Remove(string name)
        {
            for(int i=0;i<_products.Count;i++)
            {
                if(_products[i].Name==name)
                {
                    _products.RemoveAt(i);
                    break;
                }
            }
        }
        public int Add(string name,int quantity)
        {
            
            foreach(var product in _products)
            {
                if (product.Name == name)
                {
                    product.Quantity += quantity;
                    return product.Quantity;
                }
            }
            return 0;
        }
        public double Buy(string name,int quantity)
        {
            int totalProduct = this.Count;
            for(int i=0;i<totalProduct;i++)
            {
                if(_products[i].Name==name)
                {
                    if (_products[i].Quantity > quantity)
                    {
                        _products[i].Quantity -= quantity;
                        return _products[i].Price * quantity;
                    }
                    else
                        return 0;

                }
            }
            return -1;

        }

    }
}

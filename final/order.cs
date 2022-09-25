using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace glasses_project
{
    class Order
    {
        private string id;
        private string code;
        private string item;
        private int quantity;
        private float price;
        public Order(string id, string code, string item, int quantity, float price)
        {
            this.id = id;
            this.code = code;
            this.item = item;
            this.quantity = quantity;
            this.price = price;
        }

        public string getId()
        {
            return id;
        }
        public string getCode()
        {
            return code;
        }
        public string getItem()
        {
            return item;
        }
        public int getQuantity()
        {
            return quantity;
        }
        public float getPrice()
        {
            return price;
        }

        public void setID(string id)
        {
            this.id = id;
        }
        public void setCode(string code)
        {
            this.code = code;
        }
        public void setItem(string item)
        {
            this.item = item;
        }
        public void setQuantity(int quantity)
        {
            this.quantity = quantity;
        }
        public void setPrice(float price)
        {
            this.price = price;
        }
        // second class
    }
}


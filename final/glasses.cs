using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace glasses_project
{
    class glasses
    {
        private string code;
        private string item;
        private string type;
        private int quantity;
        private float price;


        public glasses(string code, string item, string type, int quantity, float price)
        {
            this.code = code;
            this.item = item;
            this.type = type;
            this.quantity = quantity;
            this.price = price;
        }

        public string getCode()
        {
            return code;
        }
        public string getItem()
        {
            return item;
        }
        public string getType()
        {
            return type;
        }
        public int getquantity()
        {
            return quantity;
        }
        public float Getprice()
        {
            return price;
        }

        public void setCode(string code)
        {
            this.code = code;
        }
        public void setItem(string item)
        {
            this.item = item;
        }
        public void Setglasscolor(string type)
        {
            this.type = type;
        }
        public void setquantity(int quantity)
        {
            this.quantity = quantity;
        }
        public void Setprice(float price)
        {
            this.price = price;
        }

    }
}

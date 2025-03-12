using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICT2ConAppDemoCS
{
    public delegate string StockHandler();
    
    internal class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public int Qty { get; set; }
        public int Rate { get; set; }
        public int StockAmount
        {
            get
            { 
                return Rate * Qty;
            }
        }
        public int MinRequiredQty { get; set; }
        public int MaxCapatity { get; set; }

        public event StockHandler Stock_Low;

        public event StockHandler Stock_High;

        public int Sell 
        {
            set
            {
                if (Qty - value >= 0)
                {
                    Qty -= value;
                    CheckStockForSales();
                }
                else
                    Console.WriteLine("Stock is less than selling quantity. So, Can't sell the product..");
            } 
        }

        public int Buy
        {
            set
            {
                if (CheckStockForPurchase(value))
                {
                    Qty += value;
                }
            }
        }
        private void CheckStockForSales()
        {
            if (Qty < MinRequiredQty)
            {
                //Console.WriteLine("Event Executed.");
                if (Stock_Low != null)
                {
                    Console.WriteLine(Stock_Low());
                    
                }
            }
        }

        private bool CheckStockForPurchase(int purchaseQty)
        {
            bool isApproved = true;
            if (Qty + purchaseQty > MaxCapatity)
            {
                isApproved = false;
                //Console.WriteLine("Event Executed.");
                if (Stock_High != null)
                {
                    Console.WriteLine(Stock_High());

                }
            }
            return isApproved;
        }

        public override string ToString()
        {
            return "Product ID : " + ProductID + "\t Name : " + Name + "\t Qunatity : " + Qty + "\t Rate : " + Rate + " \t Stock Amount : " + StockAmount;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pokno.Model
{
    public class StockPurchasedSetUpStatus
    {
        private List<long> incomingStockIds;
        private Stack<StockPurchasedSetUpLevel> stack;

        public StockPurchasedSetUpStatus()
        {
            incomingStockIds = new List<long>();
            stack = new Stack<StockPurchasedSetUpLevel>();
        }

        public List<long> IncomingStockIds
        {
            get { return incomingStockIds; }           
        }

        public void AddQuantityLevelInformation(string name,int quantity)
        {
            StockPurchasedSetUpLevel setUpLevel = new StockPurchasedSetUpLevel() { Name = name, Quantity = quantity };
            stack.Push(setUpLevel);
            
        }

        public List<StockPurchasedSetUpLevel> GetQuantityLevelInformation()
        {
            return stack.ToList();
        }
        
    }

    public class StockPurchasedSetUpLevel
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

using Pokno.Model.Model;

namespace Pokno.Model
{
    public class Stock : BaseModel
    {
        private string _name;
               
        public long Id { get; set; }
        public StockType Type { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }

        public bool HasPackage { get; set; }
        public bool HasPrice { get; set; }
        public bool HasPackageRelationship { get; set; }
                       
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                base.OnPropertyChanged("Name");
            }
        }
                
        
     
    }
}

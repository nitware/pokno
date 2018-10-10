using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokno.Model.Model
{
    public class StockReturnAction : BaseModel
    {
        private int _id;
        private string _name;

        public enum Actions
        {
            Return = 1,
            Replace = 2,
            Refund = 3
        }

        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
                base.OnPropertyChanged("Id");
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                base.OnPropertyChanged("Name");
            }
        }

        public string Description { get; set; }

    }


}

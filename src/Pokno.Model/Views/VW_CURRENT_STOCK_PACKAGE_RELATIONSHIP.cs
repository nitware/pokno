using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokno.Model.Views
{
    public class VW_CURRENT_STOCK_PACKAGE_RELATIONSHIP
    {
        public long Package_Relationship_Id { get; set; }
        public long Stock_Package_Relationship_Id { get; set; }
        public long Stock_Package_Id { get; set; }
        public long? Sub_Stock_Package_Id { get; set; }
        public decimal Quantity_In_Package { get; set; }
        public long Rank { get; set; }
        public long Stock_Id { get; set; }
        public DateTime Date_Set { get; set; }
        public long Set_By_Person_Id { get; set; }

        public string Stock_Name { get; set; }
        public string Package_Name { get; set; }
        public string Sub_Package_Name { get; set; }
    }




}

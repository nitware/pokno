using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokno.Model.Views
{
    public class VW_STOCK
    {
        public long Stock_Id { get; set; }
        public string Stock_Name { get; set; }
        public long Stock_Type_Id { get; set; }
        public string Stock_Descrption { get; set; }
        public string Image_Path { get; set; }
        public long Stock_Package_Count { get; set; }
        public long Stock_Price_Count { get; set; }
        public long Package_Relationship_Count { get; set; }
    }





}

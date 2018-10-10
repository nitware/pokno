using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Pokno.Model.Model;

namespace Pokno.Model
{
     
     public class PaymentType : BaseModel
     {
         private int _id;
         private string _name;

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
             get { return _name;}
             set
             {
                 _name = value;
                 base.OnPropertyChanged("Name");
             }
         }



     }
}

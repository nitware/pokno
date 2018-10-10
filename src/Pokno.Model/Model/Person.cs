using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

using Pokno.Model.Model;

namespace Pokno.Model
{
    
    public class Person : BaseModel
    {
        private string _name;
        private string _fullName;
        private Role _role;

        public int Id { get; set; }
        public PersonType Type { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string OtherName { get; set; }

        public string Name 
        {
            get 
            {
                //_name = FirstName + " " + LastName;
                return _name; 
            }
            set
            {
                _name = value;
                base.OnPropertyChanged("Name");
            }
        }
        
        public string FullName
        {
            get
            {
                //_fullName = FirstName + " " + LastName + " " + OtherName;
                return _fullName;
            }
            set
            {
                _fullName = value;
                base.OnPropertyChanged("FullName");
            }
        }

        public Role Role
        {
            get { return _role; }
            set
            {
                _role = value;
                base.OnPropertyChanged("Role");
            }
        }

        //public string FullName { get; set; }
        public string MobilePhone { get; set; }
        public string Email { get; set; }
        public string ContactAddress { get; set; }
       
        public Location Location { get; set; }
        public LoginDetail LoginDetail { get; set; }


    }


}

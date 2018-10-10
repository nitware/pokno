using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokno.Model.Model
{
    public class Store : Company
    {
        private string _name;
        private string _address;
        private string _website;
        private string _description;
        private string _email;
        private string _phone;
        private string _disclaimer;
        private string _logoFileName;

        public override string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                base.OnPropertyChanged("Name");
            }
        }
        public override string Address
        {
            get { return _address; }
            set
            {
                _address = value;
                base.OnPropertyChanged("Address");
            }
        }
        public override string Description 
        {
            get { return _description; } 
            set
            {
                _description = value;
                base.OnPropertyChanged("Description");
            }
        }
        public override string Website 
        {
            get { return _website; } 
            set
            {
                _website = value;
                base.OnPropertyChanged("Website");
            }
        }
        public override string Email 
        {
            get { return _email; } 
            set
            {
                _email = value;
                base.OnPropertyChanged("Email");
            }
        }
        public override string Phone 
        {
            get { return _phone; } 
            set
            {
                _phone = value;
                base.OnPropertyChanged("Phone");
            }
        }
        public override string Disclaimer 
        {
            get { return _disclaimer; }
            set
            {
                _disclaimer = value;
                base.OnPropertyChanged("Disclaimer");
            }
        }
        public string LogoFileName
        {
            get { return _logoFileName; }
            set
            {
                _logoFileName = value;
                base.OnPropertyChanged("LogoFileName");
            }
        }
       

        




    }



}

using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokno.Shell.ViewModel
{
    public interface IShellViewModel
    {
        string StoreName { get; set; }
        string YouAreHere { get; set; }
        string LoginStatus { get; set; }
        bool IsUserLoggedIn { get; set; }
        
        DelegateCommand HomeCommand { get;  }
        DelegateCommand PaymentCommand { get;  }
        DelegateCommand ReportCommand { get;  }
        DelegateCommand PeopleCommand { get;  }
        DelegateCommand StockCommand { get;  }
        DelegateCommand LogOutLinkButtonCommand { get;  }
        DelegateCommand AccountCommand { get;  }
        DelegateCommand SettingsCommand { get;  }

    }




}

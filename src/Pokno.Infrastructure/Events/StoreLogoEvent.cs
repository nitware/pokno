using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Prism.Events;

namespace Pokno.Infrastructure.Events
{
    public class StoreLogoEvent : PubSubEvent<string>
    {
    }
}

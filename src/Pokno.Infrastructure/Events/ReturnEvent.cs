using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Prism.Events;
using Pokno.Infrastructure.Models;

namespace Pokno.Infrastructure.Events
{
    public class ReturnEvent : PubSubEvent<UI.Returns>
    {
    }
}

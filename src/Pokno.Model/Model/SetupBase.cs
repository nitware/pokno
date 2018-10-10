using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Runtime.Serialization;
using Pokno.Model.Model;

namespace Pokno.Model
{
    
    public abstract class SetupBase : BaseModel
    {
        public int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
    }

}

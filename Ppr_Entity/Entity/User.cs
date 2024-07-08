using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ppr_Entity.Entity
{
    public class User
    {
        public int Id {get; set;}
        public required string Name {get; set;}
        public string FirstName {get; set;} = string.Empty;
        public string LastName {get; set;} = string.Empty;
        public string Place {get; set;} = string.Empty;
    }
}
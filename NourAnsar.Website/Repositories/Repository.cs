using NourAnsar.Website.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NourAnsar.Website.Repositories
{
    public class Repository
    {
       public ApplicationDbContext Context { get; set; }
    }
}

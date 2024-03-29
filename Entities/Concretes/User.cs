﻿
using Core.Entity.Abstracts;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes
{
    public class User:IdentityUser<int>
    {
        
        public string Picture { get; set; }

        public ICollection<Article> Articles { get; set; }

    }
}

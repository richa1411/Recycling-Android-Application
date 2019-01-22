﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using kymiraAPI;
using kymiraAPI.Models;

namespace kymiraAPI.Models
{
    public class kymiraAPIContext : DbContext
    {
        public kymiraAPIContext (DbContextOptions<kymiraAPIContext> options)
            : base(options)
        {

        }
        public DbSet<kymiraAPI.Models.Resident> ResidentDBSet { get; set; }
        public DbSet<kymiraAPI.Models.FAQ> FAQ { get; set; }
       // public Dbset<kymiraAPI.Models.FAQ> FAQDB { get; set; }
     }

    }


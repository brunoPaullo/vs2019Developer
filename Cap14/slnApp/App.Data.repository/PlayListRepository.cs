﻿using App.Data.Repository.Interface;
using App.Entities.Base;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.repository
{
    public class PlayListRepository : GenericRepository<Playlist>, IPlayListRepository
    {
        public PlayListRepository(DbContext context) : base(context)
        {
        }
    }
}

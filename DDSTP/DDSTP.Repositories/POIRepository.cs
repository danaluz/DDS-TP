﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDSTP.Data;
using DDSTP.Domain;

namespace DDSTP.Repositories
{
    public class POIRepository
    {
        public POIRepository(dbDDSTPContext context)
        {
            this.context = context;
        }

        private dbDDSTPContext context;

        public List<IPOI> Search(string filtro)
        {
            var result = from x in context ;

        }

    }
}
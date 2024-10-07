﻿using KoiOrderingSystemInJapan.Data.Base;
using KoiOrderingSystemInJapan.Data.Context;
using KoiOrderingSystemInJapan.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiOrderingSystemInJapan.Data.Repositories
{
    public class DeliveryDetailRepository : GenericRepository<DeliveryDetail>
    {
        public DeliveryDetailRepository() { }
        public DeliveryDetailRepository(KoiOrderingSystemInJapanContext context) { }
    }
}
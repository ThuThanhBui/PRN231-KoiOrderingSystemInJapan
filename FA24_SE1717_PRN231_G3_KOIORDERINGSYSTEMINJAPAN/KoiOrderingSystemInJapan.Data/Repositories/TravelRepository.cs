﻿using KoiOrderingSystemInJapan.Data.Base;
using KoiOrderingSystemInJapan.Data.Context;
using KoiOrderingSystemInJapan.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiOrderingSystemInJapan.Data.Repositories
{
    public class TravelRepository : GenericRepository<Travel>
    {
        public TravelRepository() { }

        public TravelRepository(KoiOrderingSystemInJapanContext context) => _context = context;

        public async Task<List<Travel>> GetAllTravelAsync()
        {
            return await _context.Travels.Include(x => x.TravelFarms).ThenInclude( y => y.Farm).ToListAsync();
        }

        //input: travelName || farmName || Price
        // khung search: 10000000000

        public async Task<List<Travel>> GetTravelBySearchKeyAsync(string searchKey)
        {
            IQueryable<Travel> query = _context.Set<Travel>().AsQueryable();

            if (decimal.TryParse(searchKey, out decimal price))
            {
                query = query.Where(x => x.Price == price);
            }
            else
            {
                query = query.Include(x => x.TravelFarms).ThenInclude(y => y.Farm);
                query = query.Where(x => x.Name.Contains(searchKey) || x.TravelFarms.Any(f => f.Farm.Name.Contains(searchKey)));
            }

            return await query.ToListAsync();
        }
    }
}
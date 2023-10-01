using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using webapi.Models;

namespace webapi.Data.Repositories
{
    public class VendorRepository : IVendorRepository
    {
        private readonly AppDbContext _dbContext;

        public VendorRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Vendor GetVendorById(int vendorId)
        {
            return _dbContext.Vendors
                .FirstOrDefault(v => v.Id == vendorId);
        }

        public List<Vendor> GetAllVendors()
        {
            return _dbContext.Vendors.ToList();
        }

        public void AddVendor(Vendor vendor)
        {
            _dbContext.Vendors.Add(vendor);
            _dbContext.SaveChanges();
        }

        public void UpdateVendor(Vendor vendor)
        {
            _dbContext.Vendors.Update(vendor);
            _dbContext.SaveChanges();
        }

        public void DeleteVendor(int vendorId)
        {
            var vendor = _dbContext.Vendors.Find(vendorId);
            if (vendor != null)
            {
                _dbContext.Vendors.Remove(vendor);
                _dbContext.SaveChanges();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using webapi.Models;

namespace webapi.Data
{
    public interface IVendorRepository
    {
        Vendor GetVendorById(int  vendorId);
        List<Vendor> GetAllVendors();
        void AddVendor(Vendor vendorId);
        void UpdateVendor(Vendor vendor);
        void DeleteVendor(int vendorId);
    }
}

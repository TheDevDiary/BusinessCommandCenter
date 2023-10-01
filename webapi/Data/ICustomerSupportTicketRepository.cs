using System;
using System.Collections.Generic;
using webapi.Models;

namespace webapi.Data
{
    public interface ICustomerSupportTicketRepository
    {
        CustomerSupportTicket GetCustomerSupportTicketById(int ticketId);
        List<CustomerSupportTicket> GetCustomerSupportTicketsByUserId(int userId);
        void AddCustomerSupportTicket(CustomerSupportTicket ticket);
        void UpdateCustomerSupportTicket(CustomerSupportTicket ticket);
        void DeleteCustomerSupportTicket(int ticketId);
    }
}

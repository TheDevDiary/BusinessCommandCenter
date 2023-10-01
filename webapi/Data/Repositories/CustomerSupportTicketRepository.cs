using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using webapi.Models;

namespace webapi.Data.Repositories
{
    public class CustomerSupportTicketRepository : ICustomerSupportTicketRepository
    {
        private readonly AppDbContext _dbContext;

        public CustomerSupportTicketRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public CustomerSupportTicket GetCustomerSupportTicketById(int ticketId)
        {
            return _dbContext.CustomerSupportTickets
                .FirstOrDefault(t => t.Id == ticketId);
        }

        public List<CustomerSupportTicket> GetCustomerSupportTicketsByUserId(int userId)
        {
            return _dbContext.CustomerSupportTickets
                .Where(t => t.UserId == userId)
                .ToList();
        }

        public void AddCustomerSupportTicket(CustomerSupportTicket ticket)
        {
            _dbContext.CustomerSupportTickets.Add(ticket);
            _dbContext.SaveChanges();
        }

        public void UpdateCustomerSupportTicket(CustomerSupportTicket ticket)
        {
            _dbContext.CustomerSupportTickets.Update(ticket);
            _dbContext.SaveChanges();
        }

        public void DeleteCustomerSupportTicket(int ticketId)
        {
            var ticket = _dbContext.CustomerSupportTickets.Find(ticketId);
            if (ticket != null)
            {
                _dbContext.CustomerSupportTickets.Remove(ticket);
                _dbContext.SaveChanges();
            }
        }
    }
}

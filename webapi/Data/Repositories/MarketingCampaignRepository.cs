using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using webapi.Models;

namespace webapi.Data.Repositories
{
    public class MarketingCampaignRepository : IMarketingCampaignRepository
    {
        private readonly AppDbContext _dbContext;

        public MarketingCampaignRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public MarketingCampaign GetMarketingCampaignById(int campaignId)
        {
            return _dbContext.MarketingCampaigns
                .FirstOrDefault(c => c.Id == campaignId);
        }

        public List<MarketingCampaign> GetAllMarketingCampaigns()
        {
            return _dbContext.MarketingCampaigns.ToList();
        }

        public void AddMarketingCampaign(MarketingCampaign campaign)
        {
            _dbContext.MarketingCampaigns.Add(campaign);
            _dbContext.SaveChanges();
        }

        public void UpdateMarketingCampaign(MarketingCampaign campaign)
        {
            _dbContext.MarketingCampaigns.Update(campaign);
            _dbContext.SaveChanges();
        }

        public void DeleteMarketingCampaign(int campaignId)
        {
            var campaign = _dbContext.MarketingCampaigns.Find(campaignId);
            if (campaign != null)
            {
                _dbContext.MarketingCampaigns.Remove(campaign);
                _dbContext.SaveChanges();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using webapi.Models;

namespace webapi.Data
{
    public interface IMarketingCampaignRepository
    {
        MarketingCampaign GetMarketingCampaignById(int campaignId);
        List<MarketingCampaign> GetAllMarketingCampaigns();
        void AddMarketingCampaign(MarketingCampaign campaign);
        void UpdateMarketingCampaign(MarketingCampaign campaign);
        void DeleteMarketingCampaign(int campaignId);
    }
}

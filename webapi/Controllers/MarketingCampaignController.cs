using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using webapi.Data;
using webapi.Models;

namespace webapi.Controllers
{
    [Route("api/marketingcampaigns")]
    [ApiController]
    public class MarketingCampaignsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MarketingCampaignsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/marketingcampaigns
        [HttpGet]
        public ActionResult<IEnumerable<MarketingCampaign>> GetMarketingCampaigns()
        {
            return _context.MarketingCampaigns.ToList();
        }

        // GET: api/marketingcampaigns/{id}
        [HttpGet("{id}")]
        public ActionResult<MarketingCampaign> GetMarketingCampaignById(int id)
        {
            var campaign = _context.MarketingCampaigns.Find(id);

            if (campaign == null)
            {
                return NotFound();
            }

            return campaign;
        }

        // POST: api/marketingcampaigns
        [HttpPost]
        public ActionResult<MarketingCampaign> CreateMarketingCampaign(MarketingCampaign campaign)
        {
            _context.MarketingCampaigns.Add(campaign);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetMarketingCampaignById), new { id = campaign.Id }, campaign);
        }
    }
}

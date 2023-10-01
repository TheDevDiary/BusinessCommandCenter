using System;
using System.ComponentModel.DataAnnotations;

namespace webapi.Models
{
    public class MarketingCampaign
    {
        public int Id {  get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set;}
        public string Description { get; set;}
        [Required]
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string CampaignType { get; set; }
        public decimal Budget {  get; set; }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace CorePractise.Models
{
    public class StockCode
    {
        public string Company { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty; 
    }
}

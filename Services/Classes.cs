using Microsoft.AspNetCore.Mvc.Rendering;
using CorePractise.Models;
using System.Reflection.Metadata.Ecma335;

namespace CorePractise.Services
    {
    public class LabelDataService 
    {
        private readonly List<StockCode> _stockCodes = new List<StockCode>
        {
            new StockCode { Company = "ACME", Code = "1001", Description = "Test Scones 4pk" },
            new StockCode { Company = "ACME", Code = "1002", Description = "Test Rusks 500g" },
            new StockCode { Company = "BETA", Code = "2001", Description = "Test Bread 700g" },
            new StockCode { Company = "BETA", Code = "2002", Description = "Test Rolls 6pk" }
        };

        public List<SelectListItem> GetCompanies()
        {
            return new List<SelectListItem>
            {
                new SelectListItem { Value = "ACME", Text = "Acme Foods" },
                new SelectListItem { Value = "BETA", Text = "Beta Bakery" }
            };
        }

        public List<SelectListItem> GetStockCodes(string company)
        {
            return _stockCodes
              .Where(sc => sc.Company == company)
              .Select(sc => new SelectListItem { Value = sc.Code, Text = sc.Description })
              .ToList();
        }
    }
}
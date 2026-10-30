using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CorePractise.Services;

namespace CorePractise.Pages
{
    public class LabelFormModel : PageModel
    {
        private readonly LabelDataService _service;


        public List<SelectListItem> Companies { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> StockCodes { get; set; } = new List<SelectListItem>();

        [BindProperty]

        public string SelectedCompany { get; set; } = string.Empty;

        [BindProperty]

        public string SelectedStockCode { get; set; } = string.Empty;

        [BindProperty]
        public string BatchNumber { get; set; } = string.Empty;

        public string Message { get; set; } = string.Empty;

        public LabelFormModel(LabelDataService service)
        {
            _service = service;

        }

        public void OnGet()
        {
            Companies = _service.GetCompanies();
           
        }

        public void OnPostCompanyChanged()
        {
            Companies = _service.GetCompanies();
            StockCodes = _service.GetStockCodes(SelectedCompany);

            ModelState.Remove(nameof(SelectedStockCode));
            SelectedStockCode = string.Empty;
        }


        public void OnPost()
        {
            Companies = _service.GetCompanies();
            StockCodes = _service.GetStockCodes(SelectedCompany);

            SelectListItem? selectedCompanyItem = Companies.FirstOrDefault(c => c.Value == SelectedCompany);
            SelectListItem? selectedStockCodeItem = StockCodes.FirstOrDefault(sc => sc.Value == SelectedStockCode);

            string companyName = selectedCompanyItem?.Text ?? SelectedCompany;
            string stockName = selectedStockCodeItem?.Text ?? SelectedStockCode;

            Message = $"You chose {companyName} / {stockName} / {BatchNumber}";
        }
    }

}
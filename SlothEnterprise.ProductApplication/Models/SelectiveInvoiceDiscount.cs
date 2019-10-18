using SlothEnterprise.External.V1;
using SlothEnterprise.ProductApplication.Interfaces;

namespace SlothEnterprise.ProductApplication.Models
{
    public class SelectiveInvoiceDiscount : SellerApplication, ISellerApplication
    {
        private ISelectInvoiceService _selectInvoiceService;

        public SelectiveInvoiceDiscount(ISelectInvoiceService selectInvoiceService, ISellerCompanyData companyData)
        {
            _selectInvoiceService = selectInvoiceService;
            CompanyData = companyData;
        }

        /// <summary>
        /// Proposed networth of the Invoice
        /// </summary>
        public decimal InvoiceAmount { get; set; }

        /// <summary>
        /// Percentage of the networth agreed and advanced to seller
        /// </summary>
        public decimal AdvancePercentage { get; set; } = 0.80M;

        public override int SubmitApplication()
        {
            return _selectInvoiceService.SubmitApplicationFor(this.CompanyData.Number.ToString(), this.InvoiceAmount, this.AdvancePercentage);
        }
    }
}
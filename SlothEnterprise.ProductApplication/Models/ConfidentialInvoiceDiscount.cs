using SlothEnterprise.External;
using SlothEnterprise.External.V1;
using SlothEnterprise.ProductApplication.Interfaces;

namespace SlothEnterprise.ProductApplication.Models
{
    public class ConfidentialInvoiceDiscount : SellerApplication, ISellerApplication
    {
        private IConfidentialInvoiceService _confidentialInvoiceService;

        public ConfidentialInvoiceDiscount(IConfidentialInvoiceService confidentialInvoiceService, ISellerCompanyData companyData)
        {
            _confidentialInvoiceService = confidentialInvoiceService;
            CompanyData = companyData;
        }

        public decimal TotalLedgerNetworth { get; set; }
        public decimal AdvancePercentage { get; set; }
        public decimal VatRate { get { return VatRates.UkVatRate; } }

        public override int SubmitApplication()
        {
            var companyDataRequest = new CompanyDataRequest()
            {
                CompanyFounded = this.CompanyData.Founded,
                CompanyName = this.CompanyData.Name,
                CompanyNumber = this.CompanyData.Number,
                DirectorName = this.CompanyData.DirectorName
            };

            return _confidentialInvoiceService.SubmitApplicationFor(
                companyDataRequest, TotalLedgerNetworth, AdvancePercentage, VatRate).ApplicationId.GetValueOrDefault(-1);
        }
    }
}
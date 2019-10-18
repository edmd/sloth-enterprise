using SlothEnterprise.External;
using SlothEnterprise.External.V1;
using SlothEnterprise.ProductApplication.Interfaces;

namespace SlothEnterprise.ProductApplication.Models
{
    public class BusinessLoan : SellerApplication
    {
        private IBusinessLoansService _businessLoansService;

        public BusinessLoan(IBusinessLoansService businessLoansService, ISellerCompanyData companyData)
        {
            _businessLoansService = businessLoansService;
            CompanyData = companyData;
        }

        /// <summary>
        /// Per annum interest rate
        /// </summary>
        public decimal InterestRatePerAnnum { get; set; }

        /// <summary>
        /// Total available amount to withdraw
        /// </summary>
        public decimal LoanAmount { get; set; }

        public override int SubmitApplication()
        {
            // Potential candidate for Mapper
            var companyDataRequest = new CompanyDataRequest()
            {
                CompanyFounded = this.CompanyData.Founded,
                CompanyName = this.CompanyData.Name,
                CompanyNumber = this.CompanyData.Number,
                DirectorName = this.CompanyData.DirectorName
            };

            var loansRequest = new LoansRequest()
            {
                InterestRatePerAnnum = this.InterestRatePerAnnum,
                LoanAmount = this.LoanAmount
            };

            return _businessLoansService.SubmitApplicationFor(
                companyDataRequest, loansRequest).ApplicationId.GetValueOrDefault(-1);
        }
    }
}
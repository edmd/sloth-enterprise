using SlothEnterprise.External;
using SlothEnterprise.ProductApplication.Interfaces;

namespace SlothEnterprise.ProductApplication.Models
{
    public abstract class SellerApplication : ISellerApplication
    {
        protected int Id { get; set; }

        protected ISellerCompanyData CompanyData { get; set; }

        public abstract int SubmitApplication();
    }
}
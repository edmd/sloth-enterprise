using SlothEnterprise.ProductApplication.Interfaces;

namespace SlothEnterprise.ProductApplication
{
    public interface IProductApplicationService
    {
        int SubmitApplicationFor(ISellerApplication application);
    }
}
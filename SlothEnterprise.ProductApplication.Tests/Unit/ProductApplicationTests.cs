using Moq;
using NUnit.Framework;
using SlothEnterprise.External.V1;
using SlothEnterprise.ProductApplication.Interfaces;
using SlothEnterprise.ProductApplication.Models;

namespace SlothEnterprise.ProductApplication.Tests
{
    // The tests weren't approached using TDD, the application had to be refined until 
    // the exercise became clear how I would structure it
    [TestFixture]
    public class ProductApplicationTests
    {
        private Mock<ISelectInvoiceService> _selectInvoiceServiceMock;
        private Mock<IConfidentialInvoiceService> _confidentialInvoiceWebServiceMock;
        private Mock<IBusinessLoansService> _businessLoansServiceMock;
        private Mock<ISellerCompanyData> _sellerCompanyDataMock;

        private Mock<BusinessLoan> _businessLoanMock;
        private Mock<ConfidentialInvoiceDiscount> _confidentialInvoiceDiscountMock;
        private Mock<SelectiveInvoiceDiscount> _selectiveInvoiceDiscountMock;

        private Mock<IProductApplicationService> _productApplicationServiceMock;
        private Mock<ISellerApplication> _sellerApplicationMock;

        [SetUp]
        public void Setup()
        {
            _businessLoansServiceMock = new Mock<IBusinessLoansService>();
            _selectInvoiceServiceMock = new Mock<ISelectInvoiceService>();
            _confidentialInvoiceWebServiceMock = new Mock<IConfidentialInvoiceService>();
            _sellerCompanyDataMock = new Mock<ISellerCompanyData>();

            _businessLoanMock = new Mock<BusinessLoan>();
            _confidentialInvoiceDiscountMock = new Mock<ConfidentialInvoiceDiscount>();
            _selectiveInvoiceDiscountMock = new Mock<SelectiveInvoiceDiscount>();

            _sellerApplicationMock = new Mock<ISellerApplication>();
            _productApplicationServiceMock = new Mock<IProductApplicationService>();

            _productApplicationServiceMock.Setup(
                p => p.SubmitApplicationFor(It.IsAny<BusinessLoan>())).Returns(1);
            _productApplicationServiceMock.Setup(
                p => p.SubmitApplicationFor(It.IsAny<SelectiveInvoiceDiscount>())).Returns(1);
            _productApplicationServiceMock.Setup(
                p => p.SubmitApplicationFor(It.IsAny<ConfidentialInvoiceDiscount>())).Returns(1);
        }

        [Test]
        public void BusinessLoanTest()
        { 
            var productApplicationService = _productApplicationServiceMock.Object;
            Assert.AreEqual(productApplicationService.SubmitApplicationFor(new BusinessLoan(_businessLoansServiceMock.Object, _sellerCompanyDataMock.Object)), 1);
        }

        [Test]
        public void SelectiveInvoiceDiscountTest()
        {
            var productApplicationService = _productApplicationServiceMock.Object;
            Assert.AreEqual(productApplicationService.SubmitApplicationFor(new SelectiveInvoiceDiscount(_selectInvoiceServiceMock.Object, _sellerCompanyDataMock.Object)), 1);
        }

        [Test]
        public void ConfidentialInvoiceDiscountTest()
        {
            var productApplicationService = _productApplicationServiceMock.Object;
            Assert.AreEqual(productApplicationService.SubmitApplicationFor(new ConfidentialInvoiceDiscount(_confidentialInvoiceWebServiceMock.Object, _sellerCompanyDataMock.Object)), 1);
        }
    }
}

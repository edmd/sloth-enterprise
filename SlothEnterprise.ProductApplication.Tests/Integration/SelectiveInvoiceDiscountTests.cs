using Moq;
using NUnit.Framework;
using SlothEnterprise.External.V1;
using SlothEnterprise.ProductApplication.Interfaces;
using SlothEnterprise.ProductApplication.Models;

namespace SlothEnterprise.ProductApplication.Tests.Integration
{
    [TestFixture]
    public class SelectiveInvoiceDiscountTests
    {
        private Mock<ISelectInvoiceService> _selectInvoiceServiceMock;
        private SelectiveInvoiceDiscount _selectiveInvoiceDiscountMock;

        [Test]
        public void SelectInvoiceService_ValidCompanyTest()
        {
            _selectInvoiceServiceMock = new Mock<ISelectInvoiceService>();
            _selectiveInvoiceDiscountMock = new SelectiveInvoiceDiscount(_selectInvoiceServiceMock.Object, new SellerCompanyData { Number = 123 });
            _selectInvoiceServiceMock.Setup(s => s.SubmitApplicationFor("123", It.IsAny<decimal>(), It.IsAny<decimal>())).Returns(1);
            Assert.AreEqual(_selectiveInvoiceDiscountMock.SubmitApplication(), 1);
        }

        [Test]
        public void SelectInvoiceService_InvalidCompanyTest()
        {
            _selectInvoiceServiceMock = new Mock<ISelectInvoiceService>();
            _selectiveInvoiceDiscountMock = new SelectiveInvoiceDiscount(_selectInvoiceServiceMock.Object, new SellerCompanyData { Number = 1234 });
            _selectInvoiceServiceMock.Setup(s => s.SubmitApplicationFor("1234", It.IsAny<decimal>(), It.IsAny<decimal>())).Returns(-1);
            Assert.AreEqual(_selectiveInvoiceDiscountMock.SubmitApplication(), -1);
        }
    }
}
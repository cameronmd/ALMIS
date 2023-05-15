using ALMIS.ViewModel;
using NUnit.Framework;

namespace ALMIS.Tests
{
    [TestFixture]
    public class MainViewModelTests
    {
        [Test]
        public void CalculateReturns_ProductAReturn_CalculatesCorrectly()
        {
            var viewModel = new MainViewModel();
            viewModel.PrincipalAmount = 10000;

            viewModel.CalculateReturns();

            Assert.AreEqual(10300, viewModel.ProductAReturn);
        }

        [Test]
        public void CalculateReturns_ProductBReturn_CalculatesCorrectly()
        {
            var viewModel = new MainViewModel();
            viewModel.PrincipalAmount = 10000;

            viewModel.CalculateReturns();

            Assert.AreEqual(10606.98, viewModel.ProductBReturn, 0.01);
        }
    }
}

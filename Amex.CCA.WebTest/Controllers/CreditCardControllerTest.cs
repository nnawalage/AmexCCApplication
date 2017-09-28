using Amex.CCA.WebApi.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;

namespace Amex.CCA.WebTest.Controllers
{
    [TestClass]
    public class CreditCardControllerTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var controller = new CreditCardsController();
            int id = 91;

            controller.ControllerContext = HomeControllerTest.GetTokenUser();
            HttpResponseMessage response = controller.GetCreditCard(id);

            

            // Assert
            Assert.AreNotEqual(response, null);
            //Assert.AreEqual(MessageCode.Success, response.Content.Code);
            //Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
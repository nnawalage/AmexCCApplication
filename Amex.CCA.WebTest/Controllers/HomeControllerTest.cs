using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
using System.Web.Http.Controllers;

namespace Amex.CCA.WebTest.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
       public static HttpControllerContext GetTokenUser()
        {
            var controllerContext = new HttpControllerContext();
            var request = new HttpRequestMessage();
            // Replace the token if it is expired
            request.Headers.Add("Authorization", "Bearer 2LNE3rMYG9wuzG8oZB8Mqv90cxw3QBTwsTxldS4Sj_ob9JOonYGQ8K - fd1BX70jgD_u8xgJezDaTGIZYXU41MP9IcCFxty6CT7IJKBkgf41zmPv35cPh5FabV66FtqMUoNt7NOWgntgRIzMy9e_ - GmRAE0dJvpiyJTk - CwS0wo - rMXiYRL5gqB8IgmPWr - ZYFE1U0G2codyYsP0IrS4cpv6ObTZJAy7PdewJLkHeYeh6N5_BHjnaALruUOmTVuMDx_CGO6hK3wcMfMBA3vYGaOzzDF2faoKVS - zJq9ng9Nx2CqsY0uJVFx5wJo4WiYQnnpffjPMEUZ5ss8aCtJc5p3mhCsXxKHsaMAUAnpJ_XfdsYVAmJz6mdVNDYH0px_oa2Le7jXs2VX0Zutv845c - XN0DD2Tg3E3vEWEKNlYh5UE0w95NAZXbjYpegvJ6E7KwKkObdebvFhd65AFAVGzCws4oOAzsK7K34t_zBdfqBll - QRWzA_78nxXe18GnQ3rsouqQWzdzuTxy_Yeggaebvg");
            controllerContext.Request = request;
            return controllerContext;
        }
    }
}
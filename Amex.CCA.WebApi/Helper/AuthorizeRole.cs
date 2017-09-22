using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.IdentityModel.Tokens;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using Microsoft.Owin.Security.DataHandler.Encoder;
using Thinktecture.IdentityModel.Tokens;

namespace Amex.CCA.WebAPI.Helper
{
    public class AuthorizeRole : AuthorizeAttribute
    {
       //protected IZaptecUoW uow = new ZaptecUoW(new RepositoryProvider(new RepositoryFactories()));


        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            try
            {
                if (base.IsAuthorized(actionContext))
                {
                    var handler = new JwtSecurityTokenHandler();
                    var jwt = handler.ReadToken(actionContext.Request.Headers.Authorization.Parameter) as JwtSecurityToken;
                    var email = jwt.Payload.ToList()[1].Value.ToString();
                    var entitlement = actionContext.ActionDescriptor.ActionName.ToString();
                    var controller = actionContext.Request.RequestUri.LocalPath.Split('/')[2].ToString();
                    Permissions permission = new Permissions(uow);

                    return permission.checkEntitlement(email, entitlement, controller);
                }
                else
                {
                    return false;
                }

                
            }
            catch (Exception)
            {
                
                return false;
            }

            

        }

        protected override void HandleUnauthorizedRequest(HttpActionContext actionContext)
        {
            Debug.WriteLine("Running HandleUnauthorizedRequest in CustomAuthorizationFilterAttribute as principal is not authorized.");
            base.HandleUnauthorizedRequest(actionContext);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace swaggernet_apikey
{
    public class MyAuthorizeAttribute: AuthorizeAttribute
    {
        

        public override void OnAuthorization(HttpActionContext actionContext)
        {
            try
            {
                var apikey = actionContext.Request.Headers.GetValues("apikey")?.FirstOrDefault();

                if (apikey == "123") // here is your token logic.
                {
                    actionContext.RequestContext.Principal = new ClaimsPrincipal( new MyPrincipal(apikey));
                }
            }
            catch (Exception)
            {
            }
            base.OnAuthorization(actionContext);
        }

        protected override void HandleUnauthorizedRequest(HttpActionContext actionContext)
        {
            base.HandleUnauthorizedRequest(actionContext);
        }

        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            if (actionContext.RequestContext.Principal.Identity is MyPrincipal)
            {
                return true;
            }
            return base.IsAuthorized(actionContext);
        }
    }

    public class MyPrincipal : ClaimsIdentity
    {
        /// <summary>
        /// this may be your business model Register
        /// </summary>
        public string RegisterID { get; set; }
        public MyPrincipal(string registerID)
        {
            this.RegisterID = registerID;
        }
    }
}
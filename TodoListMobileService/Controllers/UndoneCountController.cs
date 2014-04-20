using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.WindowsAzure.Mobile.Service;
using Microsoft.WindowsAzure.Mobile.Service.Security;
using TodoListMobileService.DataObjects;

namespace TodoListMobileService.Controllers
{
    [RequiresAuthorization(AuthorizationLevel.Anonymous)]
    public class UndoneCountController : ApiController
    {
        public ApiServices Services { get; set; }

        // GET api/UndoneCount
        [RequiresAuthorization(AuthorizationLevel.Anonymous)]
        public UndoneCountResult Get()
        {
            TodoListMobileService.Models.TodoListMobileServiceContext context = new Models.TodoListMobileServiceContext();
            var queryResults = from item in context.TodoItems
                               where item.Complete == false
                               select item;
            var count = queryResults.Count();
            Services.Log.Info(string.Format("Hello from custom controller! -> {0}", count.ToString()));
            return new UndoneCountResult()
            {
                Count = count
            };
        }

    }
}

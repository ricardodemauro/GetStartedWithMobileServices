using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.WindowsAzure.Mobile.Service;

namespace TodoListMobileService.ScheduledJobs
{
    // A simple scheduled job which can be invoked manually by submitting an HTTP
    // POST request to the path "/jobs/Default".

    public class DefaultJob : ScheduledJob
    {
        public override Task ExecuteAsync()
        {
            Services.Log.Info("Hello from scheduled job TESTE!");
            return Task.FromResult(true);
        }
    }
}
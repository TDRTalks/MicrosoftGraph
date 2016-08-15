using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OfficeHours.Common;
using System.Net.Http;
using System.Net.Http.Headers;
//using Microsoft.Identity.Client;
using System.Threading.Tasks;
using OfficeHours.Models;
using Newtonsoft.Json;
using Microsoft.Graph;

namespace OfficeHours.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public async Task<ActionResult> Messages()
        {
            ViewBag.Message = "Your application description page.";

            //string accessToken = await AuthProvider.Instance.GetUserAccessTokenAsync();

            //HttpClient client = new HttpClient();
            //HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Get, "https://graph.microsoft.com/v1.0/me/messages");

            //message.Headers.Authorization = new AuthenticationHeaderValue("bearer", accessToken);
            //HttpResponseMessage response = await client.SendAsync(message);

            //var data = await response.Content.ReadAsStringAsync();

            var graphClient = GraphClientHelper.GetAuthenticatedClient();

            var start = DateTime.Today.AddDays(-5).ToUniversalTime().ToString();
            var end = DateTime.Today.ToUniversalTime().ToString();

            var options = new List<Option>();
            options.Add(new QueryOption("StartDateTime", start));
            options.Add(new QueryOption("EndDateTime", end));

            IUserCalendarViewCollectionPage calEvents = await graphClient.Me.CalendarView.Request(options).OrderBy("start/DateTime").GetAsync();

            var calList = new List<OfficeHours.Models.Message>();

            foreach (var calEvent in calEvents)
            {
                calList.Add(new OfficeHours.Models.Message { Subject = calEvent.Subject });
            }

            return View(calList);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
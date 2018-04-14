using GAP.Insurace.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace GAP.Insurace.MVC.Controllers
{
    public class ClientController : Controller
    {
        // GET: Client
        public ActionResult Index()
        {
            IEnumerable<ClientModel> clientList;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Client").Result;
            clientList = response.Content.ReadAsAsync<IEnumerable<ClientModel>>().Result;
            return View(clientList);
        }

        [HttpPost]
        public ActionResult AddUpdate(ClientModel client)
        {
            if (client.id == 0)
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("Client", client).Result;
                TempData["ClientMessage"] = "Client created successsfully";

            }
            else {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("Client/" + client.id.ToString(), client).Result;
                TempData["ClientMessage"] = "Client updated successsfully";
            }
            return RedirectToAction("Index");
        }
        
        public ActionResult AddUpdate(int id=0){
            if (id == 0)
            {
                return View(new ClientModel());
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Client/"+id.ToString()).Result;
                return View(response.Content.ReadAsAsync<ClientModel>().Result);
            }
        }

        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("Client/" + id.ToString()).Result;
            TempData["ClientMessage"] = "Client deleted successsfully";
            return RedirectToAction("Index");

        }
    }
}
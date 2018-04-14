using GAP.Insurace.MVC.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace GAP.Insurace.MVC.Controllers
{
    public class ClientPolicyController : Controller
    {
        // GET: ClientPolicy
        public ActionResult Index()
        {
            ClientPolicyListModel clientPolicy = new ClientPolicyListModel();
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Client").Result;
            clientPolicy.clientList = response.Content.ReadAsAsync<IEnumerable<ClientModel>>().Result;
            //response = GlobalVariables.WebApiClient.GetAsync("ClientPolicy/0").Result;
            //clientPolicy.clientPolicyList = response.Content.ReadAsAsync<IEnumerable<ClientPolicyModel>>().Result;
            clientPolicy.clientPolicyList = Enumerable.Empty<ClientPolicyModel>();
            return View(clientPolicy);
        }

        public ActionResult GetPoliciesByClient(int? id)
        {
            if (id != null)
            {
                ClientPolicyListModel clientPolicy = new ClientPolicyListModel();
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("ClientPolicy/"+id).Result;
                clientPolicy.clientPolicyList = response.Content.ReadAsAsync<IEnumerable<ClientPolicyModel>>().Result;
                return PartialView("PolicyClient", clientPolicy);
            }
            return PartialView("PolicyClient", new ClientPolicyListModel());
        }

        public JsonResult DeleteList(String idsList)
        {
            if (!idsList.Equals(String.Empty) )
            {
                List<int> deleteList = new List<int>();
                int idDelete = 0;
                foreach (String item in idsList.Split('|'))
                {
                    
                    if (int.TryParse(item, out idDelete))
                    {
                        deleteList.Add(idDelete);
                    }
                }
                    var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Delete,
                    RequestUri = new Uri(GlobalVariables.WebApiClient.BaseAddress+"ClientPolicy/"),
                    Content = new StringContent(JsonConvert.SerializeObject(deleteList.ToArray()), Encoding.UTF8, "application/json")
                };
                var response =  GlobalVariables.WebApiClient.SendAsync(request);

                
            }

            return Json(new{isValid = true}, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AddPolicies(String id) 
        {
            @ViewBag.clientId = id;
            IEnumerable<PolicyModel> policyList;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Policy").Result;
            policyList = response.Content.ReadAsAsync<IEnumerable<PolicyModel>>().Result;
            return View(policyList);
        }

        public JsonResult AddPoliciesToClient(String idsPolice, String clientId)
        {
            if (!idsPolice.Equals(String.Empty) && !clientId.Equals(String.Empty))
            {
                int id = 0;
                //Get Client
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Client/" + clientId.ToString()).Result;
                ClientModel eClient = response.Content.ReadAsAsync<ClientModel>().Result;
                foreach (String item in idsPolice.Split('|'))
                {
                    if (int.TryParse(item, out id))
                    {
                        response = GlobalVariables.WebApiClient.GetAsync("Policy/" + id.ToString()).Result;
                        PolicyModel ePolicy = response.Content.ReadAsAsync<PolicyModel>().Result;
                        if (ePolicy != null)
                        {
                            ClientPolicyBaseModel cp = new ClientPolicyBaseModel() {  clientid= eClient.id, policyid = ePolicy.id };
                            response = GlobalVariables.WebApiClient.PostAsJsonAsync("ClientPolicy", cp).Result;
                        }
                    }
                }
                
                TempData["ClientMessage"] = "Client created successsfully";
            }
            return Json(new { isValid = true }, JsonRequestBehavior.AllowGet);
        }
    }
}
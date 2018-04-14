using GAP.Insurace.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace GAP.Insurace.MVC.Controllers
{
    public class PolicyController : Controller
    {
        // GET: Policy
        public ActionResult Index()
        {
            IEnumerable<PolicyModel> policyList;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Policy").Result;
            policyList = response.Content.ReadAsAsync<IEnumerable<PolicyModel>>().Result;
            return View(policyList);
        }

        [HttpPost]
        public ActionResult AddUpdate(PolicyModel entity)
        {
            if (entity.id == 0)
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("Policy", entity).Result;
                TempData["PolicyMessage"] = "Policy created successsfully";

            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("Policy/" + entity.id.ToString(), entity).Result;
                TempData["PolicyMessage"] = "Policy updated successsfully";
            }
            return RedirectToAction("Index");
        }

        public ActionResult AddUpdate(int id = 0)
        {
            if (id == 0)
            {
                return View(new PolicyModel());
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Policy/" + id.ToString()).Result;
                PolicyModel entity = response.Content.ReadAsAsync<PolicyModel>().Result;
                return View(entity);
            }
        }

        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("Policy/" + id.ToString()).Result;
            TempData["PolicyMessage"] = "Policy deleted successsfully";
            return RedirectToAction("Index");

        }
    }
}
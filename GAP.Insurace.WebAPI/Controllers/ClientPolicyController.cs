using GAP.Insurace.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GAP.Insurace.WebAPI.Controllers
{
    [RoutePrefix("api/ClientPolicy")]
    public class ClientPolicyController : ApiController
    {
        UnitOfWork unit = new UnitOfWork(new InsuranceContext());

        //GET api/client

        public IHttpActionResult Get()
        {
            try
            {
                var result = unit.ClientPolicy.GetAll();
                return Ok(result);
            }
            catch (Exception)
            {
                //If any exception occurs Internal Server Error i.e. Status Code 500 will be returned  
                return InternalServerError();
            }
        }

        // PUT api/ClientPolicy/id
        public IHttpActionResult Get(int id)
        {
            try
            {
                var result = unit.ClientPolicy.GetBy(x => x.client.id == id);
                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception)
            {
                //If any exception occurs Internal Server Error i.e. Status Code 500 will be returned  
                return InternalServerError();
            }

        }

        // PUT api/client
        public IHttpActionResult Put(ClientPolicy entity)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");
            var existingClient = unit.ClientPolicy.GetFirst(x => x.id == entity.id);
            if (existingClient != null)
            {
                //existingClient.firstName = client.firstName;
                //existingClient.lastName = client.lastName;

                unit.ClientPolicy.Update(existingClient);
            }
            else
            {
                return NotFound();
            }
            return Ok();
        }
        [HttpPost]
        [ActionName("PostList")]
        public IHttpActionResult PostList(String id, String id2)
        {
            String idClient = "1";
            if (!id.Equals(String.Empty) && !idClient.Equals(String.Empty))
            {
                try
                {
                    int ids = int.Parse(idClient);
                    Client existingClient = unit.Client.GetFirst(x => x.id == ids);
                    if (existingClient != null)
                    {
                        foreach (String item in id.Split('|'))
                        {
                            if (int.TryParse(item, out ids))
                            {
                                var existingPolicy = unit.Policy.GetFirst(x => x.id == ids);
                                if (existingPolicy != null)
                                {
                                    ClientPolicy cp = new ClientPolicy() { client = existingClient, policy = existingPolicy };
                                    unit.ClientPolicy.Update(cp);
                                }
                            }
                        }
                    }
                    else
                    {
                        return BadRequest("Client not found");
                    }
                    return Ok();
                }
                catch (Exception)
                {
                    //If any exception occurs Internal Server Error i.e. Status Code 500 will be returned  
                    return InternalServerError();
                }
            }
            return BadRequest("Data error");
        }
        // POST api/ClientPolicy  
        [HttpPost]
        public IHttpActionResult Post(ClientPolicy entity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Not a valid model");
            }
            unit.ClientPolicy.Add(entity);
            return Ok();
        }
        // POST api/client  
        public IHttpActionResult Delete(int id)
        {
            try
            {
                var result = unit.ClientPolicy.GetFirst(x => x.id == id);
                if (result != null)
                {
                    unit.ClientPolicy.Delete(result);
                    return Ok();
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception)
            {
                //If any exception occurs Internal Server Error i.e. Status Code 500 will be returned  
                return InternalServerError();
            }
        }
        public IHttpActionResult Delete(int[] ids)
        {
            try
            {
                foreach (int id in ids)
                {
                    var result = unit.ClientPolicy.GetFirst(x => x.id == id);
                    if (result != null)
                    {
                        unit.ClientPolicy.Delete(result);
                    }
                }
                return Ok();
            }
            catch (Exception)
            {
                //If any exception occurs Internal Server Error i.e. Status Code 500 will be returned  
                return InternalServerError();
            }
        }
    }
}


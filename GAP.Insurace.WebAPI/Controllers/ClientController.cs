using GAP.Insurace.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace GAP.Insurace.WebAPI.Controllers
{
    [Authorize]
    public class ClientController : ApiController
    {
        UnitOfWork unit = new UnitOfWork(new InsuranceContext());

        //GET api/client
        
        public IHttpActionResult Get()
        {
            try
            {
                var result = unit.Client.GetAll(); 
                return Ok(result);
            }
            catch (Exception)
            {
                //If any exception occurs Internal Server Error i.e. Status Code 500 will be returned  
                return InternalServerError();
            }
        }
        
        // PUT api/client/id
        public IHttpActionResult Get(int id)
        {
            try
            {
                var result = unit.Client.GetFirst(x => x.id == id);
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
        public IHttpActionResult Put(Client client)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");
            var existingClient = unit.Client.GetFirst(x=> x.id == client.id);
            if (existingClient != null)
            {
                existingClient.firstName = client.firstName;
                existingClient.lastName = client.lastName;

                unit.Client.Update(existingClient);
            }
            else
            {
                return NotFound();
            }
            return Ok();
        }

        // POST api/client  
        public IHttpActionResult Post(Client client)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Not a valid model");
            }
            unit.Client.Add(client);
            return Ok();
        }

        // POST api/client  
        public IHttpActionResult Delete(int id)
        {
            try
            {
                var result = unit.Client.GetFirst(x => x.id == id);
                if (result != null)
                {
                    unit.Client.Delete(result);
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
    }
}

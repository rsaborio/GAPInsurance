using GAP.Insurace.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GAP.Insurace.WebAPI.Controllers
{
    public class CoverageTypeController : ApiController
    {
        UnitOfWork unit = new UnitOfWork(new InsuranceContext());

        //GET api/client
        public IHttpActionResult Get()
        {
            try
            {
                var result = unit.CoverageType.GetAll();
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
                var result = unit.CoverageType.GetFirst(x => x.id == id);
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
        public IHttpActionResult Put(CoverageType entity)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");
            var existingEntity = unit.CoverageType.GetFirst(x => x.id == entity.id);
            if (existingEntity != null)
            {
                existingEntity.name = entity.name;
                existingEntity.description = entity.description;

                unit.CoverageType.Update(existingEntity);
            }
            else
            {
                return NotFound();
            }
            return Ok();
        }

        // POST api/client  
        public IHttpActionResult Post(CoverageType entity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Not a valid model");
            }
            unit.CoverageType.Add(entity);
            return Ok();
        }

        // POST api/client  
        public IHttpActionResult Delete(int id)
        {
            try
            {
                var result = unit.CoverageType.GetFirst(x => x.id == id);
                if (result != null)
                {
                    unit.CoverageType.Delete(result);
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

using GAP.Insurace.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GAP.Insurace.WebAPI.Controllers
{
    public class PolicyController : ApiController
    {
        UnitOfWork unit = new UnitOfWork(new InsuranceContext());

        //GET api/client
        public IHttpActionResult Get()
        {
            try
            {
                var result = unit.Policy.GetAll();

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
                var result = unit.Policy.GetFirst(x => x.id == id);
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
        public IHttpActionResult Put(Policy entity)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");
            var existingEntity = unit.Policy.GetFirst(x => x.id == entity.id);
            if (existingEntity != null)
            {
                existingEntity.name = entity.name;
                existingEntity.coverageType = entity.coverageType;
                existingEntity.description = entity.description;
                existingEntity.fee = entity.fee;
                existingEntity.initDate = entity.initDate;
                existingEntity.monthsCoverage = entity.monthsCoverage;
                existingEntity.porcentage = entity.porcentage;
                existingEntity.riskType = existingEntity.riskType;
                unit.Policy.Update(existingEntity);
            }
            else
            {
                return NotFound();
            }
            return Ok();
        }

        // POST api/client  
        public IHttpActionResult Post(Policy entity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Not a valid model");
            }
            unit.Policy.Add(entity);
            return Ok();
        }

        // POST api/client  
        public IHttpActionResult Delete(int id)
        {
            try
            {
                var result = unit.Policy.GetFirst(x => x.id == id);
                if (result != null)
                {
                    unit.Policy.Delete(result);
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

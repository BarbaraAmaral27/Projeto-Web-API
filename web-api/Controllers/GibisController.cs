using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace web_api.Controllers
{
    public class GibisController : ApiController
    {
        // GET: api/Gibis
        public IHttpActionResult Get()
        {
            List<Models.Gibi> gibis = RepositoriesEntity.Gibi.getAll();
            return Ok(gibis);
        }

        public IHttpActionResult Get(string titulo)
        {
            List<Models.Gibi> gibis = RepositoriesEntity.Gibi.getByTitulo(titulo);
            return Ok(gibis);
        }

        // GET: api/Gibis/5
        public IHttpActionResult Get(int id)
        {
            Models.Gibi gibi = RepositoriesEntity.Gibi.getById(id);
            return Ok(gibi);
        }

        // POST: api/Gibis
        public IHttpActionResult Post([FromBody] Models.Gibi gibi)
        {
            if (!ModelState.IsValid) 
                return BadRequest(); 

            try
            {
                RepositoriesEntity.Gibi.save(gibi);
                return Ok(gibi);
            }
            catch (Exception ex)
            {
                Utils.Log.gravar(ex);
                return InternalServerError();
            }
        }

        // PUT: api/Gibis/5
        public IHttpActionResult Put(int id, [FromBody] Models.Gibi gibi)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            try
            {
                gibi.Id = id;
                RepositoriesEntity.Gibi.update(gibi);
                return Ok();
            }
            catch (Exception ex)
            {
                Utils.Log.gravar(ex);
                return InternalServerError();
            }
        }

        // DELETE: api/Gibis/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                RepositoriesEntity.Gibi.deleteById(id);
                return Ok();
            }
            catch (Exception ex)
            {
                Utils.Log.gravar(ex);
                return InternalServerError();
            }
        }
    }
}

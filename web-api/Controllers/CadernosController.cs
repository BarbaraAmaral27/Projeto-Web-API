using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
//using System.Web.Http.Cors;


namespace web_api.Controllers
{
    //[EnableCors(origins: "*", headers: "*", methods: "get,post")]
    public class CadernosController : ApiController
    {
        // GET: api/Cadernos
        
        public IHttpActionResult Get()
        {
            List<Models.Caderno> cadernos = RepositoriesEntity.Caderno.getAll();            
            return Ok(cadernos);
        }

        public IHttpActionResult Get(string titulo)
        {
            List<Models.Caderno> cadernos = RepositoriesEntity.Caderno.getByTitulo(titulo);
            return Ok(cadernos);
        }

        // GET: api/Cadernos/5
        public IHttpActionResult Get(int id)
        {
            Models.Caderno caderno = RepositoriesEntity.Caderno.getById(id);
            //if (caderno == null)
            //    return NotFound();
            return Ok(caderno);
        }

        // POST: api/Cadernos
        public IHttpActionResult Post([FromBody]Models.Caderno caderno)
        {
            if (!ModelState.IsValid) //proriedade do ModelState, ele ve se realmente o dados do modelo do caderno estão de acordo com o estado do Model se ele esta valido
                return BadRequest(); // quando os os dados não estão da forma valida. mesmo erro 400.

            try
            {
                RepositoriesEntity.Caderno.save(caderno);
                return Ok(caderno);
            }
            catch (Exception ex)
            {
                Utils.Log.gravar(ex);
                return InternalServerError();
            }            
        }

        // PUT: api/Cadernos/5
        public IHttpActionResult Put(int id, [FromBody]Models.Caderno caderno)
        {
            if (!ModelState.IsValid) 
                return BadRequest();

            try
            {
                caderno.Id = id;
                RepositoriesEntity.Caderno.update(caderno);
                return Ok();
            }
            catch (Exception ex)
            {
                Utils.Log.gravar(ex);
                return InternalServerError();
            }            
        }

        // DELETE: api/Cadernos/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                RepositoriesEntity.Caderno.deleteById(id);
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace web_api.Controllers
{
    public class DocesController : ApiController
    {
        // GET: api/Doces
        public IHttpActionResult Get()
        {
            //return Repositories.Doce.getAll();
            //return Repository_Entity.Doce_Entity.getAll();
            //return RepositoriesEntity.Doce.getAll();
            List<Models.Doce> doces = RepositoriesEntity.Doce.getAll();
            return Ok(doces);
        }

        public IHttpActionResult Get(string descricao)
        {
            List<Models.Doce> doces = RepositoriesEntity.Doce.getByDescricao(descricao);
            return Ok(doces);
        }

        // GET: api/Doces/5
        public IHttpActionResult Get(int id)
        {
            //return Repositories.Doce.getById(id);
            //return Repository_Entity.Doce_Entity.getById(id);
            //return RepositoriesEntity.Doce.getById(id);
            Models.Doce doce = RepositoriesEntity.Doce.getById(id);
            return Ok(doce);
        }

        // POST: api/Doces
        public IHttpActionResult Post([FromBody]Models.Doce doce)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            try
            {
                //Repositories.Doce.save(doce);
                //Repository_Entity.Doce_Entity.save(doce);
                RepositoriesEntity.Doce.save(doce);
                //return new HttpResponseMessage(HttpStatusCode.OK);
                return Ok(doce);
            }
            catch (Exception ex)
            {
                Utils.Log.gravar(ex);
                //return new HttpResponseMessage(HttpStatusCode.InternalServerError);
                return InternalServerError();
            }
        }

        // PUT: api/Doces/5
        public IHttpActionResult Put(int id, [FromBody]Models.Doce doce)
        {
            try
            {
                doce.Id = id;
                //Repositories.Doce.update(doce);
                //Repository_Entity.Doce_Entity.update(doce);
                RepositoriesEntity.Doce.update(doce);
                //return new HttpResponseMessage(HttpStatusCode.OK);
                return Ok();
            }
            catch (Exception ex)
            {
                Utils.Log.gravar(ex);
                //return new HttpResponseMessage(HttpStatusCode.InternalServerError);
                return InternalServerError();
            }
        }

        // DELETE: api/Doces/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                //Repositories.Doce.deleteById(id);
                //Repository_Entity.Doce_Entity.deleteById(id);
                RepositoriesEntity.Doce.deleteById(id);
                //return new HttpResponseMessage(HttpStatusCode.OK);
                return Ok();
            }
            catch (Exception ex)
            {
                Utils.Log.gravar(ex);
                //return new HttpResponseMessage(HttpStatusCode.InternalServerError);
                return InternalServerError();
            }
        }
    }
}

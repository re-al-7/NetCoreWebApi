using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace Integrate.SisMed.Api.Services.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class ValuesController : Controller
    {
        public ValuesController(IHttpContextAccessor httpContextAccessor)
        {
            string strUserName = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        }

        // GET api/values
        [HttpGet]
        [Authorize]
        public string Get()
        {
            return "1.0";
        }

        // GET api/values/5
        [HttpGet("{id}")]
        [Authorize]
        public IActionResult Get(string id)
        {
            try
            {
                //instanciamos la RN
                dynamic rn = CUtilsApi.GetInstance("Integrate.SisMed.Api.Services.Dal.Modelo.Rn" + id);
                if (rn == null)
                    return BadRequest();

                var result = rn.ObtenerLista();

                //var formattedCustomObject = JsonConvert.SerializeObject(result, Formatting.Indented);
                //return Ok(formattedCustomObject);

                //En Startup.cs ConfigureServices se define el JSON por defecto
                //KB: https://stackoverflow.com/questions/42360139/asp-net-core-return-json-with-status-code
                return Ok(result);
            }
            catch (Exception exp)
            {
                var strMensaje = "";
                var strCausa = "";
                var strAccion = "";
                var strComentario = "";
                var strOrigen = "";
                CUtilsApi.CargarError(exp,out strMensaje, out strCausa, out strAccion, out strComentario, out strOrigen);
                return BadRequest(new
                {
                    error = strMensaje,
                    causa = strCausa,
                    accion = strAccion,
                    comentario = strComentario,
                    origen = strOrigen
                });
            }
        }

        // GET api/values/5
        [HttpGet("{id}/{idValue}")]
        [Authorize]
        public IActionResult Get(string id, int idValue)
        {
            try
            {
                //instanciamos la RN
                dynamic rn = CUtilsApi.GetInstance("Integrate.SisMed.Api.Services.Dal.Modelo.Rn" + id);
                if (rn == null)
                    return BadRequest();

                var result = rn.ObtenerObjeto(idValue);

                //var formattedCustomObject = JsonConvert.SerializeObject(result, Formatting.Indented);
                //return Ok(formattedCustomObject);

                //En Startup.cs ConfigureServices se define el JSON por defecto
                //KB: https://stackoverflow.com/questions/42360139/asp-net-core-return-json-with-status-code
                return Ok(result);
            }
            catch (Exception exp)
            {
                var strMensaje = "";
                var strCausa = "";
                var strAccion = "";
                var strComentario = "";
                var strOrigen = "";
                CUtilsApi.CargarError(exp, out strMensaje, out strCausa, out strAccion, out strComentario, out strOrigen);
                return BadRequest(new
                {
                    error = strMensaje,
                    causa = strCausa,
                    accion = strAccion,
                    comentario = strComentario,
                    origen = strOrigen
                });
            }
        }

        // POST api/values
        [HttpPost]
        [Authorize]
        public IActionResult Create([FromBody]JObject value)
        {
            try
            {
                if (value == null)
                    return BadRequest();

                if (ModelState.IsValid)
                {
                    dynamic jsonData = value;
                    string nombreTabla = jsonData.nombre;
                    if (nombreTabla == null)
                        return BadRequest();

                    JObject datos = jsonData.datos;

                    //instanciamos la RN
                    dynamic rn = CUtilsApi.GetInstance("Integrate.SisMed.Api.Services.Dal.Modelo.Rn" + nombreTabla);
                    if (rn == null)
                        return BadRequest();

                    //instanciamos la Entidad
                    dynamic obj = CUtilsApi.GetInstance("Integrate.SisMed.Api.BusinessObjects.Ent" + nombreTabla);
                    if (obj == null)
                        return BadRequest();

                    //Apropiamos valores
                    foreach (JProperty property in datos.Properties())
                        obj.GetType().GetProperty(property.Name).SetValue(obj,
                            rn.GetColumnType(property.Value.ToString(), property.Name.ToString()), null);

                    //Insertamos
                    rn.Insert(obj);

                    return Ok();
                }
                return BadRequest();
            }
            catch (Exception exp)
            {
                var strMensaje = "";
                var strCausa = "";
                var strAccion = "";
                var strComentario = "";
                var strOrigen = "";
                CUtilsApi.CargarError(exp, out strMensaje, out strCausa, out strAccion, out strComentario, out strOrigen);
                return BadRequest(new
                {
                    error = strMensaje,
                    causa = strCausa,
                    accion = strAccion,
                    comentario = strComentario,
                    origen = strOrigen
                });
            }
            
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]JObject value)
        {
            try
            {
                if (value == null)
                    return BadRequest();
                
                if (ModelState.IsValid)
                {
                    dynamic jsonData = value;
                    string nombreTabla = jsonData.nombre;
                    JObject datos = jsonData.datos;

                    //instanciamos la RN
                    dynamic rn = CUtilsApi.GetInstance("Integrate.SisMed.Api.Services.Dal.Modelo.Rn" + nombreTabla);
                    if (rn == null)
                        return BadRequest();

                    //instanciamos la Entidad
                    dynamic obj = CUtilsApi.GetInstance("Integrate.SisMed.Api.BusinessObjects.Ent" + nombreTabla);
                    if (obj == null)
                        return BadRequest();

                    //Verificamos que el objeto exista
                    obj = rn.ObtenerObjeto(id);
                    if (obj == null)
                        return NotFound();

                    //Apropiamos valores
                    foreach (JProperty property in datos.Properties())
                        obj.GetType().GetProperty(property.Name).SetValue(obj,
                            rn.GetColumnType(property.Value.ToString(), property.Name.ToString()), null);

                    rn.Update(obj, true);
                    return new OkResult();
                }
                return BadRequest();
            }
            catch (Exception exp)
            {
                var strMensaje = "";
                var strCausa = "";
                var strAccion = "";
                var strComentario = "";
                var strOrigen = "";
                CUtilsApi.CargarError(exp, out strMensaje, out strCausa, out strAccion, out strComentario, out strOrigen);
                return BadRequest(new
                {
                    error = strMensaje,
                    causa = strCausa,
                    accion = strAccion,
                    comentario = strComentario,
                    origen = strOrigen
                });
            }
        }

        // DELETE api/values/5
        [HttpDelete("{tabla}/{id}")]
        public IActionResult Delete(string tabla, int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //instanciamos la RN
                    dynamic rn = CUtilsApi.GetInstance("Integrate.SisMed.Api.Services.Dal.Modelo.Rn" + tabla);
                    if (rn == null)
                        return BadRequest();

                    //instanciamos la Entidad
                    dynamic obj = CUtilsApi.GetInstance("Integrate.SisMed.Api.BusinessObjects.Ent" + tabla);
                    if (obj == null)
                        return BadRequest();

                    //Verificamos que el objeto exista
                    obj = rn.ObtenerObjeto(id);
                    if (obj == null)
                        return NotFound();

                    rn.Delete(obj, true);
                    return new OkResult();
                }
                return BadRequest();
            }
            catch (Exception exp)
            {
                var strMensaje = "";
                var strCausa = "";
                var strAccion = "";
                var strComentario = "";
                var strOrigen = "";
                CUtilsApi.CargarError(exp, out strMensaje, out strCausa, out strAccion, out strComentario, out strOrigen);
                return BadRequest(new
                {
                    error = strMensaje,
                    causa = strCausa,
                    accion = strAccion,
                    comentario = strComentario,
                    origen = strOrigen
                });
            }
        }
    }
}

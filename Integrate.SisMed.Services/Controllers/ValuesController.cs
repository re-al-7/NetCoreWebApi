using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Integrate.SisMed.Services.Dal.Modelo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Integrate.SisMed.Services.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class ValuesController : Controller
    {
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
                dynamic rn = CUtilsApi.GetInstance("Integrate.SisMed.Services.Dal.Modelo.Rn" + id);
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
                    dynamic rn = CUtilsApi.GetInstance("Integrate.SisMed.Services.Dal.Modelo.Rn" + nombreTabla);
                    if (rn == null)
                        return BadRequest();

                    //instanciamos la Entidad
                    dynamic obj = CUtilsApi.GetInstance("Integrate.SisMed.BusinessObjects.Ent" + nombreTabla);
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
                    dynamic rn = CUtilsApi.GetInstance("Integrate.SisMed.Services.Dal.Modelo.Rn" + nombreTabla);
                    if (rn == null)
                        return BadRequest();

                    //instanciamos la Entidad
                    dynamic obj = CUtilsApi.GetInstance("Integrate.SisMed.BusinessObjects.Ent" + nombreTabla);
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
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromBody]JObject value)
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
                    dynamic rn = CUtilsApi.GetInstance("Integrate.SisMed.Services.Dal.Modelo.Rn" + nombreTabla);
                    if (rn == null)
                        return BadRequest();

                    //instanciamos la Entidad
                    dynamic obj = CUtilsApi.GetInstance("Integrate.SisMed.BusinessObjects.Ent" + nombreTabla);
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

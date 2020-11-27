using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebNetCore.DAOs;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Dynamic;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebNetCore.Controllers
{
    
    public class ApiController : Controller
    {
        
        private UsuariosDAO DAO;

        public ApiController() {
     
            DAO = UsuariosDAO.getInstancia();
        }
        [HttpGet]
        public IActionResult check(String name,String clave) {
            if (clave == null)
            {
                return Unauthorized();
            }
            else if (!auth(clave))
            {
                return Unauthorized();
            }
            var flag = DAO.findUsuario(name);
            /*dynamic flag = new JObject();
            flag.estado = DAO.findUsuario(name);*/
            return Json(JsonConvert.SerializeObject(flag));
        }
        [HttpGet]
        public IActionResult login(String name, String pass,String clave)
        {
            if(clave == null)
            {
                return Unauthorized();
            }else if (!auth(clave))
            {
                return Unauthorized();
            }
            var flag= DAO.checkUsuario(name, pass);
            /* dynamic flag = new ExpandoObject();
             flag.estado = DAO.checkUsuario(name, pass);*/
             return Json(JsonConvert.SerializeObject(flag));
        }
        [HttpGet]
        public IActionResult isPay(String name,String clave) {

            if (clave == null)
            {
                return Unauthorized();
            }
            else if (!auth(clave))
            {
                return Unauthorized();
            }
            var flag = DAO.checkPay(name);
           /* dynamic flag = new JObject();
            flag.estado = DAO.checkPay(name);*/
            return Json(JsonConvert.SerializeObject(flag));
        }
        [HttpGet]
        public IActionResult validarKey(String name, String key,String clave) {
            if (clave == null)
            {
                return Unauthorized();
            }
            else if (!auth(clave))
            {
                return Unauthorized();
            }
            var flag = DAO.validarKey(key,name);
            return Json(JsonConvert.SerializeObject(flag));
        }

        private Boolean auth(String clave) {
            if (clave.Equals("dejamepasarporfavor")) {
                return true;
            }
            return false;
        }
    }
}

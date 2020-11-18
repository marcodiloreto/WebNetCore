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
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebNetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        
        private UsuariosDAO DAO;

        public ApiController() {
     
            DAO = UsuariosDAO.getInstancia();
        }
        [HttpPost]
        public IActionResult registrar(String name, String pass) {
        
                var flag = DAO.create(name, pass);
                
        
                return Json(JsonConvert.SerializeObject(flag));
            }

        }
        public IActionResult check(String nom) {
            var flag = DAO.findUsuario(nom);
        }
        public IActionResult login(String name, String pass) {
            var flag = DAO.checkUsuario(name, pass);
            return Json(flag);
        }

        public IActionResult isPay(String name) {
            var flag = DAO.checkPay(name);
            return Json(flag);
        }

        //metodo registrar US

        //metodo log in

        //metodo -obtener Estado
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using WebNetCore.Models;
using WebNetCore.DAOs;
using Microsoft.AspNetCore.Http;


namespace WebNetCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private UsuariosDAO DAO;
        

        public HomeController(ILogger<HomeController> logger)
        { 
            _logger = logger;
            DAO = UsuariosDAO.getInstancia();
        }
        
        public IActionResult Index()
        {
            if (isLoged()) {
                ViewBag.usuario = getSession();
                ViewBag.pay = DAO.checkPay(getSession());
            }
            return View();
        }

        public IActionResult Login()
        {

            if (isLoged())
            {
                ViewBag.usuario = getSession();
                return View("Index");
            }
            return View();
        }

        public IActionResult Register()
        {

            if (isLoged())
            {
                ViewBag.usuario = getSession();
                return View("Index");
            }
            return View();
        }

        public IActionResult Update()
        {

            if (isLoged())
            {
                ViewBag.usuario = getSession();
                return View();
            }
            return View("Index");
        }
        [HttpPost]
        public IActionResult loguear(String userName, String password)
        {

            if (DAO.checkUsuario(userName, password))
            {

                HttpContext.Session.SetString("user", userName);

                ViewBag.usuario = getSession();

            }
            else
            {
                ViewBag.error = "Credenciales incorrectas";
                return View("Login");
            }
            return View("Index");
        }
        public IActionResult delete() {

            if (isLoged()){    
                if (DAO.deleteUsuario(getSession())) { 
                    destroy();
                    return View("Index");
                }
            }
            ViewBag.usuario = getSession();
            return View("Index");
        }
        public IActionResult cambiaPass(String password, String newPassword, String newPassword2) {

            ViewBag.usuario = getSession();
            
            if (!DAO.checkUsuario(getSession(), password)){ 
                ViewBag.error = "Contraseña incorrecta";
                return View("Update");
            }
            if (newPassword != newPassword2) {
                ViewBag.error = "Contraseñas nuevas no coinciden";
                return View("Update");
            }
            //double check
            if (DAO.checkUsuario(getSession(), password) && newPassword == newPassword2) {
                DAO.cambiaPass(getSession(), newPassword);
                return View("Index");
            }

            ViewBag.error = "Ocurrió un error inesperado, intenta mas tarde";
            return View("Update");
            
        }

        [HttpPost]
        public IActionResult registrar(String userName, String password, String password2)
        {
            // contras iguales
            if (password != password2)
            {
                ViewBag.error = "Las contraseñas no coinciden";
            }
            // si ya existe
            if (DAO.findUsuario(userName))
            {
                ViewBag.error = "Usuario existente";
            }
            //confirma lo de arriba devuelta para crear
            if (!DAO.findUsuario(userName) && password == password2)
            {
                DAO.create(userName, password);
                HttpContext.Session.SetString("user", userName);
                ViewBag.Usuario = userName;
                return View("Index");
            }

            return View("Register");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        //Sessioners
        private Boolean isLoged() {
            if (getSession() != null) {
                return true;
            }
            return false;
        }
        private String getSession() { 
        return HttpContext.Session.GetString("user");
        }
        public IActionResult destroy() {
            HttpContext.Session.Clear();
            return View("Index");
        }
        
    }
}

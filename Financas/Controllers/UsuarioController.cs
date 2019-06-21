using Financas.DAO;
using Financas.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Financas.Controllers
{
    public class UsuarioController : Controller
    {
        private UsuarioDAO usuarioDAO;

        public UsuarioController(UsuarioDAO usuarioDAO)
        {
            this.usuarioDAO = usuarioDAO;
        }

        public ActionResult Form()
        {
            return View();
        }

        public ActionResult Adiciona(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                usuarioDAO.Adiciona(usuario);
                return RedirectToAction("Index");
            }

            else
            {
                return View("Form", usuario);
            }
        }

        public ActionResult Index()
        {
            IList<Usuario> usuarios = usuarioDAO.Lista();
            return View(usuarios);
        }
    }
}
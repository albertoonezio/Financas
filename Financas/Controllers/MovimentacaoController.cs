using Financas.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Financas.Controllers
{
    public class MovimentacaoController : Controller
    {
        private MovimentacaoDAO movimentacaoDAO;
        private UsuarioDAO usuarioDAO;

        public MovimentacaoController(MovimentacaoDAO movimentacaoDAO, UsuarioDAO usuarioDAO)
        {
            this.movimentacaoDAO = movimentacaoDAO;
            this.usuarioDAO = usuarioDAO;
        }

        // GET: Movimentacao
        public ActionResult Form()
        {
            ViewBag.Usuarios = usuarioDAO.Lista();
            return View();
        }
    }
}
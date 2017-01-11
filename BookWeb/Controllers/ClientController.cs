using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookWeb.Models;

namespace BookWeb.Controllers
{
    public class ClientController : Controller
    {
        //
        // GET: /Client/

        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Metodo responsable de eliminar un cliente existente.
        /// </summary>
        /// <param name="idBook">int: id del cliente</param>
        /// <returns>string: msj si el cliente fue eliminado.</returns>
        [HttpPost]
        public string Remove_Client(int idClient)
        {
            using (BookClientsEntities db = new BookClientsEntities())
            {

                client objtClient = new client { id = idClient };
                db.clients.Attach(objtClient);
                db.clients.Remove(objtClient);
                db.SaveChanges();

                return "El libro a sido eliminado.";
            }
        }


        /// <summary>
        ///  Actualiza a un cliente existente.
        /// </summary>
        /// <param name="clientEntity">objeto: representante de un cliente</param>
        /// <returns>string: msj si el cliente fue agregado.</returns>
        [HttpPost]
        public string UpdateEmployee(client clientEntity)
        {
            using (BookClientsEntities db = new BookClientsEntities())
            {

                var selectEmpQuery = from clientq in db.clients
                                     where clientq.id == clientEntity.id
                                     select clientq;

                client objtClient = selectEmpQuery.Single();

                objtClient.clientName = clientEntity.clientName;
                objtClient.idIdenti = clientEntity.idIdenti;
                db.SaveChanges();

                return "el cliente fue actualizado.";
            }
        }

        /// <summary>
        /// agrega a un cliente nuevo
        /// </summary>
        /// <returns></returns>
        public string Add_New_Client(client clientEntity)
        {
            using (BookClientsEntities db = new BookClientsEntities())
            {

                client objtClient = new client();

                objtClient.clientName = clientEntity.clientName;
                objtClient.idIdenti = clientEntity.idIdenti;
                db.SaveChanges();

                db.clients.Add(objtClient);
                db.SaveChanges();

                return "El cliente fue agregado.";
            }
        }


    }
}

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

        public ActionResult ClientManagement()
        {
            return View();
        }

        /// <summary>
        /// Busca a un cliente en especifico deacuerdo a su cedula.
        /// </summary>
        /// <param name="identify">string: cedula del cliente</param>
        /// <returns>client: objeto representante del cliente</returns>
        [HttpGet]
        public client find_client_By_Identy(client clientEntity)
        {
            using (BookClientsEntities db = new BookClientsEntities())
            {
                var selectEmpQuery = from clientq in db.clients
                                     where clientq.idIdenti == clientEntity.idIdenti
                                     select clientq;

                client Client;

                try
                {
                    Client = selectEmpQuery.Single();
                    
                }
                catch {
                    return null;
                }

                return Client;

            }
    
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
        public string UpdateClient(client clientEntity)
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookWeb.Models;

namespace BookWeb.Controllers
{
    public class BookController : Controller
    {
        //
        // GET: /Book/

        public ActionResult index()
        {
            return View();
        }


        public ActionResult BookManagement()
        {
            return View();
        }

    
        /// <summary>
        /// Metodo responsable de agregar un libro tomado (actualiza).
        /// </summary>
        /// <param name="bookEntity">book: Objeto representante del libro</param>
        /// <param name="clientEntity">client: Objeto representante del cliente</param>
        /// <returns>string: si ha sido tomado o nop</returns>
        [HttpPost]
        public string Take_Book(bookClient bookclient)
        {
            using (BookClientsEntities db = new BookClientsEntities())
            {
                var objectQuery = from b in db.books
                                 where b.id == bookclient.id_book
                                 select b;

                book objectBook = objectQuery.Single();
                bookClient objectbookclient = new bookClient();

                if (Book_Availability(objectBook))
                {
                    objectBook.quality--;
                    db.SaveChanges();

                    objectbookclient.id_book = bookclient.id_book;
                    objectbookclient.id_user = bookclient.id_user;
                    db.bookClients.Add(objectbookclient);
                    db.SaveChanges();

                }
                else {
                    return "Este libro no esta disponible.";
                }

                return "El libro ha sido tomado";
            }       
        }


        /// <summary>
        /// Agrega un nuevo libro en la BD.
        /// </summary>
        /// <param name="name">String: nombre del empleado</param>
        /// <param name="address">String: direccion del empleado</param>
        [HttpPost]
        public string Add_New_Book(book bookEntity)
        {
            using (BookClientsEntities db = new BookClientsEntities())
            {
                book objectBook = new book();

                objectBook.bookName = bookEntity.bookName;
                objectBook.edition = bookEntity.edition;
                objectBook.tittle = bookEntity.tittle;
                objectBook.quality = bookEntity.quality;
                db.books.Add(objectBook);
                db.SaveChanges();

                return "El libro se ha agregado";
            }
        }

        /// <summary>
        /// obtine todos los libros disponibles
        /// </summary>
        /// <returns>books: listado de todos los libros</returns>
        [HttpGet]
        public JsonResult fetch_All_Book()
        {
            using (BookClientsEntities db= new BookClientsEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;

                List<book> objtBook = db.books.ToList();
                return Json(objtBook, JsonRequestBehavior.AllowGet);
            }

        }

        /// <summary>
        /// Metodo responsable de eliminar un libro existente.
        /// </summary>
        /// <param name="idBook">int: id del libro</param>
        /// <returns>string: msj si el libro fue eliminado.</returns>
        [HttpPost]
        public string Remove_Book(int idBook)
        {
            using (BookClientsEntities db = new BookClientsEntities())
            {

                book objtBook = new book { id = idBook };
                db.books.Attach(objtBook);
                db.books.Remove(objtBook);
                db.SaveChanges();

                return "El libro a sido eliminado.";
            }
        }

        /// <summary>
        /// Verifica si el libro esta disponible.
        /// </summary>
        /// <param name="bookEntity">book: Objeto representante del libro.</param>
        /// <returns>true: si esta disponible, false: si no</returns>
        [HttpPost]
        public bool Book_Availability(book bookEntity)
        {
            using (BookClientsEntities db = new BookClientsEntities())
           {
               if (bookEntity.quality > 0)
                   return true;
               
               else
               return false;
           } 
        }

        /// <summary>
        /// Verifica si el cliente puede tomar un libro
        /// </summary>
        /// <param name="clienEntity">client: objeto representante del cliente</param>
        /// <returns>true: si tiene menos de tres libros prestados, si tiene > que 2</returns>
        [HttpPost]
        public bool Client_Can_Take_book(client clienEntity)
        {
            using (BookClientsEntities db = new BookClientsEntities())
            {
                var objectQuery = db.bookClients
                     .Where( s =>
                             s.id_user == clienEntity.id).Count();

                if (objectQuery < 3)
                {
                    return true;
                }

                return false;
            }
        }

        /// <summary>
        /// Agrega un libro  que sido tomado (actualiza).
        /// </summary>
        /// <param name="bookEntity">book: Objeto representante del libro</param>
        /// <param name="clientEntity">client: Objeto representante del cliente</param>
        /// <returns>string: si ha sido tomado o nop</returns>
        [HttpPost]
        public string Return_Book(bookClient bookclientEntity)
        {
            using (BookClientsEntities db = new BookClientsEntities())
            {
                var objectQuery = from b in db.books
                                 where b.id == bookclientEntity.id_book 
                                 select b;

                book objectBook = objectQuery.Single();
                bookClient objectbookclient = new bookClient();
                   
                objectBook.quality++;
                   
                db.SaveChanges();
                    
                bookClient objtbookclient = new bookClient { id_user = bookclientEntity.id_user,                       
                    id_book = bookclientEntity.id_book };

                    db.bookClients.Attach(objtbookclient);
                    db.bookClients.Remove(objtbookclient);
                    db.SaveChanges();


                return "El libro ha sido retornado por el cliente.";
            }     
        }
    }
}

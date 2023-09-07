using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRUD_WEB_API_SP_MVC.Models;
using CRUD_WEB_API_SP_MVC.DataAccess;


namespace CRUD_WEB_API_SP_MVC.Controllers
{
    public class CustomerController : Controller
    {
        //    
        // GET: /Customer/    
        [HttpGet]
        public ActionResult InsertCustomer()
        {
            return View();
        }
        [HttpPost]
        public ActionResult InsertCustomer(Customer objCustomer)
        {

            objCustomer.Birthdate = Convert.ToDateTime(objCustomer.Birthdate);
            if (ModelState.IsValid)  
            {
                DataAccessLayer objDB = new DataAccessLayer();
                string result = objDB.InsertData(objCustomer);
                //ViewData["result"] = result;    
                TempData["result1"] = result;
                ModelState.Clear(); //clearing model    
                                    //return View();    
                return RedirectToAction("ShowAllCustomerDetails");
            }

            else
            {
                ModelState.AddModelError("", "Error in saving data");
                return View();
            }
        }

        [HttpGet]
        public ActionResult ShowAllCustomerDetails()
        {
            Customer objCustomer = new Customer();
            DataAccessLayer objDB = new DataAccessLayer(); //calling class DBdata    
            objCustomer.ShowallCustomer = objDB.Selectalldata();
            return View(objCustomer);
        }
        [HttpGet]
        public ActionResult Details(string ID)
        {
            //Customer objCustomer = new Customer();    
            //DataAccessLayer objDB = new DataAccessLayer(); //calling class DBdata    
            //objCustomer.ShowallCustomer = objDB.Selectalldata();    
            //return View(objCustomer);    
            Customer objCustomer = new Customer();
            DataAccessLayer objDB = new DataAccessLayer(); //calling class DBdata    
            return View(objDB.SelectDatabyID(ID));
        }
        [HttpGet]
        public ActionResult Edit(string ID)
        {
            Customer objCustomer = new Customer();
            DataAccessLayer objDB = new DataAccessLayer(); //calling class DBdata    
            return View(objDB.SelectDatabyID(ID));
        }

        [HttpPost]
        public ActionResult Edit(Customer objCustomer)
        {
            objCustomer.Birthdate = Convert.ToDateTime(objCustomer.Birthdate);
            if (ModelState.IsValid)    
            {
                DataAccessLayer objDB = new DataAccessLayer();    
                string result = objDB.UpdateData(objCustomer);
                //ViewData["result"] = result;    
                TempData["result2"] = result;
                ModelState.Clear(); //clearing model    
                //return View();    
                return RedirectToAction("ShowAllCustomerDetails");
            }
            else
            {
                ModelState.AddModelError("", "Error in saving data");
                return View();
            }
        }

        [HttpGet]
        public ActionResult Delete(String ID)
        {
            DataAccessLayer objDB = new DataAccessLayer();
            int result = objDB.DeleteData(ID);
            TempData["result3"] = result;
            ModelState.Clear(); //clearing model    
                                //return View();    
            return RedirectToAction("ShowAllCustomerDetails");
        }
    }
}
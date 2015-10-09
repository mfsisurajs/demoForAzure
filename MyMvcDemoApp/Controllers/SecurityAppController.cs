using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyMvcDemoApp.Models;
using SecurityApplicationData;
using SecurityApplicationData.ModelData;

namespace MyMvcDemoApp.Controllers
{
    public class SecurityAppController : Controller
    {
        readonly SecurityPersonnelService _service = new SecurityPersonnelService();
        public SecurityAppController()
        {
            
        }
        // GET: SecurityApp
        public ActionResult Index()
        {
            return View();
        }

        // GET: SecurityApp/Details/5
        public ActionResult Details(long id)
        {
            var details = _service.GetSecurityDetails(id);
            var detailsModel = new SecurityPersonnelViewModel
            {
                SecurityPersonnelAddress = details.SecurityPersonnelAddress,
                SecurityPersonnelAge = details.SecurityPersonnelAge,
                SecurityPersonnelName = details.SecurityPersonnelName,
                DepartmentDetail = details.SecurityDepartmentDetail,
                SecurityPersonnelID = details.SecurityPersonnelID
            };
            return View(detailsModel);
        }

        // GET: SecurityApp/Create
        public ActionResult Create()
        {
            var securityDepartments =
                new SecurityPersonnelViewModel
                {
                    SecurityDepartment = new SelectList(_service.GetDepartments(), "SecurityDepartmentID", "SecurityDepartmentName")
                };
            return View(securityDepartments);
        }

        // POST: SecurityApp/Create
        [HttpPost]
        public ActionResult Create(SecurityPersonnelViewModel securityViewModel)
        {
            try
            {
                var securityPersonnel = new SecurityPersonnelDetail
                {
                    SecurityDepartmentID = securityViewModel.SecurityDepartmentID,
                    SecurityPersonnelAddress = securityViewModel.SecurityPersonnelAddress,
                    SecurityPersonnelAge = securityViewModel.SecurityPersonnelAge,
                    SecurityPersonnelName = securityViewModel.SecurityPersonnelName
                };
               var id = _service.AddNewSecurityPersonel(securityPersonnel);
                return RedirectToAction("Details",id);
            }
            catch
            {
                return View();
            }
        }

        // GET: SecurityApp/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SecurityApp/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: SecurityApp/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SecurityApp/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

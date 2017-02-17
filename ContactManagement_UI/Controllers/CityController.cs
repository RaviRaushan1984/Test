using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ContactManagement_BAL.Masters;
using ContactManagement_Entities.Masters;
using ContactManagement_Entities.Common;

namespace ContactManagement_UI.Controllers
{
    public class CityController : Controller
    {
        //
        // GET: /City/

        public ActionResult Index()
        {
            if (!Generic.UserProfile.IsSessionValid())
                return RedirectToAction("LogOn", "Account");

            var cityList = (new City_BAL()).Select(null);
            return View(cityList);
        }

        //
        // GET: /City/Create

        public ActionResult Create()
        {
            if (!Generic.UserProfile.IsSessionValid())
                return RedirectToAction("LogOn", "Account");

            return View();
        }

        //
        // POST: /City/Create

        [HttpPost]
        public ActionResult Create(City model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.CreatedBy = Convert.ToInt32(Session["UserId"]);

                    MethodResponse resultObj = (new City_BAL()).Insert(ref model);

                    if (resultObj.ResponseStatus)
                    {
                        ModelState.Clear();
                        TempData["Success"] = resultObj.ResponseMessage;
                    }
                    else
                        ViewData["Error"] = resultObj.ResponseMessage;

                    return View(model);
                }
                else
                    return View(model);
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /City/Edit/5

        public ActionResult Edit(int id)
        {
            if (!Generic.UserProfile.IsSessionValid())
                return RedirectToAction("LogOn", "Account");

            List<City> cityList = (new City_BAL()).Select(new City() { Id = id });

            return View(cityList[0]);
        }

        //
        // POST: /City/Edit/5

        [HttpPost]
        public ActionResult Edit(City model)
        {
            if (!Generic.UserProfile.IsSessionValid())
                return RedirectToAction("LogOn", "Account");

            try
            {
                if (ModelState.IsValid)
                {
                    model.ModifiedBy = Convert.ToInt32(Session["UserId"]);

                    MethodResponse resultObj = (new City_BAL()).Update(ref model);

                    if (resultObj.ResponseStatus)
                    {
                        ModelState.Clear();
                        TempData["Success"] = resultObj.ResponseMessage;
                    }
                    else
                        ViewData["Error"] = resultObj.ResponseMessage;

                    return View(model);
                }
                else
                    return View(model);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error", ex.Message);
                return View();
            }
        }

        //
        // POST: /City/Delete/5

        [HttpPost]
        public ActionResult Delete(int id)
        {
            if (!Generic.UserProfile.IsSessionValid())
                return RedirectToAction("LogOn", "Account");

            try
            {
                City stateObj = new City();
                stateObj.Id = id;
                stateObj.ModifiedBy = Convert.ToInt32(Session["UserId"]);

                MethodResponse responseObj = (new City_BAL()).Delete(ref stateObj);

                return RedirectToAction("Index", "City");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error", ex.Message);
                return View();
            }
        }
    }
}

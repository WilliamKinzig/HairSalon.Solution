using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System.Collections.Generic;
using System;

namespace HairSalon.Controllers
{
  public class StylistController : Controller
  {

    [HttpGet("/stylists")]
    public ActionResult Index()
    {
        List<Stylist> stylistList = Stylist.GetAll();
        // return View(0);//FAIL
        return View(stylistList);
    }


    [HttpGet("/stylists/new")]
    public ActionResult CreateForm()
    {
      // return new EmptyResult(); //FAIL
      return View();
    }


    [HttpPost("/stylists")]
    public ActionResult Create()
    {
      Stylist newStylist = new Stylist (Request.Form["newStylist"]);
      newStylist.Save();
      List<Stylist> stylistList = Stylist.GetAll();
      return View("Index", stylistList);
    }


    [HttpGet("/stylists/{id}")]
    public ActionResult Details(int id)
    {
        Stylist item = Stylist.Find(id);

        return View(item);
    }

    [HttpGet("/stylists/{id}/update")]
    public ActionResult UpdateForm(int id)
    {
        Stylist thisStylist = Stylist.Find(id);
        return View(thisStylist);
    }

    [HttpPost("/stylists/{id}/update")]
    public ActionResult Update(int id)
    {
        Stylist thisStylist = Stylist.Find(id);
        thisStylist.Edit(Request.Form["updateStylist"]);
        return RedirectToAction("Index");
    }

    [HttpGet("/stylists/{id}/delete")]
    public ActionResult Delete(int id)
    {
        Stylist thisStylist = Stylist.Find(id);
        thisStylist.Delete();
        return RedirectToAction("Index");
    }
    // [HttpPost("/stylists/delete")]
    // public ActionResult DeleteAll()
    // {
    //   Stylist.ClearAll();
    //   return View();
    // }
  }
}

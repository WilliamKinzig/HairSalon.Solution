using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System.Collections.Generic;
using System;

namespace HairSalon.Controllers
{
  public class ClientController : Controller
  {

    [HttpGet("/clients")]
    public ActionResult Index()
    {
        List<Client> allClients = Client.GetAll();
        return View(allClients);
    }

    [HttpPost("/clients")]
    public ActionResult Create()
    {
      Client newClient = new Client (Request.Form["newClient"], 7);
      newClient.Save();
      List<Client> allClients = Client.GetAll();
      return View("Index", allClients);
    }


    [HttpGet("/clients/oops")]
    public ActionResult Oops()
    {

      return View();
    }

    [HttpGet("/clients/new")]
    public ActionResult CreateForm()
    {
      List<Stylist> listStylists = Stylist.GetAll();
      if(listStylists.Count > 0)
      {
        return View(listStylists);
      }
      else
      {
        return RedirectToAction("Oops");
      }
    }




    [HttpGet("/clients/{id}/details")]
    public ActionResult Details()
    {
        //Client thisClient = Client.Find(id);
        return View();
    }





    [HttpGet("/clients/{id}/update")]
    public ActionResult UpdateForm(int id)
    {
        Client thisClient = Client.Find(id);
        return View(thisClient);
    }

    [HttpPost("/clients/{id}/update")]
    public ActionResult Update(int id)
    {
        Client thisClient = Client.Find(id);
        thisClient.Edit(Request.Form["updateClient"]);
        return RedirectToAction("Index");
    }


    [HttpGet("/clients/{id}/delete")]
    public ActionResult Delete(int id)
    {
        Client thisClient = Client.Find(id);
        thisClient.Delete();
        return RedirectToAction("Index");
    }

  }
}

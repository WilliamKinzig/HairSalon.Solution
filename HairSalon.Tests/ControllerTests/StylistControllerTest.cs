using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using HairSalon.Controllers;
using HairSalon.Models;

namespace HairSalon.Tests
{
  [TestClass]
  public class StylistControllerTest
  {

    [TestMethod]
    public void Index_ReturnsView_True()
    {
      //Arrange
      StylistController controller = new StylistController();

      //Act
      ActionResult indexView = controller.Index();

      //Assert
      Assert.IsInstanceOfType(indexView, typeof(ViewResult));
    }


    [TestMethod]
    public void Index_IsExpectedType_List()
    {
      //Arrange
      StylistController controller = new StylistController();
      IActionResult actionResult = controller.Index();
      ViewResult indexView = controller.Index() as ViewResult;

      //Act
      var result = indexView.ViewData.Model;

      //Assert
      Assert.IsInstanceOfType(result, typeof(List<Stylist>));
    }


    [TestMethod]
    public void CreateForm_ReturnsExpectedView_True()
    {
      //Arrange
      StylistController controller = new StylistController();

      //Act
      ActionResult createFormView = controller.CreateForm();

      //Assert
      Assert.IsInstanceOfType(createFormView, typeof(ViewResult));
    }


    [TestMethod]
    public void Blah_ReturnsExpectedView_True()
    {
      //Arrange
      StylistController controller = new StylistController();

      //Act
      ActionResult detailsView = controller.Details(0);

      //Assert
      Assert.IsInstanceOfType(detailsView, typeof(ViewResult));
    }


    [TestMethod]
    public void Blah_HasCorrectModelType_StyleItem()
    {
      //Arrange
      StylistController controller = new StylistController();
      IActionResult actionResult = controller.Details(0);
      ViewResult detailsView = controller.Details(0) as ViewResult;

      //Act
      var result = detailsView.ViewData.Model;

      //Assert
      Assert.IsInstanceOfType(result, typeof(Stylist));
    }
  }
}

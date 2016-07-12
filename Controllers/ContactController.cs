using Microsoft.AspNetCore.Mvc;
using Azure_Demo_2.ViewModels;
using AzureDemo2.Models;
using System;
using System.Linq;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Azure_Demo_2.Controllers
{
    public class ContactController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            using (var contactDb = new ContactContext())
            {
                var contactModel = new Contact()
                {
                    Name = "Vishal tahiliani",
                    Age = 26,
                    Dob = DateTime.Now
                };
                contactDb.Contacts.Add(contactModel);
                contactDb.SaveChanges();
            }
            return RedirectToAction("Detail");
        }

        public IActionResult Detail()
        {
            var contactModel = new Contact();
            using (var contactDb = new ContactContext())
            {
                contactModel = contactDb.Contacts.FirstOrDefault();
            }

            var contact = new ContactModel()
            {
                Name = contactModel.Name,
                Age = contactModel.Age,
                Dob = contactModel.Dob
            };

            return View(contact);
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Reflection;
using System.IO;
using Newtonsoft.Json;
using Readresource.Web.Models;

namespace Readresource.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.SendMailStatus = string.Empty;
            Assembly assem = Assembly.GetExecutingAssembly();

            using (Stream stream = assem.GetManifestResourceStream(assem.GetName().Name + ".Resources.DefaultTemplate.json")) 
            {
                using (var reader = new StreamReader(stream))
                {
                    var jsonString =  reader.ReadToEnd();
                    var mailModel = JsonConvert.DeserializeObject<EmailModel>(jsonString);
                    return View(mailModel);
                }
            }

            
        }
        [HttpPost]
        public ActionResult Index(EmailModel mailModel)
        {
            ViewBag.SendMailStatus = "Mail sent";
            return View(mailModel); 
        }

        
    }
}
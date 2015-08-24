using ReverseStorage;
using ReverseStorage.Abstraction;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WordReverserMVC.Models;

namespace WordReverserMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            TextStorageModel model = new TextStorageModel();

            var path = Path.Combine(Environment.CurrentDirectory, "SavedWords.txt");
            
            IWordService handler = new WordService(new FileWrapper());
            List<string> storedWords = handler.RetrieveAllWords(path);
            model.StoredWords = string.Join("\r\n", storedWords);

            //string test = test234.MakeRelativePath(@"C:\Users\mfinn\Desktop\ReverseStorage\ReverseStorage\Business", @"C:\Users\mfinn\Desktop\ReverseStorage\ReverseStorage\SavedWords.txt");

            return View(model);
        }

        public ActionResult InsertWord(TextStorageModel model)
        {
            IModeHandler service = new ModeHandler(new WordService(new FileWrapper()), new Validator(), new WordInverter());
            UserMode mode = UserMode.INSERT;
            var path = Path.Combine(Environment.CurrentDirectory, "SavedWords.txt");

            service.OrchestrateMode(mode, model.WordToStore);
           
            return View("Index");

            
        }
    }
}
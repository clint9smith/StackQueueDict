using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StackQueueDict2.Controllers
{
    public class StackController : Controller
    {
        static Stack<string> myStack = new Stack<string>();
        static bool displaystack = false;
        // GET: Stack
        public ActionResult Index()
        {
            if (displaystack == false)
            {
                ViewBag.StackViewBag = null;
            }
            else
            {
                ViewBag.StackViewBag = myStack;
            }
            return View("StackIndex");
        }
        public ActionResult AddItem()
        {
            if (displaystack == false)
            {
                ViewBag.StackViewBag = null;
            }
            else
            {
                ViewBag.StackViewBag = myStack;
            }
            string a = "New Entry";
            myStack.Push(a + " " + (myStack.Count + 1));
            

            return View("StackIndex");
        }
        public ActionResult ClearStack()
        {
            while (myStack.Count > 0)
            {
                DeleteFromStack();
            }

            return View("StackIndex");
        }
        public ActionResult AddHuge()
        {
            ClearStack();
            for (int i = 0; i < 2000; i++)
            {
                /*string a = "New Entry";
                myStack.Push(a + " " + (myStack.Count + 1));
                ViewBag.StackViewBag = myStack;*/
                AddItem();
            }
            return View("StackIndex");
        }
        public ActionResult DeleteFromStack()
        {
            if (displaystack == false)
            {
                ViewBag.StackViewBag = null;
            }
            else
            {
                ViewBag.StackViewBag = myStack;
            }
            if (myStack.Count > 0)
            {
                myStack.Pop();
            }
            else
            {
                ViewBag.Output = "<p>There is nothing to delete</p>";
            }

            return View("StackIndex");
        }
        public ActionResult DisplayStack()
        {
            if (displaystack == false)
            {
                displaystack = true;
                ViewBag.StackViewBag = myStack;
                ViewBag.Display = "<a href=\"/Stack/DisplayStack\" class=\"w3-bar-item w3-button\">Toggle Display</a>";
                return View("StackIndex");
            }
            else
            {
                displaystack = false;
                ViewBag.StackViewBag = null;
                ViewBag.Display = "<a href=\"/Stack/DisplayStack\" class=\"w3-bar-item w3-button\">Toggle Display</a>";
                return View("StackIndex");
            }
            
        }
        public ActionResult SearchStack()
        {
            if (displaystack == false)
            {
                ViewBag.StackViewBag = null;
            }
            else
            {
                ViewBag.StackViewBag = myStack;
            }
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();

            sw.Start();
            bool InStack = false;
            foreach(var z in myStack)
            {
                if (z == "New Entry 5")
                {
                    InStack = true;
                    break;
                }
            }

            sw.Stop();

            TimeSpan ts = sw.Elapsed;
            if (InStack == false)
            {
                ViewBag.StopWatch = "<p>Item not found :(</p>";
            }
            else
            {
                ViewBag.StopWatch = "<p>Item found in: " + ts + " seconds</p>";
            }

            return View("StackIndex");
        }
    }
}
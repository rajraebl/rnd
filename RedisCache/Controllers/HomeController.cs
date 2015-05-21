using System.Linq;
using System.Web.Mvc;
using RedisCache.Utils;
using StackExchange.Redis;

namespace RedisCache.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            //IDatabase cache = CacheUtil.Connection.GetEndPoints();

            var endpoints = CacheUtil.Connection.GetEndPoints();
            var server = CacheUtil.Connection.GetServer(endpoints.First());
            var keys = server.Keys(2, pattern: "85962f27-9fd3-4a90-9a98-3b3efd780f44_QUOTE*");
            foreach (var key in keys)
            {
                var m = key;
                //Console.WriteLine("Removing Key {0} from cache", key.ToString());
                //_redisCache.KeyDelete(key);
            }

            //cache.StringSet("ola", DateTime.UtcNow.ToString());
            //ViewBag.key = cache.StringGet("ola");
            return View();
        }

        //
        // GET: /Home/Details/5

        public ActionResult Details()
        {
            ServiceProxy proxy = new ServiceProxy();
            var kk = proxy.GetCars();


           // ViewBag.key = cache.StringGet("ola");


            return View(kk);
        }

        //
        // GET: /Home/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Home/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Home/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Home/Edit/5

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

        //
        // GET: /Home/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Home/Delete/5

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

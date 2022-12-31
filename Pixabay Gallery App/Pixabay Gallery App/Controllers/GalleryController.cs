using Microsoft.AspNetCore.Mvc;

using Newtonsoft.Json.Linq;

using Pixabay_Gallery_App.Models;
using Newtonsoft.Json;

namespace Pixabay_Gallery_App.Controllers
{
    public class GalleryController : Controller
    {

        //Now define your asynchronous method which will retrieve all your pokemon.
        public async Task<ActionResult> Index(string query)
        {
            if (query == null)
                query = "";
            //Define your baseUrl
            string apiUrl = "https://pixabay.com/api/?key=32034970-fbd6a67c873fd7587e3f7c733&q=" + query;
            //Have your using statements within a try/catch block
            try
            {
                //We will now define your HttpClient with your first using statement which will implements a IDisposable interface.
                using (HttpClient client = new())
                {
                    //In the next using statement you will initiate the Get Request, use the await keyword so it will execute the using statement in order.
                    using (HttpResponseMessage res = await client.GetAsync(apiUrl))
                    {
                        //Then get the content from the response in the next using statement, then within it you will get the data, and convert it to a c# object.
                        using (HttpContent content = res.Content)
                        {
                            //Now assign your content to your data variable, by converting into a string using the await keyword.
                            var data = await content.ReadAsStringAsync();
                            //If the data isn't null return log convert the data using newtonsoft JObject Parse class method on the data.
                            if (content != null)
                            {
                                List<Image>? images = new();
                                images = JsonConvert.DeserializeObject<List<Image>>(JObject.Parse(data)["hits"].ToString());
                                return View(images);
                            }
                            else
                            {
                                Console.WriteLine("NO Data----------");
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine("NO Data-----");
                Console.WriteLine(exception);
            }
            return View();
        }

    }
}

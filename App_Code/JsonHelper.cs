using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

/// <summary>
/// Description résumée de JsonHelper
/// </summary>
public class JsonHelper
{

    public static Cats GetCats(string url)
    {
        using (var client = new WebClient())
        {
            var json = client.DownloadString(url);

            var cats = JsonConvert.DeserializeObject<Cats>(json);
            cats.images.ForEach(c => { c.voted = false; c.score = 0; });
            return cats;

        }

    }
}
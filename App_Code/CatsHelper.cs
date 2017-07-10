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
public class CatsHelper
{

    public static List<Cat> GetCats(string url)
    {
        using (var client = new WebClient())
        {
            var json = client.DownloadString(url);

            var cats = JsonConvert.DeserializeObject<Cats>(json).cats.ToList();
            cats.RemoveAll(c => !IsImageExists(c.url));
            cats.ForEach(c => { c.nbvotes = 0; c.score = 1000;  });

            return cats;

        }

    }

    private static bool IsImageExists(string url)
    {
        HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
        request.Method = "HEAD";

        bool exists = true;
        try
        {
            request.GetResponse();
            exists = true;
        }
        catch
        {
            exists = false;
        }
        return exists;
    }

    public static IEnumerable<T> Random<T>(IEnumerable<T> enumerable)
    {
        if (enumerable == null)
        {
            throw new ArgumentNullException(nameof(enumerable));
        }

        // note: creating a Random instance each call may not be correct for you,
        // consider a thread-safe static instance
        var r = new Random();
        var list = enumerable as IList<T> ?? enumerable.ToList();
        var first = list[r.Next(0, list.Count)];
        var second = list.Except(new List<T>() { first }).ToList()[r.Next(0, list.Count - 1)];
        return new List<T>() { first, second };
    }
}
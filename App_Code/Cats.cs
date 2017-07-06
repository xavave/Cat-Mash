using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Description résumée de Cats
/// </summary>
public class Cats
{
    public List<CatImage> images { get; set; }

}
public class CatImage
{
    public string url { get; set; }
    public string id { get; set; }
    public bool voted { get; set; }
    public double score { get; set; }
}
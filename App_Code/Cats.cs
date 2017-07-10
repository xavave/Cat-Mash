using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Description résumée de Cats
/// </summary>
public class Cats
{
    [JsonProperty("images")]
    public List<Cat> cats { get; set; }
  

}
public class Cat
{
    public string url { get; set; }
    public string id { get; set; }
    public int nbvotes { get; set; }
    public double score { get; set; }
   
}
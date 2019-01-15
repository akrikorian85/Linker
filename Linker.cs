using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.IO;

namespace EntranaDotNet.Helpers.Linker
{
  public static class Linker
  {
    private static Dictionary<string, string> Data;
    static Linker()
    {
      using (StreamReader reader = new StreamReader(HttpContext.Current.Server.MapPath("~/links.json")))
      {
        string json = reader.ReadToEnd();

        Data = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
      }
    }
    public static string GetUrl(string key)
    {
      return Data.ContainsKey(key) ? Data[key] : "#";
    }
  }
}
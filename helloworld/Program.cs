using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;

public class Program
{
    static public void Main()
    {
        Console.WriteLine("ようこそ");

        // Read CSV Convert to JSON and output

        var csv = new List<string[]>();
        var lines = File.ReadAllLines("coldData.csv");

        foreach (string line in lines)
            csv.Add(line.Split(','));

        var properties = lines[0].Split(',');

        var listObjResult = new List<Dictionary<string, string>>();

        for (int i = 1; i < lines.Length; i++)
        {
            var objResult = new Dictionary<string, string>();
            for (int j = 0; j < properties.Length; j++)
                objResult.Add(properties[j], csv[i][j]);

            listObjResult.Add(objResult);
        }

        var json = JsonConvert.SerializeObject(listObjResult); 
        System.IO.File.WriteAllText(@"output.json", json);
        

        // Read File
        // String st = File.ReadAllText("./output.json");
        // Console.WriteLine(st);
    }
}

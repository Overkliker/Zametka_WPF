using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zametka_WPF
{
    internal class JsonSer
    {
        public static string cur = Directory.GetCurrentDirectory();
        public static string file = cur.Substring(0, cur.Length - 24) + "Notes.json";

        public static void Ser(Dictionary<string, List<Note>> obj)
        {
            string json = JsonConvert.SerializeObject(obj);
            File.WriteAllText(file, json);
        }

        public static Dictionary<string, List<Note>> Des()
        {
            Debug.WriteLine(file);
            string json = File.ReadAllText(file);
            Dictionary<string, List<Note>> notes = JsonConvert.DeserializeObject<Dictionary<string, List<Note>>>(json);

            return notes;
        }
    }
}

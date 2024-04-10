using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountdownForExam.ViewModels
{
    public class Base
    {
        public static MyData Read()
        {
            var file = SysFile.Instance.FilePath;
            if (!File.Exists(file))
            {
                return null;
            }
            var str = File.ReadAllText(file);
            MyData m = JsonConvert.DeserializeObject<MyData>(str);
            return m;
        }

        public static void Write(MyData data)
        {
            var file = SysFile.Instance.FilePath;
            var str = JsonConvert.SerializeObject(data);
            File.WriteAllText(file, str);
        }
    }

    public class MyData
    {
        public string Description { get; set; }
        public DateTime DateTime { get; set; }
    }
}

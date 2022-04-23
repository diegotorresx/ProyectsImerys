using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckErrorLogs.Model
{
    public class ModelData
    {
        public int ID { get; set; }
        public string RPA_ID { get; set; }
        public DateTime dateTime { get; set; }
        public string Error_Description { get; set; }
        public string Enviroment { get; set; }
        public string IsProcessed { get; set; }
    }
}

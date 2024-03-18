using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DSG.Service.Models
{
    public class Result
    {
        public bool Exitoso { get; set; }
        public string? MessageError { get; set; }
        Users?  users { get; set; }
    }
}

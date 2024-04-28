using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoutingAIgorithm.Models
{
    public class ResultData
    {
        public string Node { get; set; }
        public List<string> Adj { get; set; }
        public Stack<string> ListL { get; set; }

        //BNB
        public List<string> ListL1Sorted { get; set; }
        public List<double> Kuv { get; set; }
        public List<double> Hv { get; set; }
        public List<double> Gv { get; set; }
        public List<double> Fv { get; set; }

        public ResultData()
        {
            Adj = new List<string>();
            ListL = new Stack<string>();
            ListL1Sorted = new List<string>();
            Kuv = new List<double>();
            Hv = new List<double>();
            Gv = new List<double>();
            Fv = new List<double>();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoutingAIgorithm.Models
{
    public static class Utils
    {
        public static double GetVertex(string node)
        {
            var nodeVal = node.Split(':');
            return double.Parse(nodeVal[1]);
            //return double.Parse(node.Substring(k, node.Length-k));
        }

        public static string GetName(string node)
        {
            var nodeVal = node.Split(':');
            return nodeVal[0];
        }
    }
}

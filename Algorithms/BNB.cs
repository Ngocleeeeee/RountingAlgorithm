using RoutingAIgorithm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoutingAIgorithm.Algorithms
{
    public class BNB
    {
        public Dictionary<string, List<string>> Adj { get; set; }
        public Dictionary<string, double> Vertex { get; set; }
        public Dictionary<string, double> Edge { get; set; }
        public string FromNode { get; set; }
        public string ToNode { get; set; }

        private List<ResultData> lstData;

        private List<string> lstNodeRoute;

        private double cost;


        public BNB(Dictionary<string, List<string>> adj, Dictionary<string, double> vertex, Dictionary<string, double> edge)
        {
            Adj = adj;
            Vertex = vertex;
            Edge = edge;
            lstData = new List<ResultData>();
            lstNodeRoute = new List<string>();
        }


        public List<ResultData> GetTable()
        {

            return lstData;
        }

        public double GetCost()
        {
            return cost;
        }

        public List<string> GetRoute()
        {
            List<string> reversedList = lstNodeRoute.AsEnumerable().Reverse().ToList();
            return reversedList;
        }

        public void SearchRoute(string startNode, string endNode)
        {
            Stack<string> ListL = new Stack<string>();
            List<string> ListL1 = new List<string>();
            Dictionary<string, double> g = new Dictionary<string, double>();
            Dictionary<string, double> f = new Dictionary<string, double>();
            Dictionary<string, string> father = new Dictionary<string, string>();

            g.Add(startNode, 0);
            ListL.Push(startNode);
            cost = 999999999999;
            while (ListL.Count() != 0)
            {
                //
                string u = Utils.GetName(ListL.Pop());
                ResultData resultData = new ResultData();
                resultData.Node = u;
                if (Adj.ContainsKey(u)) resultData.Adj = Adj[u];

                if (!g.ContainsKey(u)) g.Add(u, Vertex[u]);
                if (u == endNode)
                {
                    if (g[u] <= cost)
                    {
                        cost = g[u];
                        resultData.ListL1Sorted = new List<string>() { "->Cost =" + cost };
                        if (ListL.Any(x => Utils.GetVertex(x) <= cost))
                        {
                            lstData.Add(resultData);
                            continue;
                        }
                        resultData.ListL1Sorted.Add("->STOP");
                        lstData.Add(resultData);
                        break;
                    }

                }
                else
                {
                    ListL1 = new List<string>();
                    if (!Adj.ContainsKey(u))
                    {
                        resultData.ListL = new Stack<string>(ListL.ToList()); ;
                        lstData.Add(resultData);
                        continue;
                    }
                    foreach (var v in Adj[u])
                    {
                        g[v] = g[u] + k(u, v);
                        f[v] = g[v] + h(v);
                        father[v] = u;
                        ListL1.Add(v +":"+ f[v]);
                        ListL1 = ListL1.OrderBy(x => Utils.GetVertex(x)).ToList();
                        //
                        resultData.Kuv.Add(k(u, v));
                        resultData.Hv.Add(h(v));
                        resultData.Gv.Add(g[v]);
                        resultData.Fv.Add(f[v]);
                    }

                    for (int i = ListL1.Count - 1; i >= 0; i--)
                    {
                        ListL.Push(ListL1[i]);
                    }

                    resultData.ListL1Sorted = ListL1;
                    resultData.ListL = new Stack<string>(ListL.ToList()); ;
                }
                lstData.Add(resultData);
            }
            //if (ListL.Count() == 0)
            //{
            //    ResultData resultData = new ResultData();
            //    resultData.ListL.Push("-> End");
            //    lstData.Add(resultData);
            //}
            if (cost!= 999999999999)
            {
                lstNodeRoute.Add(endNode);
            }
            string node = endNode;
            bool check = true;
            while (node != startNode && father.ContainsKey(node))
            {
                node = father[node];
                lstNodeRoute.Add(node);
                check = false;
            }
            if (check == true)
            {
                ResultData resultData = new ResultData();
                resultData.ListL.Push("-> End");
                lstData.Add(resultData);
            }
        }

        private double k(string u, string v)
        {
            if (!Edge.ContainsKey(u + v))
            {
                if (!Edge.ContainsKey(v + u))
                {
                    return 0;
                }
                return Edge[v + u];
            }
            return Edge[u + v];
        }

        private double h(string v)
        {
            if (!Vertex.ContainsKey(v)) return 0;
            return Vertex[v];
        }
    }
}

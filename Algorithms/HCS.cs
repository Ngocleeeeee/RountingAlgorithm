using RoutingAIgorithm.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RoutingAIgorithm.Algorithms
{
    public class HCS
    {
        public Dictionary<string, List<string>> Adj { get; set; }
        public Dictionary<string, double> Vertex { get; set; }
        public string FromNode { get; set; }
        public string ToNode { get; set; }
        private List<ResultData> lstData;
        private List<string> lstNodeRoute;
        private double cost;

        public HCS(Dictionary<string, List<string>> adj, Dictionary<string, double> vertex)
        {
            Adj =new Dictionary<string, List<string>>(adj);
            Vertex = new Dictionary<string, double>(vertex);
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
            Dictionary<string, string> father = new Dictionary<string, string>();

            g.Add(startNode, 0);
            ListL.Push(startNode);
            cost = 999999999;

            while (ListL.Count() != 0)
            {
                string u = Utils.GetName(ListL.Pop());
                double uCost = g[u];
                ResultData resultData = new ResultData();
                resultData.Node = u;
                if (Adj.ContainsKey(u))
                    resultData.Adj = Adj[u];

                if (!g.ContainsKey(u))
                    g.Add(u, Vertex[u]);

                if (u == endNode)
                {
                    if (uCost <= cost)
                    {
                        cost = uCost;
                        resultData.ListL1Sorted = new List<string>() { "->Cost =" + cost };
                        resultData.ListL = new Stack<string>(ListL.ToList());
                        resultData.ListL1Sorted.Add("->STOP");
                        lstData.Add(resultData);

                        break;
                    }
                }
                else
                {
                    
                    ListL1 = new List<string>();
                    if (!Adj.ContainsKey(u)) continue;
                    foreach (var v in Adj[u])
                    {
                        double newCost = uCost + Vertex[v];
                        double oldcost = Vertex[v];
                        if (!g.ContainsKey(v) || newCost < g[v])
                        {
                            g[v] = newCost;
                            father[v] = u;
                            ListL1.Add(v +":"+oldcost.ToString());
                            ListL1 = ListL1.OrderBy(x => Utils.GetVertex(x)).ToList();
                            //ListL.Push(v);
                        }
                    }
                    for (int i = ListL1.Count - 1; i >= 0; i--)
                    {
                        ListL.Push(ListL1[i]);
                    }
                    resultData.ListL1Sorted = ListL1;
                    resultData.ListL = new Stack<string>(ListL.ToList());
                    
                }
                lstData.Add(resultData);
            }

            // lstNodeRoute.Clear();
            if (lstData.Any(x => x.ListL1Sorted.Contains("->STOP")))
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
    }
}
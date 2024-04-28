using RoutingAIgorithm.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoutingAIgorithm.Algorithms
{
    public class DFS
    {
        public Dictionary<string, List<string>> Adj { get; set; }
        public string FromNode { get; set; }
        public string ToNode { get; set; }

        private List<ResultData> lstData;

        private List<string> lstNodeRoute;

        public DFS(Dictionary<string, List<string>> adj)
        {
            Adj = adj;
            lstData = new List<ResultData>();
            lstNodeRoute = new List<string>();
        }
        

        public List<ResultData> GetTable()
        {

            return lstData;
        }

        public List<string> GetRoute()
        {
            List<string> reversedList = lstNodeRoute.AsEnumerable().Reverse().ToList();
            return reversedList;
        }

        public void SearchRoute(string startNode, string endNode)
        {
            Stack<string> ListL = new Stack<string>();
            Dictionary<string, bool> visited = new Dictionary<string, bool>();
            Dictionary<string, string> father = new Dictionary<string, string>();

            ListL.Push(startNode);
            
            while (ListL.Count()!=0)
            {
                string currNode = ListL.Pop();
                ResultData resultData = new ResultData();
                resultData.Node = currNode;
                if (Adj.ContainsKey(currNode)) resultData.Adj = Adj[currNode];
                if (currNode == endNode)
                {
                    resultData.ListL.Push("->Stop");
                    lstData.Add(resultData);
                    lstNodeRoute.Add(currNode);
                    break;

                }
                else 
                {
                    // Nếu đỉnh chưa được thăm, thêm vào đường đi và đánh dấu đã thăm
                    visited[currNode] = true;

                    // Thêm các đỉnh kề chưa thăm vào stack
                    if (Adj.ContainsKey(currNode))
                    {
                        foreach (var neighbor in Adj[currNode])
                        {
                            if (!visited.ContainsKey(neighbor) && !ListL.Contains(neighbor))
                            {
                                ListL.Push(neighbor);
                                father[neighbor] = currNode;
                            }
                        }
                    }
                    resultData.ListL = new Stack<string>(ListL.Reverse().ToList());
                    
                }
                lstData.Add(resultData);
            }

            string node = endNode;
            bool check = true;
            while (node != startNode&&father.ContainsKey(node))
            {
                node = father[node];
                lstNodeRoute.Add(node);
                check = false;              

            }
            if(check == true)
            {
                ResultData resultData = new ResultData();
                resultData.ListL.Push("-> End");
                lstData.Add(resultData);
            }
            
        }
    }
}

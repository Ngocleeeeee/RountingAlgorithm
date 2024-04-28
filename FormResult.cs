using RoutingAIgorithm.Algorithms;
using RoutingAIgorithm.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace RoutingAIgorithm
{
    public partial class FormResult : Form
    {
        Dictionary<string, List<string>> Adj;
        Dictionary<string, double> Vertex;
        Dictionary<string, double> Edge;

        Dictionary<string, int> levels;
        string AlgorithmName = null;
        int treeHeight = 0;
        int yDepth = 0;
        int xBreadth = 0;
        FormWindowState LastWindowState = FormWindowState.Minimized;
        //
        List<string> lstRouteSave;
        public FormResult()
        {
            InitializeComponent();
       
            panelTree2.AutoSize = false;
            panelTree2.AutoScroll = true;
        }
        public void SetAlgorithm(string algorithmName){
            AlgorithmName = algorithmName;
        }
        public void SetPreview(string AlgorithmName, Bitmap image, string from, string to)
        {
            lblAlgo.Text = AlgorithmName;
            //PictureBox pictureBox = new PictureBox();
            //pictureBox.Image = image;
            //pictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
            //panelSource.Controls.Add(pictureBox);
            
            txtFrom.Text = from;
            txtTo.Text = to;
      
        }
        public void DFS()
        {
            DFS dfs = new DFS(Adj);  
            dfs.SearchRoute(txtFrom.Text, txtTo.Text);

            var lstData = dfs.GetTable();

            SetUpGrid(new List<string>() { "Node", "Adj", "List L" });
            gridTable.Rows.Clear();
            foreach (var obj in lstData)
            {
                string adjCol = string.Join(Environment.NewLine, obj.Adj);
                string lCol = string.Join(", ", obj.ListL);
                gridTable.Rows.Add(new object[]
                {
                    obj.Node,
                    adjCol,
                    lCol
                });
            }
            lstRouteSave = new List<string>(dfs.GetRoute());
            lblRoute.Text = string.Join(" -> ", dfs.GetRoute());
            if (dfs.GetRoute().Count == 0)lblRoute.Text = "No path found from "+txtFrom.Text+"->" +txtTo.Text;
            lblCost.Text = "N/A";  // DFS không có chi phí.
            //DrawTree(dfs.GetRoute());


        }

        public void HCS()
        {
            HCS hcs = new HCS(Adj, Vertex);
            hcs.SearchRoute(txtFrom.Text, txtTo.Text);

            var lstData = hcs.GetTable();

            SetUpGrid(new List<string>() { "Node", "Adj", "List L1", "List L" });
            gridTable.Rows.Clear();
            foreach (var obj in lstData)
            {
                string adjCol = string.Join(Environment.NewLine, obj.Adj);
                string l1Col = string.Join(", ", obj.ListL1Sorted);
                string lCol = string.Join(", ", obj.ListL);
                gridTable.Rows.Add(new object[]
                {
                    obj.Node,
                    adjCol,
                    l1Col,
                    lCol
                });
            }
            lstRouteSave = new List<string>(hcs.GetRoute());
            lblRoute.Text = string.Join(" -> ", hcs.GetRoute());
            lblCost.Text = "N/A";
            if (hcs.GetRoute().Count == 0)
            {

                lblRoute.Text = "No path found from " + txtFrom.Text + "->" + txtTo.Text;
                
            } 
            DrawTree(hcs.GetRoute(), panelTree2);

        }

        public void BNB()
        {

            BNB bnb = new BNB(Adj, Vertex, Edge);
            bnb.SearchRoute(txtFrom.Text, txtTo.Text);

            var lstData = bnb.GetTable();

            SetUpGrid(new List<string>() { "Node", "Adj", "k(u,v)", "h(v)", "g(v)", "f(v)", "List L1", "List L" });
            gridTable.Rows.Clear();
            foreach (var obj in lstData)
            {
                string adjCol = string.Join(Environment.NewLine, obj.Adj);
                string kuvCol = string.Join(Environment.NewLine, obj.Kuv);
                string hvCol = string.Join(Environment.NewLine, obj.Hv);
                string gvCol = string.Join(Environment.NewLine, obj.Gv);
                string fvCol = string.Join(Environment.NewLine, obj.Fv);
                string l1Col = string.Join(", ", obj.ListL1Sorted);
                string lCol = string.Join(", ", obj.ListL);
                gridTable.Rows.Add(new object[]
                {
                    obj.Node,
                    adjCol,
                    kuvCol,
                    hvCol,
                    gvCol,
                    fvCol,
                    l1Col,
                    lCol
                });
            }
            lstRouteSave = new List<string>(bnb.GetRoute());
            lblRoute.Text = string.Join(" -> ", bnb.GetRoute());
            lblCost.Text = bnb.GetCost().ToString();
            if (bnb.GetRoute().Count == 0)
            {

                lblRoute.Text = "No path found from " + txtFrom.Text + "->" + txtTo.Text;
                lblCost.Text = "N/A";
            }
            DrawTree(bnb.GetRoute(), panelTree2);
        }

        public void SetData(Dictionary<string, List<string>> Adj, Dictionary<string, double> Vertex = null, Dictionary<string, double> Edge=null)
        {
            this.Adj = Adj;
            this.Vertex = Vertex;
            this.Edge = Edge;
            
        }
        public void SetUpGrid(List<string> lstTitle)
        {
            foreach (var title in lstTitle)
            {
                gridTable.Columns.Add("Column", title);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRefesh_Click(object sender, EventArgs e)
        {
            //ResetTree();
            //panelTree2.Controls.Re();
            ResetTree();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FileHandler.ExportToExcel(gridTable, saveFileDialog1.FileName, lblAlgo.Text, lblRoute.Text, lblCost.Text);
            }
        }


        //DRAW TREE
        
   
        private void DrawTree(List<string> routeNode, Panel panelTree2)
        {
            
            //DRAW TREE
            var centerPanel = new Point(panelTree2.Width / 2-50, panelTree2.Location.Y-80);
            Dictionary<string, bool> visited = new Dictionary<string, bool>();
            Queue<string> Q = new Queue<string>();
            Q.Enqueue(Adj.Keys.FirstOrDefault());
            visited.Add(Adj.Keys.FirstOrDefault(), true);

            Node nodeRoot = null;
            if (AlgorithmName!="DFS")
            {
                nodeRoot = new Node(Adj.Keys.FirstOrDefault(), Vertex[Adj.Keys.FirstOrDefault()]);
            }
            else
            {
                nodeRoot = new Node(Adj.Keys.FirstOrDefault(), 0);
            }

            nodeRoot.SetPosition(centerPanel);

            panelTree2.Controls.Add(nodeRoot);
            //level
            levels = new Dictionary<string, int>();

            List<Node> vistedNode = new List<Node>();
            vistedNode.Add(nodeRoot);

            levels[nodeRoot.Name] = 0;
            yDepth = 0;
            xBreadth = 0;
            while (Q.Count() != 0)
            {
                var u = Q.Dequeue();
                // Node parentNode = new Node(u, Vertex[u]);
                treeHeight = levels[u];
                Node parentNode = null;

                if (AlgorithmName == "DFS")
                {
                    parentNode = new Node(u, 0);
                }
                else
                {
                    parentNode = new Node(u, Vertex[u]);
                }
                if (vistedNode.Any(x => x.Text == parentNode.Text))
                {
                    parentNode = vistedNode.FirstOrDefault(x => x.Text == parentNode.Text);
                }
                if (!Adj.ContainsKey(u)) continue;
                int level = levels[parentNode.Name];
                yDepth = Math.Max(yDepth, parentNode.Location.Y);
                xBreadth = Math.Max(xBreadth, parentNode.Location.X);

                int xOffset = 20;
                int flag = 0;
                foreach (var v in Adj[u])
                {
                    int startX = parentNode.Location.X - Adj[u].Count() * 30;
                    if (visited.ContainsKey(v) && visited[v])
                    {
                        Node node = null;
                        if (AlgorithmName == "DFS")
                        {
                            node = new Node(v, 0);
                        }
                        else
                        {
                            node = new Node(v, Vertex[v]);
                        }

                        var adjNode = vistedNode.FirstOrDefault(x => x.Text == node.Text);
                        double edge = 0;
                        if (Edge != null && Edge.ContainsKey(u + v)) edge = Edge[u + v];
                        if (adjNode.Location.Y == parentNode.Location.Y)
                        {
                            var isNextTo = true;
                            if (vistedNode.Any(x =>
                                x.Location.Y == adjNode.Location.Y &&
                                (
                                    (x.Location.X > adjNode.Location.X && x.Location.X < parentNode.Location.X)
                                    || (x.Location.X < adjNode.Location.X && x.Location.X > parentNode.Location.X)
                                )
                            ))
                            {
                                isNextTo = false;
                            }
                            var isRouteNode = CheckRouteLine(parentNode, adjNode, routeNode);

                            if (adjNode.Location.X < parentNode.Location.X)
                            {
                                panelTree2.Paint += (s, e) =>
                                {
                                    
                                    if (isNextTo) DrawLine(e.Graphics, parentNode.LeftPoint, adjNode.RightPoint, edge, isRouteNode);
                                    else DrawQuadraticBezierCurve(e.Graphics, parentNode.LeftPoint, adjNode.RightPoint, edge, isRouteNode);
                                };
                            }
                            else
                            {
                                panelTree2.Paint += (s, e) =>
                                {
                                     if (isNextTo) DrawLine(e.Graphics, parentNode.RightPoint, adjNode.LeftPoint, edge, isRouteNode);
                                    else DrawQuadraticBezierCurve(e.Graphics, parentNode.RightPoint, adjNode.LeftPoint, edge, isRouteNode);
                                };
                            }
                            xOffset += adjNode.Size.Width + 10;
                        }
                        else
                        {
                            flag = 1;
                            var isRouteNode = CheckRouteLine(parentNode, adjNode, routeNode);
                            if (parentNode.Location.Y > adjNode.Location.Y)
                            {
                                panelTree2.Paint += (s, e) =>
                                {
                                    
                                    DrawLine(e.Graphics, parentNode.TopPoint, adjNode.BottomPoint, edge, isRouteNode);
                                };
                            }
                            else
                            {
                                panelTree2.Paint += (s, e) =>
                                {
                                    DrawLine(e.Graphics, parentNode.BottomPoint, adjNode.TopPoint, edge, isRouteNode);
                                };
                            }
                        }

                    }
                    if (!visited.ContainsKey(v) || visited[v] != true)
                    {
                        visited[v] = true;

                        Q.Enqueue(v);

                        //Node nodeAdj = new Node(v, Vertex[v]);
                        Node nodeAdj = null;
                        if (AlgorithmName == "DFS")
                        {
                            nodeAdj = new Node(v, 0);
                        }
                        else
                        {
                            nodeAdj = new Node(v, Vertex[v]);
                        }
                        nodeAdj.ParrentNode = parentNode;

                        nodeAdj.SetPosition(startX + xOffset, parentNode.Location.Y + 70);
                        if (flag == 1)
                        {
                            nodeAdj.SetPosition(startX + xOffset + 60, parentNode.Location.Y + 70);
                        }
                        if (vistedNode.Any(x => x.Location.Y == nodeAdj.Location.Y && x.ParrentNode.Name != u))
                        {


                            foreach (var nodeVisted in vistedNode)
                            {
                                if (nodeVisted.Location.Y == nodeAdj.Location.Y && nodeVisted.ParrentNode.Name != u)
                                {
                                    if (Math.Abs(nodeAdj.Location.X - nodeVisted.Location.X) <= nodeAdj.Size.Width)
                                    {
                                        nodeAdj.SetPosition(startX + xOffset + 60, parentNode.Location.Y + 70);
                                        xOffset += 60;
                                    }
                                }

                            }


                        }
                        levels[nodeAdj.Name] = level + 1;
                        vistedNode.Add(nodeAdj);
                        double edge = 0;
                        if (Edge != null && Edge.ContainsKey(u + v)) edge = Edge[u + v];

                        //MessageBox.Show(edge.ToString());
                        panelTree2.Controls.Add(nodeAdj);
                        panelTree2.Paint += (s, e) =>
                        {
                            var isRouteNode = CheckRouteLine(parentNode, nodeAdj, routeNode);
                            DrawLine(e.Graphics, parentNode.BottomPoint, nodeAdj.TopPoint, edge, isRouteNode);
                        };

                        xOffset += nodeAdj.Size.Width * 2 + 10;
                    }
                }

            }

            panelTree2.Invalidate();
            panelTree2.Refresh();

        }

        private bool CheckRouteLine(Node parentNode, Node adjNode, List<string> routeNode)
        {
            bool isRouteNode = false;
            if (routeNode.Count != 0)
            {
                var parentIndex = routeNode.IndexOf(routeNode.FirstOrDefault(x => x == parentNode.Name));
                if (parentIndex != -1)
                {
                    if (parentIndex + 1 < routeNode.Count)
                    {
                        if (routeNode[parentIndex + 1] == adjNode.Name)
                        {
                            parentNode.BackColor = Color.Green;
                            adjNode.BackColor = Color.Green;
                            isRouteNode = true;
                        }
                    }
                }
            }
            return isRouteNode;
        }
        private static void DrawLine(Graphics g, Point from, Point to,double edge = 0, bool isRoute = false)
        {
            Color penColor = isRoute ? Color.Green : Color.Black;
            int size = isRoute ? 2 : 1;
            var pen = new Pen(penColor, size);

            pen.CustomEndCap = new AdjustableArrowCap(3, 3);

            g.DrawLine(pen, from, to);

            if (edge == 0) return;
            // Tính toán trung điểm của mũi tên
            int centerX = (from.X + to.X) / 2 - 5;
            int centerY = (from.Y + to.Y) / 2 - 12;
            Point arrowCenter = new Point(centerX, centerY);

            // Vẽ chú thích trên trung điểm của mũi tên
            string caption = edge.ToString();
            Font captionFont = new Font("Arial", 8);
            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            g.DrawString(caption, captionFont, Brushes.Black, arrowCenter, stringFormat);
        }

        private static void DrawQuadraticBezierCurve(Graphics g, Point startPoint, Point endPoint, double edge = 0, bool isRoute = false)
        {
            Color penColor = isRoute ? Color.Green : Color.Black;
            int size = isRoute ? 2 : 1;
            var pen = new Pen(penColor, size);

            pen.CustomEndCap = new AdjustableArrowCap(3, 3);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            float radius = 0.4f;
            Point controlPoint = new Point((startPoint.X + endPoint.X) / 2, (startPoint.Y + endPoint.Y) / 2);
            float distance = radius * radius * Math.Abs(startPoint.X - endPoint.X);
            controlPoint.Y -= (startPoint.Y > endPoint.Y) ? (int)distance : -(int)distance;

            g.DrawBezier(pen, startPoint, controlPoint, controlPoint, endPoint);

            if (edge == 0) return;
            float t = 0.5f; // Tham số t cho đỉnh (bề lõm) là 0.5
            float oneMinusT = 1f - t;
            float xVertex = oneMinusT * oneMinusT * startPoint.X + 2 * oneMinusT * t * controlPoint.X + t * t * endPoint.X;
            float yVertex = oneMinusT * oneMinusT * startPoint.Y + 2 * oneMinusT * t * controlPoint.Y + t * t * endPoint.Y;

            // Vẽ chú thích trong đỉnh (bề lõm) của đường cong
            string caption = edge.ToString();
            Font captionFont = new Font("Arial", 8);
            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            g.DrawString(caption, captionFont, Brushes.Black, xVertex, yVertex, stringFormat);
        }

        //RESET
        public void ResetTree()
        {
            Panel panel = new Panel();
            panel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            panel.AutoScroll = true;
            panel.BackColor = Color.White;
            panel.BorderStyle = BorderStyle.FixedSingle;
            panel.Location = panelTree2.Location;//184, 11

            panel.TabIndex = 5;
            panel.AutoSize = true;
            panel.AutoScroll = true;


            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is Panel)
                {
                    panel.Size = ctrl.Size;
                    this.Controls.Remove(ctrl);
                }
            }
            this.Controls.Add(panel);
            DrawTree(lstRouteSave, panel);


        }

        private void panelTree2_Resize(object sender, EventArgs e)
        {
            //ResetTree();
        }

        private void FormResult_SizeChanged(object sender, EventArgs e)
        {
            
            if (WindowState != LastWindowState)
            {
                LastWindowState = WindowState;


                if (WindowState == FormWindowState.Maximized)
                {
                    ResetTree();
                    // Maximized!
                }
                if (WindowState == FormWindowState.Minimized)
                {
                    ResetTree();
                    // Restored!
                }
            }
        }
    }
}

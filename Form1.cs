using RoutingAIgorithm.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using IniParser;
using IniParser.Model;

namespace RoutingAIgorithm
{
    public partial class Form1 : Form
    {
        string fullFilePath = "";
        IniData data;
        KeyDataCollection adjacencyListKeys;
        KeyDataCollection vertexWeightKeys;
        KeyDataCollection edgeWeightKeys;

        string algorihmName = "";
        string fromNode = "";
        string toNode = "";
        Dictionary<string, List<string>> Adj;
        Dictionary<string, double> Vertex;
        Dictionary<string, double> Edge;

        Dictionary<string, int> levels;
        int treeHeight = 0;
        int yDepth = 0;
        int xBreadth = 0;

        FileIniDataParser parser;
        public Form1()
        {
            InitializeComponent();

            //panelTree2.AutoSize = false;
            //panelTree2.AutoScroll = true;
            optionDFS.Enabled = false;
            optionHCS.Enabled = false;
            optionBNB.Enabled = false;
            parser = new FileIniDataParser();
           
        }

        public void ResetReadingFile()
        {
            adjacencyListKeys = null;
            vertexWeightKeys = null;
            edgeWeightKeys = null;
            Adj = new Dictionary<string, List<string>>();
            Vertex = new Dictionary<string, double>();
            Edge = new Dictionary<string, double>();
        }
        
        public Panel ResetTree()
        {

            ResetReadingFile();
            Size sizePanel = new Size();
            Point locationPanel = new Point();
           
            foreach (Control ctrl in groupBox2.Controls)
            {
                if(ctrl is Panel)
                {
                    ctrl.Controls.Clear();
                    //using (Graphics g = ctrl.CreateGraphics())
                    //{
                    //    g.Clear(ctrl.BackColor);
                    //}
                    sizePanel = ctrl.Size;
                    locationPanel = ctrl.Location;
                    groupBox2.Controls.Remove(ctrl);
                    break;

                    
                }

            }
            groupBox2.Invalidate();
            groupBox2.Refresh();
            Panel panelTree = new Panel();
            groupBox2.Controls.Add(panelTree);
            panelTree.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
          | System.Windows.Forms.AnchorStyles.Left)
          | System.Windows.Forms.AnchorStyles.Right)));

            panelTree.AutoScroll = true;
            panelTree.BackColor = Color.White;
            panelTree.BorderStyle = BorderStyle.FixedSingle;
            panelTree.Location = locationPanel;//184, 11
            panelTree.Size = sizePanel;//402, 218
            panelTree.TabIndex = 5;
            panelTree.AutoSize = false;
            panelTree.AutoScroll = true;

            return panelTree;


        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            openFileInput.Filter = "Tệp tin INI (*.ini)|*.ini";
            if (openFileInput.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                fullFilePath = openFileInput.FileName;
                string justFileName = Path.GetFileName(fullFilePath);

                lblFilename.Text = justFileName;
            }
       
        }

        private void btnReadFile_Click(object sender, EventArgs e)
        {
            if (fullFilePath.Trim() == "")
            {
                MessageBox.Show("Choose a file(.ini) to read", "Can not read");
                return;
            }
            string filePath = fullFilePath;
            var newPanel= ResetTree();
            data = parser.ReadFile(filePath);
           
            DrawTree(newPanel);
            //newPanel.Padding = new Padding(0, 0, xBreadth, yDepth);

            Label lblTemp = new Label();
            lblTemp.Location = new Point(newPanel.Right + 10, newPanel.Top);
            lblTemp.Size = new Size(1, newPanel.Height);
           
            newPanel.Controls.Add(lblTemp);

        }

        private void DrawTree(Panel panelTree)
        {
            if(!SelectAlgorithms()) return;
            GetAdjacencyList();
            GetTheRouteSearch();
            if (optionHCS.Checked||optionBNB.Checked) GetVertexWeight();
            if (optionBNB.Checked) GetEdgeWeight();

            //DRAW TREE
            var centerPanel = new Point(panelTree.Width / 2 -120, panelTree.Location.Y);
            Dictionary<string, bool> visited = new Dictionary<string, bool>();
            Queue<string> Q = new Queue<string>();
            Q.Enqueue(Adj.Keys.FirstOrDefault());
            visited.Add(Adj.Keys.FirstOrDefault(), true);

            Node nodeRoot = null;
            if (!optionDFS.Checked)
            {
                nodeRoot = new Node(Adj.Keys.FirstOrDefault(), Vertex[Adj.Keys.FirstOrDefault()]);
            }
            else
            {
                nodeRoot = new Node(Adj.Keys.FirstOrDefault(), 0);
            }

            nodeRoot.SetPosition(centerPanel);

            panelTree.Controls.Add(nodeRoot);
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

                if (optionDFS.Checked)
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
                        if (optionDFS.Checked)
                        {
                            node = new Node(v, 0);
                        }
                        else
                        {
                            node = new Node(v, Vertex[v]);
                        }

                        var adjNode = vistedNode.FirstOrDefault(x => x.Text == node.Text);
                        double edge = 0;
                        if (Edge!=null&&Edge.ContainsKey(u + v)) edge = Edge[u + v];
                        if (adjNode.Location.Y == parentNode.Location.Y)
                        {
                            var isNextTo = true;
                            if (vistedNode.Any(x => 
                                x.Location.Y == adjNode.Location.Y && 
                                (
                                    (x.Location.X > adjNode.Location.X && x.Location.X < parentNode.Location.X)
                                    ||(x.Location.X < adjNode.Location.X && x.Location.X > parentNode.Location.X)
                                )
                            ))
                            {
                                isNextTo = false;
                            }
                            if (adjNode.Location.X < parentNode.Location.X)
                            {                                
                                panelTree.Paint += (s, e) =>
                                {
                                    if(isNextTo) DrawLine(e.Graphics, parentNode.LeftPoint, adjNode.RightPoint, edge);
                                    else DrawQuadraticBezierCurve(e.Graphics, parentNode.LeftPoint, adjNode.RightPoint, edge);
                                };
                            }
                            else
                            {
                                panelTree.Paint += (s, e) =>
                                {
                                    if (isNextTo) DrawLine(e.Graphics, parentNode.RightPoint, adjNode.LeftPoint, edge);
                                    else DrawQuadraticBezierCurve(e.Graphics, parentNode.RightPoint, adjNode.LeftPoint, edge);
                                };
                            }
                            xOffset += adjNode.Size.Width + 10;
                        }
                        else
                        {
                            flag = 1;
                           
                            if(parentNode.Location.Y > adjNode.Location.Y )
                            {
                                panelTree.Paint += (s, e) =>
                                {
                                    DrawLine(e.Graphics, parentNode.TopPoint, adjNode.BottomPoint, edge);
                                };
                            }
                            else
                            {
                                panelTree.Paint += (s, e) =>
                                {
                                    DrawLine(e.Graphics, parentNode.BottomPoint, adjNode.TopPoint, edge);
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
                        if (optionDFS.Checked)
                        {
                            nodeAdj = new Node(v, 0);
                        }
                        else
                        {
                            nodeAdj = new Node(v, Vertex[v]);
                        }
                        nodeAdj.ParrentNode = parentNode;

                        nodeAdj.SetPosition(startX + xOffset, parentNode.Location.Y + 70);
                        if(flag == 1)
                        {
                           nodeAdj.SetPosition(startX + xOffset+60, parentNode.Location.Y + 70);
                        }
                        if (vistedNode.Any(x => x.Location.Y == nodeAdj.Location.Y && x.ParrentNode.Name != u))
                        {
                            

                            foreach (var nodeVisted in vistedNode)
                            {
                                if(nodeVisted.Location.Y == nodeAdj.Location.Y && nodeVisted.ParrentNode.Name != u)
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
                        if (Edge!=null&&Edge.ContainsKey(u+v)) edge = Edge[u + v];
                       
                        //MessageBox.Show(edge.ToString());
                        panelTree.Controls.Add(nodeAdj);
                        panelTree.Paint += (s, e) =>
                        {
                            DrawLine(e.Graphics, parentNode.BottomPoint, nodeAdj.TopPoint, edge);
                        };

                        xOffset += nodeAdj.Size.Width*2+10;
                    }
                }

            }

            panelTree.Invalidate();
            panelTree.Refresh();

        }
       
        private bool SelectAlgorithms()
        {
            //SELECT ALGORITHMS
            string algorithmValue = data["Algorithm"]["Algorithm"].Trim();
            optionDFS.Enabled = false;
            optionHCS.Enabled = false;
            optionBNB.Enabled = false;
            optionDFS.Checked = false;
            optionHCS.Checked = false;
            optionBNB.Checked = false;
            
            if (algorithmValue == "DFS")
            {
                optionDFS.Checked = true;
                algorihmName = optionDFS.Text;
            }
            else if (algorithmValue == "HCS")
            {
                optionHCS.Checked = true;
                algorihmName = optionHCS.Text;
            }
            else if (algorithmValue == "BNB")
            {
                optionBNB.Checked = true;
                algorihmName = optionBNB.Text;
            }
            else
            {
                MessageBox.Show("Algorithm is not exist");
                return false;
            }
            return true;
        }

        private void GetAdjacencyList()
        {
            //GET THE Adjacency OF PER NODE
            adjacencyListKeys = data["Adjacency List"];
            Adj = new Dictionary<string, List<string>>();
            foreach (var key in adjacencyListKeys)
            {
                var lstAdj = key.Value.Trim().Split(',').ToList();
                Adj.Add(key.KeyName, lstAdj);

            }
        }

        private void GetTheRouteSearch()
        {
            string fromNode = data["Route Search"]["From"].Trim();
            string toNode = data["Route Search"]["To"].Trim();
            txtFromNode.Text = fromNode;
            txtToNode.Text = toNode;
        }
        private void GetVertexWeight()
        {
            //GET THE Vertex OF PER NODE
            vertexWeightKeys = data["Vertex Weight"];
            Vertex = new Dictionary<string, double>();
            foreach (var key in vertexWeightKeys)
            {
                Vertex.Add(key.KeyName, double.Parse(key.Value));
            }
        }
        private void GetEdgeWeight()
        {

            //GET THE Edge BETWEEN EACH 2 NODE
            edgeWeightKeys = data["Edge Weight"];
            Edge = new Dictionary<string, double>();
            foreach (var key in edgeWeightKeys)
            {

                Edge.Add(key.KeyName, double.Parse(key.Value));
            }

        }
        private static void DrawLine(Graphics g, Point from, Point to, double edge = 0)
        {
            var pen = new Pen(Color.Black, 1);

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

        private static void DrawQuadraticBezierCurve(Graphics g, Point startPoint, Point endPoint, double edge = 0)
        {
            var pen = new Pen(Color.Black, 1);
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

      
        private void btnRefesh_Click(object sender, EventArgs e)
        {
            ResetTree();
            optionDFS.Checked = false;
            optionHCS.Checked = false;
            optionBNB.Checked = false;
            txtFromNode.Text = "";
            txtToNode.Text = "";

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnSolve_Click(object sender, EventArgs e)
        {
            if(txtFromNode.Text.Trim() == ""|| txtToNode.Text.Trim() == "")
            {
                MessageBox.Show("Must be spectific the route", "Can not solve");
                return;
            }
            if (optionDFS.Checked == false && optionHCS.Checked == false && optionBNB.Checked == false)
            {
                MessageBox.Show("Algorithm is not selected", "Can not solve");
                return;
            }
            FormResult frmRes = new FormResult();
            Panel resPanel = new Panel();
            foreach (Control ctrl in groupBox2.Controls)
            {
                if (ctrl is Panel)
                {
                    resPanel = (Panel)ctrl;
                }

            }
            Bitmap panelImage = CapturePanelImage(resPanel);
            string algorithmValue = data["Algorithm"]["Algorithm"].Trim();
            frmRes.SetAlgorithm(algorithmValue);
            frmRes.SetPreview(algorihmName, panelImage, txtFromNode.Text, txtToNode.Text);
            frmRes.SetData(Adj, Vertex, Edge);
            if (optionDFS.Checked) frmRes.DFS();
            else if (optionHCS.Checked) frmRes.HCS();
            else if (optionBNB.Checked) frmRes.BNB();
            frmRes.Show();
        }

        private Bitmap CapturePanelImage(Panel panel)
        {
            Bitmap bitmap = new Bitmap(panel.Width, panel.Height);
            panel.DrawToBitmap(bitmap, new Rectangle(0, 0, panel.Width, panel.Height));
            return bitmap;
        }
    }
}

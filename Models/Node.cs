using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RoutingAIgorithm.Models
{
    public class Node : Label
    {
        public double VertexWeight { get; set; } = 0;
        public Point TopPoint { get => new Point(Location.X + Size.Width/2, Location.Y);}
        public Point BottomPoint { get => new Point(Location.X + Size.Width / 2, Location.Y + Size.Height); }

        public Point LeftPoint { get => new Point(Location.X, Location.Y + Size.Height/2); }
        public Point RightPoint { get => new Point(Location.X + Size.Width , Location.Y + Size.Height/2); }
        public Node ParrentNode { get; set; }
        public Node(string name, double vertexWeight = 0)
        {
            Name = name;
            VertexWeight = vertexWeight;

            Text = name;
            //BackColor = Color.White;
            BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            Padding = new System.Windows.Forms.Padding(2);
            TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            AutoSize = true;
            Anchor = AnchorStyles.None;

            if (vertexWeight != 0)
            {
                Text = name + " : " + vertexWeight.ToString();
            }

           

        }

        public void SetPosition(int x, int y)
        {
            Location = new System.Drawing.Point(x, y);
        }

        public void SetPosition(Point point)
        {
            Location = point;
        }

        public override bool Equals(object obj)
        {
            return obj is Node node &&
                   Text == node.Text;
        }
    }
}

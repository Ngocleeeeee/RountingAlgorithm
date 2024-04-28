namespace RoutingAIgorithm
{
    partial class FormResult
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.lblAlgo = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtFrom = new System.Windows.Forms.TextBox();
            this.txtTo = new System.Windows.Forms.TextBox();
            this.gridTable = new System.Windows.Forms.DataGridView();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnRefesh = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblCost = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblRoute = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.panelTree2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.gridTable)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Algorithm: ";
            // 
            // lblAlgo
            // 
            this.lblAlgo.AutoSize = true;
            this.lblAlgo.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlgo.Location = new System.Drawing.Point(153, 18);
            this.lblAlgo.Name = "lblAlgo";
            this.lblAlgo.Size = new System.Drawing.Size(271, 29);
            this.lblAlgo.TabIndex = 0;
            this.lblAlgo.Text = "BNB (Brand and Bound)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 25);
            this.label3.TabIndex = 1;
            this.label3.Text = "From";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(268, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 25);
            this.label5.TabIndex = 1;
            this.label5.Text = "To";
            // 
            // txtFrom
            // 
            this.txtFrom.Location = new System.Drawing.Point(75, 66);
            this.txtFrom.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtFrom.Name = "txtFrom";
            this.txtFrom.Size = new System.Drawing.Size(88, 22);
            this.txtFrom.TabIndex = 3;
            // 
            // txtTo
            // 
            this.txtTo.Location = new System.Drawing.Point(309, 63);
            this.txtTo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTo.Name = "txtTo";
            this.txtTo.Size = new System.Drawing.Size(100, 22);
            this.txtTo.TabIndex = 3;
            // 
            // gridTable
            // 
            this.gridTable.AllowUserToAddRows = false;
            this.gridTable.AllowUserToDeleteRows = false;
            this.gridTable.AllowUserToOrderColumns = true;
            this.gridTable.AllowUserToResizeRows = false;
            this.gridTable.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridTable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.gridTable.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.gridTable.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle16.ForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle16;
            this.gridTable.ColumnHeadersHeight = 20;
            this.gridTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle17.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle17.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridTable.DefaultCellStyle = dataGridViewCellStyle17;
            this.gridTable.EnableHeadersVisualStyles = false;
            this.gridTable.Location = new System.Drawing.Point(635, 12);
            this.gridTable.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridTable.Name = "gridTable";
            this.gridTable.ReadOnly = true;
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle18.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridTable.RowHeadersDefaultCellStyle = dataGridViewCellStyle18;
            this.gridTable.RowHeadersVisible = false;
            this.gridTable.RowHeadersWidth = 51;
            this.gridTable.RowTemplate.Height = 24;
            this.gridTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.gridTable.Size = new System.Drawing.Size(791, 361);
            this.gridTable.TabIndex = 4;
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Location = new System.Drawing.Point(1320, 476);
            this.btnExport.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(105, 36);
            this.btnExport.TabIndex = 6;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Location = new System.Drawing.Point(1099, 476);
            this.btnExit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(105, 36);
            this.btnExit.TabIndex = 6;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnRefesh
            // 
            this.btnRefesh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefesh.Location = new System.Drawing.Point(1209, 476);
            this.btnRefesh.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRefesh.Name = "btnRefesh";
            this.btnRefesh.Size = new System.Drawing.Size(105, 36);
            this.btnRefesh.TabIndex = 6;
            this.btnRefesh.Text = "Refesh";
            this.btnRefesh.UseVisualStyleBackColor = true;
            this.btnRefesh.Click += new System.EventHandler(this.btnRefesh_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.lblCost);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.lblRoute);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(635, 388);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(793, 71);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Result";
            // 
            // lblCost
            // 
            this.lblCost.AutoSize = true;
            this.lblCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCost.ForeColor = System.Drawing.Color.Red;
            this.lblCost.Location = new System.Drawing.Point(673, 31);
            this.lblCost.Name = "lblCost";
            this.lblCost.Size = new System.Drawing.Size(53, 25);
            this.lblCost.TabIndex = 1;
            this.lblCost.Text = "Cost";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(619, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 25);
            this.label4.TabIndex = 1;
            this.label4.Text = "Cost:";
            // 
            // lblRoute
            // 
            this.lblRoute.AutoSize = true;
            this.lblRoute.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRoute.ForeColor = System.Drawing.Color.Red;
            this.lblRoute.Location = new System.Drawing.Point(85, 31);
            this.lblRoute.Name = "lblRoute";
            this.lblRoute.Size = new System.Drawing.Size(63, 25);
            this.lblRoute.TabIndex = 1;
            this.lblRoute.Text = "Route";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Route:";
            // 
            // panelTree2
            // 
            this.panelTree2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panelTree2.AutoScroll = true;
            this.panelTree2.BackColor = System.Drawing.Color.White;
            this.panelTree2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTree2.Location = new System.Drawing.Point(12, 105);
            this.panelTree2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelTree2.Name = "panelTree2";
            this.panelTree2.Size = new System.Drawing.Size(615, 407);
            this.panelTree2.TabIndex = 8;
            this.panelTree2.Resize += new System.EventHandler(this.panelTree2_Resize);
            // 
            // FormResult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1439, 529);
            this.Controls.Add(this.panelTree2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnRefesh);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.gridTable);
            this.Controls.Add(this.txtTo);
            this.Controls.Add(this.txtFrom);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblAlgo);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormResult";
            this.Text = "FormResult";
            this.SizeChanged += new System.EventHandler(this.FormResult_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.gridTable)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblAlgo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtFrom;
        private System.Windows.Forms.TextBox txtTo;
        private System.Windows.Forms.DataGridView gridTable;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnRefesh;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblRoute;
        private System.Windows.Forms.Label lblCost;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Panel panelTree2;
    }
}
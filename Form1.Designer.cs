namespace RoutingAIgorithm
{
    partial class Form1
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblFilename = new System.Windows.Forms.Label();
            this.btnUpload = new System.Windows.Forms.Button();
            this.btnSolve = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnRefesh = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtToNode = new System.Windows.Forms.TextBox();
            this.txtFromNode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panelTree2 = new System.Windows.Forms.Panel();
            this.optionBNB = new System.Windows.Forms.RadioButton();
            this.optionHCS = new System.Windows.Forms.RadioButton();
            this.optionDFS = new System.Windows.Forms.RadioButton();
            this.openFileInput = new System.Windows.Forms.OpenFileDialog();
            this.btnReadFile = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.lblFilename);
            this.groupBox1.Controls.Add(this.btnUpload);
            this.groupBox1.Location = new System.Drawing.Point(12, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(813, 71);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select input file";
            // 
            // lblFilename
            // 
            this.lblFilename.AutoSize = true;
            this.lblFilename.Location = new System.Drawing.Point(158, 36);
            this.lblFilename.Name = "lblFilename";
            this.lblFilename.Size = new System.Drawing.Size(61, 16);
            this.lblFilename.TabIndex = 5;
            this.lblFilename.Text = "file name";
            // 
            // btnUpload
            // 
            this.btnUpload.Location = new System.Drawing.Point(20, 26);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(113, 36);
            this.btnUpload.TabIndex = 4;
            this.btnUpload.Text = "Upload";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // btnSolve
            // 
            this.btnSolve.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSolve.Location = new System.Drawing.Point(712, 482);
            this.btnSolve.Name = "btnSolve";
            this.btnSolve.Size = new System.Drawing.Size(113, 36);
            this.btnSolve.TabIndex = 4;
            this.btnSolve.Text = "Solve";
            this.btnSolve.UseVisualStyleBackColor = true;
            this.btnSolve.Click += new System.EventHandler(this.btnSolve_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExit.Location = new System.Drawing.Point(12, 482);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(113, 36);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnRefesh
            // 
            this.btnRefesh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRefesh.Location = new System.Drawing.Point(143, 482);
            this.btnRefesh.Name = "btnRefesh";
            this.btnRefesh.Size = new System.Drawing.Size(113, 36);
            this.btnRefesh.TabIndex = 4;
            this.btnRefesh.Text = "Clear";
            this.btnRefesh.UseVisualStyleBackColor = true;
            this.btnRefesh.Click += new System.EventHandler(this.btnRefesh_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.panelTree2);
            this.groupBox2.Controls.Add(this.optionBNB);
            this.groupBox2.Controls.Add(this.optionHCS);
            this.groupBox2.Controls.Add(this.optionDFS);
            this.groupBox2.Location = new System.Drawing.Point(12, 142);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(813, 334);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Preview Input";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.txtToNode);
            this.groupBox3.Controls.Add(this.txtFromNode);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Location = new System.Drawing.Point(20, 174);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(190, 93);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Search Route";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "To";
            // 
            // txtToNode
            // 
            this.txtToNode.Location = new System.Drawing.Point(65, 55);
            this.txtToNode.Name = "txtToNode";
            this.txtToNode.Size = new System.Drawing.Size(106, 22);
            this.txtToNode.TabIndex = 5;
            // 
            // txtFromNode
            // 
            this.txtFromNode.Location = new System.Drawing.Point(65, 27);
            this.txtFromNode.Name = "txtFromNode";
            this.txtFromNode.Size = new System.Drawing.Size(106, 22);
            this.txtFromNode.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "From";
            // 
            // panelTree2
            // 
            this.panelTree2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelTree2.AutoScroll = true;
            this.panelTree2.BackColor = System.Drawing.Color.White;
            this.panelTree2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTree2.Location = new System.Drawing.Point(246, 14);
            this.panelTree2.Name = "panelTree2";
            this.panelTree2.Size = new System.Drawing.Size(561, 314);
            this.panelTree2.TabIndex = 5;
            // 
            // optionBNB
            // 
            this.optionBNB.AutoSize = true;
            this.optionBNB.Location = new System.Drawing.Point(20, 111);
            this.optionBNB.Name = "optionBNB";
            this.optionBNB.Size = new System.Drawing.Size(177, 20);
            this.optionBNB.TabIndex = 2;
            this.optionBNB.TabStop = true;
            this.optionBNB.Text = "BNB (Branch and Bound)";
            this.optionBNB.UseVisualStyleBackColor = true;
            // 
            // optionHCS
            // 
            this.optionHCS.AutoSize = true;
            this.optionHCS.Location = new System.Drawing.Point(20, 74);
            this.optionHCS.Name = "optionHCS";
            this.optionHCS.Size = new System.Drawing.Size(190, 20);
            this.optionHCS.TabIndex = 1;
            this.optionHCS.TabStop = true;
            this.optionHCS.Text = "HCS (Hill Climbing Search) ";
            this.optionHCS.UseVisualStyleBackColor = true;
            // 
            // optionDFS
            // 
            this.optionDFS.AutoSize = true;
            this.optionDFS.Location = new System.Drawing.Point(20, 34);
            this.optionDFS.Name = "optionDFS";
            this.optionDFS.Size = new System.Drawing.Size(176, 20);
            this.optionDFS.TabIndex = 0;
            this.optionDFS.TabStop = true;
            this.optionDFS.Text = "DFS (Depth First Search)";
            this.optionDFS.UseVisualStyleBackColor = true;
            // 
            // openFileInput
            // 
            this.openFileInput.FileName = "openFileDialog1";
            // 
            // btnReadFile
            // 
            this.btnReadFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReadFile.Location = new System.Drawing.Point(712, 100);
            this.btnReadFile.Name = "btnReadFile";
            this.btnReadFile.Size = new System.Drawing.Size(113, 36);
            this.btnReadFile.TabIndex = 4;
            this.btnReadFile.Text = "Read file";
            this.btnReadFile.UseVisualStyleBackColor = true;
            this.btnReadFile.Click += new System.EventHandler(this.btnReadFile_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 530);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnReadFile);
            this.Controls.Add(this.btnRefesh);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSolve);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Routing ALgorithms";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSolve;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnRefesh;
        private System.Windows.Forms.Label lblFilename;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton optionBNB;
        private System.Windows.Forms.RadioButton optionHCS;
        private System.Windows.Forms.RadioButton optionDFS;
        private System.Windows.Forms.OpenFileDialog openFileInput;
        private System.Windows.Forms.Button btnReadFile;
        private System.Windows.Forms.Panel panelTree2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtToNode;
        private System.Windows.Forms.TextBox txtFromNode;
        private System.Windows.Forms.Label label2;
    }
}


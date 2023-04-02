namespace supermarket项目
{
    partial class Cashier_OriderInfo
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Cashier_OriderInfo));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.查看详情ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.查看今日订单ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查看今日订单ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.查看昨日订单ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.查看本月订单ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.查看上月订单ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.skinComDay = new CCWin.SkinControl.SkinComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.skinComMonth = new CCWin.SkinControl.SkinComboBox();
            this.skinComVip = new CCWin.SkinControl.SkinComboBox();
            this.skinComYear = new CCWin.SkinControl.SkinComboBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labSubtotal = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.skinButton1 = new CCWin.SkinControl.SkinButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8});
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1338, 358);
            this.dataGridView1.TabIndex = 7;
            this.dataGridView1.TabStop = false;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "OrId";
            this.Column1.HeaderText = "订单号";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "MustPrice";
            this.Column2.HeaderText = "原价";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "ActualPrice";
            this.Column3.HeaderText = "优惠";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "OrWhether";
            this.Column4.HeaderText = "是否会员";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "OrMemberID";
            this.Column5.HeaderText = "会员号";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "Amass";
            this.Column6.HeaderText = "积分";
            this.Column6.Name = "Column6";
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "DealTime";
            this.Column7.HeaderText = "交易时间";
            this.Column7.Name = "Column7";
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "UidName";
            this.Column8.HeaderText = "操作员编号";
            this.Column8.Name = "Column8";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.查看详情ToolStripMenuItem,
            this.toolStripSeparator1,
            this.查看今日订单ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(159, 58);
            // 
            // 查看详情ToolStripMenuItem
            // 
            this.查看详情ToolStripMenuItem.Name = "查看详情ToolStripMenuItem";
            this.查看详情ToolStripMenuItem.Size = new System.Drawing.Size(158, 24);
            this.查看详情ToolStripMenuItem.Text = "查看详情(&C)";
            this.查看详情ToolStripMenuItem.Click += new System.EventHandler(this.查看详情ToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(155, 6);
            // 
            // 查看今日订单ToolStripMenuItem
            // 
            this.查看今日订单ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.查看今日订单ToolStripMenuItem1,
            this.查看昨日订单ToolStripMenuItem1,
            this.查看本月订单ToolStripMenuItem1,
            this.查看上月订单ToolStripMenuItem1});
            this.查看今日订单ToolStripMenuItem.Name = "查看今日订单ToolStripMenuItem";
            this.查看今日订单ToolStripMenuItem.Size = new System.Drawing.Size(158, 24);
            this.查看今日订单ToolStripMenuItem.Text = "订单查询(&Z)";
            // 
            // 查看今日订单ToolStripMenuItem1
            // 
            this.查看今日订单ToolStripMenuItem1.Name = "查看今日订单ToolStripMenuItem1";
            this.查看今日订单ToolStripMenuItem1.Size = new System.Drawing.Size(195, 26);
            this.查看今日订单ToolStripMenuItem1.Text = "查看今日订单(&A)";
            this.查看今日订单ToolStripMenuItem1.Click += new System.EventHandler(this.查看今日订单ToolStripMenuItem1_Click);
            // 
            // 查看昨日订单ToolStripMenuItem1
            // 
            this.查看昨日订单ToolStripMenuItem1.Name = "查看昨日订单ToolStripMenuItem1";
            this.查看昨日订单ToolStripMenuItem1.Size = new System.Drawing.Size(195, 26);
            this.查看昨日订单ToolStripMenuItem1.Text = "查看昨日订单(&B)";
            this.查看昨日订单ToolStripMenuItem1.Click += new System.EventHandler(this.查看昨日订单ToolStripMenuItem1_Click);
            // 
            // 查看本月订单ToolStripMenuItem1
            // 
            this.查看本月订单ToolStripMenuItem1.Name = "查看本月订单ToolStripMenuItem1";
            this.查看本月订单ToolStripMenuItem1.Size = new System.Drawing.Size(195, 26);
            this.查看本月订单ToolStripMenuItem1.Text = "查看本月订单(&F)";
            this.查看本月订单ToolStripMenuItem1.Click += new System.EventHandler(this.查看本月订单ToolStripMenuItem1_Click);
            // 
            // 查看上月订单ToolStripMenuItem1
            // 
            this.查看上月订单ToolStripMenuItem1.Name = "查看上月订单ToolStripMenuItem1";
            this.查看上月订单ToolStripMenuItem1.Size = new System.Drawing.Size(195, 26);
            this.查看上月订单ToolStripMenuItem1.Text = "查看上月订单(&V)";
            this.查看上月订单ToolStripMenuItem1.Click += new System.EventHandler(this.查看上月订单ToolStripMenuItem1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.skinButton1);
            this.groupBox1.Controls.Add(this.skinComDay);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.skinComMonth);
            this.groupBox1.Controls.Add(this.skinComVip);
            this.groupBox1.Controls.Add(this.skinComYear);
            this.groupBox1.Controls.Add(this.pictureBox5);
            this.groupBox1.Controls.Add(this.pictureBox7);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.labSubtotal);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(12, 381);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(954, 193);
            this.groupBox1.TabIndex = 31;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "搜索账单";
            // 
            // skinComDay
            // 
            this.skinComDay.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.skinComDay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.skinComDay.FormattingEnabled = true;
            this.skinComDay.Location = new System.Drawing.Point(491, 36);
            this.skinComDay.Name = "skinComDay";
            this.skinComDay.Size = new System.Drawing.Size(181, 31);
            this.skinComDay.TabIndex = 50;
            this.skinComDay.WaterText = "";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(414, 39);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 20);
            this.label6.TabIndex = 49;
            this.label6.Text = "日份：";
            // 
            // skinComMonth
            // 
            this.skinComMonth.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.skinComMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.skinComMonth.FormattingEnabled = true;
            this.skinComMonth.Location = new System.Drawing.Point(117, 152);
            this.skinComMonth.Name = "skinComMonth";
            this.skinComMonth.Size = new System.Drawing.Size(181, 31);
            this.skinComMonth.TabIndex = 48;
            this.skinComMonth.WaterText = "";
            this.skinComMonth.SelectedIndexChanged += new System.EventHandler(this.skinComMonth_SelectedIndexChanged);
            // 
            // skinComVip
            // 
            this.skinComVip.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.skinComVip.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.skinComVip.FormattingEnabled = true;
            this.skinComVip.Location = new System.Drawing.Point(492, 152);
            this.skinComVip.Name = "skinComVip";
            this.skinComVip.Size = new System.Drawing.Size(181, 31);
            this.skinComVip.TabIndex = 48;
            this.skinComVip.WaterText = "";
            // 
            // skinComYear
            // 
            this.skinComYear.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.skinComYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.skinComYear.FormattingEnabled = true;
            this.skinComYear.Location = new System.Drawing.Point(117, 36);
            this.skinComYear.Name = "skinComYear";
            this.skinComYear.Size = new System.Drawing.Size(181, 31);
            this.skinComYear.TabIndex = 48;
            this.skinComYear.WaterText = "";
            this.skinComYear.SelectedIndexChanged += new System.EventHandler(this.skinComYear_SelectedIndexChanged);
            // 
            // pictureBox5
            // 
            this.pictureBox5.Enabled = false;
            this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
            this.pictureBox5.Location = new System.Drawing.Point(203, 77);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(95, 59);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 47;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox7
            // 
            this.pictureBox7.Enabled = false;
            this.pictureBox7.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox7.Image")));
            this.pictureBox7.Location = new System.Drawing.Point(39, 75);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(95, 59);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox7.TabIndex = 47;
            this.pictureBox7.TabStop = false;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(491, 92);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(182, 30);
            this.textBox2.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(351, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "操作员编号：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(372, 154);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "是否会员：";
            // 
            // labSubtotal
            // 
            this.labSubtotal.AutoSize = true;
            this.labSubtotal.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Bold);
            this.labSubtotal.ForeColor = System.Drawing.Color.Red;
            this.labSubtotal.Location = new System.Drawing.Point(785, 39);
            this.labSubtotal.Name = "labSubtotal";
            this.labSubtotal.Size = new System.Drawing.Size(48, 24);
            this.labSubtotal.TabIndex = 6;
            this.labSubtotal.Text = "0元";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(706, 39);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 24);
            this.label7.TabIndex = 6;
            this.label7.Text = "总账:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(39, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "年份：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(39, 155);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 20);
            this.label5.TabIndex = 2;
            this.label5.Text = "月份：";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(993, 381);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(322, 203);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 32;
            this.pictureBox2.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(4460, 3265);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 33;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // skinButton1
            // 
            this.skinButton1.BackColor = System.Drawing.Color.Transparent;
            this.skinButton1.BaseColor = System.Drawing.Color.YellowGreen;
            this.skinButton1.BorderColor = System.Drawing.Color.YellowGreen;
            this.skinButton1.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinButton1.DownBack = null;
            this.skinButton1.Location = new System.Drawing.Point(745, 112);
            this.skinButton1.MouseBack = null;
            this.skinButton1.Name = "skinButton1";
            this.skinButton1.NormlBack = null;
            this.skinButton1.Radius = 20;
            this.skinButton1.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinButton1.Size = new System.Drawing.Size(124, 62);
            this.skinButton1.TabIndex = 51;
            this.skinButton1.TabStop = false;
            this.skinButton1.Text = "查询";
            this.skinButton1.UseVisualStyleBackColor = false;
            this.skinButton1.Click += new System.EventHandler(this.skinButton1_Click);
            // 
            // Cashier_OriderInfo
            // 
            this.AcceptButton = this.skinButton1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1338, 629);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Cashier_OriderInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "订单信息";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Cashier_OriderInfo_FormClosing);
            this.Load += new System.EventHandler(this.Cashier_OriderInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private CCWin.SkinControl.SkinComboBox skinComYear;
        private CCWin.SkinControl.SkinComboBox skinComMonth;
        private CCWin.SkinControl.SkinComboBox skinComDay;
        private System.Windows.Forms.Label label6;
        private CCWin.SkinControl.SkinComboBox skinComVip;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labSubtotal;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 查看详情ToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem 查看今日订单ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 查看今日订单ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 查看昨日订单ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 查看本月订单ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 查看上月订单ToolStripMenuItem1;
        private CCWin.SkinControl.SkinButton skinButton1;
    }
}
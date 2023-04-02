namespace supermarket项目
{
    partial class Cashier_Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Cashier_Main));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.strGoods = new System.Windows.Forms.ToolStripButton();
            this.strShouYan = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.StrDingDang = new System.Windows.Forms.ToolStripButton();
            this.strGuanLiyu = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStrUid = new System.Windows.Forms.ToolStripLabel();
            this.strLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.staLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.staLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton5,
            this.strGoods,
            this.strShouYan,
            this.toolStripButton3,
            this.StrDingDang,
            this.strGuanLiyu,
            this.toolStripButton2,
            this.toolStripButton1,
            this.toolStrUid,
            this.strLabel1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1079, 79);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.toolStripButton5.Image = global::supermarket项目.Properties.Resources.Bee12;
            this.toolStripButton5.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(82, 76);
            this.toolStripButton5.Text = "商品类型";
            this.toolStripButton5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton5.Click += new System.EventHandler(this.toolStripButton5_Click);
            // 
            // strGoods
            // 
            this.strGoods.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.strGoods.Image = ((System.Drawing.Image)(resources.GetObject("strGoods.Image")));
            this.strGoods.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.strGoods.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.strGoods.Name = "strGoods";
            this.strGoods.Size = new System.Drawing.Size(82, 76);
            this.strGoods.Text = "商品信息";
            this.strGoods.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.strGoods.Click += new System.EventHandler(this.strGoods_Click);
            // 
            // strShouYan
            // 
            this.strShouYan.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.strShouYan.Image = ((System.Drawing.Image)(resources.GetObject("strShouYan.Image")));
            this.strShouYan.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.strShouYan.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.strShouYan.Name = "strShouYan";
            this.strShouYan.Size = new System.Drawing.Size(82, 76);
            this.strShouYan.Text = "收银结账";
            this.strShouYan.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.strShouYan.Click += new System.EventHandler(this.strShouYan_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(82, 76);
            this.toolStripButton3.Text = "商品销售";
            this.toolStripButton3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // StrDingDang
            // 
            this.StrDingDang.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.StrDingDang.Image = ((System.Drawing.Image)(resources.GetObject("StrDingDang.Image")));
            this.StrDingDang.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.StrDingDang.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.StrDingDang.Name = "StrDingDang";
            this.StrDingDang.Size = new System.Drawing.Size(82, 76);
            this.StrDingDang.Text = "订单查询";
            this.StrDingDang.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.StrDingDang.Click += new System.EventHandler(this.StrDingDang_Click);
            // 
            // strGuanLiyu
            // 
            this.strGuanLiyu.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.strGuanLiyu.Image = global::supermarket项目.Properties.Resources.Bee11;
            this.strGuanLiyu.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.strGuanLiyu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.strGuanLiyu.Name = "strGuanLiyu";
            this.strGuanLiyu.Size = new System.Drawing.Size(99, 76);
            this.strGuanLiyu.Text = "管理员系统";
            this.strGuanLiyu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.strGuanLiyu.Click += new System.EventHandler(this.strGuanLiyu_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.toolStripButton2.Image = global::supermarket项目.Properties.Resources.f2;
            this.toolStripButton2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(68, 76);
            this.toolStripButton2.Text = "  挂机  ";
            this.toolStripButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(68, 76);
            this.toolStripButton1.Text = "  退出  ";
            this.toolStripButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStrUid
            // 
            this.toolStrUid.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStrUid.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.toolStrUid.Name = "toolStrUid";
            this.toolStrUid.Size = new System.Drawing.Size(139, 76);
            this.toolStrUid.Text = "toolStripLabel1";
            // 
            // strLabel1
            // 
            this.strLabel1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.strLabel1.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.strLabel1.Name = "strLabel1";
            this.strLabel1.Size = new System.Drawing.Size(95, 76);
            this.strLabel1.Text = "当前用户：";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.staLabel1,
            this.staLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 529);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1079, 29);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // staLabel1
            // 
            this.staLabel1.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.staLabel1.Name = "staLabel1";
            this.staLabel1.Size = new System.Drawing.Size(95, 24);
            this.staLabel1.Text = "登录时间：";
            // 
            // staLabel2
            // 
            this.staLabel2.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.staLabel2.Name = "staLabel2";
            this.staLabel2.Size = new System.Drawing.Size(95, 24);
            this.staLabel2.Text = "当前时间：";
            // 
            // Cashier_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::supermarket项目.Properties.Resources.wallhaven_43e633_3840x1600;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(1079, 558);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("宋体", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MaximizeBox = false;
            this.Name = "Cashier_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "超市系统（收银）";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Cashier_Main_FormClosing);
            this.Load += new System.EventHandler(this.Cashier_Main_Load);
            this.LocationChanged += new System.EventHandler(this.Cashier_Main_LocationChanged);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton strShouYan;
        private System.Windows.Forms.ToolStripButton StrDingDang;
        private System.Windows.Forms.ToolStripLabel strLabel1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel staLabel1;
        private System.Windows.Forms.ToolStripStatusLabel staLabel2;
        private System.Windows.Forms.ToolStripButton strGuanLiyu;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton strGoods;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.ToolStripLabel toolStrUid;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
    }
}
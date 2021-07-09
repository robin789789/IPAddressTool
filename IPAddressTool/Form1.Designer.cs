
namespace IPAddressTool
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.projectNumeric = new System.Windows.Forms.NumericUpDown();
            this.nicQty = new System.Windows.Forms.Label();
            this.LabelProNum = new System.Windows.Forms.Label();
            this.cmbAdapter = new System.Windows.Forms.ComboBox();
            this.btnEnable = new System.Windows.Forms.Button();
            this.btnDisable = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnOpenSetting = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.projectNumeric)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(21, 26);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(344, 27);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(21, 58);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(345, 29);
            this.button2.TabIndex = 2;
            this.button2.Text = "DHCP";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.settingDHCP_Click);
            // 
            // projectNumeric
            // 
            this.projectNumeric.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.projectNumeric.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.projectNumeric.Location = new System.Drawing.Point(93, 25);
            this.projectNumeric.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.projectNumeric.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.projectNumeric.Name = "projectNumeric";
            this.projectNumeric.Size = new System.Drawing.Size(73, 47);
            this.projectNumeric.TabIndex = 4;
            this.projectNumeric.Value = new decimal(new int[] {
            87,
            0,
            0,
            0});
            this.projectNumeric.ValueChanged += new System.EventHandler(this.projectNumeric_ValueChanged);
            // 
            // nicQty
            // 
            this.nicQty.AutoSize = true;
            this.nicQty.Location = new System.Drawing.Point(186, 53);
            this.nicQty.Name = "nicQty";
            this.nicQty.Size = new System.Drawing.Size(147, 19);
            this.nicQty.TabIndex = 5;
            this.nicQty.Text = "已連線的網路卡數量:";
            // 
            // LabelProNum
            // 
            this.LabelProNum.AutoSize = true;
            this.LabelProNum.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.LabelProNum.Location = new System.Drawing.Point(16, 34);
            this.LabelProNum.Name = "LabelProNum";
            this.LabelProNum.Size = new System.Drawing.Size(67, 30);
            this.LabelProNum.TabIndex = 6;
            this.LabelProNum.Text = "案號:";
            // 
            // cmbAdapter
            // 
            this.cmbAdapter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAdapter.FormattingEnabled = true;
            this.cmbAdapter.Location = new System.Drawing.Point(23, 32);
            this.cmbAdapter.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbAdapter.Name = "cmbAdapter";
            this.cmbAdapter.Size = new System.Drawing.Size(343, 27);
            this.cmbAdapter.TabIndex = 7;
            // 
            // btnEnable
            // 
            this.btnEnable.Location = new System.Drawing.Point(23, 70);
            this.btnEnable.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnEnable.Name = "btnEnable";
            this.btnEnable.Size = new System.Drawing.Size(153, 29);
            this.btnEnable.TabIndex = 8;
            this.btnEnable.Text = "Enable";
            this.btnEnable.UseVisualStyleBackColor = true;
            this.btnEnable.Click += new System.EventHandler(this.btnEnable_Click);
            // 
            // btnDisable
            // 
            this.btnDisable.Location = new System.Drawing.Point(213, 70);
            this.btnDisable.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDisable.Name = "btnDisable";
            this.btnDisable.Size = new System.Drawing.Size(153, 29);
            this.btnDisable.TabIndex = 9;
            this.btnDisable.Text = "Disable";
            this.btnDisable.UseVisualStyleBackColor = true;
            this.btnDisable.Click += new System.EventHandler(this.btnDisable_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnRefresh);
            this.groupBox1.Controls.Add(this.btnOpenSetting);
            this.groupBox1.Controls.Add(this.LabelProNum);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.projectNumeric);
            this.groupBox1.Controls.Add(this.nicQty);
            this.groupBox1.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox1.Location = new System.Drawing.Point(16, 15);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(393, 189);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "案號與IP設置";
            // 
            // btnOpenSetting
            // 
            this.btnOpenSetting.Location = new System.Drawing.Point(20, 152);
            this.btnOpenSetting.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnOpenSetting.Name = "btnOpenSetting";
            this.btnOpenSetting.Size = new System.Drawing.Size(345, 29);
            this.btnOpenSetting.TabIndex = 7;
            this.btnOpenSetting.Text = "Network Adapters setting";
            this.btnOpenSetting.UseVisualStyleBackColor = true;
            this.btnOpenSetting.Click += new System.EventHandler(this.btnOpenSetting_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(21, 80);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(344, 65);
            this.button1.TabIndex = 1;
            this.button1.Text = "AutoSetting XLS600";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.settingIP_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cmbAdapter);
            this.groupBox2.Controls.Add(this.btnEnable);
            this.groupBox2.Controls.Add(this.btnDisable);
            this.groupBox2.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox2.Location = new System.Drawing.Point(16, 316);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(393, 108);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "網路卡啟用與停用";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.comboBox1);
            this.groupBox3.Controls.Add(this.button2);
            this.groupBox3.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox3.Location = new System.Drawing.Point(16, 211);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Size = new System.Drawing.Size(393, 98);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "DHCP";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(259, 20);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(106, 30);
            this.btnRefresh.TabIndex = 8;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 429);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IPAddressTool";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.projectNumeric)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.NumericUpDown projectNumeric;
        private System.Windows.Forms.Label nicQty;
        private System.Windows.Forms.Label LabelProNum;
        private System.Windows.Forms.ComboBox cmbAdapter;
        private System.Windows.Forms.Button btnEnable;
        private System.Windows.Forms.Button btnDisable;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnOpenSetting;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnRefresh;
    }
}


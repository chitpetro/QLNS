namespace QLNS
{
    partial class f_nghiphep
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
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.cbohoso = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cboloai = new DevExpress.XtraEditors.ComboBoxEdit();
            this.ddenngay = new DevExpress.XtraEditors.DateEdit();
            this.dtungay = new DevExpress.XtraEditors.DateEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbohoso.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboloai.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddenngay.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddenngay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtungay.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtungay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.cbohoso);
            this.layoutControl1.Controls.Add(this.cboloai);
            this.layoutControl1.Controls.Add(this.ddenngay);
            this.layoutControl1.Controls.Add(this.dtungay);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 28);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(288, 122);
            this.layoutControl1.TabIndex = 4;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // cbohoso
            // 
            this.cbohoso.Location = new System.Drawing.Point(79, 84);
            this.cbohoso.MenuManager = this.barManager1;
            this.cbohoso.Name = "cbohoso";
            this.cbohoso.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbohoso.Properties.Items.AddRange(new object[] {
            "Có đơn xin phép",
            "Không có đơn xin phép"});
            this.cbohoso.Size = new System.Drawing.Size(197, 20);
            this.cbohoso.StyleController = this.layoutControl1;
            this.cbohoso.TabIndex = 10;
            // 
            // cboloai
            // 
            this.cboloai.Location = new System.Drawing.Point(79, 12);
            this.cboloai.MenuManager = this.barManager1;
            this.cboloai.Name = "cboloai";
            this.cboloai.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboloai.Properties.Items.AddRange(new object[] {
            "Nghỉ phép",
            "Nghỉ không lương"});
            this.cboloai.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboloai.Size = new System.Drawing.Size(197, 20);
            this.cboloai.StyleController = this.layoutControl1;
            this.cboloai.TabIndex = 9;
            // 
            // ddenngay
            // 
            this.ddenngay.EditValue = null;
            this.ddenngay.Location = new System.Drawing.Point(79, 60);
            this.ddenngay.MenuManager = this.barManager1;
            this.ddenngay.Name = "ddenngay";
            this.ddenngay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ddenngay.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ddenngay.Size = new System.Drawing.Size(197, 20);
            this.ddenngay.StyleController = this.layoutControl1;
            this.ddenngay.TabIndex = 8;
            // 
            // dtungay
            // 
            this.dtungay.EditValue = null;
            this.dtungay.Location = new System.Drawing.Point(79, 36);
            this.dtungay.MenuManager = this.barManager1;
            this.dtungay.Name = "dtungay";
            this.dtungay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtungay.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtungay.Size = new System.Drawing.Size(197, 20);
            this.dtungay.StyleController = this.layoutControl1;
            this.dtungay.TabIndex = 6;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem3,
            this.layoutControlItem1,
            this.layoutControlItem4,
            this.layoutControlItem2});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(288, 122);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.dtungay;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(268, 24);
            this.layoutControlItem3.Text = "Từ Ngày";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(64, 13);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.ddenngay;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(268, 24);
            this.layoutControlItem1.Text = "Đến Ngày";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(64, 13);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.cbohoso;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 72);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(268, 30);
            this.layoutControlItem4.Text = "Đơn Xin Phép";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(64, 13);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.cboloai;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(268, 24);
            this.layoutControlItem2.Text = "Loại";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(64, 13);
            // 
            // f_nghiphep
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(288, 172);
            this.Controls.Add(this.layoutControl1);
            this.Name = "f_nghiphep";
            this.Text = "Nghỉ Phép";
            this.Controls.SetChildIndex(this.layoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cbohoso.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboloai.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddenngay.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddenngay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtungay.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtungay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraEditors.DateEdit dtungay;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.DateEdit ddenngay;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.ComboBoxEdit cbohoso;
        private DevExpress.XtraEditors.ComboBoxEdit cboloai;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
    }
}
namespace QLNS
{
    partial class f_dieuchuyenns
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
            this.dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.txtngaydc = new DevExpress.XtraEditors.DateEdit();
            this.txtnoidc = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.rnoicongtacBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblnoidc = new DevExpress.XtraEditors.LabelControl();
            this.lblnoict = new DevExpress.XtraEditors.LabelControl();
            this.txtnoict = new DevExpress.XtraEditors.TextEdit();
            this.lblinfo = new DevExpress.XtraEditors.LabelControl();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lbl = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtngaydc.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtngaydc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtnoidc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rnoicongtacBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtnoict.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataLayoutControl1
            // 
            this.dataLayoutControl1.Controls.Add(this.txtngaydc);
            this.dataLayoutControl1.Controls.Add(this.txtnoidc);
            this.dataLayoutControl1.Controls.Add(this.lblnoidc);
            this.dataLayoutControl1.Controls.Add(this.lblnoict);
            this.dataLayoutControl1.Controls.Add(this.txtnoict);
            this.dataLayoutControl1.Controls.Add(this.lblinfo);
            this.dataLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataLayoutControl1.Location = new System.Drawing.Point(0, 28);
            this.dataLayoutControl1.Name = "dataLayoutControl1";
            this.dataLayoutControl1.Root = this.Root;
            this.dataLayoutControl1.Size = new System.Drawing.Size(633, 118);
            this.dataLayoutControl1.TabIndex = 4;
            this.dataLayoutControl1.Text = "dataLayoutControl1";
            // 
            // txtngaydc
            // 
            this.txtngaydc.EditValue = null;
            this.txtngaydc.Location = new System.Drawing.Point(105, 86);
            this.txtngaydc.Name = "txtngaydc";
            this.txtngaydc.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtngaydc.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtngaydc.Size = new System.Drawing.Size(171, 20);
            this.txtngaydc.StyleController = this.dataLayoutControl1;
            this.txtngaydc.TabIndex = 9;
            // 
            // txtnoidc
            // 
            this.txtnoidc.Location = new System.Drawing.Point(105, 62);
            this.txtnoidc.Name = "txtnoidc";
            this.txtnoidc.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtnoidc.Properties.DataSource = this.rnoicongtacBindingSource;
            this.txtnoidc.Properties.DisplayMember = "id";
            this.txtnoidc.Properties.NullText = "";
            this.txtnoidc.Properties.PopupView = this.searchLookUpEdit1View;
            this.txtnoidc.Properties.ValueMember = "id";
            this.txtnoidc.Size = new System.Drawing.Size(171, 20);
            this.txtnoidc.StyleController = this.dataLayoutControl1;
            this.txtnoidc.TabIndex = 8;
            this.txtnoidc.Popup += new System.EventHandler(this.txtnoidc_Popup);
            this.txtnoidc.EditValueChanged += new System.EventHandler(this.txtnoidc_EditValueChanged);
            // 
            // rnoicongtacBindingSource
            // 
            this.rnoicongtacBindingSource.DataSource = typeof(DAL.r_noicongtac);
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4});
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowAutoFilterRow = true;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Mã";
            this.gridColumn1.FieldName = "id";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Nơi Công Tác";
            this.gridColumn2.FieldName = "noicongtac";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Khu Vực";
            this.gridColumn3.FieldName = "khuvuc";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Địa Chỉ";
            this.gridColumn4.FieldName = "diachi";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            // 
            // lblnoidc
            // 
            this.lblnoidc.Location = new System.Drawing.Point(280, 62);
            this.lblnoidc.Name = "lblnoidc";
            this.lblnoidc.Size = new System.Drawing.Size(341, 20);
            this.lblnoidc.StyleController = this.dataLayoutControl1;
            this.lblnoidc.TabIndex = 7;
            // 
            // lblnoict
            // 
            this.lblnoict.Location = new System.Drawing.Point(280, 38);
            this.lblnoict.Name = "lblnoict";
            this.lblnoict.Size = new System.Drawing.Size(341, 20);
            this.lblnoict.StyleController = this.dataLayoutControl1;
            this.lblnoict.TabIndex = 6;
            // 
            // txtnoict
            // 
            this.txtnoict.Location = new System.Drawing.Point(105, 38);
            this.txtnoict.Name = "txtnoict";
            this.txtnoict.Properties.ReadOnly = true;
            this.txtnoict.Size = new System.Drawing.Size(171, 20);
            this.txtnoict.StyleController = this.dataLayoutControl1;
            this.txtnoict.TabIndex = 5;
            // 
            // lblinfo
            // 
            this.lblinfo.Location = new System.Drawing.Point(12, 12);
            this.lblinfo.Name = "lblinfo";
            this.lblinfo.Size = new System.Drawing.Size(609, 22);
            this.lblinfo.StyleController = this.dataLayoutControl1;
            this.lblinfo.TabIndex = 4;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.lbl,
            this.layoutControlItem5,
            this.layoutControlItem6,
            this.emptySpaceItem1});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(633, 118);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.lblinfo;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.MinSize = new System.Drawing.Size(67, 17);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(613, 26);
            this.layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtnoict;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 26);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(268, 24);
            this.layoutControlItem2.Text = "Nơi Công Tác";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(90, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.lblnoict;
            this.layoutControlItem3.Location = new System.Drawing.Point(268, 26);
            this.layoutControlItem3.MinSize = new System.Drawing.Size(67, 17);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(345, 24);
            this.layoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // lbl
            // 
            this.lbl.Control = this.lblnoidc;
            this.lbl.Location = new System.Drawing.Point(268, 50);
            this.lbl.MinSize = new System.Drawing.Size(67, 17);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(345, 24);
            this.lbl.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lbl.TextSize = new System.Drawing.Size(0, 0);
            this.lbl.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.txtnoidc;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 50);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(268, 24);
            this.layoutControlItem5.Text = "Nơi Điều Chuyển";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(90, 13);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.txtngaydc;
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 74);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(268, 24);
            this.layoutControlItem6.Text = "Ngày Điều Chuyển";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(90, 13);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(268, 74);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(345, 24);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // f_dieuchuyenns
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 168);
            this.Controls.Add(this.dataLayoutControl1);
            this.Name = "f_dieuchuyenns";
            this.Text = "Điều Chuyển Nhân Sự";
            this.Load += new System.EventHandler(this.f_dieuchuyenns_Load);
            this.Controls.SetChildIndex(this.dataLayoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtngaydc.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtngaydc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtnoidc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rnoicongtacBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtnoict.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private DevExpress.XtraEditors.DateEdit txtngaydc;
        private DevExpress.XtraEditors.SearchLookUpEdit txtnoidc;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraEditors.LabelControl lblnoidc;
        private DevExpress.XtraEditors.LabelControl lblnoict;
        private DevExpress.XtraEditors.TextEdit txtnoict;
        private DevExpress.XtraEditors.LabelControl lblinfo;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem lbl;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private System.Windows.Forms.BindingSource rnoicongtacBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
    }
}
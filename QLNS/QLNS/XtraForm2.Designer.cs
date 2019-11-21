namespace QLNS
{
    partial class XtraForm2
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
            this.customSearchLookUpEdit1 = new Lotus.Base.Libraries.CustomSearchLookUpEdit();
            this.customSearchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.customSearchLookUpEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customSearchLookUpEdit1View)).BeginInit();
            this.SuspendLayout();
            // 
            // customSearchLookUpEdit1
            // 
            this.customSearchLookUpEdit1.Location = new System.Drawing.Point(40, 73);
            this.customSearchLookUpEdit1.Name = "customSearchLookUpEdit1";
            this.customSearchLookUpEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.customSearchLookUpEdit1.Properties.PopupView = this.customSearchLookUpEdit1View;
            this.customSearchLookUpEdit1.Size = new System.Drawing.Size(215, 20);
            this.customSearchLookUpEdit1.TabIndex = 0;
            // 
            // customSearchLookUpEdit1View
            // 
            this.customSearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.customSearchLookUpEdit1View.Name = "customSearchLookUpEdit1View";
            this.customSearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.customSearchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // XtraForm2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 268);
            this.Controls.Add(this.customSearchLookUpEdit1);
            this.Name = "XtraForm2";
            this.Text = "XtraForm2";
            ((System.ComponentModel.ISupportInitialize)(this.customSearchLookUpEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customSearchLookUpEdit1View)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Lotus.Base.Libraries.CustomSearchLookUpEdit customSearchLookUpEdit1;
        private DevExpress.XtraGrid.Views.Grid.GridView customSearchLookUpEdit1View;
    }
}
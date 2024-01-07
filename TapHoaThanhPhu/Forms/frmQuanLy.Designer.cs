namespace TapHoaThanhPhu.Forms
{
    partial class frmQuanLy
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
            this.fcShow = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer();
            this.accordionControl1 = new DevExpress.XtraBars.Navigation.AccordionControl();
            this.accordionControlElement1 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.mnDanhSachTaiKhoan = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.mnTaoTaiKhoan = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionControlElement2 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.mnDanhSachMatHang = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.mnThemMatHang = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionControlElement3 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.fluentDesignFormControl1 = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl();
            this.fluentFormDefaultManager1 = new DevExpress.XtraBars.FluentDesignSystem.FluentFormDefaultManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.accordionControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentDesignFormControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentFormDefaultManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // fcShow
            // 
            this.fcShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fcShow.Location = new System.Drawing.Point(260, 31);
            this.fcShow.Name = "fcShow";
            this.fcShow.Size = new System.Drawing.Size(970, 688);
            this.fcShow.TabIndex = 0;
            // 
            // accordionControl1
            // 
            this.accordionControl1.Appearance.AccordionControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.accordionControl1.Appearance.AccordionControl.Options.UseBackColor = true;
            this.accordionControl1.Appearance.Group.Default.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.accordionControl1.Appearance.Group.Default.Options.UseBackColor = true;
            this.accordionControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.accordionControl1.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.accordionControlElement1,
            this.accordionControlElement2,
            this.accordionControlElement3});
            this.accordionControl1.Location = new System.Drawing.Point(0, 31);
            this.accordionControl1.Name = "accordionControl1";
            this.accordionControl1.ScrollBarMode = DevExpress.XtraBars.Navigation.ScrollBarMode.Touch;
            this.accordionControl1.Size = new System.Drawing.Size(260, 688);
            this.accordionControl1.TabIndex = 1;
            this.accordionControl1.ViewType = DevExpress.XtraBars.Navigation.AccordionControlViewType.HamburgerMenu;
            // 
            // accordionControlElement1
            // 
            this.accordionControlElement1.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.mnDanhSachTaiKhoan,
            this.mnTaoTaiKhoan});
            this.accordionControlElement1.Expanded = true;
            this.accordionControlElement1.Name = "accordionControlElement1";
            this.accordionControlElement1.Text = "Tài Khoản";
            // 
            // mnDanhSachTaiKhoan
            // 
            this.mnDanhSachTaiKhoan.Name = "mnDanhSachTaiKhoan";
            this.mnDanhSachTaiKhoan.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.mnDanhSachTaiKhoan.Text = "Danh Sách Tài Khoản";
            this.mnDanhSachTaiKhoan.Click += new System.EventHandler(this.mnDanhSachTaiKhoan_Click);
            // 
            // mnTaoTaiKhoan
            // 
            this.mnTaoTaiKhoan.Name = "mnTaoTaiKhoan";
            this.mnTaoTaiKhoan.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.mnTaoTaiKhoan.Text = "Tạo Tài Khoản";
            this.mnTaoTaiKhoan.Click += new System.EventHandler(this.mnTaoTaiKhoan_Click);
            // 
            // accordionControlElement2
            // 
            this.accordionControlElement2.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.mnDanhSachMatHang,
            this.mnThemMatHang});
            this.accordionControlElement2.Expanded = true;
            this.accordionControlElement2.Name = "accordionControlElement2";
            this.accordionControlElement2.Text = "Mặt Hàng";
            // 
            // mnDanhSachMatHang
            // 
            this.mnDanhSachMatHang.Name = "mnDanhSachMatHang";
            this.mnDanhSachMatHang.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.mnDanhSachMatHang.Text = "Danh Sách Mặt Hàng";
            // 
            // mnThemMatHang
            // 
            this.mnThemMatHang.Name = "mnThemMatHang";
            this.mnThemMatHang.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.mnThemMatHang.Text = "Thêm Mặt Hàng";
            this.mnThemMatHang.Click += new System.EventHandler(this.mnThemMatHang_Click);
            // 
            // accordionControlElement3
            // 
            this.accordionControlElement3.Expanded = true;
            this.accordionControlElement3.Name = "accordionControlElement3";
            this.accordionControlElement3.Text = "Thu Chi";
            // 
            // fluentDesignFormControl1
            // 
            this.fluentDesignFormControl1.FluentDesignForm = this;
            this.fluentDesignFormControl1.Location = new System.Drawing.Point(0, 0);
            this.fluentDesignFormControl1.Manager = this.fluentFormDefaultManager1;
            this.fluentDesignFormControl1.Name = "fluentDesignFormControl1";
            this.fluentDesignFormControl1.Size = new System.Drawing.Size(1230, 31);
            this.fluentDesignFormControl1.TabIndex = 2;
            this.fluentDesignFormControl1.TabStop = false;
            // 
            // fluentFormDefaultManager1
            // 
            this.fluentFormDefaultManager1.Form = this;
            // 
            // frmQuanLy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1230, 719);
            this.ControlContainer = this.fcShow;
            this.Controls.Add(this.fcShow);
            this.Controls.Add(this.accordionControl1);
            this.Controls.Add(this.fluentDesignFormControl1);
            this.FluentDesignFormControl = this.fluentDesignFormControl1;
            this.Name = "frmQuanLy";
            this.NavigationControl = this.accordionControl1;
            this.Text = "frmQuanLy";
            ((System.ComponentModel.ISupportInitialize)(this.accordionControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentDesignFormControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentFormDefaultManager1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer fcShow;
        private DevExpress.XtraBars.Navigation.AccordionControl accordionControl1;
        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl fluentDesignFormControl1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement1;
        private DevExpress.XtraBars.FluentDesignSystem.FluentFormDefaultManager fluentFormDefaultManager1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement2;
        private DevExpress.XtraBars.Navigation.AccordionControlElement mnDanhSachTaiKhoan;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement3;
        private DevExpress.XtraBars.Navigation.AccordionControlElement mnTaoTaiKhoan;
        private DevExpress.XtraBars.Navigation.AccordionControlElement mnDanhSachMatHang;
        private DevExpress.XtraBars.Navigation.AccordionControlElement mnThemMatHang;
    }
}
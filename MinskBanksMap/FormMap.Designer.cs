namespace MinskBanksMap
{
    partial class FormMap
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
            this.gMap = new GMap.NET.WindowsForms.GMapControl();
            this.contextMenuStripViewMode = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemIAmHere = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemShowNearest = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemReset = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItemBanksSelection = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemShowRates = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemMin = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemSellMin = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemUsdSellMin = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemEurSellMin = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemRurSellMin = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemBuyMin = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemUsdBuyMin = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemEurBuyMin = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemRurBuyMin = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemMax = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemSellMax = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemUsdSellMax = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemEurSellMax = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemRurSellMax = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemBuyMax = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemUsdBuyMax = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemEurBuyMax = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemRurBuyMax = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemCancelRates = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemMode = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemViewMode = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemEditMode = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStripEditMode = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemAddDepartment = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStripViewMode.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.contextMenuStripEditMode.SuspendLayout();
            this.SuspendLayout();
            // 
            // gMap
            // 
            this.gMap.Bearing = 0F;
            this.gMap.CanDragMap = true;
            this.gMap.ContextMenuStrip = this.contextMenuStripViewMode;
            this.gMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gMap.EmptyTileColor = System.Drawing.Color.Navy;
            this.gMap.GrayScaleMode = false;
            this.gMap.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gMap.LevelsKeepInMemmory = 5;
            this.gMap.Location = new System.Drawing.Point(0, 24);
            this.gMap.MarkersEnabled = true;
            this.gMap.MaxZoom = 18;
            this.gMap.MinZoom = 2;
            this.gMap.MouseWheelZoomEnabled = true;
            this.gMap.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionWithoutCenter;
            this.gMap.Name = "gMap";
            this.gMap.NegativeMode = false;
            this.gMap.PolygonsEnabled = true;
            this.gMap.RetryLoadTile = 0;
            this.gMap.RoutesEnabled = true;
            this.gMap.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gMap.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gMap.ShowTileGridLines = false;
            this.gMap.Size = new System.Drawing.Size(284, 237);
            this.gMap.TabIndex = 0;
            this.gMap.Zoom = 12D;
            this.gMap.OnMarkerClick += new GMap.NET.WindowsForms.MarkerClick(this.GMapControl_OnMarkerClick);
            // 
            // contextMenuStripViewMode
            // 
            this.contextMenuStripViewMode.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemIAmHere,
            this.toolStripMenuItemShowNearest,
            this.toolStripMenuItemReset});
            this.contextMenuStripViewMode.Name = "contextMenuStrip1";
            this.contextMenuStripViewMode.Size = new System.Drawing.Size(184, 70);
            // 
            // toolStripMenuItemIAmHere
            // 
            this.toolStripMenuItemIAmHere.Name = "toolStripMenuItemIAmHere";
            this.toolStripMenuItemIAmHere.Size = new System.Drawing.Size(183, 22);
            this.toolStripMenuItemIAmHere.Text = "Я здесь";
            this.toolStripMenuItemIAmHere.Click += new System.EventHandler(this.ToolStripMenuItemIAmHere_Click);
            // 
            // toolStripMenuItemShowNearest
            // 
            this.toolStripMenuItemShowNearest.Enabled = false;
            this.toolStripMenuItemShowNearest.Name = "toolStripMenuItemShowNearest";
            this.toolStripMenuItemShowNearest.Size = new System.Drawing.Size(183, 22);
            this.toolStripMenuItemShowNearest.Text = "Показать ближайший";
            this.toolStripMenuItemShowNearest.Click += new System.EventHandler(this.ToolStripMenuItemShowNearest_Click);
            // 
            // toolStripMenuItemReset
            // 
            this.toolStripMenuItemReset.Enabled = false;
            this.toolStripMenuItemReset.Name = "toolStripMenuItemReset";
            this.toolStripMenuItemReset.Size = new System.Drawing.Size(183, 22);
            this.toolStripMenuItemReset.Text = "Сброс";
            this.toolStripMenuItemReset.Click += new System.EventHandler(this.ToolStripMenuItemReset_Click);
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemBanksSelection,
            this.toolStripMenuItemShowRates,
            this.toolStripMenuItemMode});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(284, 24);
            this.menuStrip.TabIndex = 1;
            // 
            // toolStripMenuItemBanksSelection
            // 
            this.toolStripMenuItemBanksSelection.Name = "toolStripMenuItemBanksSelection";
            this.toolStripMenuItemBanksSelection.Size = new System.Drawing.Size(90, 20);
            this.toolStripMenuItemBanksSelection.Text = "Выбор банков";
            this.toolStripMenuItemBanksSelection.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.ToolStripMenuItemBanksSelection_DropDownItemClicked);
            // 
            // toolStripMenuItemShowRates
            // 
            this.toolStripMenuItemShowRates.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemMin,
            this.toolStripMenuItemMax,
            this.toolStripMenuItemCancelRates});
            this.toolStripMenuItemShowRates.Name = "toolStripMenuItemShowRates";
            this.toolStripMenuItemShowRates.Size = new System.Drawing.Size(101, 20);
            this.toolStripMenuItemShowRates.Text = "Показать курсы";
            // 
            // toolStripMenuItemMin
            // 
            this.toolStripMenuItemMin.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemSellMin,
            this.toolStripMenuItemBuyMin});
            this.toolStripMenuItemMin.Name = "toolStripMenuItemMin";
            this.toolStripMenuItemMin.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItemMin.Tag = "Min";
            this.toolStripMenuItemMin.Text = "Минимальный";
            // 
            // toolStripMenuItemSellMin
            // 
            this.toolStripMenuItemSellMin.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemUsdSellMin,
            this.toolStripMenuItemEurSellMin,
            this.toolStripMenuItemRurSellMin});
            this.toolStripMenuItemSellMin.Name = "toolStripMenuItemSellMin";
            this.toolStripMenuItemSellMin.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItemSellMin.Tag = "Sell";
            this.toolStripMenuItemSellMin.Text = "Продажи";
            // 
            // toolStripMenuItemUsdSellMin
            // 
            this.toolStripMenuItemUsdSellMin.Name = "toolStripMenuItemUsdSellMin";
            this.toolStripMenuItemUsdSellMin.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItemUsdSellMin.Tag = "USD";
            this.toolStripMenuItemUsdSellMin.Text = "USD";
            this.toolStripMenuItemUsdSellMin.Click += new System.EventHandler(this.ToolStripMenuItemCurrency_Click);
            // 
            // toolStripMenuItemEurSellMin
            // 
            this.toolStripMenuItemEurSellMin.Name = "toolStripMenuItemEurSellMin";
            this.toolStripMenuItemEurSellMin.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItemEurSellMin.Tag = "EUR";
            this.toolStripMenuItemEurSellMin.Text = "EUR";
            this.toolStripMenuItemEurSellMin.Click += new System.EventHandler(this.ToolStripMenuItemCurrency_Click);
            // 
            // toolStripMenuItemRurSellMin
            // 
            this.toolStripMenuItemRurSellMin.Name = "toolStripMenuItemRurSellMin";
            this.toolStripMenuItemRurSellMin.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItemRurSellMin.Tag = "RUR";
            this.toolStripMenuItemRurSellMin.Text = "RUR";
            this.toolStripMenuItemRurSellMin.Click += new System.EventHandler(this.ToolStripMenuItemCurrency_Click);
            // 
            // toolStripMenuItemBuyMin
            // 
            this.toolStripMenuItemBuyMin.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemUsdBuyMin,
            this.toolStripMenuItemEurBuyMin,
            this.toolStripMenuItemRurBuyMin});
            this.toolStripMenuItemBuyMin.Name = "toolStripMenuItemBuyMin";
            this.toolStripMenuItemBuyMin.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItemBuyMin.Tag = "Buy";
            this.toolStripMenuItemBuyMin.Text = "Покупки";
            // 
            // toolStripMenuItemUsdBuyMin
            // 
            this.toolStripMenuItemUsdBuyMin.Name = "toolStripMenuItemUsdBuyMin";
            this.toolStripMenuItemUsdBuyMin.Size = new System.Drawing.Size(95, 22);
            this.toolStripMenuItemUsdBuyMin.Tag = "USD";
            this.toolStripMenuItemUsdBuyMin.Text = "USD";
            this.toolStripMenuItemUsdBuyMin.Click += new System.EventHandler(this.ToolStripMenuItemCurrency_Click);
            // 
            // toolStripMenuItemEurBuyMin
            // 
            this.toolStripMenuItemEurBuyMin.Name = "toolStripMenuItemEurBuyMin";
            this.toolStripMenuItemEurBuyMin.Size = new System.Drawing.Size(95, 22);
            this.toolStripMenuItemEurBuyMin.Tag = "EUR";
            this.toolStripMenuItemEurBuyMin.Text = "EUR";
            this.toolStripMenuItemEurBuyMin.Click += new System.EventHandler(this.ToolStripMenuItemCurrency_Click);
            // 
            // toolStripMenuItemRurBuyMin
            // 
            this.toolStripMenuItemRurBuyMin.Name = "toolStripMenuItemRurBuyMin";
            this.toolStripMenuItemRurBuyMin.Size = new System.Drawing.Size(95, 22);
            this.toolStripMenuItemRurBuyMin.Tag = "RUR";
            this.toolStripMenuItemRurBuyMin.Text = "RUR";
            this.toolStripMenuItemRurBuyMin.Click += new System.EventHandler(this.ToolStripMenuItemCurrency_Click);
            // 
            // toolStripMenuItemMax
            // 
            this.toolStripMenuItemMax.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemSellMax,
            this.toolStripMenuItemBuyMax});
            this.toolStripMenuItemMax.Name = "toolStripMenuItemMax";
            this.toolStripMenuItemMax.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItemMax.Tag = "Max";
            this.toolStripMenuItemMax.Text = "Максимальный";
            // 
            // toolStripMenuItemSellMax
            // 
            this.toolStripMenuItemSellMax.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemUsdSellMax,
            this.toolStripMenuItemEurSellMax,
            this.toolStripMenuItemRurSellMax});
            this.toolStripMenuItemSellMax.Name = "toolStripMenuItemSellMax";
            this.toolStripMenuItemSellMax.Size = new System.Drawing.Size(120, 22);
            this.toolStripMenuItemSellMax.Tag = "Sell";
            this.toolStripMenuItemSellMax.Text = "Продажи";
            // 
            // toolStripMenuItemUsdSellMax
            // 
            this.toolStripMenuItemUsdSellMax.Name = "toolStripMenuItemUsdSellMax";
            this.toolStripMenuItemUsdSellMax.Size = new System.Drawing.Size(95, 22);
            this.toolStripMenuItemUsdSellMax.Tag = "USD";
            this.toolStripMenuItemUsdSellMax.Text = "USD";
            this.toolStripMenuItemUsdSellMax.Click += new System.EventHandler(this.ToolStripMenuItemCurrency_Click);
            // 
            // toolStripMenuItemEurSellMax
            // 
            this.toolStripMenuItemEurSellMax.Name = "toolStripMenuItemEurSellMax";
            this.toolStripMenuItemEurSellMax.Size = new System.Drawing.Size(95, 22);
            this.toolStripMenuItemEurSellMax.Tag = "EUR";
            this.toolStripMenuItemEurSellMax.Text = "EUR";
            this.toolStripMenuItemEurSellMax.Click += new System.EventHandler(this.ToolStripMenuItemCurrency_Click);
            // 
            // toolStripMenuItemRurSellMax
            // 
            this.toolStripMenuItemRurSellMax.Name = "toolStripMenuItemRurSellMax";
            this.toolStripMenuItemRurSellMax.Size = new System.Drawing.Size(95, 22);
            this.toolStripMenuItemRurSellMax.Tag = "RUR";
            this.toolStripMenuItemRurSellMax.Text = "RUR";
            this.toolStripMenuItemRurSellMax.Click += new System.EventHandler(this.ToolStripMenuItemCurrency_Click);
            // 
            // toolStripMenuItemBuyMax
            // 
            this.toolStripMenuItemBuyMax.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemUsdBuyMax,
            this.toolStripMenuItemEurBuyMax,
            this.toolStripMenuItemRurBuyMax});
            this.toolStripMenuItemBuyMax.Name = "toolStripMenuItemBuyMax";
            this.toolStripMenuItemBuyMax.Size = new System.Drawing.Size(120, 22);
            this.toolStripMenuItemBuyMax.Tag = "Buy";
            this.toolStripMenuItemBuyMax.Text = "Покупки";
            // 
            // toolStripMenuItemUsdBuyMax
            // 
            this.toolStripMenuItemUsdBuyMax.Name = "toolStripMenuItemUsdBuyMax";
            this.toolStripMenuItemUsdBuyMax.Size = new System.Drawing.Size(95, 22);
            this.toolStripMenuItemUsdBuyMax.Tag = "USD";
            this.toolStripMenuItemUsdBuyMax.Text = "USD";
            this.toolStripMenuItemUsdBuyMax.Click += new System.EventHandler(this.ToolStripMenuItemCurrency_Click);
            // 
            // toolStripMenuItemEurBuyMax
            // 
            this.toolStripMenuItemEurBuyMax.Name = "toolStripMenuItemEurBuyMax";
            this.toolStripMenuItemEurBuyMax.Size = new System.Drawing.Size(95, 22);
            this.toolStripMenuItemEurBuyMax.Tag = "EUR";
            this.toolStripMenuItemEurBuyMax.Text = "EUR";
            this.toolStripMenuItemEurBuyMax.Click += new System.EventHandler(this.ToolStripMenuItemCurrency_Click);
            // 
            // toolStripMenuItemRurBuyMax
            // 
            this.toolStripMenuItemRurBuyMax.Name = "toolStripMenuItemRurBuyMax";
            this.toolStripMenuItemRurBuyMax.Size = new System.Drawing.Size(95, 22);
            this.toolStripMenuItemRurBuyMax.Tag = "RUR";
            this.toolStripMenuItemRurBuyMax.Text = "RUR";
            this.toolStripMenuItemRurBuyMax.Click += new System.EventHandler(this.ToolStripMenuItemCurrency_Click);
            // 
            // toolStripMenuItemCancelRates
            // 
            this.toolStripMenuItemCancelRates.Name = "toolStripMenuItemCancelRates";
            this.toolStripMenuItemCancelRates.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItemCancelRates.Text = "Отмена";
            this.toolStripMenuItemCancelRates.Click += new System.EventHandler(this.ToolStripMenuItemCancelRates_Click);
            // 
            // toolStripMenuItemMode
            // 
            this.toolStripMenuItemMode.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemViewMode,
            this.toolStripMenuItemEditMode});
            this.toolStripMenuItemMode.Name = "toolStripMenuItemMode";
            this.toolStripMenuItemMode.Size = new System.Drawing.Size(51, 20);
            this.toolStripMenuItemMode.Text = "Режим";
            // 
            // toolStripMenuItemViewMode
            // 
            this.toolStripMenuItemViewMode.Checked = true;
            this.toolStripMenuItemViewMode.CheckOnClick = true;
            this.toolStripMenuItemViewMode.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripMenuItemViewMode.Name = "toolStripMenuItemViewMode";
            this.toolStripMenuItemViewMode.Size = new System.Drawing.Size(159, 22);
            this.toolStripMenuItemViewMode.Text = "Просмотра";
            this.toolStripMenuItemViewMode.Click += new System.EventHandler(this.ToolStripMenuItemViewMode_Click);
            // 
            // toolStripMenuItemEditMode
            // 
            this.toolStripMenuItemEditMode.CheckOnClick = true;
            this.toolStripMenuItemEditMode.Name = "toolStripMenuItemEditMode";
            this.toolStripMenuItemEditMode.Size = new System.Drawing.Size(159, 22);
            this.toolStripMenuItemEditMode.Text = "Редактирования";
            this.toolStripMenuItemEditMode.Click += new System.EventHandler(this.ToolStripMenuItemEditMode_Click);
            // 
            // contextMenuStripEditMode
            // 
            this.contextMenuStripEditMode.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemAddDepartment});
            this.contextMenuStripEditMode.Name = "contextMenuStrip2";
            this.contextMenuStripEditMode.Size = new System.Drawing.Size(215, 26);
            // 
            // toolStripMenuItemAddDepartment
            // 
            this.toolStripMenuItemAddDepartment.Name = "toolStripMenuItemAddDepartment";
            this.toolStripMenuItemAddDepartment.Size = new System.Drawing.Size(214, 22);
            this.toolStripMenuItemAddDepartment.Text = "Добавить отделение здесь";
            this.toolStripMenuItemAddDepartment.Click += new System.EventHandler(this.ToolStripMenuItemAddDepartment_Click);
            // 
            // FormMap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.gMap);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.Name = "FormMap";
            this.Text = "Банки Минска";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormMap_Load);
            this.contextMenuStripViewMode.ResumeLayout(false);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.contextMenuStripEditMode.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemShowRates;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemMin;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemSellMin;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemUsdSellMin;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemEurSellMin;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemRurSellMin;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemBuyMin;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemUsdBuyMin;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemEurBuyMin;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemRurBuyMin;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemMax;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemSellMax;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemUsdSellMax;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemEurSellMax;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemRurSellMax;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemBuyMax;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemUsdBuyMax;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemEurBuyMax;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemRurBuyMax;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemCancelRates;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripViewMode;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemIAmHere;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemShowNearest;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemReset;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemMode;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemViewMode;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemEditMode;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripEditMode;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemAddDepartment;
        public System.Windows.Forms.ToolStripMenuItem toolStripMenuItemBanksSelection;
        public GMap.NET.WindowsForms.GMapControl gMap;
    }
}


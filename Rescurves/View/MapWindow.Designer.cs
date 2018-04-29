namespace Rescurves.View
{
    partial class MapWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MapWindow));
            this.MapContainer = new System.Windows.Forms.SplitContainer();
            this.mapViewer = new System.Windows.Forms.Integration.ElementHost();
            this.mapViewerControl = new Rescurves.View.MapPlotControl();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newCurveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exportMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.curvesManagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editComponentLabelsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.coordinatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.temperatureArrowsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataPointsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pointLabelsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.borderRuleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.preferencesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutRescurves3DToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutRescurves3DToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.recenterBtn = new System.Windows.Forms.Button();
            this.dataBtn = new System.Windows.Forms.Button();
            this.updateBtn = new System.Windows.Forms.Button();
            this.newCurveBtn = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.MapContainer)).BeginInit();
            this.MapContainer.Panel1.SuspendLayout();
            this.MapContainer.Panel2.SuspendLayout();
            this.MapContainer.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // MapContainer
            // 
            this.MapContainer.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.MapContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MapContainer.Location = new System.Drawing.Point(0, 0);
            this.MapContainer.Name = "MapContainer";
            this.MapContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // MapContainer.Panel1
            // 
            this.MapContainer.Panel1.Controls.Add(this.mapViewer);
            this.MapContainer.Panel1.Controls.Add(this.menuStrip1);
            this.MapContainer.Panel1.Tag = "";
            // 
            // MapContainer.Panel2
            // 
            this.MapContainer.Panel2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.MapContainer.Panel2.Controls.Add(this.recenterBtn);
            this.MapContainer.Panel2.Controls.Add(this.dataBtn);
            this.MapContainer.Panel2.Controls.Add(this.updateBtn);
            this.MapContainer.Panel2.Controls.Add(this.newCurveBtn);
            this.MapContainer.Size = new System.Drawing.Size(502, 479);
            this.MapContainer.SplitterDistance = 448;
            this.MapContainer.SplitterWidth = 2;
            this.MapContainer.TabIndex = 0;
            // 
            // mapViewer
            // 
            this.mapViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mapViewer.Location = new System.Drawing.Point(0, 24);
            this.mapViewer.Name = "mapViewer";
            this.mapViewer.Size = new System.Drawing.Size(502, 424);
            this.mapViewer.TabIndex = 0;
            this.mapViewer.Text = "MapViewer";
            this.mapViewer.Child = this.mapViewerControl;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mapToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.toolsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(502, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mapToolStripMenuItem
            // 
            this.mapToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newCurveToolStripMenuItem,
            this.editDataToolStripMenuItem,
            this.updateToolStripMenuItem,
            this.toolStripSeparator1,
            this.exportMapToolStripMenuItem});
            this.mapToolStripMenuItem.Name = "mapToolStripMenuItem";
            this.mapToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.mapToolStripMenuItem.Text = "Map";
            // 
            // newCurveToolStripMenuItem
            // 
            this.newCurveToolStripMenuItem.Name = "newCurveToolStripMenuItem";
            this.newCurveToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.newCurveToolStripMenuItem.Text = "New Curve";
            // 
            // editDataToolStripMenuItem
            // 
            this.editDataToolStripMenuItem.Name = "editDataToolStripMenuItem";
            this.editDataToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.editDataToolStripMenuItem.Text = "Edit data";
            // 
            // updateToolStripMenuItem
            // 
            this.updateToolStripMenuItem.Name = "updateToolStripMenuItem";
            this.updateToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.updateToolStripMenuItem.Text = "Update";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(131, 6);
            // 
            // exportMapToolStripMenuItem
            // 
            this.exportMapToolStripMenuItem.Name = "exportMapToolStripMenuItem";
            this.exportMapToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.exportMapToolStripMenuItem.Text = "Export map";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.curvesManagerToolStripMenuItem,
            this.editComponentLabelsToolStripMenuItem,
            this.toolStripSeparator2,
            this.coordinatesToolStripMenuItem,
            this.temperatureArrowsToolStripMenuItem,
            this.dataPointsToolStripMenuItem,
            this.pointLabelsToolStripMenuItem,
            this.borderRuleToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // curvesManagerToolStripMenuItem
            // 
            this.curvesManagerToolStripMenuItem.Name = "curvesManagerToolStripMenuItem";
            this.curvesManagerToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.curvesManagerToolStripMenuItem.Text = "Curves manager";
            // 
            // editComponentLabelsToolStripMenuItem
            // 
            this.editComponentLabelsToolStripMenuItem.Name = "editComponentLabelsToolStripMenuItem";
            this.editComponentLabelsToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.editComponentLabelsToolStripMenuItem.Text = "Edit component labels";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(189, 6);
            // 
            // coordinatesToolStripMenuItem
            // 
            this.coordinatesToolStripMenuItem.Name = "coordinatesToolStripMenuItem";
            this.coordinatesToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.coordinatesToolStripMenuItem.Text = "Coordinate system";
            this.coordinatesToolStripMenuItem.Click += new System.EventHandler(this.coordinatesToolStripMenuItem_Click);
            // 
            // temperatureArrowsToolStripMenuItem
            // 
            this.temperatureArrowsToolStripMenuItem.Name = "temperatureArrowsToolStripMenuItem";
            this.temperatureArrowsToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.temperatureArrowsToolStripMenuItem.Text = "Temperature arrows";
            this.temperatureArrowsToolStripMenuItem.Click += new System.EventHandler(this.TemperatureArrowsToolStripMenuItem_Click);
            // 
            // dataPointsToolStripMenuItem
            // 
            this.dataPointsToolStripMenuItem.Name = "dataPointsToolStripMenuItem";
            this.dataPointsToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.dataPointsToolStripMenuItem.Text = "Data points";
            this.dataPointsToolStripMenuItem.Click += new System.EventHandler(this.DataPointsToolStripMenuItem_Click);
            // 
            // pointLabelsToolStripMenuItem
            // 
            this.pointLabelsToolStripMenuItem.Name = "pointLabelsToolStripMenuItem";
            this.pointLabelsToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.pointLabelsToolStripMenuItem.Text = "Point labels";
            this.pointLabelsToolStripMenuItem.Click += new System.EventHandler(this.PointLabelsToolStripMenuItem_Click);
            // 
            // borderRuleToolStripMenuItem
            // 
            this.borderRuleToolStripMenuItem.Name = "borderRuleToolStripMenuItem";
            this.borderRuleToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.borderRuleToolStripMenuItem.Text = "Border rule";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.preferencesToolStripMenuItem,
            this.toolStripSeparator3,
            this.aboutRescurves3DToolStripMenuItem,
            this.aboutRescurves3DToolStripMenuItem1});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // preferencesToolStripMenuItem
            // 
            this.preferencesToolStripMenuItem.Name = "preferencesToolStripMenuItem";
            this.preferencesToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.preferencesToolStripMenuItem.Text = "Preferences";
            this.preferencesToolStripMenuItem.Click += new System.EventHandler(this.PreferencesToolStripMenuItem);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(176, 6);
            // 
            // aboutRescurves3DToolStripMenuItem
            // 
            this.aboutRescurves3DToolStripMenuItem.Name = "aboutRescurves3DToolStripMenuItem";
            this.aboutRescurves3DToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.aboutRescurves3DToolStripMenuItem.Text = "Help";
            // 
            // aboutRescurves3DToolStripMenuItem1
            // 
            this.aboutRescurves3DToolStripMenuItem1.Name = "aboutRescurves3DToolStripMenuItem1";
            this.aboutRescurves3DToolStripMenuItem1.Size = new System.Drawing.Size(179, 22);
            this.aboutRescurves3DToolStripMenuItem1.Text = "About Rescurves 3D";
            this.aboutRescurves3DToolStripMenuItem1.Click += new System.EventHandler(this.aboutRescurves3DToolStripMenuItem1_Click);
            // 
            // recenterBtn
            // 
            this.recenterBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.recenterBtn.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.recenterBtn.Location = new System.Drawing.Point(423, 3);
            this.recenterBtn.Name = "recenterBtn";
            this.recenterBtn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.recenterBtn.Size = new System.Drawing.Size(76, 23);
            this.recenterBtn.TabIndex = 1;
            this.recenterBtn.Text = "Recenter";
            this.recenterBtn.UseVisualStyleBackColor = false;
            this.recenterBtn.Click += new System.EventHandler(this.recenterBtn_Click);
            // 
            // dataBtn
            // 
            this.dataBtn.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataBtn.Location = new System.Drawing.Point(190, 4);
            this.dataBtn.Name = "dataBtn";
            this.dataBtn.Size = new System.Drawing.Size(75, 23);
            this.dataBtn.TabIndex = 1;
            this.dataBtn.Text = "Edit curves";
            this.dataBtn.UseVisualStyleBackColor = false;
            this.dataBtn.Click += new System.EventHandler(this.editCurvesBtn_Click);
            // 
            // updateBtn
            // 
            this.updateBtn.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.updateBtn.Location = new System.Drawing.Point(83, 4);
            this.updateBtn.Name = "updateBtn";
            this.updateBtn.Size = new System.Drawing.Size(101, 23);
            this.updateBtn.TabIndex = 1;
            this.updateBtn.Text = "Update all curves";
            this.updateBtn.UseVisualStyleBackColor = false;
            this.updateBtn.Click += new System.EventHandler(this.updateBtn_Click);
            // 
            // newCurveBtn
            // 
            this.newCurveBtn.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.newCurveBtn.Location = new System.Drawing.Point(3, 4);
            this.newCurveBtn.Name = "newCurveBtn";
            this.newCurveBtn.Size = new System.Drawing.Size(75, 23);
            this.newCurveBtn.TabIndex = 0;
            this.newCurveBtn.Text = "New curve";
            this.newCurveBtn.UseVisualStyleBackColor = false;
            this.newCurveBtn.Click += new System.EventHandler(this.newCurveBtn_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // MapWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 479);
            this.Controls.Add(this.MapContainer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MapWindow";
            this.Text = "MapWindow";
            this.MapContainer.Panel1.ResumeLayout(false);
            this.MapContainer.Panel1.PerformLayout();
            this.MapContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MapContainer)).EndInit();
            this.MapContainer.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer MapContainer;
        private System.Windows.Forms.Integration.ElementHost mapViewer;
        private MapPlotControl mapViewerControl;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Button dataBtn;
        private System.Windows.Forms.Button newCurveBtn;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ToolStripMenuItem newCurveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportMapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem coordinatesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutRescurves3DToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutRescurves3DToolStripMenuItem1;
        private System.Windows.Forms.Button updateBtn;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.ToolStripMenuItem curvesManagerToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem dataPointsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem borderRuleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editComponentLabelsToolStripMenuItem;
        private System.Windows.Forms.Button recenterBtn;
        private System.Windows.Forms.ToolStripMenuItem pointLabelsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem preferencesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem temperatureArrowsToolStripMenuItem;
    }
}
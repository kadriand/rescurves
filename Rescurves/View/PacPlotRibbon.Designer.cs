using System;

namespace Rescurves.View
{
    partial class PacPlotRibbon : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public PacPlotRibbon(): base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.tab1 = this.Factory.CreateRibbonTab();
            this.resCurvesGroup = this.Factory.CreateRibbonGroup();
            this.launcherButton = this.Factory.CreateRibbonButton();
            this.separator1 = this.Factory.CreateRibbonSeparator();
            this.mapsDropDown = this.Factory.CreateRibbonDropDown();
            this.moreMenu = this.Factory.CreateRibbonMenu();
            this.importButton = this.Factory.CreateRibbonButton();
            this.separator2 = this.Factory.CreateRibbonSeparator();
            this.settingsButton = this.Factory.CreateRibbonButton();
            this.aboutButton = this.Factory.CreateRibbonButton();
            this.tab1.SuspendLayout();
            this.resCurvesGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab1
            // 
            this.tab1.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tab1.Groups.Add(this.resCurvesGroup);
            this.tab1.Label = "TabAddIns";
            this.tab1.Name = "tab1";
            // 
            // resCurvesGroup
            // 
            this.resCurvesGroup.Items.Add(this.launcherButton);
            this.resCurvesGroup.Items.Add(this.separator1);
            this.resCurvesGroup.Items.Add(this.mapsDropDown);
            this.resCurvesGroup.Items.Add(this.moreMenu);
            this.resCurvesGroup.Label = "ResCurves 3D";
            this.resCurvesGroup.Name = "resCurvesGroup";
            // 
            // launcherButton
            // 
            this.launcherButton.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.launcherButton.Image = global::Rescurves.Properties.Resources.squares;
            this.launcherButton.Label = "Draw map";
            this.launcherButton.Name = "launcherButton";
            this.launcherButton.ShowImage = true;
            this.launcherButton.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.launcherButton_Click);
            // 
            // separator1
            // 
            this.separator1.Name = "separator1";
            // 
            // mapsDropDown
            // 
            this.mapsDropDown.Label = "Maps";
            this.mapsDropDown.Name = "mapsDropDown";
            this.mapsDropDown.SelectionChanged += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.mapsDropDown_SelectionChanged);
            // 
            // moreMenu
            // 
            this.moreMenu.Dynamic = true;
            this.moreMenu.Items.Add(this.importButton);
            this.moreMenu.Items.Add(this.separator2);
            this.moreMenu.Items.Add(this.settingsButton);
            this.moreMenu.Items.Add(this.aboutButton);
            this.moreMenu.Label = "More...";
            this.moreMenu.Name = "moreMenu";
            // 
            // importButton
            // 
            this.importButton.Label = "Import";
            this.importButton.Name = "importButton";
            this.importButton.ShowImage = true;
            // 
            // separator2
            // 
            this.separator2.Name = "separator2";
            // 
            // settingsButton
            // 
            this.settingsButton.Label = "Settings";
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.ShowImage = true;
            this.settingsButton.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.settingsButton_Click);
            // 
            // aboutButton
            // 
            this.aboutButton.Label = "About";
            this.aboutButton.Name = "aboutButton";
            this.aboutButton.ShowImage = true;
            // 
            // PacPlotRibbon
            // 
            this.Name = "PacPlotRibbon";
            this.RibbonType = "Microsoft.Excel.Workbook";
            this.Tabs.Add(this.tab1);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.PacPlotRibbon_Load);
            this.tab1.ResumeLayout(false);
            this.tab1.PerformLayout();
            this.resCurvesGroup.ResumeLayout(false);
            this.resCurvesGroup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tab1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup resCurvesGroup;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton launcherButton;
        internal Microsoft.Office.Tools.Ribbon.RibbonSeparator separator1;
        internal Microsoft.Office.Tools.Ribbon.RibbonDropDown mapsDropDown;
        internal Microsoft.Office.Tools.Ribbon.RibbonMenu moreMenu;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton importButton;
        internal Microsoft.Office.Tools.Ribbon.RibbonSeparator separator2;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton aboutButton;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton settingsButton;
    }

    partial class ThisRibbonCollection
    {
        internal PacPlotRibbon PacPlotRibbon
        {
            get { return this.GetRibbon<PacPlotRibbon>(); }
        }

        private PacPlotRibbon GetRibbon<T>()
        {
            throw new NotImplementedException();
        }
    }
}

namespace MBEditor.Tabs
{
    partial class TabHero
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lstCompanions = new BrightIdeasSoftware.ObjectListView();
            this.olvNPCName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.splHorizontal = new DarkUI.Support.DarkSplitContainer();
            this.splVertical = new DarkUI.Support.DarkSplitContainer();
            this.DockPanel = new DarkUI.Docking.DarkDockPanel();
            ((System.ComponentModel.ISupportInitialize)(this.lstCompanions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splHorizontal)).BeginInit();
            this.splHorizontal.Panel1.SuspendLayout();
            this.splHorizontal.Panel2.SuspendLayout();
            this.splHorizontal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splVertical)).BeginInit();
            this.splVertical.Panel2.SuspendLayout();
            this.splVertical.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstCompanions
            // 
            this.lstCompanions.AllColumns.Add(this.olvNPCName);
            this.lstCompanions.CellEditUseWholeCell = false;
            this.lstCompanions.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvNPCName});
            this.lstCompanions.Cursor = System.Windows.Forms.Cursors.Default;
            this.lstCompanions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstCompanions.HideSelection = false;
            this.lstCompanions.Location = new System.Drawing.Point(0, 0);
            this.lstCompanions.Margin = new System.Windows.Forms.Padding(0);
            this.lstCompanions.Name = "lstCompanions";
            this.lstCompanions.Size = new System.Drawing.Size(756, 646);
            this.lstCompanions.TabIndex = 0;
            this.lstCompanions.UseCompatibleStateImageBehavior = false;
            this.lstCompanions.View = System.Windows.Forms.View.Details;
            this.lstCompanions.SelectionChanged += new System.EventHandler(this.lstCompanions_SelectionChanged);
            // 
            // olvNPCName
            // 
            this.olvNPCName.AspectName = "Name";
            this.olvNPCName.IsEditable = false;
            this.olvNPCName.MinimumWidth = 50;
            this.olvNPCName.Text = "姓名";
            this.olvNPCName.UseInitialLetterForGroup = true;
            this.olvNPCName.Width = 235;
            // 
            // splHorizontal
            // 
            this.splHorizontal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splHorizontal.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splHorizontal.Location = new System.Drawing.Point(0, 0);
            this.splHorizontal.Margin = new System.Windows.Forms.Padding(0);
            this.splHorizontal.Name = "splHorizontal";
            // 
            // splHorizontal.Panel1
            // 
            this.splHorizontal.Panel1.Controls.Add(this.lstCompanions);
            // 
            // splHorizontal.Panel2
            // 
            this.splHorizontal.Panel2.Controls.Add(this.splVertical);
            this.splHorizontal.Panel2MinSize = 300;
            this.splHorizontal.Size = new System.Drawing.Size(1104, 646);
            this.splHorizontal.SplitterDistance = 756;
            this.splHorizontal.SplitterWidth = 8;
            this.splHorizontal.TabIndex = 1;
            // 
            // splVertical
            // 
            this.splVertical.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splVertical.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splVertical.Location = new System.Drawing.Point(0, 0);
            this.splVertical.Margin = new System.Windows.Forms.Padding(0);
            this.splVertical.Name = "splVertical";
            this.splVertical.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splVertical.Panel2
            // 
            this.splVertical.Panel2.Controls.Add(this.DockPanel);
            this.splVertical.Panel2MinSize = 40;
            this.splVertical.Size = new System.Drawing.Size(340, 646);
            this.splVertical.SplitterDistance = 259;
            this.splVertical.SplitterWidth = 8;
            this.splVertical.TabIndex = 1;
            // 
            // DockPanel
            // 
            this.DockPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.DockPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DockPanel.Location = new System.Drawing.Point(0, 0);
            this.DockPanel.Margin = new System.Windows.Forms.Padding(0);
            this.DockPanel.Name = "DockPanel";
            this.DockPanel.Size = new System.Drawing.Size(340, 379);
            this.DockPanel.TabIndex = 0;
            // 
            // TabHero
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splHorizontal);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "TabHero";
            this.Size = new System.Drawing.Size(1104, 646);
            ((System.ComponentModel.ISupportInitialize)(this.lstCompanions)).EndInit();
            this.splHorizontal.Panel1.ResumeLayout(false);
            this.splHorizontal.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splHorizontal)).EndInit();
            this.splHorizontal.ResumeLayout(false);
            this.splVertical.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splVertical)).EndInit();
            this.splVertical.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private BrightIdeasSoftware.ObjectListView lstCompanions;
        private BrightIdeasSoftware.OLVColumn olvNPCName;
        private DarkUI.Support.DarkSplitContainer splHorizontal;
        private new DarkUI.Docking.DarkDockPanel DockPanel;
        private DarkUI.Support.DarkSplitContainer splVertical;
    }
}

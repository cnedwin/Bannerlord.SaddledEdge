namespace MBEditor.Tabs
{
    partial class TabNPCs
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
            this.components = new System.ComponentModel.Container();
            this.lstNPCs = new BrightIdeasSoftware.ObjectListView();
            this.olvNPCName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.splitContainer1 = new DarkUI.Support.DarkSplitContainer();
            this.tabStripDetail = new DarkUI.Controls.DarkTabControl(this.components);
            this.tabInfo = new System.Windows.Forms.TabPage();
            this.splVertical = new DarkUI.Support.DarkSplitContainer();
            this.dockPanel = new DarkUI.Docking.DarkDockPanel();
            this.tabNPCDetail = new System.Windows.Forms.TabPage();
            this.darkPropertyGrid1 = new MBEditor.Controls.MBEditPropertyGrid(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.lstNPCs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabStripDetail.SuspendLayout();
            this.tabInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splVertical)).BeginInit();
            this.splVertical.Panel2.SuspendLayout();
            this.splVertical.SuspendLayout();
            this.tabNPCDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.darkPropertyGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // lstNPCs
            // 
            this.lstNPCs.AllColumns.Add(this.olvNPCName);
            this.lstNPCs.CellEditUseWholeCell = false;
            this.lstNPCs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvNPCName});
            this.lstNPCs.Cursor = System.Windows.Forms.Cursors.Default;
            this.lstNPCs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstNPCs.HideSelection = false;
            this.lstNPCs.Location = new System.Drawing.Point(0, 0);
            this.lstNPCs.Margin = new System.Windows.Forms.Padding(0);
            this.lstNPCs.Name = "lstNPCs";
            this.lstNPCs.Size = new System.Drawing.Size(772, 623);
            this.lstNPCs.TabIndex = 43;
            this.lstNPCs.UseCompatibleStateImageBehavior = false;
            this.lstNPCs.View = System.Windows.Forms.View.Details;
            this.lstNPCs.SelectionChanged += new System.EventHandler(this.lstNPCs_SelectionChanged);
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
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lstNPCs);
            this.splitContainer1.Panel1MinSize = 400;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabStripDetail);
            this.splitContainer1.Size = new System.Drawing.Size(1144, 623);
            this.splitContainer1.SplitterDistance = 772;
            this.splitContainer1.SplitterWidth = 8;
            this.splitContainer1.TabIndex = 44;
            // 
            // tabStripDetail
            // 
            this.tabStripDetail.Controls.Add(this.tabInfo);
            this.tabStripDetail.Controls.Add(this.tabNPCDetail);
            this.tabStripDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabStripDetail.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabStripDetail.HotTrack = true;
            this.tabStripDetail.Location = new System.Drawing.Point(0, 0);
            this.tabStripDetail.Name = "tabStripDetail";
            this.tabStripDetail.SelectedIndex = 0;
            this.tabStripDetail.Size = new System.Drawing.Size(364, 623);
            this.tabStripDetail.TabIndex = 2;
            this.tabStripDetail.SelectedIndexChanged += new System.EventHandler(this.tabStripDetail_SelectedIndexChanged);
            // 
            // tabInfo
            // 
            this.tabInfo.BackColor = System.Drawing.Color.Transparent;
            this.tabInfo.Controls.Add(this.splVertical);
            this.tabInfo.Location = new System.Drawing.Point(4, 25);
            this.tabInfo.Name = "tabInfo";
            this.tabInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabInfo.Size = new System.Drawing.Size(356, 594);
            this.tabInfo.TabIndex = 0;
            this.tabInfo.Text = "信息";
            // 
            // splVertical
            // 
            this.splVertical.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splVertical.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splVertical.Location = new System.Drawing.Point(3, 3);
            this.splVertical.Margin = new System.Windows.Forms.Padding(0);
            this.splVertical.Name = "splVertical";
            this.splVertical.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splVertical.Panel2
            // 
            this.splVertical.Panel2.Controls.Add(this.dockPanel);
            this.splVertical.Panel2MinSize = 40;
            this.splVertical.Size = new System.Drawing.Size(350, 588);
            this.splVertical.SplitterDistance = 259;
            this.splVertical.SplitterWidth = 8;
            this.splVertical.TabIndex = 2;
            // 
            // dockPanel
            // 
            this.dockPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.dockPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dockPanel.Location = new System.Drawing.Point(0, 0);
            this.dockPanel.Margin = new System.Windows.Forms.Padding(4);
            this.dockPanel.Name = "dockPanel";
            this.dockPanel.Size = new System.Drawing.Size(350, 321);
            this.dockPanel.TabIndex = 0;
            // 
            // tabNPCDetail
            // 
            this.tabNPCDetail.BackColor = System.Drawing.Color.Transparent;
            this.tabNPCDetail.Controls.Add(this.darkPropertyGrid1);
            this.tabNPCDetail.Location = new System.Drawing.Point(4, 25);
            this.tabNPCDetail.Name = "tabNPCDetail";
            this.tabNPCDetail.Padding = new System.Windows.Forms.Padding(3);
            this.tabNPCDetail.Size = new System.Drawing.Size(237, 521);
            this.tabNPCDetail.TabIndex = 1;
            this.tabNPCDetail.Text = "详情";
            // 
            // darkPropertyGrid1
            // 
            this.darkPropertyGrid1.AlternateRowBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(51)))), ((int)(((byte)(53)))));
            this.darkPropertyGrid1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.darkPropertyGrid1.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.SingleClick;
            this.darkPropertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.darkPropertyGrid1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkPropertyGrid1.FullRowSelect = true;
            this.darkPropertyGrid1.HeaderWordWrap = true;
            this.darkPropertyGrid1.HideSelection = false;
            this.darkPropertyGrid1.Location = new System.Drawing.Point(3, 3);
            this.darkPropertyGrid1.MultiSelect = false;
            this.darkPropertyGrid1.Name = "darkPropertyGrid1";
            this.darkPropertyGrid1.SelectColumnsOnRightClickBehaviour = BrightIdeasSoftware.ObjectListView.ColumnSelectBehaviour.Submenu;
            this.darkPropertyGrid1.SelectedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(110)))), ((int)(((byte)(175)))));
            this.darkPropertyGrid1.SelectedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkPropertyGrid1.ShowCommandMenuOnRightClick = true;
            this.darkPropertyGrid1.ShowGroups = false;
            this.darkPropertyGrid1.ShowImagesOnSubItems = true;
            this.darkPropertyGrid1.ShowItemCountOnGroups = true;
            this.darkPropertyGrid1.Size = new System.Drawing.Size(231, 515);
            this.darkPropertyGrid1.TabIndex = 1;
            this.darkPropertyGrid1.UseAlternatingBackColors = true;
            this.darkPropertyGrid1.UseCompatibleStateImageBehavior = false;
            this.darkPropertyGrid1.UseFiltering = true;
            this.darkPropertyGrid1.UseHotControls = false;
            this.darkPropertyGrid1.View = System.Windows.Forms.View.Details;
            this.darkPropertyGrid1.VirtualMode = true;
            // 
            // TabNPCs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "TabNPCs";
            this.Size = new System.Drawing.Size(1144, 623);
            ((System.ComponentModel.ISupportInitialize)(this.lstNPCs)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabStripDetail.ResumeLayout(false);
            this.tabInfo.ResumeLayout(false);
            this.splVertical.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splVertical)).EndInit();
            this.splVertical.ResumeLayout(false);
            this.tabNPCDetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.darkPropertyGrid1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private BrightIdeasSoftware.ObjectListView lstNPCs;
        private BrightIdeasSoftware.OLVColumn olvNPCName;
        private DarkUI.Support.DarkSplitContainer splitContainer1;
        private MBEditor.Controls.MBEditPropertyGrid darkPropertyGrid1;
        private DarkUI.Controls.DarkTabControl tabStripDetail;
        private System.Windows.Forms.TabPage tabInfo;
        private System.Windows.Forms.TabPage tabNPCDetail;
        private DarkUI.Support.DarkSplitContainer splVertical;
        private DarkUI.Docking.DarkDockPanel dockPanel;
    }
}

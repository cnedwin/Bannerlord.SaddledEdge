namespace MBEditor.Tabs
{
    partial class TabFaction
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
            this.lstItems = new BrightIdeasSoftware.ObjectListView();
            this.MainSplitter = new DarkUI.Support.DarkSplitContainer();
            this.tabSidePanel = new DarkUI.Controls.DarkTabControl(this.components);
            this.tabSideDetail = new System.Windows.Forms.TabPage();
            this.PropertyGrid = new MBEditor.Controls.MBEditPropertyGrid(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.lstItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainSplitter)).BeginInit();
            this.MainSplitter.Panel1.SuspendLayout();
            this.MainSplitter.Panel2.SuspendLayout();
            this.MainSplitter.SuspendLayout();
            this.tabSidePanel.SuspendLayout();
            this.tabSideDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PropertyGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // lstItems
            // 
            this.lstItems.BackColor = System.Drawing.Color.DimGray;
            this.lstItems.CellEditUseWholeCell = false;
            this.lstItems.Cursor = System.Windows.Forms.Cursors.Default;
            this.lstItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstItems.HideSelection = false;
            this.lstItems.Location = new System.Drawing.Point(0, 0);
            this.lstItems.Margin = new System.Windows.Forms.Padding(0);
            this.lstItems.Name = "lstItems";
            this.lstItems.Size = new System.Drawing.Size(527, 613);
            this.lstItems.TabIndex = 8;
            this.lstItems.UseCompatibleStateImageBehavior = false;
            this.lstItems.View = System.Windows.Forms.View.Details;
            this.lstItems.SelectionChanged += new System.EventHandler(this.lstItems_SelectionChanged);
            // 
            // MainSplitter
            // 
            this.MainSplitter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainSplitter.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.MainSplitter.Location = new System.Drawing.Point(0, 0);
            this.MainSplitter.Margin = new System.Windows.Forms.Padding(0);
            this.MainSplitter.Name = "MainSplitter";
            // 
            // MainSplitter.Panel1
            // 
            this.MainSplitter.Panel1.Controls.Add(this.lstItems);
            // 
            // MainSplitter.Panel2
            // 
            this.MainSplitter.Panel2.Controls.Add(this.tabSidePanel);
            this.MainSplitter.Panel2MinSize = 100;
            this.MainSplitter.Size = new System.Drawing.Size(897, 613);
            this.MainSplitter.SplitterDistance = 527;
            this.MainSplitter.SplitterWidth = 8;
            this.MainSplitter.TabIndex = 9;
            // 
            // tabSidePanel
            // 
            this.tabSidePanel.Controls.Add(this.tabSideDetail);
            this.tabSidePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabSidePanel.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabSidePanel.HotTrack = true;
            this.tabSidePanel.Location = new System.Drawing.Point(0, 0);
            this.tabSidePanel.Name = "tabSidePanel";
            this.tabSidePanel.SelectedIndex = 0;
            this.tabSidePanel.Size = new System.Drawing.Size(362, 613);
            this.tabSidePanel.TabIndex = 1;
            // 
            // tabSideDetail
            // 
            this.tabSideDetail.Controls.Add(this.PropertyGrid);
            this.tabSideDetail.Location = new System.Drawing.Point(4, 25);
            this.tabSideDetail.Name = "tabSideDetail";
            this.tabSideDetail.Padding = new System.Windows.Forms.Padding(3);
            this.tabSideDetail.Size = new System.Drawing.Size(354, 584);
            this.tabSideDetail.TabIndex = 1;
            this.tabSideDetail.Text = "详情";
            this.tabSideDetail.UseVisualStyleBackColor = true;
            // 
            // PropertyGrid
            // 
            this.PropertyGrid.AlternateRowBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(51)))), ((int)(((byte)(53)))));
            this.PropertyGrid.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.PropertyGrid.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.SingleClick;
            this.PropertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PropertyGrid.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.PropertyGrid.FullRowSelect = true;
            this.PropertyGrid.HeaderWordWrap = true;
            this.PropertyGrid.HideSelection = false;
            this.PropertyGrid.Location = new System.Drawing.Point(3, 3);
            this.PropertyGrid.Margin = new System.Windows.Forms.Padding(0);
            this.PropertyGrid.MultiSelect = false;
            this.PropertyGrid.Name = "PropertyGrid";
            this.PropertyGrid.SelectColumnsOnRightClickBehaviour = BrightIdeasSoftware.ObjectListView.ColumnSelectBehaviour.Submenu;
            this.PropertyGrid.SelectedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(110)))), ((int)(((byte)(175)))));
            this.PropertyGrid.SelectedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.PropertyGrid.ShowCommandMenuOnRightClick = true;
            this.PropertyGrid.ShowGroups = false;
            this.PropertyGrid.ShowImagesOnSubItems = true;
            this.PropertyGrid.ShowItemCountOnGroups = true;
            this.PropertyGrid.Size = new System.Drawing.Size(348, 578);
            this.PropertyGrid.TabIndex = 0;
            this.PropertyGrid.UseAlternatingBackColors = true;
            this.PropertyGrid.UseCompatibleStateImageBehavior = false;
            this.PropertyGrid.UseFiltering = true;
            this.PropertyGrid.UseHotControls = false;
            this.PropertyGrid.View = System.Windows.Forms.View.Details;
            this.PropertyGrid.VirtualMode = true;
            // 
            // TabFaction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.MainSplitter);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "TabFaction";
            this.Size = new System.Drawing.Size(897, 613);
            ((System.ComponentModel.ISupportInitialize)(this.lstItems)).EndInit();
            this.MainSplitter.Panel1.ResumeLayout(false);
            this.MainSplitter.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MainSplitter)).EndInit();
            this.MainSplitter.ResumeLayout(false);
            this.tabSidePanel.ResumeLayout(false);
            this.tabSideDetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PropertyGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private BrightIdeasSoftware.ObjectListView lstItems;
        private DarkUI.Support.DarkSplitContainer MainSplitter;
        private MBEditor.Controls.MBEditPropertyGrid PropertyGrid;
        private DarkUI.Controls.DarkTabControl tabSidePanel;
        private System.Windows.Forms.TabPage tabSideDetail;
    }
}

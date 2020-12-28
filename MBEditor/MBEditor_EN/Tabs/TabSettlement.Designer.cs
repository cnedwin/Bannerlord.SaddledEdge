namespace MBEditor.Tabs
{
    partial class TabSettlement
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
            this.splitContainer1 = new DarkUI.Support.DarkSplitContainer();
            this.tabSettlementDetails = new DarkUI.Controls.DarkTabControl(this.components);
            this.tabInfo = new System.Windows.Forms.TabPage();
            this.grpBuildingQueue = new DarkUI.Controls.DarkGroupBox();
            this.lstBuildingQueue = new BrightIdeasSoftware.ObjectListView();
            this.grpBuilding = new DarkUI.Controls.DarkGroupBox();
            this.btnFinishQueue = new DarkUI.Controls.DarkButton();
            this.btnFinishBuilding = new DarkUI.Controls.DarkButton();
            this.txtBuildingCurrent = new DarkUI.Controls.DarkTextBox();
            this.darkLabel1 = new DarkUI.Controls.DarkLabel();
            this.txtDisplayName = new DarkUI.Controls.DarkTextBox();
            this.lblName = new DarkUI.Controls.DarkLabel();
            this.tabDetails = new System.Windows.Forms.TabPage();
            this.darkPropertyGrid1 = new MBEditor.Controls.MBEditPropertyGrid(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.lstItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabSettlementDetails.SuspendLayout();
            this.tabInfo.SuspendLayout();
            this.grpBuildingQueue.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lstBuildingQueue)).BeginInit();
            this.grpBuilding.SuspendLayout();
            this.tabDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.darkPropertyGrid1)).BeginInit();
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
            this.lstItems.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.lstItems.Name = "lstItems";
            this.lstItems.Size = new System.Drawing.Size(404, 550);
            this.lstItems.TabIndex = 8;
            this.lstItems.UseCompatibleStateImageBehavior = false;
            this.lstItems.View = System.Windows.Forms.View.Details;
            this.lstItems.SelectionChanged += new System.EventHandler(this.lstItems_SelectionChanged);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lstItems);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabSettlementDetails);
            this.splitContainer1.Panel2MinSize = 100;
            this.splitContainer1.Size = new System.Drawing.Size(780, 550);
            this.splitContainer1.SplitterDistance = 404;
            this.splitContainer1.SplitterWidth = 8;
            this.splitContainer1.TabIndex = 9;
            // 
            // tabSettlementDetails
            // 
            this.tabSettlementDetails.Controls.Add(this.tabInfo);
            this.tabSettlementDetails.Controls.Add(this.tabDetails);
            this.tabSettlementDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabSettlementDetails.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabSettlementDetails.HotTrack = true;
            this.tabSettlementDetails.Location = new System.Drawing.Point(0, 0);
            this.tabSettlementDetails.Margin = new System.Windows.Forms.Padding(0);
            this.tabSettlementDetails.Name = "tabSettlementDetails";
            this.tabSettlementDetails.Padding = new System.Drawing.Point(0, 0);
            this.tabSettlementDetails.SelectedIndex = 0;
            this.tabSettlementDetails.Size = new System.Drawing.Size(368, 550);
            this.tabSettlementDetails.TabIndex = 0;
            this.tabSettlementDetails.SelectedIndexChanged += new System.EventHandler(this.tabSettlementDetails_SelectedIndexChanged);
            // 
            // tabInfo
            // 
            this.tabInfo.BackColor = System.Drawing.Color.Transparent;
            this.tabInfo.Controls.Add(this.grpBuildingQueue);
            this.tabInfo.Controls.Add(this.grpBuilding);
            this.tabInfo.Controls.Add(this.txtDisplayName);
            this.tabInfo.Controls.Add(this.lblName);
            this.tabInfo.Location = new System.Drawing.Point(4, 25);
            this.tabInfo.Margin = new System.Windows.Forms.Padding(0);
            this.tabInfo.Name = "tabInfo";
            this.tabInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabInfo.Size = new System.Drawing.Size(360, 521);
            this.tabInfo.TabIndex = 0;
            this.tabInfo.Text = "Info";
            // 
            // grpBuildingQueue
            // 
            this.grpBuildingQueue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpBuildingQueue.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.grpBuildingQueue.Controls.Add(this.lstBuildingQueue);
            this.grpBuildingQueue.Location = new System.Drawing.Point(8, 119);
            this.grpBuildingQueue.Name = "grpBuildingQueue";
            this.grpBuildingQueue.Size = new System.Drawing.Size(346, 256);
            this.grpBuildingQueue.TabIndex = 5;
            this.grpBuildingQueue.TabStop = false;
            this.grpBuildingQueue.Text = "Building Queue";
            // 
            // lstBuildingQueue
            // 
            this.lstBuildingQueue.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstBuildingQueue.CellEditUseWholeCell = false;
            this.lstBuildingQueue.Cursor = System.Windows.Forms.Cursors.Default;
            this.lstBuildingQueue.HideSelection = false;
            this.lstBuildingQueue.Location = new System.Drawing.Point(6, 30);
            this.lstBuildingQueue.Name = "lstBuildingQueue";
            this.lstBuildingQueue.Size = new System.Drawing.Size(333, 220);
            this.lstBuildingQueue.TabIndex = 0;
            this.lstBuildingQueue.UseCompatibleStateImageBehavior = false;
            this.lstBuildingQueue.View = System.Windows.Forms.View.Details;
            // 
            // grpBuilding
            // 
            this.grpBuilding.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpBuilding.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.grpBuilding.Controls.Add(this.btnFinishQueue);
            this.grpBuilding.Controls.Add(this.btnFinishBuilding);
            this.grpBuilding.Controls.Add(this.txtBuildingCurrent);
            this.grpBuilding.Controls.Add(this.darkLabel1);
            this.grpBuilding.Location = new System.Drawing.Point(6, 33);
            this.grpBuilding.Name = "grpBuilding";
            this.grpBuilding.Size = new System.Drawing.Size(348, 80);
            this.grpBuilding.TabIndex = 4;
            this.grpBuilding.TabStop = false;
            this.grpBuilding.Text = "Building";
            // 
            // btnFinishQueue
            // 
            this.btnFinishQueue.Location = new System.Drawing.Point(103, 45);
            this.btnFinishQueue.Name = "btnFinishQueue";
            this.btnFinishQueue.Padding = new System.Windows.Forms.Padding(5);
            this.btnFinishQueue.Size = new System.Drawing.Size(88, 23);
            this.btnFinishQueue.TabIndex = 3;
            this.btnFinishQueue.Text = "Finish Queue";
            this.btnFinishQueue.Click += new System.EventHandler(this.btnFinishQueue_Click);
            // 
            // btnFinishBuilding
            // 
            this.btnFinishBuilding.Location = new System.Drawing.Point(20, 45);
            this.btnFinishBuilding.Name = "btnFinishBuilding";
            this.btnFinishBuilding.Padding = new System.Windows.Forms.Padding(5);
            this.btnFinishBuilding.Size = new System.Drawing.Size(77, 23);
            this.btnFinishBuilding.TabIndex = 2;
            this.btnFinishBuilding.Text = "Finish";
            this.btnFinishBuilding.Click += new System.EventHandler(this.btnFinishBuilding_Click);
            // 
            // txtBuildingCurrent
            // 
            this.txtBuildingCurrent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBuildingCurrent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.txtBuildingCurrent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBuildingCurrent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.txtBuildingCurrent.Location = new System.Drawing.Point(67, 19);
            this.txtBuildingCurrent.Name = "txtBuildingCurrent";
            this.txtBuildingCurrent.ReadOnly = true;
            this.txtBuildingCurrent.Size = new System.Drawing.Size(274, 20);
            this.txtBuildingCurrent.TabIndex = 1;
            // 
            // darkLabel1
            // 
            this.darkLabel1.AutoSize = true;
            this.darkLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel1.Location = new System.Drawing.Point(17, 21);
            this.darkLabel1.Name = "darkLabel1";
            this.darkLabel1.Size = new System.Drawing.Size(44, 13);
            this.darkLabel1.TabIndex = 0;
            this.darkLabel1.Text = "Current:";
            // 
            // txtDisplayName
            // 
            this.txtDisplayName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDisplayName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.txtDisplayName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDisplayName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.txtDisplayName.Location = new System.Drawing.Point(57, 6);
            this.txtDisplayName.Name = "txtDisplayName";
            this.txtDisplayName.ReadOnly = true;
            this.txtDisplayName.Size = new System.Drawing.Size(290, 20);
            this.txtDisplayName.TabIndex = 1;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.lblName.Location = new System.Drawing.Point(11, 8);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(38, 13);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "Name:";
            // 
            // tabDetails
            // 
            this.tabDetails.BackColor = System.Drawing.Color.Transparent;
            this.tabDetails.Controls.Add(this.darkPropertyGrid1);
            this.tabDetails.Location = new System.Drawing.Point(4, 25);
            this.tabDetails.Margin = new System.Windows.Forms.Padding(0);
            this.tabDetails.Name = "tabDetails";
            this.tabDetails.Padding = new System.Windows.Forms.Padding(3);
            this.tabDetails.Size = new System.Drawing.Size(356, 521);
            this.tabDetails.TabIndex = 1;
            this.tabDetails.Text = "Details";
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
            this.darkPropertyGrid1.Margin = new System.Windows.Forms.Padding(0);
            this.darkPropertyGrid1.MultiSelect = false;
            this.darkPropertyGrid1.Name = "darkPropertyGrid1";
            this.darkPropertyGrid1.SelectColumnsOnRightClickBehaviour = BrightIdeasSoftware.ObjectListView.ColumnSelectBehaviour.Submenu;
            this.darkPropertyGrid1.SelectedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(110)))), ((int)(((byte)(175)))));
            this.darkPropertyGrid1.SelectedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkPropertyGrid1.ShowCommandMenuOnRightClick = true;
            this.darkPropertyGrid1.ShowGroups = false;
            this.darkPropertyGrid1.ShowImagesOnSubItems = true;
            this.darkPropertyGrid1.ShowItemCountOnGroups = true;
            this.darkPropertyGrid1.Size = new System.Drawing.Size(350, 515);
            this.darkPropertyGrid1.TabIndex = 0;
            this.darkPropertyGrid1.UseAlternatingBackColors = true;
            this.darkPropertyGrid1.UseCompatibleStateImageBehavior = false;
            this.darkPropertyGrid1.UseFiltering = true;
            this.darkPropertyGrid1.UseHotControls = false;
            this.darkPropertyGrid1.View = System.Windows.Forms.View.Details;
            this.darkPropertyGrid1.VirtualMode = true;
            // 
            // TabSettlement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "TabSettlement";
            this.Size = new System.Drawing.Size(780, 550);
            ((System.ComponentModel.ISupportInitialize)(this.lstItems)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabSettlementDetails.ResumeLayout(false);
            this.tabInfo.ResumeLayout(false);
            this.tabInfo.PerformLayout();
            this.grpBuildingQueue.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lstBuildingQueue)).EndInit();
            this.grpBuilding.ResumeLayout(false);
            this.grpBuilding.PerformLayout();
            this.tabDetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.darkPropertyGrid1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private BrightIdeasSoftware.ObjectListView lstItems;
        private DarkUI.Support.DarkSplitContainer splitContainer1;
        private MBEditor.Controls.MBEditPropertyGrid darkPropertyGrid1;
        private DarkUI.Controls.DarkTabControl tabSettlementDetails;
        private System.Windows.Forms.TabPage tabInfo;
        private System.Windows.Forms.TabPage tabDetails;
        private DarkUI.Controls.DarkLabel lblName;
        private DarkUI.Controls.DarkGroupBox grpBuilding;
        private DarkUI.Controls.DarkTextBox txtBuildingCurrent;
        private DarkUI.Controls.DarkLabel darkLabel1;
        private DarkUI.Controls.DarkButton btnFinishBuilding;
        private DarkUI.Controls.DarkGroupBox grpBuildingQueue;
        private BrightIdeasSoftware.ObjectListView lstBuildingQueue;
        private DarkUI.Controls.DarkButton btnFinishQueue;
        private DarkUI.Controls.DarkTextBox txtDisplayName;
    }
}

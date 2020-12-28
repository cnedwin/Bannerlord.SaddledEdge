namespace MBEditor.Tabs
{
    partial class TabTroops
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
            this.lblCount = new DarkUI.Controls.DarkLabel();
            this.numTroopsAdd = new DarkUI.Controls.DarkNumericUpDown();
            this.btnTroopsAdd = new DarkUI.Controls.DarkButton();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.lstAllItems = new BrightIdeasSoftware.ObjectListView();
            this.olvColumn1 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.pnlRight = new System.Windows.Forms.Panel();
            this.btnPrisoners = new DarkUI.Controls.DarkButton();
            this.lstRosterTroops = new BrightIdeasSoftware.ObjectListView();
            this.btnTroopsRemove = new DarkUI.Controls.DarkButton();
            this.btnSort = new DarkUI.Controls.DarkButton();
            this.btnTroopsUpgrade = new DarkUI.Controls.DarkButton();
            this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.splParty = new DarkUI.Support.DarkSplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.numTroopsAdd)).BeginInit();
            this.pnlLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lstAllItems)).BeginInit();
            this.pnlRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lstRosterTroops)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splParty)).BeginInit();
            this.splParty.Panel1.SuspendLayout();
            this.splParty.Panel2.SuspendLayout();
            this.splParty.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblCount
            // 
            this.lblCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCount.AutoSize = true;
            this.lblCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.lblCount.Location = new System.Drawing.Point(79, 600);
            this.lblCount.Margin = new System.Windows.Forms.Padding(0);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(35, 13);
            this.lblCount.TabIndex = 1;
            this.lblCount.Text = "Count";
            // 
            // numTroopsAdd
            // 
            this.numTroopsAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.numTroopsAdd.Location = new System.Drawing.Point(132, 598);
            this.numTroopsAdd.Margin = new System.Windows.Forms.Padding(0);
            this.numTroopsAdd.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.numTroopsAdd.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numTroopsAdd.MouseWheelIncrement = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.numTroopsAdd.Name = "numTroopsAdd";
            this.numTroopsAdd.Size = new System.Drawing.Size(104, 20);
            this.numTroopsAdd.TabIndex = 2;
            this.numTroopsAdd.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnTroopsAdd
            // 
            this.btnTroopsAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTroopsAdd.Location = new System.Drawing.Point(246, 598);
            this.btnTroopsAdd.Margin = new System.Windows.Forms.Padding(0);
            this.btnTroopsAdd.Name = "btnTroopsAdd";
            this.btnTroopsAdd.Padding = new System.Windows.Forms.Padding(1);
            this.btnTroopsAdd.Size = new System.Drawing.Size(72, 24);
            this.btnTroopsAdd.TabIndex = 3;
            this.btnTroopsAdd.Text = "Add";
            this.btnTroopsAdd.Click += new System.EventHandler(this.btnTroopsAdd_Click);
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.lstAllItems);
            this.pnlLeft.Controls.Add(this.btnTroopsAdd);
            this.pnlLeft.Controls.Add(this.lblCount);
            this.pnlLeft.Controls.Add(this.numTroopsAdd);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Margin = new System.Windows.Forms.Padding(0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(323, 629);
            this.pnlLeft.TabIndex = 0;
            // 
            // lstAllItems
            // 
            this.lstAllItems.AllColumns.Add(this.olvColumn1);
            this.lstAllItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstAllItems.BackColor = System.Drawing.Color.DarkGray;
            this.lstAllItems.CellEditUseWholeCell = false;
            this.lstAllItems.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumn1});
            this.lstAllItems.Cursor = System.Windows.Forms.Cursors.Default;
            this.lstAllItems.HideSelection = false;
            this.lstAllItems.Location = new System.Drawing.Point(5, 6);
            this.lstAllItems.Margin = new System.Windows.Forms.Padding(0);
            this.lstAllItems.Name = "lstAllItems";
            this.lstAllItems.Size = new System.Drawing.Size(313, 580);
            this.lstAllItems.TabIndex = 0;
            this.lstAllItems.UseCompatibleStateImageBehavior = false;
            this.lstAllItems.View = System.Windows.Forms.View.Details;
            this.lstAllItems.DoubleClick += new System.EventHandler(this.lstAllItems_DoubleClick);
            // 
            // olvColumn1
            // 
            this.olvColumn1.AspectName = "Name";
            this.olvColumn1.IsEditable = false;
            this.olvColumn1.MinimumWidth = 50;
            this.olvColumn1.Text = "Name";
            this.olvColumn1.UseInitialLetterForGroup = true;
            this.olvColumn1.Width = 235;
            // 
            // pnlRight
            // 
            this.pnlRight.Controls.Add(this.btnPrisoners);
            this.pnlRight.Controls.Add(this.lstRosterTroops);
            this.pnlRight.Controls.Add(this.btnTroopsRemove);
            this.pnlRight.Controls.Add(this.btnSort);
            this.pnlRight.Controls.Add(this.btnTroopsUpgrade);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRight.Location = new System.Drawing.Point(0, 0);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(646, 629);
            this.pnlRight.TabIndex = 0;
            // 
            // btnPrisoners
            // 
            this.btnPrisoners.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrisoners.Location = new System.Drawing.Point(520, 600);
            this.btnPrisoners.Margin = new System.Windows.Forms.Padding(0);
            this.btnPrisoners.Name = "btnPrisoners";
            this.btnPrisoners.Padding = new System.Windows.Forms.Padding(1);
            this.btnPrisoners.Size = new System.Drawing.Size(107, 21);
            this.btnPrisoners.TabIndex = 4;
            this.btnPrisoners.Text = "Show Prisoners";
            this.btnPrisoners.Click += new System.EventHandler(this.btnPrisoners_Click);
            // 
            // lstRosterTroops
            // 
            this.lstRosterTroops.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstRosterTroops.BackColor = System.Drawing.Color.DimGray;
            this.lstRosterTroops.CellEditUseWholeCell = false;
            this.lstRosterTroops.Cursor = System.Windows.Forms.Cursors.Default;
            this.lstRosterTroops.HideSelection = false;
            this.lstRosterTroops.Location = new System.Drawing.Point(6, 7);
            this.lstRosterTroops.Margin = new System.Windows.Forms.Padding(0);
            this.lstRosterTroops.Name = "lstRosterTroops";
            this.lstRosterTroops.Size = new System.Drawing.Size(633, 579);
            this.lstRosterTroops.TabIndex = 0;
            this.lstRosterTroops.UseCompatibleStateImageBehavior = false;
            this.lstRosterTroops.View = System.Windows.Forms.View.Details;
            // 
            // btnTroopsRemove
            // 
            this.btnTroopsRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnTroopsRemove.Location = new System.Drawing.Point(6, 599);
            this.btnTroopsRemove.Margin = new System.Windows.Forms.Padding(0);
            this.btnTroopsRemove.Name = "btnTroopsRemove";
            this.btnTroopsRemove.Padding = new System.Windows.Forms.Padding(1);
            this.btnTroopsRemove.Size = new System.Drawing.Size(72, 24);
            this.btnTroopsRemove.TabIndex = 1;
            this.btnTroopsRemove.Text = "Remove";
            this.btnTroopsRemove.Click += new System.EventHandler(this.btnTroopsRemove_Click);
            // 
            // btnSort
            // 
            this.btnSort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSort.Location = new System.Drawing.Point(170, 599);
            this.btnSort.Margin = new System.Windows.Forms.Padding(0);
            this.btnSort.Name = "btnSort";
            this.btnSort.Padding = new System.Windows.Forms.Padding(1);
            this.btnSort.Size = new System.Drawing.Size(72, 24);
            this.btnSort.TabIndex = 3;
            this.btnSort.Text = "Sort";
            this.btnSort.Visible = false;
            this.btnSort.Click += new System.EventHandler(this.btnSort_Click);
            // 
            // btnTroopsUpgrade
            // 
            this.btnTroopsUpgrade.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnTroopsUpgrade.Location = new System.Drawing.Point(88, 599);
            this.btnTroopsUpgrade.Margin = new System.Windows.Forms.Padding(0);
            this.btnTroopsUpgrade.Name = "btnTroopsUpgrade";
            this.btnTroopsUpgrade.Padding = new System.Windows.Forms.Padding(1);
            this.btnTroopsUpgrade.Size = new System.Drawing.Size(72, 24);
            this.btnTroopsUpgrade.TabIndex = 2;
            this.btnTroopsUpgrade.Text = "Upgrade";
            this.btnTroopsUpgrade.Click += new System.EventHandler(this.btnTroopsUpgrade_Click);
            // 
            // splParty
            // 
            this.splParty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splParty.Location = new System.Drawing.Point(0, 0);
            this.splParty.Margin = new System.Windows.Forms.Padding(0);
            this.splParty.Name = "splParty";
            // 
            // splParty.Panel1
            // 
            this.splParty.Panel1.Controls.Add(this.pnlLeft);
            // 
            // splParty.Panel2
            // 
            this.splParty.Panel2.Controls.Add(this.pnlRight);
            this.splParty.Size = new System.Drawing.Size(977, 629);
            this.splParty.SplitterDistance = 323;
            this.splParty.SplitterWidth = 8;
            this.splParty.TabIndex = 11;
            // 
            // TabTroops
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.splParty);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "TabTroops";
            this.Size = new System.Drawing.Size(977, 629);
            ((System.ComponentModel.ISupportInitialize)(this.numTroopsAdd)).EndInit();
            this.pnlLeft.ResumeLayout(false);
            this.pnlLeft.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lstAllItems)).EndInit();
            this.pnlRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lstRosterTroops)).EndInit();
            this.splParty.Panel1.ResumeLayout(false);
            this.splParty.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splParty)).EndInit();
            this.splParty.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private DarkUI.Controls.DarkLabel lblCount;
        private DarkUI.Controls.DarkNumericUpDown numTroopsAdd;
        private DarkUI.Controls.DarkButton btnTroopsAdd;
        private BrightIdeasSoftware.ObjectListView lstAllItems;
        private BrightIdeasSoftware.OLVColumn olvColumn1;
        private System.Windows.Forms.ToolTip ToolTip;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Panel pnlRight;
        private DarkUI.Controls.DarkButton btnPrisoners;
        private BrightIdeasSoftware.ObjectListView lstRosterTroops;
        private DarkUI.Controls.DarkButton btnTroopsRemove;
        private DarkUI.Controls.DarkButton btnTroopsUpgrade;
        private DarkUI.Support.DarkSplitContainer splParty;
        private DarkUI.Controls.DarkButton btnSort;
    }
}

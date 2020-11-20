namespace MBEditor.Tabs
{
    partial class TabInventory
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
            this.cboItemModifier = new DarkUI.Controls.DarkComboBox();
            this.cboInvItemFilter = new DarkUI.Controls.DarkComboBox();
            this.label22 = new DarkUI.Controls.DarkLabel();
            this.lstInvEquipment = new BrightIdeasSoftware.ObjectListView();
            this.numInvItemCount = new DarkUI.Controls.DarkNumericUpDown();
            this.labelAmount = new DarkUI.Controls.DarkLabel();
            this.btnInvAdd = new DarkUI.Controls.DarkButton();
            this.btnInvRemove = new DarkUI.Controls.DarkButton();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.lstAllItems = new BrightIdeasSoftware.ObjectListView();
            this.olvColumn1 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.pnlRight = new System.Windows.Forms.Panel();
            this.btnApplyMods = new DarkUI.Controls.DarkButton();
            this.btnSortItems = new DarkUI.Controls.DarkButton();
            this.btnEnsureFood = new DarkUI.Controls.DarkButton();
            this.tooltip = new System.Windows.Forms.ToolTip(this.components);
            this.splInventory = new DarkUI.Support.DarkSplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.lstInvEquipment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numInvItemCount)).BeginInit();
            this.pnlLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lstAllItems)).BeginInit();
            this.pnlRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splInventory)).BeginInit();
            this.splInventory.Panel1.SuspendLayout();
            this.splInventory.Panel2.SuspendLayout();
            this.splInventory.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboItemModifier
            // 
            this.cboItemModifier.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboItemModifier.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cboItemModifier.FormattingEnabled = true;
            this.cboItemModifier.Location = new System.Drawing.Point(15, 497);
            this.cboItemModifier.Margin = new System.Windows.Forms.Padding(0);
            this.cboItemModifier.Name = "cboItemModifier";
            this.cboItemModifier.Size = new System.Drawing.Size(239, 21);
            this.cboItemModifier.TabIndex = 4;
            // 
            // cboInvItemFilter
            // 
            this.cboInvItemFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboInvItemFilter.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cboInvItemFilter.FormattingEnabled = true;
            this.cboInvItemFilter.Location = new System.Drawing.Point(73, 9);
            this.cboInvItemFilter.Margin = new System.Windows.Forms.Padding(0);
            this.cboInvItemFilter.Name = "cboInvItemFilter";
            this.cboInvItemFilter.Size = new System.Drawing.Size(181, 21);
            this.cboInvItemFilter.TabIndex = 1;
            this.cboInvItemFilter.SelectedIndexChanged += new System.EventHandler(this.cboInvItemFilter_SelectedIndexChanged);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.label22.Location = new System.Drawing.Point(12, 17);
            this.label22.Margin = new System.Windows.Forms.Padding(0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(55, 13);
            this.label22.TabIndex = 0;
            this.label22.Text = "Item Filter:";
            // 
            // lstInvEquipment
            // 
            this.lstInvEquipment.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstInvEquipment.CellEditUseWholeCell = false;
            this.lstInvEquipment.Cursor = System.Windows.Forms.Cursors.Default;
            this.lstInvEquipment.HideSelection = false;
            this.lstInvEquipment.Location = new System.Drawing.Point(6, 0);
            this.lstInvEquipment.Margin = new System.Windows.Forms.Padding(0);
            this.lstInvEquipment.Name = "lstInvEquipment";
            this.lstInvEquipment.Size = new System.Drawing.Size(500, 515);
            this.lstInvEquipment.TabIndex = 1;
            this.lstInvEquipment.UseCompatibleStateImageBehavior = false;
            this.lstInvEquipment.View = System.Windows.Forms.View.Details;
            this.lstInvEquipment.CellEditFinishing += new BrightIdeasSoftware.CellEditEventHandler(this.lstInvEquipment_CellEditFinishing);
            this.lstInvEquipment.CellEditStarting += new BrightIdeasSoftware.CellEditEventHandler(this.lstInvEquipment_CellEditStarting);
            // 
            // numInvItemCount
            // 
            this.numInvItemCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.numInvItemCount.Location = new System.Drawing.Point(121, 524);
            this.numInvItemCount.Margin = new System.Windows.Forms.Padding(0);
            this.numInvItemCount.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.numInvItemCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numInvItemCount.MouseWheelIncrement = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.numInvItemCount.Name = "numInvItemCount";
            this.numInvItemCount.Size = new System.Drawing.Size(78, 20);
            this.numInvItemCount.TabIndex = 6;
            this.numInvItemCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // labelAmount
            // 
            this.labelAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelAmount.AutoSize = true;
            this.labelAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.labelAmount.Location = new System.Drawing.Point(66, 527);
            this.labelAmount.Margin = new System.Windows.Forms.Padding(0);
            this.labelAmount.Name = "labelAmount";
            this.labelAmount.Size = new System.Drawing.Size(43, 13);
            this.labelAmount.TabIndex = 5;
            this.labelAmount.Text = "Amount";
            // 
            // btnInvAdd
            // 
            this.btnInvAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInvAdd.Location = new System.Drawing.Point(211, 525);
            this.btnInvAdd.Margin = new System.Windows.Forms.Padding(0);
            this.btnInvAdd.Name = "btnInvAdd";
            this.btnInvAdd.Padding = new System.Windows.Forms.Padding(5);
            this.btnInvAdd.Size = new System.Drawing.Size(42, 21);
            this.btnInvAdd.TabIndex = 7;
            this.btnInvAdd.Text = "Add";
            this.btnInvAdd.Click += new System.EventHandler(this.btnInvAdd_Click);
            // 
            // btnInvRemove
            // 
            this.btnInvRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnInvRemove.Location = new System.Drawing.Point(13, 523);
            this.btnInvRemove.Margin = new System.Windows.Forms.Padding(0);
            this.btnInvRemove.Name = "btnInvRemove";
            this.btnInvRemove.Padding = new System.Windows.Forms.Padding(5);
            this.btnInvRemove.Size = new System.Drawing.Size(96, 21);
            this.btnInvRemove.TabIndex = 2;
            this.btnInvRemove.Text = "Remove";
            this.btnInvRemove.Click += new System.EventHandler(this.btnInvRemove_Click);
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.cboItemModifier);
            this.pnlLeft.Controls.Add(this.label22);
            this.pnlLeft.Controls.Add(this.lstAllItems);
            this.pnlLeft.Controls.Add(this.numInvItemCount);
            this.pnlLeft.Controls.Add(this.btnInvAdd);
            this.pnlLeft.Controls.Add(this.labelAmount);
            this.pnlLeft.Controls.Add(this.cboInvItemFilter);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Margin = new System.Windows.Forms.Padding(0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(260, 550);
            this.pnlLeft.TabIndex = 6;
            // 
            // lstAllItems
            // 
            this.lstAllItems.AllColumns.Add(this.olvColumn1);
            this.lstAllItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstAllItems.CellEditUseWholeCell = false;
            this.lstAllItems.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumn1});
            this.lstAllItems.Cursor = System.Windows.Forms.Cursors.Default;
            this.lstAllItems.HideSelection = false;
            this.lstAllItems.Location = new System.Drawing.Point(9, 39);
            this.lstAllItems.Margin = new System.Windows.Forms.Padding(0);
            this.lstAllItems.Name = "lstAllItems";
            this.lstAllItems.Size = new System.Drawing.Size(245, 455);
            this.lstAllItems.TabIndex = 3;
            this.lstAllItems.UseCompatibleStateImageBehavior = false;
            this.lstAllItems.View = System.Windows.Forms.View.Details;
            this.lstAllItems.CellEditFinishing += new BrightIdeasSoftware.CellEditEventHandler(this.lstInvEquipment_CellEditFinishing);
            this.lstAllItems.CellEditStarting += new BrightIdeasSoftware.CellEditEventHandler(this.lstInvEquipment_CellEditStarting);
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
            this.pnlRight.Controls.Add(this.lstInvEquipment);
            this.pnlRight.Controls.Add(this.btnApplyMods);
            this.pnlRight.Controls.Add(this.btnInvRemove);
            this.pnlRight.Controls.Add(this.btnSortItems);
            this.pnlRight.Controls.Add(this.btnEnsureFood);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRight.Location = new System.Drawing.Point(0, 0);
            this.pnlRight.Margin = new System.Windows.Forms.Padding(0);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(512, 550);
            this.pnlRight.TabIndex = 6;
            // 
            // btnApplyMods
            // 
            this.btnApplyMods.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApplyMods.Location = new System.Drawing.Point(408, 524);
            this.btnApplyMods.Margin = new System.Windows.Forms.Padding(0);
            this.btnApplyMods.Name = "btnApplyMods";
            this.btnApplyMods.Padding = new System.Windows.Forms.Padding(5);
            this.btnApplyMods.Size = new System.Drawing.Size(96, 21);
            this.btnApplyMods.TabIndex = 5;
            this.btnApplyMods.Text = "Apply Mods";
            this.tooltip.SetToolTip(this.btnApplyMods, "Apply Default Mods to Items without Mods");
            this.btnApplyMods.Click += new System.EventHandler(this.btnApplyMods_Click);
            // 
            // btnSortItems
            // 
            this.btnSortItems.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSortItems.Location = new System.Drawing.Point(302, 524);
            this.btnSortItems.Margin = new System.Windows.Forms.Padding(0);
            this.btnSortItems.Name = "btnSortItems";
            this.btnSortItems.Padding = new System.Windows.Forms.Padding(5);
            this.btnSortItems.Size = new System.Drawing.Size(96, 21);
            this.btnSortItems.TabIndex = 4;
            this.btnSortItems.Text = "Sort Inventory";
            this.btnSortItems.Click += new System.EventHandler(this.btnSortItems_Click);
            // 
            // btnEnsureFood
            // 
            this.btnEnsureFood.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEnsureFood.Location = new System.Drawing.Point(196, 523);
            this.btnEnsureFood.Margin = new System.Windows.Forms.Padding(0);
            this.btnEnsureFood.Name = "btnEnsureFood";
            this.btnEnsureFood.Padding = new System.Windows.Forms.Padding(5);
            this.btnEnsureFood.Size = new System.Drawing.Size(96, 21);
            this.btnEnsureFood.TabIndex = 3;
            this.btnEnsureFood.Text = "Ensure Food";
            this.tooltip.SetToolTip(this.btnEnsureFood, "Ensure at least 25 of each Food");
            this.btnEnsureFood.Click += new System.EventHandler(this.btnEnsureFood_Click);
            // 
            // tooltip
            // 
            this.tooltip.BackColor = System.Drawing.Color.Wheat;
            // 
            // splInventory
            // 
            this.splInventory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splInventory.Location = new System.Drawing.Point(0, 0);
            this.splInventory.Margin = new System.Windows.Forms.Padding(0);
            this.splInventory.Name = "splInventory";
            // 
            // splInventory.Panel1
            // 
            this.splInventory.Panel1.Controls.Add(this.pnlLeft);
            // 
            // splInventory.Panel2
            // 
            this.splInventory.Panel2.Controls.Add(this.pnlRight);
            this.splInventory.Size = new System.Drawing.Size(780, 550);
            this.splInventory.SplitterDistance = 260;
            this.splInventory.SplitterWidth = 8;
            this.splInventory.TabIndex = 14;
            // 
            // TabInventory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splInventory);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "TabInventory";
            this.Size = new System.Drawing.Size(780, 550);
            ((System.ComponentModel.ISupportInitialize)(this.lstInvEquipment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numInvItemCount)).EndInit();
            this.pnlLeft.ResumeLayout(false);
            this.pnlLeft.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lstAllItems)).EndInit();
            this.pnlRight.ResumeLayout(false);
            this.splInventory.Panel1.ResumeLayout(false);
            this.splInventory.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splInventory)).EndInit();
            this.splInventory.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private DarkUI.Controls.DarkComboBox cboItemModifier;
        private DarkUI.Controls.DarkComboBox cboInvItemFilter;
        private DarkUI.Controls.DarkLabel label22;
        private BrightIdeasSoftware.ObjectListView lstInvEquipment;
        private DarkUI.Controls.DarkNumericUpDown numInvItemCount;
        private DarkUI.Controls.DarkLabel labelAmount;
        private DarkUI.Controls.DarkButton btnInvAdd;
        private DarkUI.Controls.DarkButton btnInvRemove;
        private BrightIdeasSoftware.ObjectListView lstAllItems;
        private BrightIdeasSoftware.OLVColumn olvColumn1;
        private DarkUI.Controls.DarkButton btnApplyMods;
        private DarkUI.Controls.DarkButton btnSortItems;
        private DarkUI.Controls.DarkButton btnEnsureFood;
        private System.Windows.Forms.ToolTip tooltip;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Panel pnlRight;
        private DarkUI.Support.DarkSplitContainer splInventory;
    }
}

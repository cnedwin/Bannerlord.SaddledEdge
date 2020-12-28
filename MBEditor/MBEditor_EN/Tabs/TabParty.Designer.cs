namespace MBEditor.Tabs
{
    partial class TabParty
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
            this.numInvGold = new DarkUI.Controls.DarkNumericUpDown();
            this.label17 = new DarkUI.Controls.DarkLabel();
            this.grpDefaultMods = new DarkUI.Controls.DarkGroupBox();
            this.lstInvMod = new BrightIdeasSoftware.ObjectListView();
            this.olvColumn1 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.txtItemModExplain = new DarkUI.Controls.DarkTextBox();
            this.spltItems = new DarkUI.Support.DarkSplitContainer();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.grpCheats = new DarkUI.Controls.DarkGroupBox();
            this.numPartyMaxPrisoners = new DarkUI.Controls.DarkNumericUpDown();
            this.numMaxPartySize = new DarkUI.Controls.DarkNumericUpDown();
            this.darkLabel3 = new DarkUI.Controls.DarkLabel();
            this.darkLabel2 = new DarkUI.Controls.DarkLabel();
            this.grpPlayer = new DarkUI.Controls.DarkGroupBox();
            this.numControversy = new DarkUI.Controls.DarkNumericUpDown();
            this.lblControversy = new DarkUI.Controls.DarkLabel();
            this.lblRenown = new DarkUI.Controls.DarkLabel();
            this.numInfluence = new DarkUI.Controls.DarkNumericUpDown();
            this.lblInfluence = new DarkUI.Controls.DarkLabel();
            this.numRenown = new DarkUI.Controls.DarkNumericUpDown();
            this.grpHotKey = new DarkUI.Controls.DarkGroupBox();
            this.btnOpenKeySave = new DarkUI.Controls.DarkButton();
            this.lblOpenShift = new DarkUI.Controls.DarkLabel();
            this.lblOpenAlt = new DarkUI.Controls.DarkLabel();
            this.lblOpenCtrl = new DarkUI.Controls.DarkLabel();
            this.lblOpenKey = new DarkUI.Controls.DarkLabel();
            this.cboOpenShift = new DarkUI.Controls.DarkComboBox();
            this.cboOpenAlt = new DarkUI.Controls.DarkComboBox();
            this.cboOpenCtrl = new DarkUI.Controls.DarkComboBox();
            this.cboOpenKey = new DarkUI.Controls.DarkComboBox();
            this.grpSiege = new DarkUI.Controls.DarkGroupBox();
            this.btnComplete = new DarkUI.Controls.DarkButton();
            this.chkPlayerSiege = new DarkUI.Controls.DarkCheckBox();
            this.txtSiegeSettlement = new DarkUI.Controls.DarkTextBox();
            this.darkLabel1 = new DarkUI.Controls.DarkLabel();
            this.tabStripDetail = new DarkUI.Controls.DarkTabControl(this.components);
            this.tabModDefault = new System.Windows.Forms.TabPage();
            this.tabDetail = new System.Windows.Forms.TabPage();
            this.darkPropertyGrid1 = new MBEditor.Controls.MBEditPropertyGrid(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.numInvGold)).BeginInit();
            this.grpDefaultMods.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lstInvMod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spltItems)).BeginInit();
            this.spltItems.Panel1.SuspendLayout();
            this.spltItems.Panel2.SuspendLayout();
            this.spltItems.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.grpCheats.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPartyMaxPrisoners)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxPartySize)).BeginInit();
            this.grpPlayer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numControversy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numInfluence)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRenown)).BeginInit();
            this.grpHotKey.SuspendLayout();
            this.grpSiege.SuspendLayout();
            this.tabStripDetail.SuspendLayout();
            this.tabModDefault.SuspendLayout();
            this.tabDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.darkPropertyGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // numInvGold
            // 
            this.numInvGold.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numInvGold.Location = new System.Drawing.Point(146, 25);
            this.numInvGold.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.numInvGold.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.numInvGold.MouseWheelIncrement = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numInvGold.Name = "numInvGold";
            this.numInvGold.Size = new System.Drawing.Size(74, 20);
            this.numInvGold.TabIndex = 1;
            this.numInvGold.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numInvGold.ValueChanged += new System.EventHandler(this.numInvGold_ValueChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.label17.Location = new System.Drawing.Point(8, 25);
            this.label17.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(32, 13);
            this.label17.TabIndex = 0;
            this.label17.Text = "Gold:";
            // 
            // grpDefaultMods
            // 
            this.grpDefaultMods.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.grpDefaultMods.Controls.Add(this.lstInvMod);
            this.grpDefaultMods.Controls.Add(this.txtItemModExplain);
            this.grpDefaultMods.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpDefaultMods.Location = new System.Drawing.Point(3, 3);
            this.grpDefaultMods.Name = "grpDefaultMods";
            this.grpDefaultMods.Size = new System.Drawing.Size(308, 515);
            this.grpDefaultMods.TabIndex = 0;
            this.grpDefaultMods.TabStop = false;
            this.grpDefaultMods.Text = "Default Item Modifications";
            // 
            // lstInvMod
            // 
            this.lstInvMod.AllColumns.Add(this.olvColumn1);
            this.lstInvMod.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstInvMod.CellEditUseWholeCell = false;
            this.lstInvMod.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumn1});
            this.lstInvMod.Cursor = System.Windows.Forms.Cursors.Default;
            this.lstInvMod.HideSelection = false;
            this.lstInvMod.Location = new System.Drawing.Point(8, 80);
            this.lstInvMod.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.lstInvMod.Name = "lstInvMod";
            this.lstInvMod.Size = new System.Drawing.Size(292, 425);
            this.lstInvMod.TabIndex = 1;
            this.lstInvMod.UseCompatibleStateImageBehavior = false;
            this.lstInvMod.View = System.Windows.Forms.View.Details;
            // 
            // olvColumn1
            // 
            this.olvColumn1.AspectName = "Name";
            this.olvColumn1.IsEditable = false;
            this.olvColumn1.MinimumWidth = 50;
            this.olvColumn1.Text = "Name";
            this.olvColumn1.UseInitialLetterForGroup = true;
            this.olvColumn1.Width = 145;
            // 
            // txtItemModExplain
            // 
            this.txtItemModExplain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtItemModExplain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.txtItemModExplain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtItemModExplain.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.txtItemModExplain.Location = new System.Drawing.Point(8, 25);
            this.txtItemModExplain.Multiline = true;
            this.txtItemModExplain.Name = "txtItemModExplain";
            this.txtItemModExplain.ReadOnly = true;
            this.txtItemModExplain.Size = new System.Drawing.Size(292, 45);
            this.txtItemModExplain.TabIndex = 0;
            this.txtItemModExplain.Text = "These modifications are used with the \"Apply Mods\" button on Inventory Page";
            this.txtItemModExplain.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // spltItems
            // 
            this.spltItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spltItems.Location = new System.Drawing.Point(0, 0);
            this.spltItems.Margin = new System.Windows.Forms.Padding(0);
            this.spltItems.Name = "spltItems";
            // 
            // spltItems.Panel1
            // 
            this.spltItems.Panel1.Controls.Add(this.pnlLeft);
            // 
            // spltItems.Panel2
            // 
            this.spltItems.Panel2.Controls.Add(this.tabStripDetail);
            this.spltItems.Size = new System.Drawing.Size(780, 550);
            this.spltItems.SplitterDistance = 450;
            this.spltItems.SplitterWidth = 8;
            this.spltItems.TabIndex = 0;
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.grpCheats);
            this.pnlLeft.Controls.Add(this.grpPlayer);
            this.pnlLeft.Controls.Add(this.grpHotKey);
            this.pnlLeft.Controls.Add(this.grpSiege);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Margin = new System.Windows.Forms.Padding(0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(450, 550);
            this.pnlLeft.TabIndex = 4;
            // 
            // grpCheats
            // 
            this.grpCheats.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.grpCheats.Controls.Add(this.numPartyMaxPrisoners);
            this.grpCheats.Controls.Add(this.numMaxPartySize);
            this.grpCheats.Controls.Add(this.darkLabel3);
            this.grpCheats.Controls.Add(this.darkLabel2);
            this.grpCheats.Location = new System.Drawing.Point(7, 223);
            this.grpCheats.Name = "grpCheats";
            this.grpCheats.Size = new System.Drawing.Size(388, 92);
            this.grpCheats.TabIndex = 3;
            this.grpCheats.TabStop = false;
            this.grpCheats.Text = "Cheats";
            // 
            // numPartyMaxPrisoners
            // 
            this.numPartyMaxPrisoners.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numPartyMaxPrisoners.Location = new System.Drawing.Point(175, 55);
            this.numPartyMaxPrisoners.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.numPartyMaxPrisoners.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.numPartyMaxPrisoners.MouseWheelIncrement = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numPartyMaxPrisoners.Name = "numPartyMaxPrisoners";
            this.numPartyMaxPrisoners.Size = new System.Drawing.Size(74, 20);
            this.numPartyMaxPrisoners.TabIndex = 7;
            this.numPartyMaxPrisoners.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numPartyMaxPrisoners.ValueChanged += new System.EventHandler(this.numPartyMaxPrisoners_ValueChanged);
            // 
            // numMaxPartySize
            // 
            this.numMaxPartySize.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numMaxPartySize.Location = new System.Drawing.Point(175, 21);
            this.numMaxPartySize.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.numMaxPartySize.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.numMaxPartySize.MouseWheelIncrement = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numMaxPartySize.Name = "numMaxPartySize";
            this.numMaxPartySize.Size = new System.Drawing.Size(74, 20);
            this.numMaxPartySize.TabIndex = 7;
            this.numMaxPartySize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numMaxPartySize.ValueChanged += new System.EventHandler(this.numMaxPartySize_ValueChanged);
            // 
            // darkLabel3
            // 
            this.darkLabel3.AutoSize = true;
            this.darkLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel3.Location = new System.Drawing.Point(16, 57);
            this.darkLabel3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.darkLabel3.Name = "darkLabel3";
            this.darkLabel3.Size = new System.Drawing.Size(107, 13);
            this.darkLabel3.TabIndex = 6;
            this.darkLabel3.Text = "Player Add Prisoners:";
            // 
            // darkLabel2
            // 
            this.darkLabel2.AutoSize = true;
            this.darkLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel2.Location = new System.Drawing.Point(16, 23);
            this.darkLabel2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.darkLabel2.Name = "darkLabel2";
            this.darkLabel2.Size = new System.Drawing.Size(97, 13);
            this.darkLabel2.TabIndex = 6;
            this.darkLabel2.Text = "Player Add Troops:";
            // 
            // grpPlayer
            // 
            this.grpPlayer.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.grpPlayer.Controls.Add(this.numInvGold);
            this.grpPlayer.Controls.Add(this.numControversy);
            this.grpPlayer.Controls.Add(this.label17);
            this.grpPlayer.Controls.Add(this.lblControversy);
            this.grpPlayer.Controls.Add(this.lblRenown);
            this.grpPlayer.Controls.Add(this.numInfluence);
            this.grpPlayer.Controls.Add(this.lblInfluence);
            this.grpPlayer.Controls.Add(this.numRenown);
            this.grpPlayer.Location = new System.Drawing.Point(3, 3);
            this.grpPlayer.Name = "grpPlayer";
            this.grpPlayer.Size = new System.Drawing.Size(392, 134);
            this.grpPlayer.TabIndex = 0;
            this.grpPlayer.TabStop = false;
            this.grpPlayer.Text = "Player";
            // 
            // numControversy
            // 
            this.numControversy.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numControversy.Location = new System.Drawing.Point(146, 101);
            this.numControversy.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.numControversy.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.numControversy.Minimum = new decimal(new int[] {
            99999999,
            0,
            0,
            -2147483648});
            this.numControversy.MouseWheelIncrement = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numControversy.Name = "numControversy";
            this.numControversy.Size = new System.Drawing.Size(74, 20);
            this.numControversy.TabIndex = 7;
            this.numControversy.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numControversy.ValueChanged += new System.EventHandler(this.numControversy_ValueChanged);
            // 
            // lblControversy
            // 
            this.lblControversy.AutoSize = true;
            this.lblControversy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.lblControversy.Location = new System.Drawing.Point(8, 101);
            this.lblControversy.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblControversy.Name = "lblControversy";
            this.lblControversy.Size = new System.Drawing.Size(66, 13);
            this.lblControversy.TabIndex = 6;
            this.lblControversy.Text = "Controversy:";
            // 
            // lblRenown
            // 
            this.lblRenown.AutoSize = true;
            this.lblRenown.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.lblRenown.Location = new System.Drawing.Point(8, 49);
            this.lblRenown.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblRenown.Name = "lblRenown";
            this.lblRenown.Size = new System.Drawing.Size(50, 13);
            this.lblRenown.TabIndex = 2;
            this.lblRenown.Text = "Renown:";
            // 
            // numInfluence
            // 
            this.numInfluence.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numInfluence.Location = new System.Drawing.Point(146, 73);
            this.numInfluence.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.numInfluence.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.numInfluence.Minimum = new decimal(new int[] {
            99999999,
            0,
            0,
            -2147483648});
            this.numInfluence.MouseWheelIncrement = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numInfluence.Name = "numInfluence";
            this.numInfluence.Size = new System.Drawing.Size(74, 20);
            this.numInfluence.TabIndex = 5;
            this.numInfluence.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numInfluence.ValueChanged += new System.EventHandler(this.numInfluence_ValueChanged);
            // 
            // lblInfluence
            // 
            this.lblInfluence.AutoSize = true;
            this.lblInfluence.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.lblInfluence.Location = new System.Drawing.Point(8, 73);
            this.lblInfluence.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblInfluence.Name = "lblInfluence";
            this.lblInfluence.Size = new System.Drawing.Size(54, 13);
            this.lblInfluence.TabIndex = 4;
            this.lblInfluence.Text = "Influence:";
            // 
            // numRenown
            // 
            this.numRenown.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numRenown.Location = new System.Drawing.Point(146, 49);
            this.numRenown.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.numRenown.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.numRenown.Minimum = new decimal(new int[] {
            99999999,
            0,
            0,
            -2147483648});
            this.numRenown.MouseWheelIncrement = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numRenown.Name = "numRenown";
            this.numRenown.Size = new System.Drawing.Size(74, 20);
            this.numRenown.TabIndex = 3;
            this.numRenown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numRenown.ValueChanged += new System.EventHandler(this.numRenown_ValueChanged);
            // 
            // grpHotKey
            // 
            this.grpHotKey.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.grpHotKey.Controls.Add(this.btnOpenKeySave);
            this.grpHotKey.Controls.Add(this.lblOpenShift);
            this.grpHotKey.Controls.Add(this.lblOpenAlt);
            this.grpHotKey.Controls.Add(this.lblOpenCtrl);
            this.grpHotKey.Controls.Add(this.lblOpenKey);
            this.grpHotKey.Controls.Add(this.cboOpenShift);
            this.grpHotKey.Controls.Add(this.cboOpenAlt);
            this.grpHotKey.Controls.Add(this.cboOpenCtrl);
            this.grpHotKey.Controls.Add(this.cboOpenKey);
            this.grpHotKey.Location = new System.Drawing.Point(7, 321);
            this.grpHotKey.Name = "grpHotKey";
            this.grpHotKey.Size = new System.Drawing.Size(388, 157);
            this.grpHotKey.TabIndex = 2;
            this.grpHotKey.TabStop = false;
            this.grpHotKey.Text = "Open Hot Key";
            // 
            // btnOpenKeySave
            // 
            this.btnOpenKeySave.Location = new System.Drawing.Point(94, 126);
            this.btnOpenKeySave.Name = "btnOpenKeySave";
            this.btnOpenKeySave.Padding = new System.Windows.Forms.Padding(5);
            this.btnOpenKeySave.Size = new System.Drawing.Size(75, 23);
            this.btnOpenKeySave.TabIndex = 3;
            this.btnOpenKeySave.Text = "Save";
            this.btnOpenKeySave.Click += new System.EventHandler(this.btnOpenKeySave_Click);
            // 
            // lblOpenShift
            // 
            this.lblOpenShift.AutoSize = true;
            this.lblOpenShift.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.lblOpenShift.Location = new System.Drawing.Point(6, 102);
            this.lblOpenShift.Name = "lblOpenShift";
            this.lblOpenShift.Size = new System.Drawing.Size(72, 13);
            this.lblOpenShift.TabIndex = 6;
            this.lblOpenShift.Text = "Shift Pressed:";
            // 
            // lblOpenAlt
            // 
            this.lblOpenAlt.AutoSize = true;
            this.lblOpenAlt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.lblOpenAlt.Location = new System.Drawing.Point(6, 77);
            this.lblOpenAlt.Name = "lblOpenAlt";
            this.lblOpenAlt.Size = new System.Drawing.Size(63, 13);
            this.lblOpenAlt.TabIndex = 4;
            this.lblOpenAlt.Text = "Alt Pressed:";
            // 
            // lblOpenCtrl
            // 
            this.lblOpenCtrl.AutoSize = true;
            this.lblOpenCtrl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.lblOpenCtrl.Location = new System.Drawing.Point(6, 51);
            this.lblOpenCtrl.Name = "lblOpenCtrl";
            this.lblOpenCtrl.Size = new System.Drawing.Size(66, 13);
            this.lblOpenCtrl.TabIndex = 2;
            this.lblOpenCtrl.Text = "Ctrl Pressed:";
            // 
            // lblOpenKey
            // 
            this.lblOpenKey.AutoSize = true;
            this.lblOpenKey.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.lblOpenKey.Location = new System.Drawing.Point(6, 19);
            this.lblOpenKey.Name = "lblOpenKey";
            this.lblOpenKey.Size = new System.Drawing.Size(28, 13);
            this.lblOpenKey.TabIndex = 0;
            this.lblOpenKey.Text = "Key:";
            // 
            // cboOpenShift
            // 
            this.cboOpenShift.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cboOpenShift.FormattingEnabled = true;
            this.cboOpenShift.Items.AddRange(new object[] {
            "No",
            "Yes",
            "Either"});
            this.cboOpenShift.Location = new System.Drawing.Point(137, 99);
            this.cboOpenShift.Name = "cboOpenShift";
            this.cboOpenShift.Size = new System.Drawing.Size(121, 21);
            this.cboOpenShift.TabIndex = 7;
            // 
            // cboOpenAlt
            // 
            this.cboOpenAlt.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cboOpenAlt.FormattingEnabled = true;
            this.cboOpenAlt.Items.AddRange(new object[] {
            "No",
            "Yes",
            "Either"});
            this.cboOpenAlt.Location = new System.Drawing.Point(137, 74);
            this.cboOpenAlt.Name = "cboOpenAlt";
            this.cboOpenAlt.Size = new System.Drawing.Size(121, 21);
            this.cboOpenAlt.TabIndex = 5;
            // 
            // cboOpenCtrl
            // 
            this.cboOpenCtrl.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cboOpenCtrl.FormattingEnabled = true;
            this.cboOpenCtrl.Items.AddRange(new object[] {
            "No",
            "Yes",
            "Either"});
            this.cboOpenCtrl.Location = new System.Drawing.Point(137, 48);
            this.cboOpenCtrl.Name = "cboOpenCtrl";
            this.cboOpenCtrl.Size = new System.Drawing.Size(121, 21);
            this.cboOpenCtrl.TabIndex = 3;
            // 
            // cboOpenKey
            // 
            this.cboOpenKey.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cboOpenKey.FormattingEnabled = true;
            this.cboOpenKey.Location = new System.Drawing.Point(137, 16);
            this.cboOpenKey.Name = "cboOpenKey";
            this.cboOpenKey.Size = new System.Drawing.Size(121, 21);
            this.cboOpenKey.TabIndex = 1;
            // 
            // grpSiege
            // 
            this.grpSiege.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.grpSiege.Controls.Add(this.btnComplete);
            this.grpSiege.Controls.Add(this.chkPlayerSiege);
            this.grpSiege.Controls.Add(this.txtSiegeSettlement);
            this.grpSiege.Controls.Add(this.darkLabel1);
            this.grpSiege.Location = new System.Drawing.Point(4, 140);
            this.grpSiege.Name = "grpSiege";
            this.grpSiege.Size = new System.Drawing.Size(391, 78);
            this.grpSiege.TabIndex = 1;
            this.grpSiege.TabStop = false;
            this.grpSiege.Text = "Active Siege";
            // 
            // btnComplete
            // 
            this.btnComplete.Location = new System.Drawing.Point(178, 52);
            this.btnComplete.Name = "btnComplete";
            this.btnComplete.Padding = new System.Windows.Forms.Padding(5);
            this.btnComplete.Size = new System.Drawing.Size(75, 23);
            this.btnComplete.TabIndex = 3;
            this.btnComplete.Text = "Finish";
            this.btnComplete.Click += new System.EventHandler(this.btnComplete_Click);
            // 
            // chkPlayerSiege
            // 
            this.chkPlayerSiege.AutoSize = true;
            this.chkPlayerSiege.Location = new System.Drawing.Point(13, 52);
            this.chkPlayerSiege.Name = "chkPlayerSiege";
            this.chkPlayerSiege.Size = new System.Drawing.Size(103, 17);
            this.chkPlayerSiege.TabIndex = 2;
            this.chkPlayerSiege.Text = "Player Attacking";
            // 
            // txtSiegeSettlement
            // 
            this.txtSiegeSettlement.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSiegeSettlement.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.txtSiegeSettlement.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSiegeSettlement.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.txtSiegeSettlement.Location = new System.Drawing.Point(178, 20);
            this.txtSiegeSettlement.Name = "txtSiegeSettlement";
            this.txtSiegeSettlement.Size = new System.Drawing.Size(207, 20);
            this.txtSiegeSettlement.TabIndex = 1;
            // 
            // darkLabel1
            // 
            this.darkLabel1.AutoSize = true;
            this.darkLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel1.Location = new System.Drawing.Point(10, 20);
            this.darkLabel1.Name = "darkLabel1";
            this.darkLabel1.Size = new System.Drawing.Size(91, 13);
            this.darkLabel1.TabIndex = 0;
            this.darkLabel1.Text = "Settlement Name:";
            // 
            // tabStripDetail
            // 
            this.tabStripDetail.Controls.Add(this.tabModDefault);
            this.tabStripDetail.Controls.Add(this.tabDetail);
            this.tabStripDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabStripDetail.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabStripDetail.HotTrack = true;
            this.tabStripDetail.Location = new System.Drawing.Point(0, 0);
            this.tabStripDetail.Name = "tabStripDetail";
            this.tabStripDetail.SelectedIndex = 0;
            this.tabStripDetail.Size = new System.Drawing.Size(322, 550);
            this.tabStripDetail.TabIndex = 0;
            this.tabStripDetail.SelectedIndexChanged += new System.EventHandler(this.tabStripDetail_SelectedIndexChanged);
            // 
            // tabModDefault
            // 
            this.tabModDefault.BackColor = System.Drawing.Color.Transparent;
            this.tabModDefault.Controls.Add(this.grpDefaultMods);
            this.tabModDefault.Location = new System.Drawing.Point(4, 25);
            this.tabModDefault.Name = "tabModDefault";
            this.tabModDefault.Padding = new System.Windows.Forms.Padding(3);
            this.tabModDefault.Size = new System.Drawing.Size(314, 521);
            this.tabModDefault.TabIndex = 0;
            this.tabModDefault.Text = "Mod Defaults";
            // 
            // tabDetail
            // 
            this.tabDetail.BackColor = System.Drawing.Color.Transparent;
            this.tabDetail.Controls.Add(this.darkPropertyGrid1);
            this.tabDetail.Location = new System.Drawing.Point(4, 25);
            this.tabDetail.Name = "tabDetail";
            this.tabDetail.Padding = new System.Windows.Forms.Padding(3);
            this.tabDetail.Size = new System.Drawing.Size(314, 521);
            this.tabDetail.TabIndex = 1;
            this.tabDetail.Text = "Detail";
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
            this.darkPropertyGrid1.Size = new System.Drawing.Size(308, 515);
            this.darkPropertyGrid1.TabIndex = 3;
            this.darkPropertyGrid1.UseAlternatingBackColors = true;
            this.darkPropertyGrid1.UseCompatibleStateImageBehavior = false;
            this.darkPropertyGrid1.UseFiltering = true;
            this.darkPropertyGrid1.UseHotControls = false;
            this.darkPropertyGrid1.View = System.Windows.Forms.View.Details;
            this.darkPropertyGrid1.VirtualMode = true;
            // 
            // TabParty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.spltItems);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "TabParty";
            this.Size = new System.Drawing.Size(780, 550);
            this.Load += new System.EventHandler(this.TabParty_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numInvGold)).EndInit();
            this.grpDefaultMods.ResumeLayout(false);
            this.grpDefaultMods.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lstInvMod)).EndInit();
            this.spltItems.Panel1.ResumeLayout(false);
            this.spltItems.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spltItems)).EndInit();
            this.spltItems.ResumeLayout(false);
            this.pnlLeft.ResumeLayout(false);
            this.grpCheats.ResumeLayout(false);
            this.grpCheats.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPartyMaxPrisoners)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxPartySize)).EndInit();
            this.grpPlayer.ResumeLayout(false);
            this.grpPlayer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numControversy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numInfluence)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRenown)).EndInit();
            this.grpHotKey.ResumeLayout(false);
            this.grpHotKey.PerformLayout();
            this.grpSiege.ResumeLayout(false);
            this.grpSiege.PerformLayout();
            this.tabStripDetail.ResumeLayout(false);
            this.tabModDefault.ResumeLayout(false);
            this.tabDetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.darkPropertyGrid1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DarkUI.Controls.DarkNumericUpDown numInvGold;
        private DarkUI.Controls.DarkLabel label17;
        private DarkUI.Controls.DarkGroupBox grpDefaultMods;
        private DarkUI.Controls.DarkTextBox txtItemModExplain;
        private BrightIdeasSoftware.ObjectListView lstInvMod;
        private BrightIdeasSoftware.OLVColumn olvColumn1;
        private DarkUI.Support.DarkSplitContainer spltItems;
        private MBEditor.Controls.MBEditPropertyGrid darkPropertyGrid1;
        private DarkUI.Controls.DarkNumericUpDown numRenown;
        private DarkUI.Controls.DarkLabel lblRenown;
        private DarkUI.Controls.DarkNumericUpDown numInfluence;
        private DarkUI.Controls.DarkLabel lblInfluence;
        private DarkUI.Controls.DarkNumericUpDown numControversy;
        private DarkUI.Controls.DarkLabel lblControversy;
        private DarkUI.Controls.DarkGroupBox grpSiege;
        private DarkUI.Controls.DarkTextBox txtSiegeSettlement;
        private DarkUI.Controls.DarkLabel darkLabel1;
        private DarkUI.Controls.DarkGroupBox grpPlayer;
        private DarkUI.Controls.DarkCheckBox chkPlayerSiege;
        private DarkUI.Controls.DarkButton btnComplete;
        private DarkUI.Controls.DarkTabControl tabStripDetail;
        private System.Windows.Forms.TabPage tabModDefault;
        private System.Windows.Forms.TabPage tabDetail;
        private DarkUI.Controls.DarkGroupBox grpHotKey;
        private DarkUI.Controls.DarkButton btnOpenKeySave;
        private DarkUI.Controls.DarkLabel lblOpenShift;
        private DarkUI.Controls.DarkLabel lblOpenAlt;
        private DarkUI.Controls.DarkLabel lblOpenCtrl;
        private DarkUI.Controls.DarkLabel lblOpenKey;
        private DarkUI.Controls.DarkComboBox cboOpenShift;
        private DarkUI.Controls.DarkComboBox cboOpenAlt;
        private DarkUI.Controls.DarkComboBox cboOpenCtrl;
        private DarkUI.Controls.DarkComboBox cboOpenKey;
        private DarkUI.Controls.DarkGroupBox grpCheats;
        private DarkUI.Controls.DarkNumericUpDown numMaxPartySize;
        private DarkUI.Controls.DarkLabel darkLabel2;
        private DarkUI.Controls.DarkNumericUpDown numPartyMaxPrisoners;
        private DarkUI.Controls.DarkLabel darkLabel3;
        private System.Windows.Forms.Panel pnlLeft;
    }
}

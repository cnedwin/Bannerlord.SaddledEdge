namespace MBEditor.Tabs.HeroTab
{
    partial class TabHeroMain
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
            this.txtFullName = new DarkUI.Controls.DarkTextBox();
            this.label1 = new DarkUI.Controls.DarkLabel();
            this.numAge = new DarkUI.Controls.DarkNumericUpDown();
            this.lblCharAge = new DarkUI.Controls.DarkLabel();
            this.numLevel = new DarkUI.Controls.DarkNumericUpDown();
            this.lblLevel = new DarkUI.Controls.DarkLabel();
            this.txtFirstName = new DarkUI.Controls.DarkTextBox();
            this.lblName = new DarkUI.Controls.DarkLabel();
            this.btnMakeSibling = new DarkUI.Controls.DarkButton();
            this.btnBodyPropsPaste = new DarkUI.Controls.DarkButton();
            this.btnBodyPropsCopy = new DarkUI.Controls.DarkButton();
            this.numFocus = new DarkUI.Controls.DarkNumericUpDown();
            this.numAttr = new DarkUI.Controls.DarkNumericUpDown();
            this.label21 = new DarkUI.Controls.DarkLabel();
            this.label20 = new DarkUI.Controls.DarkLabel();
            this.numHealth = new DarkUI.Controls.DarkNumericUpDown();
            this.label18 = new DarkUI.Controls.DarkLabel();
            this.lblActions = new DarkUI.Controls.DarkLabel();
            this.lblBodyProps = new DarkUI.Controls.DarkLabel();
            this.lblClan = new DarkUI.Controls.DarkLabel();
            this.cboClanInfo = new DarkUI.Controls.DarkComboBox();
            this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.numAge)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFocus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAttr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHealth)).BeginInit();
            this.SuspendLayout();
            // 
            // txtFullName
            // 
            this.txtFullName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFullName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.txtFullName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFullName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.txtFullName.Location = new System.Drawing.Point(79, 27);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(189, 20);
            this.txtFullName.TabIndex = 5;
            this.txtFullName.WordWrap = false;
            this.txtFullName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFullName_KeyDown);
            this.txtFullName.Leave += new System.EventHandler(this.txtFullName_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.label1.Location = new System.Drawing.Point(19, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Full Name:";
            // 
            // numAge
            // 
            this.numAge.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numAge.Location = new System.Drawing.Point(326, 2);
            this.numAge.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.numAge.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numAge.MouseWheelIncrement = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.numAge.Name = "numAge";
            this.numAge.Size = new System.Drawing.Size(82, 20);
            this.numAge.TabIndex = 3;
            this.numAge.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numAge.ValueChanged += new System.EventHandler(this.numCharAge_ValueChanged);
            // 
            // lblCharAge
            // 
            this.lblCharAge.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCharAge.AutoSize = true;
            this.lblCharAge.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.lblCharAge.Location = new System.Drawing.Point(282, 4);
            this.lblCharAge.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCharAge.Name = "lblCharAge";
            this.lblCharAge.Size = new System.Drawing.Size(29, 13);
            this.lblCharAge.TabIndex = 2;
            this.lblCharAge.Text = "Age:";
            // 
            // numLevel
            // 
            this.numLevel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numLevel.Location = new System.Drawing.Point(326, 27);
            this.numLevel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.numLevel.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numLevel.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numLevel.MouseWheelIncrement = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.numLevel.Name = "numLevel";
            this.numLevel.Size = new System.Drawing.Size(82, 20);
            this.numLevel.TabIndex = 7;
            this.ToolTip.SetToolTip(this.numLevel, "Level is based on Skill XP.  Change Skills to impact level properly.");
            this.numLevel.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numLevel.ValueChanged += new System.EventHandler(this.numLevel_ValueChanged);
            // 
            // lblLevel
            // 
            this.lblLevel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLevel.AutoSize = true;
            this.lblLevel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.lblLevel.Location = new System.Drawing.Point(282, 29);
            this.lblLevel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLevel.Name = "lblLevel";
            this.lblLevel.Size = new System.Drawing.Size(36, 13);
            this.lblLevel.TabIndex = 6;
            this.lblLevel.Text = "Level:";
            // 
            // txtFirstName
            // 
            this.txtFirstName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFirstName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.txtFirstName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFirstName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.txtFirstName.Location = new System.Drawing.Point(79, 2);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(189, 20);
            this.txtFirstName.TabIndex = 1;
            this.txtFirstName.WordWrap = false;
            this.txtFirstName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFirstName_KeyDown);
            this.txtFirstName.Leave += new System.EventHandler(this.txtFirstName_Leave);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.lblName.Location = new System.Drawing.Point(15, 6);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(60, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "First Name:";
            // 
            // btnMakeSibling
            // 
            this.btnMakeSibling.Location = new System.Drawing.Point(285, 149);
            this.btnMakeSibling.Name = "btnMakeSibling";
            this.btnMakeSibling.Padding = new System.Windows.Forms.Padding(1);
            this.btnMakeSibling.Size = new System.Drawing.Size(86, 20);
            this.btnMakeSibling.TabIndex = 18;
            this.btnMakeSibling.Text = "Make Sibling";
            this.btnMakeSibling.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnMakeSibling.Click += new System.EventHandler(this.btnMakeSibling_Click);
            // 
            // btnBodyPropsPaste
            // 
            this.btnBodyPropsPaste.Location = new System.Drawing.Point(94, 149);
            this.btnBodyPropsPaste.Name = "btnBodyPropsPaste";
            this.btnBodyPropsPaste.Padding = new System.Windows.Forms.Padding(1);
            this.btnBodyPropsPaste.Size = new System.Drawing.Size(72, 20);
            this.btnBodyPropsPaste.TabIndex = 16;
            this.btnBodyPropsPaste.Text = "Paste";
            this.btnBodyPropsPaste.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBodyPropsPaste.Click += new System.EventHandler(this.btnBodyPropsPaste_Click);
            // 
            // btnBodyPropsCopy
            // 
            this.btnBodyPropsCopy.Location = new System.Drawing.Point(3, 149);
            this.btnBodyPropsCopy.Name = "btnBodyPropsCopy";
            this.btnBodyPropsCopy.Padding = new System.Windows.Forms.Padding(1);
            this.btnBodyPropsCopy.Size = new System.Drawing.Size(73, 20);
            this.btnBodyPropsCopy.TabIndex = 15;
            this.btnBodyPropsCopy.Text = "Copy";
            this.btnBodyPropsCopy.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBodyPropsCopy.Click += new System.EventHandler(this.btnBodyPropsCopy_Click);
            // 
            // numFocus
            // 
            this.numFocus.Location = new System.Drawing.Point(212, 102);
            this.numFocus.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.numFocus.MouseWheelIncrement = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.numFocus.Name = "numFocus";
            this.numFocus.Size = new System.Drawing.Size(69, 20);
            this.numFocus.TabIndex = 13;
            this.numFocus.ValueChanged += new System.EventHandler(this.numFocus_ValueChanged);
            // 
            // numAttr
            // 
            this.numAttr.Location = new System.Drawing.Point(125, 102);
            this.numAttr.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.numAttr.MouseWheelIncrement = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.numAttr.Name = "numAttr";
            this.numAttr.Size = new System.Drawing.Size(69, 20);
            this.numAttr.TabIndex = 11;
            this.numAttr.ValueChanged += new System.EventHandler(this.numAttr_ValueChanged);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.label21.Location = new System.Drawing.Point(210, 83);
            this.label21.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(71, 13);
            this.label21.TabIndex = 12;
            this.label21.Text = "Focus Points:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.label20.Location = new System.Drawing.Point(121, 83);
            this.label20.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(81, 13);
            this.label20.TabIndex = 10;
            this.label20.Text = "Attribute Points:";
            // 
            // numHealth
            // 
            this.numHealth.Location = new System.Drawing.Point(35, 102);
            this.numHealth.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.numHealth.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numHealth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numHealth.MouseWheelIncrement = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.numHealth.Name = "numHealth";
            this.numHealth.Size = new System.Drawing.Size(69, 20);
            this.numHealth.TabIndex = 9;
            this.numHealth.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numHealth.ValueChanged += new System.EventHandler(this.numHealth_ValueChanged);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.label18.Location = new System.Drawing.Point(35, 83);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(41, 13);
            this.label18.TabIndex = 8;
            this.label18.Text = "Health:";
            // 
            // lblActions
            // 
            this.lblActions.AutoSize = true;
            this.lblActions.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.lblActions.Location = new System.Drawing.Point(282, 130);
            this.lblActions.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblActions.Name = "lblActions";
            this.lblActions.Size = new System.Drawing.Size(45, 13);
            this.lblActions.TabIndex = 17;
            this.lblActions.Text = "Actions:";
            // 
            // lblBodyProps
            // 
            this.lblBodyProps.AutoSize = true;
            this.lblBodyProps.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.lblBodyProps.Location = new System.Drawing.Point(4, 130);
            this.lblBodyProps.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBodyProps.Name = "lblBodyProps";
            this.lblBodyProps.Size = new System.Drawing.Size(84, 13);
            this.lblBodyProps.TabIndex = 14;
            this.lblBodyProps.Text = "Body Properties:";
            // 
            // lblClan
            // 
            this.lblClan.AutoSize = true;
            this.lblClan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.lblClan.Location = new System.Drawing.Point(42, 57);
            this.lblClan.Name = "lblClan";
            this.lblClan.Size = new System.Drawing.Size(31, 13);
            this.lblClan.TabIndex = 19;
            this.lblClan.Text = "Clan:";
            // 
            // cboClanInfo
            // 
            this.cboClanInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboClanInfo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cboClanInfo.Location = new System.Drawing.Point(79, 55);
            this.cboClanInfo.Name = "cboClanInfo";
            this.cboClanInfo.Size = new System.Drawing.Size(189, 21);
            this.cboClanInfo.TabIndex = 20;
            this.cboClanInfo.SelectionChangeCommitted += new System.EventHandler(this.cboClanInfo_SelectionChangeCommitted);
            // 
            // TabHeroMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.cboClanInfo);
            this.Controls.Add(this.lblClan);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblBodyProps);
            this.Controls.Add(this.lblActions);
            this.Controls.Add(this.txtFullName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numAge);
            this.Controls.Add(this.lblCharAge);
            this.Controls.Add(this.numLevel);
            this.Controls.Add(this.lblLevel);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.btnMakeSibling);
            this.Controls.Add(this.btnBodyPropsPaste);
            this.Controls.Add(this.btnBodyPropsCopy);
            this.Controls.Add(this.numFocus);
            this.Controls.Add(this.numAttr);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.numHealth);
            this.Name = "TabHeroMain";
            this.Size = new System.Drawing.Size(412, 176);
            ((System.ComponentModel.ISupportInitialize)(this.numAge)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFocus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAttr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHealth)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DarkUI.Controls.DarkLabel lblActions;
        private DarkUI.Controls.DarkNumericUpDown numAge;
        private DarkUI.Controls.DarkLabel lblCharAge;
        private DarkUI.Controls.DarkNumericUpDown numLevel;
        private DarkUI.Controls.DarkLabel lblLevel;
        private DarkUI.Controls.DarkTextBox txtFirstName;
        private DarkUI.Controls.DarkLabel lblName;
        private DarkUI.Controls.DarkButton btnMakeSibling;
        private DarkUI.Controls.DarkButton btnBodyPropsPaste;
        private DarkUI.Controls.DarkButton btnBodyPropsCopy;
        private DarkUI.Controls.DarkNumericUpDown numFocus;
        private DarkUI.Controls.DarkNumericUpDown numAttr;
        private DarkUI.Controls.DarkLabel label21;
        private DarkUI.Controls.DarkLabel label20;
        private DarkUI.Controls.DarkNumericUpDown numHealth;
        private DarkUI.Controls.DarkLabel lblBodyProps;
        private DarkUI.Controls.DarkLabel label18;
        private DarkUI.Controls.DarkTextBox txtFullName;
        private DarkUI.Controls.DarkLabel label1;
        private DarkUI.Controls.DarkLabel lblClan;
        private DarkUI.Controls.DarkComboBox cboClanInfo;
        private System.Windows.Forms.ToolTip ToolTip;
    }
}

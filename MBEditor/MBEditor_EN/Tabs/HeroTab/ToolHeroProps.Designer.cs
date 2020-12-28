namespace MBEditor.Tabs.HeroTab
{
    partial class TabHeroProps
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
            this.darkPropertyGrid1 = new MBEditor.Controls.MBEditPropertyGrid(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.darkPropertyGrid1)).BeginInit();
            this.SuspendLayout();
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
            this.darkPropertyGrid1.Location = new System.Drawing.Point(0, 0);
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
            this.darkPropertyGrid1.Size = new System.Drawing.Size(560, 242);
            this.darkPropertyGrid1.TabIndex = 0;
            this.darkPropertyGrid1.UseAlternatingBackColors = true;
            this.darkPropertyGrid1.UseCompatibleStateImageBehavior = false;
            this.darkPropertyGrid1.UseFiltering = true;
            this.darkPropertyGrid1.UseHotControls = false;
            this.darkPropertyGrid1.View = System.Windows.Forms.View.Details;
            this.darkPropertyGrid1.VirtualMode = true;
            // 
            // TabHeroProps
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.darkPropertyGrid1);
            this.DockText = "Attributes";
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "TabHeroProps";
            this.Size = new System.Drawing.Size(560, 242);
            ((System.ComponentModel.ISupportInitialize)(this.darkPropertyGrid1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MBEditor.Controls.MBEditPropertyGrid darkPropertyGrid1;
    }
}

namespace MBEditor.Tabs.HeroTab
{
    partial class TabHeroSkills
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
            this.lstItems = new BrightIdeasSoftware.ObjectListView();
            ((System.ComponentModel.ISupportInitialize)(this.lstItems)).BeginInit();
            this.SuspendLayout();
            // 
            // lstItems
            // 
            this.lstItems.CellEditUseWholeCell = false;
            this.lstItems.Cursor = System.Windows.Forms.Cursors.Default;
            this.lstItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstItems.HideSelection = false;
            this.lstItems.Location = new System.Drawing.Point(0, 0);
            this.lstItems.Name = "lstItems";
            this.lstItems.Size = new System.Drawing.Size(567, 264);
            this.lstItems.TabIndex = 44;
            this.lstItems.UseCompatibleStateImageBehavior = false;
            this.lstItems.View = System.Windows.Forms.View.Details;
            // 
            // TabHeroSkills
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lstItems);
            this.DockText = "技能";
            this.Name = "TabHeroSkills";
            this.Size = new System.Drawing.Size(567, 264);
            ((System.ComponentModel.ISupportInitialize)(this.lstItems)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private BrightIdeasSoftware.ObjectListView lstItems;
    }
}

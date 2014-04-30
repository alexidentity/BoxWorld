namespace BoxWorld {
    partial class LevelEditorForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewItem listViewItem6 = new System.Windows.Forms.ListViewItem("Wall", "wall.png");
            System.Windows.Forms.ListViewItem listViewItem7 = new System.Windows.Forms.ListViewItem("Box", "box.png");
            System.Windows.Forms.ListViewItem listViewItem8 = new System.Windows.Forms.ListViewItem("Player", "playerUp.png");
            System.Windows.Forms.ListViewItem listViewItem9 = new System.Windows.Forms.ListViewItem("Storage", "storageLocation.png");
            System.Windows.Forms.ListViewItem listViewItem10 = new System.Windows.Forms.ListViewItem(new string[] {
            "Remove"}, "remove.png", System.Drawing.Color.Empty, System.Drawing.SystemColors.Window, null);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LevelEditorForm));
            this.menuLevelEditor = new System.Windows.Forms.MenuStrip();
            this.editorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.listViewComponents = new System.Windows.Forms.ListView();
            this.imgListComponents = new System.Windows.Forms.ImageList(this.components);
            this.levelGrid = new System.Windows.Forms.TableLayoutPanel();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearLevelGrid = new System.Windows.Forms.ToolStripMenuItem();
            this.exitLevelEditor = new System.Windows.Forms.ToolStripMenuItem();
            this.helper = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLevelEditor.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuLevelEditor
            // 
            this.menuLevelEditor.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editorToolStripMenuItem,
            this.helper});
            this.menuLevelEditor.Location = new System.Drawing.Point(0, 0);
            this.menuLevelEditor.Name = "menuLevelEditor";
            this.menuLevelEditor.Size = new System.Drawing.Size(451, 24);
            this.menuLevelEditor.TabIndex = 0;
            this.menuLevelEditor.Text = "menuStrip1";
            // 
            // editorToolStripMenuItem
            // 
            this.editorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.clearLevelGrid,
            this.toolStripMenuItem1,
            this.exitLevelEditor});
            this.editorToolStripMenuItem.Image = global::BoxWorld.Properties.Resources.edit;
            this.editorToolStripMenuItem.Name = "editorToolStripMenuItem";
            this.editorToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.editorToolStripMenuItem.Text = "Editor";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(149, 6);
            // 
            // listViewComponents
            // 
            this.listViewComponents.Dock = System.Windows.Forms.DockStyle.Right;
            listViewItem6.StateImageIndex = 0;
            listViewItem6.Tag = "wall";
            listViewItem7.Tag = "box";
            listViewItem8.Tag = "player";
            listViewItem9.Tag = "storage";
            listViewItem10.Tag = "empty";
            this.listViewComponents.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem6,
            listViewItem7,
            listViewItem8,
            listViewItem9,
            listViewItem10});
            this.listViewComponents.LargeImageList = this.imgListComponents;
            this.listViewComponents.Location = new System.Drawing.Point(342, 24);
            this.listViewComponents.MultiSelect = false;
            this.listViewComponents.Name = "listViewComponents";
            this.listViewComponents.Scrollable = false;
            this.listViewComponents.Size = new System.Drawing.Size(109, 342);
            this.listViewComponents.TabIndex = 1;
            this.listViewComponents.UseCompatibleStateImageBehavior = false;
            this.listViewComponents.View = System.Windows.Forms.View.Tile;
            // 
            // imgListComponents
            // 
            this.imgListComponents.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgListComponents.ImageStream")));
            this.imgListComponents.TransparentColor = System.Drawing.Color.Transparent;
            this.imgListComponents.Images.SetKeyName(0, "wall.png");
            this.imgListComponents.Images.SetKeyName(1, "box.png");
            this.imgListComponents.Images.SetKeyName(2, "playerUp.png");
            this.imgListComponents.Images.SetKeyName(3, "storageLocation.png");
            this.imgListComponents.Images.SetKeyName(4, "remove.png");
            // 
            // levelGrid
            // 
            this.levelGrid.AutoSize = true;
            this.levelGrid.BackColor = System.Drawing.Color.LemonChiffon;
            this.levelGrid.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.levelGrid.ColumnCount = 10;
            this.levelGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.levelGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.levelGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.levelGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.levelGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.levelGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.levelGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.levelGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.levelGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.levelGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.levelGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.levelGrid.Cursor = System.Windows.Forms.Cursors.Cross;
            this.levelGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.levelGrid.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.levelGrid.Location = new System.Drawing.Point(0, 24);
            this.levelGrid.Margin = new System.Windows.Forms.Padding(0);
            this.levelGrid.Name = "levelGrid";
            this.levelGrid.RowCount = 10;
            this.levelGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.levelGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.levelGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.levelGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.levelGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.levelGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.levelGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.levelGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.levelGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.levelGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.levelGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.levelGrid.Size = new System.Drawing.Size(342, 342);
            this.levelGrid.TabIndex = 2;
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Image = global::BoxWorld.Properties.Resources.load;
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Image = global::BoxWorld.Properties.Resources.save;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // clearLevelGrid
            // 
            this.clearLevelGrid.Image = global::BoxWorld.Properties.Resources.clear;
            this.clearLevelGrid.Name = "clearLevelGrid";
            this.clearLevelGrid.Size = new System.Drawing.Size(152, 22);
            this.clearLevelGrid.Text = "Clear";
            this.clearLevelGrid.Click += new System.EventHandler(this.clearLevelGrid_Click);
            // 
            // exitLevelEditor
            // 
            this.exitLevelEditor.Image = global::BoxWorld.Properties.Resources.quit;
            this.exitLevelEditor.Name = "exitLevelEditor";
            this.exitLevelEditor.Size = new System.Drawing.Size(152, 22);
            this.exitLevelEditor.Text = "Quit";
            this.exitLevelEditor.Click += new System.EventHandler(this.exitLevelEditor_Click);
            // 
            // helper
            // 
            this.helper.Image = global::BoxWorld.Properties.Resources.information;
            this.helper.Name = "helper";
            this.helper.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.helper.Size = new System.Drawing.Size(70, 20);
            this.helper.Text = "Helper";
            this.helper.Click += new System.EventHandler(this.helper_Click);
            // 
            // LevelEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 366);
            this.Controls.Add(this.levelGrid);
            this.Controls.Add(this.listViewComponents);
            this.Controls.Add(this.menuLevelEditor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuLevelEditor;
            this.MaximizeBox = false;
            this.Name = "LevelEditorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BoxWorld - Level Editor";
            this.menuLevelEditor.ResumeLayout(false);
            this.menuLevelEditor.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuLevelEditor;
        private System.Windows.Forms.ToolStripMenuItem editorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitLevelEditor;
        private System.Windows.Forms.ToolStripMenuItem helper;
        private System.Windows.Forms.ListView listViewComponents;
        private System.Windows.Forms.ImageList imgListComponents;
        private System.Windows.Forms.TableLayoutPanel levelGrid;
        private System.Windows.Forms.ToolStripMenuItem clearLevelGrid;
    }
}
namespace BoxWorld {
    partial class MainMenuForm {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenuForm));
            this.label1 = new System.Windows.Forms.Label();
            this.btnPlayLevel = new System.Windows.Forms.Button();
            this.btnLevelEditor = new System.Windows.Forms.Button();
            this.btnRefreshLevels = new System.Windows.Forms.Button();
            this.lbLevels = new System.Windows.Forms.ListBox();
            this.btnQuit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "<Box World>";
            // 
            // btnPlayLevel
            // 
            this.btnPlayLevel.Location = new System.Drawing.Point(12, 225);
            this.btnPlayLevel.Name = "btnPlayLevel";
            this.btnPlayLevel.Size = new System.Drawing.Size(195, 23);
            this.btnPlayLevel.TabIndex = 1;
            this.btnPlayLevel.Text = "Play Level";
            this.btnPlayLevel.UseVisualStyleBackColor = true;
            this.btnPlayLevel.Click += new System.EventHandler(this.btnPlayLevel_Click);
            // 
            // btnLevelEditor
            // 
            this.btnLevelEditor.Location = new System.Drawing.Point(12, 254);
            this.btnLevelEditor.Name = "btnLevelEditor";
            this.btnLevelEditor.Size = new System.Drawing.Size(195, 23);
            this.btnLevelEditor.TabIndex = 2;
            this.btnLevelEditor.Text = "Level Editor";
            this.btnLevelEditor.UseVisualStyleBackColor = true;
            this.btnLevelEditor.Click += new System.EventHandler(this.btnLevelEditor_Click);
            // 
            // btnRefreshLevels
            // 
            this.btnRefreshLevels.Location = new System.Drawing.Point(12, 283);
            this.btnRefreshLevels.Name = "btnRefreshLevels";
            this.btnRefreshLevels.Size = new System.Drawing.Size(96, 23);
            this.btnRefreshLevels.TabIndex = 3;
            this.btnRefreshLevels.Text = "Refresh Levels";
            this.btnRefreshLevels.UseVisualStyleBackColor = true;
            this.btnRefreshLevels.Click += new System.EventHandler(this.btnRefreshLevels_Click);
            // 
            // lbLevels
            // 
            this.lbLevels.BackColor = System.Drawing.Color.PapayaWhip;
            this.lbLevels.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbLevels.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLevels.FormattingEnabled = true;
            this.lbLevels.ItemHeight = 25;
            this.lbLevels.Location = new System.Drawing.Point(12, 44);
            this.lbLevels.Name = "lbLevels";
            this.lbLevels.ScrollAlwaysVisible = true;
            this.lbLevels.Size = new System.Drawing.Size(195, 175);
            this.lbLevels.TabIndex = 5;
            // 
            // btnQuit
            // 
            this.btnQuit.Location = new System.Drawing.Point(111, 283);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(96, 23);
            this.btnQuit.TabIndex = 6;
            this.btnQuit.Text = "Quit";
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // MainMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSalmon;
            this.ClientSize = new System.Drawing.Size(219, 311);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.lbLevels);
            this.Controls.Add(this.btnRefreshLevels);
            this.Controls.Add(this.btnLevelEditor);
            this.Controls.Add(this.btnPlayLevel);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainMenuForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BoxWorld Menu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnPlayLevel;
        private System.Windows.Forms.Button btnLevelEditor;
        private System.Windows.Forms.Button btnRefreshLevels;
        private System.Windows.Forms.ListBox lbLevels;
        private System.Windows.Forms.Button btnQuit;

    }
}


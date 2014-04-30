using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Media;

namespace BoxWorld {

    public partial class MainMenuForm : Form {

        public MainMenuForm() {
            InitializeComponent();
            refreshLevelsList();
        }

        private void btnPlayLevel_Click(object sender, EventArgs e) {

            if (lbLevels.SelectedIndex == -1) {
                MessageBox.Show("Please select a level first!", "Information",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            FileInfo selectedLevelPath = (FileInfo)lbLevels.SelectedItem;

            string line = "";
            string loadedFileName = selectedLevelPath.FullName;

            string[,] selectedLevel = new string[10, 10];

            using (StreamReader sr = new StreamReader(loadedFileName)) {
                int row = 0;
                while ((line = sr.ReadLine()) != null) {
                    int column = 0;

                    foreach (char c in line) {
                        selectedLevel[row, column] = c.ToString();
                        column++;
                    }

                    row++;
                }
            }

            GameForm gameForm = new GameForm(selectedLevel);
            DialogResult dialogResult = gameForm.ShowDialog();
        }

        private void btnLevelEditor_Click(object sender, EventArgs e) {
            LevelEditorForm levelEditorForm = new LevelEditorForm();
            levelEditorForm.ShowDialog();
            refreshLevelsList();
        }

        private void btnRefreshLevels_Click(object sender, EventArgs e) {
            refreshLevelsList();
        }

        public void refreshLevelsList() {
            lbLevels.Items.Clear();

            DirectoryInfo directoryInfo = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
            FileInfo[] levels = directoryInfo.GetFiles("*.lvl");

            foreach (FileInfo level in levels) {
                lbLevels.Items.Add(level);
                lbLevels.DisplayMember = level.Name;
            }
        }

        private void btnQuit_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}

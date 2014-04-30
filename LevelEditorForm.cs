using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.Media;

namespace BoxWorld {

    public partial class LevelEditorForm : Form {

        public static string DIALOG_DIRECTORY = AppDomain.CurrentDomain.BaseDirectory;
        public static string DIALOG_FILTER = "BoxWorld Level (*.lvl)|*.lvl";

        public LevelEditorForm() {
            InitializeComponent();
            initialiseLevelGrid();
            listViewComponents.Items[0].Selected = true;
        }

        private void initialiseLevelGrid() {
            int pictureIndex = 0;
            for (int row = 0; row < 10; row++) {
                for (int column = 0; column < levelGrid.ColumnCount; column++) {
                    PictureBox pictureBox = new PictureBox();
                    pictureBox.BackColor = Color.Cornsilk;
                    pictureBox.Size = new Size(32, 32);
                    pictureBox.Margin = new Padding(0);

                    if (row == 0 || row == 9 || column == 0 || column == 9) {
                        pictureBox.Image = Properties.Resources.wall;
                        pictureBox.Tag = "wall";
                    } else {
                        pictureBox.Click += new EventHandler(pictureBoxClickEventHandler);
                        pictureBox.Tag = "empty";
                    }
                    
                    pictureIndex++;
                    levelGrid.Controls.Add(pictureBox, row, column);
                }
            }
        }

        private void pictureBoxClickEventHandler(object sender, EventArgs e) {
            PictureBox clickedPictureBox = sender as PictureBox;
            int row = levelGrid.GetPositionFromControl(clickedPictureBox).Row;
            int column = levelGrid.GetPositionFromControl(clickedPictureBox).Column;

            bool oneItemSelected = false;
            foreach (ListViewItem item in listViewComponents.Items) {
                if (item.Selected == true) {
                    oneItemSelected = true;
                }
            }

            if (!oneItemSelected) {
                MessageBox.Show("Please choose a component from the list!", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            ListViewItem selectedItem = listViewComponents.SelectedItems[0];

            string pictureTag = selectedItem.Tag.ToString();
            PictureBox pictureBox = new PictureBox();

            if ("wall".Equals(pictureTag)) {
                pictureBox.Image = Properties.Resources.wall;
            } else if ("box".Equals(pictureTag)) {
                pictureBox.Image = Properties.Resources.box;
            } else if ("player".Equals(pictureTag)) {
                pictureBox.Image = Properties.Resources.playerUp;
            } else if ("storage".Equals(pictureTag)) {
                pictureBox.Image = Properties.Resources.storageLocation;
            } else {
                pictureBox.BackColor = Color.Cornsilk;
            }

            pictureBox.Tag = pictureTag;
            pictureBox.Size = new Size(32, 32);
            pictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox.Margin = new Padding(0);
            pictureBox.Click += new EventHandler(pictureBoxClickEventHandler);
            levelGrid.Controls.Remove(clickedPictureBox);
            levelGrid.Controls.Add(pictureBox, column, row);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e) {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = DIALOG_DIRECTORY;
            saveFileDialog.FileName = "MyLevel";
            saveFileDialog.Filter = DIALOG_FILTER;
            DialogResult dialogResult = saveFileDialog.ShowDialog(this);

            if (dialogResult == System.Windows.Forms.DialogResult.OK) {
                StreamWriter streamWriter = new StreamWriter(saveFileDialog.FileName);

                int numberOfPlayers = 0;
                int numberOfBoxes = 0;
                int numberOfStorageLocations = 0;

                int maxRows = levelGrid.RowCount;
                int maxColumns = levelGrid.ColumnCount;
                for (int row = 0; row < maxRows; row++) {
                    for (int col = 0; col < maxColumns; col++) {
                        PictureBox currentPictureBox = (PictureBox)levelGrid.GetControlFromPosition(col, row);
                        if ("wall".Equals(currentPictureBox.Tag.ToString())) {
                            streamWriter.Write("#");
                        } else if ("box".Equals(currentPictureBox.Tag.ToString())) {
                            streamWriter.Write("b");
                            numberOfBoxes++;
                        } else if ("player".Equals(currentPictureBox.Tag.ToString())) {
                            streamWriter.Write("p");
                            numberOfPlayers++;
                        } else if ("storage".Equals(currentPictureBox.Tag.ToString())) {
                            streamWriter.Write("@");
                            numberOfStorageLocations++;
                        } else {
                            streamWriter.Write("_");
                        }
                    }
                    streamWriter.WriteLine();
                }
                streamWriter.Close();

                StringBuilder stringBuilder = new StringBuilder();

                if (numberOfPlayers != 1) {
                    stringBuilder.Append("- The level must contain only one player!\n");
                }

                if (numberOfBoxes == 0 || numberOfStorageLocations == 0) {
                    stringBuilder.Append("- The level must have at least one box and storage location!\n");
                }

                if (numberOfBoxes != numberOfStorageLocations) {
                    stringBuilder.Append("- The level must have equal number of boxes and storage locations!\n");
                }

                string warningMessages = stringBuilder.ToString().Trim();
                if (!"".Equals(warningMessages)) {
                    MessageBox.Show(warningMessages, "Information",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    File.Delete(@saveFileDialog.FileName);
                }
            }
         }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e) {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = DIALOG_DIRECTORY;
            openFileDialog.Filter = DIALOG_FILTER;
            DialogResult dialogResult = openFileDialog.ShowDialog();

            if (dialogResult == System.Windows.Forms.DialogResult.OK) {
                levelGrid.Visible = false;
                levelGrid.Controls.Clear();

                string line = "";
                string loadedFileName = openFileDialog.FileName;

                using (StreamReader sr = new StreamReader(loadedFileName)) {
                    int row = 0;
                    while ((line = sr.ReadLine()) != null) {
                        int column = 0;
                        foreach (char c in line) {
                            PictureBox pictureBox = new PictureBox();

                            if (c == '#') {
                                pictureBox.Image = Properties.Resources.wall;
                                pictureBox.Tag = "wall";
                            } else if (c == 'p') {
                                pictureBox.Image = Properties.Resources.playerUp;
                                pictureBox.Tag = "player";
                            } else if (c == 'b') {
                                pictureBox.Image = Properties.Resources.box;
                                pictureBox.Tag = "box";
                            } else if (c == '@') {
                                pictureBox.Image = Properties.Resources.storageLocation;
                                pictureBox.Tag = "storage";
                            } else {
                                pictureBox.BackColor = Color.Cornsilk;
                                pictureBox.Tag = "empty";
                            }

                            pictureBox.Size = new Size(32, 32);
                            pictureBox.Margin = new Padding(0);
                            pictureBox.Click += new EventHandler(pictureBoxClickEventHandler);
                            levelGrid.Controls.Add(pictureBox, column, row);

                            column++;
                        }

                        row++;
                    }
                }
                levelGrid.Visible = true;
            }          
        }

        private void clearLevelGrid_Click(object sender, EventArgs e) {
            levelGrid.Visible = false;
            levelGrid.Controls.Clear();
            initialiseLevelGrid();
            levelGrid.Visible = true;
        }

        private void helper_Click(object sender, EventArgs e) {
            System.Diagnostics.Process.Start("https://github.com/alexidentity/BoxWorld#level-editor");
        }

        private void exitLevelEditor_Click(object sender, EventArgs e) {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
    }
}

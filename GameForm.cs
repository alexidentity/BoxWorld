using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BoxWorld {

    public partial class GameForm : Form {

        public Level level { get; set; }
        public string[,] originalLevel { get; set; }

        public GameForm(string[,] selectedLevel) {
            InitializeComponent();
            originalLevel = new string[10, 10];

            for (int row = 0; row < 10; row++) {
                for (int column = 0; column < 10; column++) {
                    originalLevel[row, column] = selectedLevel[row, column];
                }
            }

            initialiseLevel(selectedLevel);
        }

        public void initialiseLevel(string[,] selectedLevel) {
            level = new Level(screen, selectedLevel);
            level.drawScreenGrid();
        }

        private void GameForm_KeyDown(object sender, KeyEventArgs e) {
            playerMovement(e);
        }

        public void playerMovement(KeyEventArgs e) {
            if (e.KeyCode == Keys.Up) {
                level.movePlayerUp();
            }
            if (e.KeyCode == Keys.Down) {
                level.movePlayerDown();
            }
            if (e.KeyCode == Keys.Right) {
                level.movePlayerRight();  
            }
            if (e.KeyCode == Keys.Left) {
                level.movePlayerLeft();
            }

            if (level.isWon()) {
                MessageBox.Show("You did it, now select another level! :)", "Splendid!");
                this.DialogResult = System.Windows.Forms.DialogResult.Yes;
            }
        }

        private void restartLevel_Click(object sender, EventArgs e) {
            string[,] selectedLevel = new string[10, 10];

            for (int row = 0; row < 10; row++) {
                for (int column = 0; column < 10; column++) {
                    selectedLevel[row, column] = originalLevel[row, column];
                }
            }

            screen.Visible = false;
            initialiseLevel(selectedLevel);
            screen.Visible = true;
        }

        private void quitLevel_Click(object sender, EventArgs e) {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
    }
}

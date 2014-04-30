using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace BoxWorld {

    public class Level {
        public string[,] levelMatrix { get; set; }

        public Player player { get; set; }
        public PictureBox playerImage { get; set; }

        public List<StorageLocation> storageLocations { get; set; }

        public TableLayoutPanel screen { get; set; }

        public Level(TableLayoutPanel screen, string[,] selectedLevel) {
            levelMatrix = selectedLevel;
            this.screen = screen;
            initialisePlayerImage();
            setCurrentPositionForPlayerAndStorageLocations();
        }

        public void initialisePlayerImage() {
            playerImage = createAnEmptyPictureBox();
            playerImage.Image = Properties.Resources.playerUp;
        }

        public PictureBox createAnEmptyPictureBox() {
            PictureBox emptyPictureBox = new PictureBox();
            emptyPictureBox.Size = new Size(32, 32);
            emptyPictureBox.Margin = new Padding(0);
            emptyPictureBox.BackColor = Color.Cornsilk;

            return emptyPictureBox;
        }

        public bool isWon() {
            foreach (StorageLocation sl in storageLocations) {

                if (levelMatrix[sl.row, sl.column] != "b") {
                    return false;
                }
            }

            return true;
        }

        public void setCurrentPositionForPlayerAndStorageLocations() {
            int length = levelMatrix.GetLength(0);
            player = new Player();
            storageLocations = new List<StorageLocation>();

            for (int row = 0; row < length; row++) {
                for (int column = 0; column < length; column++) {
                    if (levelMatrix[row, column].Equals("p")) {
                        player.row = row;
                        player.column = column;
                    }

                    if (levelMatrix[row, column].Equals("@")) {
                        StorageLocation storageLocation = new StorageLocation();
                        storageLocation.row = row;
                        storageLocation.column = column;
                        storageLocations.Add(storageLocation);
                    }
                }
            }
        }

        public void drawScreenGrid() {
            int length = levelMatrix.GetLength(0);
            screen.Controls.Clear();

            for (int row = 0; row < length; row++) {
                for (int column = 0; column < length; column++) {
                    PictureBox pictureBox = createAnEmptyPictureBox();

                    if (levelMatrix[row, column].Equals("#")) {
                        pictureBox.Image = Properties.Resources.wall;
                    } else if (levelMatrix[row, column].Equals("p")) {
                        pictureBox = playerImage;
                    } else if (levelMatrix[row, column].Equals("b")) {
                        pictureBox.Image = Properties.Resources.box;
                    } else if (levelMatrix[row, column].Equals("@")) {
                        pictureBox.BackColor = Color.Coral;
                        pictureBox.BorderStyle = BorderStyle.Fixed3D;
                        levelMatrix[row, column] = "_";
                    }

                    drawControlOnScreen(pictureBox, column, row);
                }
            }
        }

        public bool isInList(int row, int column) {
            foreach (StorageLocation sl in storageLocations) {
                if (sl.row == row && sl.column == column) {
                    return true;
                }
            }

            return false;
        }

        public void drawControlOnScreen(PictureBox pb, int column, int row) {
            pb.BackColor = Color.Cornsilk;
            pb.BorderStyle = BorderStyle.None;

            if (isInList(row, column)) {
                pb.BackColor = Color.Coral;
                pb.BorderStyle = BorderStyle.Fixed3D;
            } 

            screen.Controls.Add(pb, column, row);
        }

        public void movePlayerUp() {
            playerImage.Image = Properties.Resources.playerUp;
            if (levelMatrix[player.row - 1, player.column] == "_") {

                levelMatrix[player.row, player.column] = "_";
                levelMatrix[player.row - 1, player.column] = "p";

                PictureBox pbEmpty = (PictureBox)screen.GetControlFromPosition(player.column, player.row - 1);
                screen.Controls.Remove(pbEmpty);
                screen.Controls.Remove(playerImage);

                drawControlOnScreen(playerImage, player.column, player.row - 1);
                drawControlOnScreen(createAnEmptyPictureBox(), player.column, player.row);

                player.row -= 1;
            } else if (levelMatrix[player.row - 1, player.column] == "b"
                && levelMatrix[player.row - 2, player.column] == "_") {

                levelMatrix[player.row, player.column] = "_";
                levelMatrix[player.row - 1, player.column] = "p";
                levelMatrix[player.row - 2, player.column] = "b";

                PictureBox pbBox = (PictureBox)screen.GetControlFromPosition(player.column, player.row - 1);
                PictureBox pbEmpty = (PictureBox)screen.GetControlFromPosition(player.column, player.row - 2);
                screen.Controls.Remove(pbBox);
                screen.Controls.Remove(playerImage);
                screen.Controls.Remove(pbEmpty);
                drawControlOnScreen(pbBox, player.column, player.row - 2);
                drawControlOnScreen(playerImage, player.column, player.row - 1);
                drawControlOnScreen(createAnEmptyPictureBox(), player.column, player.row);

                player.row -= 1;
            }
        }

        public void movePlayerDown() {
            playerImage.Image = Properties.Resources.playerDown;
            if (levelMatrix[player.row + 1, player.column] == "_") {

                levelMatrix[player.row, player.column] = "_";
                levelMatrix[player.row + 1, player.column] = "p";

                PictureBox pbEmpty = (PictureBox)screen.GetControlFromPosition(player.column, player.row + 1);
                screen.Controls.Remove(pbEmpty);
                screen.Controls.Remove(playerImage);
                drawControlOnScreen(createAnEmptyPictureBox(), player.column, player.row);
                drawControlOnScreen(playerImage, player.column, player.row + 1);

                player.row += 1;
            } else if (levelMatrix[player.row + 1, player.column] == "b"
                && levelMatrix[player.row + 2, player.column] == "_") {

                levelMatrix[player.row, player.column] = "_";
                levelMatrix[player.row + 1, player.column] = "p";
                levelMatrix[player.row + 2, player.column] = "b";

                PictureBox pbBox = (PictureBox)screen.GetControlFromPosition(player.column, player.row + 1);
                PictureBox pbEmpty = (PictureBox)screen.GetControlFromPosition(player.column, player.row + 2);
                screen.Controls.Remove(pbBox);
                screen.Controls.Remove(playerImage);
                screen.Controls.Remove(pbEmpty);
                drawControlOnScreen(createAnEmptyPictureBox(), player.column, player.row);
                drawControlOnScreen(playerImage, player.column, player.row + 1);
                drawControlOnScreen(pbBox, player.column, player.row + 2);

                player.row += 1;
            }
        }

        public void movePlayerLeft() {
            playerImage.Image = Properties.Resources.playerLeft;
            if (levelMatrix[player.row, player.column - 1] == "_") {

                levelMatrix[player.row, player.column] = "_";
                levelMatrix[player.row, player.column - 1] = "p";

                PictureBox pbEmpty = (PictureBox)screen.GetControlFromPosition(player.column - 1, player.row);
                screen.Controls.Remove(pbEmpty);
                screen.Controls.Remove(playerImage);
                drawControlOnScreen(playerImage, player.column - 1, player.row);
                drawControlOnScreen(createAnEmptyPictureBox(), player.column, player.row);

                player.column -= 1;
            } else if (levelMatrix[player.row, player.column - 1] == "b"
                && levelMatrix[player.row, player.column - 2] == "_") {

                levelMatrix[player.row, player.column] = "_";
                levelMatrix[player.row, player.column - 1] = "p";
                levelMatrix[player.row, player.column - 2] = "b";

                PictureBox pbBox = (PictureBox)screen.GetControlFromPosition(player.column - 1, player.row);
                PictureBox pbEmpty = (PictureBox)screen.GetControlFromPosition(player.column - 2, player.row);
                screen.Controls.Remove(pbBox);
                screen.Controls.Remove(playerImage);
                screen.Controls.Remove(pbEmpty);
                drawControlOnScreen(pbBox, player.column - 2, player.row);
                drawControlOnScreen(playerImage, player.column - 1, player.row);
                drawControlOnScreen(createAnEmptyPictureBox(), player.column, player.row);

                player.column -= 1;
            }
        }

        public void movePlayerRight() {
            playerImage.Image = Properties.Resources.playerRight;
            if (levelMatrix[player.row, player.column + 1] == "_") {

                levelMatrix[player.row, player.column] = "_";
                levelMatrix[player.row, player.column + 1] = "p";

                PictureBox pbEmpty = (PictureBox)screen.GetControlFromPosition(player.column + 1, player.row);
                screen.Controls.Remove(pbEmpty);
                screen.Controls.Remove(playerImage);
                drawControlOnScreen(createAnEmptyPictureBox(), player.column, player.row);
                drawControlOnScreen(playerImage, player.column + 1, player.row);

                player.column += 1;
            } else if (levelMatrix[player.row, player.column + 1] == "b"
                && levelMatrix[player.row, player.column + 2] == "_") {

                levelMatrix[player.row, player.column] = "_";
                levelMatrix[player.row, player.column + 1] = "p";
                levelMatrix[player.row, player.column + 2] = "b";

                PictureBox pbBox = (PictureBox)screen.GetControlFromPosition(player.column + 1, player.row);
                PictureBox pbEmpty = (PictureBox)screen.GetControlFromPosition(player.column + 2, player.row);
                screen.Controls.Remove(pbBox);
                screen.Controls.Remove(playerImage);
                screen.Controls.Remove(pbEmpty);
                drawControlOnScreen(createAnEmptyPictureBox(), player.column, player.row);
                drawControlOnScreen(playerImage, player.column + 1, player.row);
                drawControlOnScreen(pbBox, player.column + 2, player.row);
                
                player.column += 1;
            }
        }
    }
}

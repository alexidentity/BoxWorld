Box World
======================

Оваа игра треба да е реплика на играта [Sōkoban](http://en.wikipedia.org/wiki/Sokoban), направена од Hiroyuki Imabayashi во 1981 година.

Опис на играта
--------------

**Box World** е игра од тип на [Transport puzzle](http://en.wikipedia.org/wiki/Transport_puzzle) каде што играчот турка пакети низ магацинот и треба да ги однесе до локациите за складирање.

> **Појаснување:**
> 
> - Играта е реализирана со помош на матрица од квадратчиња.
> - Секое квадратче е или под или ѕид.
> - Некои квадратчиња на подот содржат пакети, а некои се маркирани како локација за складирање.
> - Играчот е ограничен во матрицата и може да се движи хоризонтално или вертикално низ празните квадратчиња.
> - Играчот не може да оди преку пакети или ѕидови.
> - Пакетите не може да се туркаат ако пред пакетот има ѕид или друг пакет. Исто така пакетите не може да се тргаат.
> - Одредена загатка (мапа) се смета за решена ако сите пакети се на локациите за складирање.

Level Editor
------------

**Level Editor** е алатка која овозможува дизајнирање на загатки (мапи). Оваа игра има интегриран level editor.

> **Компоненти за работа:**
>
> - ![wall-tile-img][1] Wall (Ѕид)
> - ![box-img][2] Box (Пакет)
> - ![player-up-img][3] Player (Играч)
> - ![storage-location-img][4] Storage (Локација за складирање)
> - ![remove-img][5] Remove (Отстрани)

Дизајнирањето на мапи со едиторот е многу едноставно. Од листата десно се избира посакуваната компонента и со кликнување на одредени полиња во матрицата, тие се пополнуваат со селектираната компонента. Едиторот е прикажан на следната слика:

> **Горното мени се состои од:**
>
> - Load - Отворање на постоечка мапа со .lvl наставката
(Како изгледа една ваква датотека е прикажано подолу)
> - Save - Зачувување на моментално креираната мапа.
> - Clear - Ја брише моментално креираната мапа.
> - Exit - Го исклучува едиторот.

Во игра | Датотека
--- | ---
![level2][6] | ![level2File][7]

Структура на кодот
==================

#### Player.cs

```C#
public class Player {
    public int row { get; set; }
    public int column { get; set; }
}
```

Во оваа класа се чуваат само броевите на редицата и колоната каде што се наоѓа играчот.

#### Level.cs

```C#
// Метод за движење и цртање на екран

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
```

Кога корисникот ќе ја притисне стрелката за нагоре се повикува методот прикажан погоре каде што проверува дали над играчот е празно место или има пакет и после пакетот има празно место. Само тогаш ја изменуваме матрицата соодветно горе, долу, лево или десно и ја освежуваме панелата според тие промени.

Форми
-----

#### MainForm.cs

```C#
// Методот за ажурирање на мапите

public void refreshLevelsList() {
    lbLevels.Items.Clear();

    DirectoryInfo directoryInfo = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
    FileInfo[] levels = directoryInfo.GetFiles("*.lvl");

    foreach (FileInfo level in levels) {
        lbLevels.Items.Add(level.Name);
    }
}
```
Овој метод го зема директориумот на моменталната локација на извршната датотека, потоа во низа од FileInfo се сместуваат сите датотеки што имаат наставка (*.lvl). И датотеките се ставаат во листата.

<p align="center">
  <img src="http://i.imgur.com/rOLYzEN.png" />
</p>

#### GameForm.cs

```C#
// Методот за манипулација со типките од тастатурата и рестарт на избраната мапа

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
```
Во настанот KeyDown на самата форма се повикува методот playerMovement со KeyEventArgs. Во методот playerMovement се проверува дали се притиснала некоја стрелка и соодветно се повикува од класата Level методот за движење.
Методот за рестартирање прави нова матрица, ја пополнуваме според одбраната мапа и се повикува методот за иницијализација на мапа со ново креираната матрица.
<p align="center">
  <img src="http://i.imgur.com/IUobSLz.png" />
</p>

#### LevelEditorForm.cs

```C#
// Медоти за иницијализација на матрицата, зачувување и вчитување на мапа

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
```

При иницијализација на формата се повикува и методот за иницијализација на матрицата. Се изминуваат сите редици и колони, и во секоја ќелија се генерира нова слика (PictureBox) со одредени конфигурации и се додава настан на при кликнување на сликата.

По краевите на матрицата се додава ѕид и за него не се генерира настан.
Прво во методот за настанот при кликнување на сликата се изминува листата од компоненти за работа и во променливата oneItemSelected се чува true или false соодветно. Ако корисникот не селектирал ништо од листата да се испише порака дека мора да селектира компонента од листата. Потоа од зависност што е селектирано од листата се проверува која слика е селектирана и соодветно се става сликата и се додава на матрицата.

Со методот за зачувување на мапата, најпрво се отвора дијалог прозорец од типот SaveFileDialog и се подесуваат иницијалниот директориум каде да се отвори и која наставка ја користи. Потоа се креира StreamWriter со името на фајлот како што е зачувано предходно и се изминува матрицата и соодветно се пишуваат знаците за одредените компоненти. На крај ако корисникот не додал играч, или бројот на пакети и локации за складирање се различни, датотеката се брише и се прикажуваат соодветните пораки.
Исто како и методот за зачувување, многу слично работи и методот за вчитување мапа.

<p align="center">
  <img src="http://i.imgur.com/A9bJRy5.png" />
</p>

> **Интересен факт:** При вчитување на одредена мапа, времето на чекање беше околу 10 секунди. Со сетирање на својството Visible = false на
> панелата, и откако ќе се исцрта матрицата Visible = true, времето на
> чекање се намали за ~9 секунди.

  [1]: http://i.imgur.com/OXCmSC1.png
  [2]: http://i.imgur.com/BZf8fSb.png
  [3]: http://i.imgur.com/ccZsIxz.png
  [4]: http://i.imgur.com/yH7sWIS.png
  [5]: http://i.imgur.com/bKgzwwX.png
  [6]: http://i.imgur.com/6bPPt0U.png
  [7]: http://i.imgur.com/pAgxE62.png
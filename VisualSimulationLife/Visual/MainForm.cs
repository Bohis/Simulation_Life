using System;
using System.Drawing;
using System.Windows.Forms;
using LifeSimulation_ConsoleVersion.LifeSimulation;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using System.Text.RegularExpressions;

namespace VisualSimulationLife {
	public partial class MainForm : Form {
		/// <summary>
		/// Блок управления логикой программы
		/// </summary>
		WebCenter MainBloc;
		/// <summary>
		/// Холсты для рисования
		/// </summary>
		Bitmap FirstBmp;
		Bitmap SecondBmp;
		Bitmap TherdBmp;
		/// <summary>
		/// Карандаш для рисования поля 
		/// </summary>
		Pen BluePen;
		/// <summary>
		/// Кисти для рисования на главном поле
		/// </summary>
		Brush GreenBrush;
		Brush OldLace;
		/// <summary>
		/// Рисование линий 
		/// </summary>
		Graphics LineOne;
		Graphics LineTwo;
		Graphics LinesTherd;
		/// <summary>
		/// Триггеры для выбора
		/// </summary>
		bool SimplisticStyle;
		bool DinamicChoiseBool;
		bool StatistChoiseBool;
		/// <summary>
		/// Конструктор с полученным параметром начального выбора
		/// </summary>
		/// <param name="PacComponets"></param>
		public MainForm(OutFirstForm PacComponets) {
			this.DoubleBuffered = true;
			InitializeComponent();
			MainBloc = new WebCenter(PacComponets.FileNameBrain, PacComponets.NumberBotInt, PacComponets.DinamicChoiseBool);
			DinamicChoiseBool = PacComponets.DinamicChoiseBool;
			FirstBmp = new Bitmap(Field_One.Width, Field_One.Height);
			SecondBmp = new Bitmap(Field_Two.Width, Field_Two.Height);
			TherdBmp = new Bitmap(Field_Therd.Width, Field_Therd.Height);
			LineOne = Graphics.FromImage(FirstBmp);
			LineTwo = Graphics.FromImage(SecondBmp);
			LinesTherd = Graphics.FromImage(TherdBmp);
			BluePen = new Pen(Color.Blue);
			NetLinesBig();
			NetLinesSmallTwo();
			NetLinesSmallThred();
			GreenBrush = Brushes.Green;
			OldLace = Brushes.OldLace;
			DrawFieldOne();
			CountFor.Text = "100";
			CountFor.Refresh();
			CountIter.ReadOnly = true;
			SimplisticStyle = false;
			HelpMessage.Visible = false;
			StatistChoiseBool = false;
		}
		/// <summary>
		/// Перерисовка главного поля
		/// </summary>
		private void DrawFieldOne() {
			for (int i = 0; i < MainBloc.MainField.N; i++)
				for (int j = 0; j < MainBloc.MainField.N; j++) {
					if (MainBloc.MainField[ j, i ].CHANGES == true) {
						if (MainBloc.MainField[ j, i ].CheckBotPlace) 
							BoxOne(i, j, GreenBrush);
						else
							if (MainBloc.MainField[ j, i ].PLACE_ORGANIC_MATTER)
							BoxOne(i, j, Brushes.LightGreen);
						else
							BoxOne(i, j, OldLace);
						MainBloc.MainField[ j, i ].CHANGES = false;
					}
				}
		}
		/// <summary>
		/// Рисовка для поля яркости
		/// </summary>
		/// <param name="value">Значение яркости</param>
		/// <returns></returns>
		private Color ColorForLight(byte value) {
			if (value >= 0 && value <= 10)
				return Color.FromArgb(0,0,0);
			if (value > 10 && value <= 20)
				return Color.FromArgb(134,165,12);
			if (value > 20 && value <= 30)
				return Color.FromArgb(151,185,13);
			if (value > 30 && value <= 40)
				return Color.FromArgb(174, 215, 15);
			if (value > 40 && value <= 50)
				return Color.FromArgb(232, 162, 30);
			if (value > 50 && value <= 60)
				return Color.FromArgb(253, 100, 43);
			if (value > 60 && value <= 70)
				return Color.FromArgb(199, 239, 37);
			if (value > 80 && value <= 90)
				return Color.FromArgb(209, 242, 79);
			if (value > 90 && value <= 100)
				return Color.FromArgb(253, 243, 159);
			return Color.FromArgb(255, 255, 255);
		}
		/// <summary>
		/// Рисовка поля температуры
		/// </summary>
		/// <param name="value">Значение температуры</param>
		/// <returns></returns>
		private Color ColorForCold(sbyte value) {
			if (value >= -110 && value <= -80)
				return Color.FromArgb(74, 57, 172);
			if (value > -80 && value <= -60)
				return Color.FromArgb(141, 136, 210);
			if (value > -40 && value <= -20)
				return Color.FromArgb(177, 179, 228);
			if (value > -20 && value <= 0)
				return Color.FromArgb(217, 216, 243);
			if (value > 0 && value <= 20)
				return Color.FromArgb(255, 255, 255);
			if (value > 20 && value <= 40)
				return Color.FromArgb(241, 251, 206);
			if (value > 40 && value <= 60)
				return Color.FromArgb(227, 244, 132);
			if (value > 60 && value <= 80)
				return Color.FromArgb(253, 133, 81);
			if (value > 80 && value <= 100)
				return Color.FromArgb(250, 207, 39);
			return Color.FromArgb(255, 255, 255);
		}
		/// <summary>
		/// Рисовка границ 
		/// </summary>
		private void DrawFieldTwo() {
			for (int i = 0; i < MainBloc.MainField.N; i++)
				for (int j = 0; j < MainBloc.MainField.N; j++) {
					BoxTwo(i, j, new SolidBrush(ColorForLight(MainBloc.MainField[ j, i ].PLACE_LIGHT)));
				}
		}
		/// <summary>
		/// Рисовка границ 
		/// </summary>
		private void DrawFieldTherd() {
			for (int i = 0; i < MainBloc.MainField.N; i++)
				for (int j = 0; j < MainBloc.MainField.N; j++) {
					BoxTherd(i, j, new SolidBrush(ColorForCold(MainBloc.MainField[ j, i ].PLACE_TEMP)));
				}
		}
		/// <summary>
		/// Рисование всех границ полей
		/// </summary>
		private void NetLinesBig() {
			for (int i = 0; i <= Field_One.Width; i += 10)
				LineOne.DrawLine(BluePen, i, 0, i, Field_One.Width);
			LineOne.DrawLine(BluePen, Field_One.Width - 1, 0, Field_One.Height - 1, Field_One.Width - 1);

			for (int i = 0; i <= Field_One.Height; i += 10)
				LineOne.DrawLine(BluePen, 0, i, Field_One.Height, i);
			LineOne.DrawLine(BluePen, 0, Field_One.Height - 1, Field_One.Height - 1, Field_One.Height - 1);
			Field_One.Image = FirstBmp;
		}
		/// <summary>
		/// Рисование всех границ полей
		/// </summary>
		private void NetLinesSmallTwo() {
			for (int i = 0; i <= Field_Two.Width; i += 5)
				LineTwo.DrawLine(BluePen, i, 0, i, Field_Two.Width);
			LineTwo.DrawLine(BluePen, Field_Two.Width - 1, 0, Field_Two.Height - 1, Field_Two.Width - 1);

			for (int i = 0; i <= Field_Two.Height; i += 5)
				LineTwo.DrawLine(BluePen, 0, i, Field_Two.Height, i);
			LineTwo.DrawLine(BluePen, 0, Field_Two.Height - 1, Field_Two.Height - 1, Field_Two.Height - 1);
			Field_Two.Image = SecondBmp;
		}
		/// <summary>
		/// Рисование всех границ полей
		/// </summary>
		private void NetLinesSmallThred() {
			for (int i = 0; i <= Field_Therd.Width; i += 5)
				LinesTherd.DrawLine(BluePen, i, 0, i, Field_Therd.Width);
			LinesTherd.DrawLine(BluePen, Field_Therd.Width - 1, 0, Field_Therd.Height - 1, Field_Therd.Width - 1);

			for (int i = 0; i <= Field_Therd.Height; i += 5)
				LinesTherd.DrawLine(BluePen, 0, i, Field_Therd.Height, i);
			LinesTherd.DrawLine(BluePen, 0, Field_Therd.Height - 1, Field_Therd.Height - 1, Field_Therd.Height - 1);
			Field_Therd.Image = TherdBmp;
		}
		/// <summary>
		/// Рисование клеток
		/// </summary>
		/// <param name="i">координата</param>
		/// <param name="j">координата</param>
		/// <param name="brush">кисть</param>
		private void BoxOne(int i, int j, Brush brush) {
			LineOne.FillRectangle(brush, ( i * 10 ) + 2, ( j * 10 ) + 2, 7, 7);
			Field_One.Image = FirstBmp;
		}
		/// <summary>
		/// Рисование клеток
		/// </summary>
		/// <param name="i">координата</param>
		/// <param name="j">координата</param>
		/// <param name="brush">кисть</param>
		private void BoxTwo(int i, int j, Brush brush) {
			LineTwo.FillRectangle(brush, ( i * 5 ) + 1, ( j * 5 ) + 1, 3, 3);
			Field_Two.Image = SecondBmp;
		}
		/// <summary>
		/// Рисование клеток
		/// </summary>
		/// <param name="i">координата</param>
		/// <param name="j">координата</param>
		/// <param name="brush">кисть</param>
		private void BoxTherd(int i, int j, Brush brush) {
			LinesTherd.FillRectangle(brush, ( i * 5 ) + 1, ( j * 5 ) + 1, 3, 3);
			Field_Therd.Image = TherdBmp;
		}
		/// <summary>
		/// Работа логики программы
		/// </summary>
		/// <param name="last">необходимость перерисовки</param>
		private void work(bool last = false) {
			CountIter.Text = MainBloc.COUNT.ToString();
			CountIter.Refresh();
			MainBloc.WorkProject(StatistChoiseBool);
			if (SimplisticStyle == false || last == true) {
				DrawFieldOne();
				DrawFieldTwo();
				DrawFieldTherd();
				Field_One.Refresh();
				Field_Two.Refresh();
				Field_Therd.Refresh();
			}
		}
		/// <summary>
		/// Нажатие на старт
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Startbutton_Click_1(object sender, EventArgs e) {
			try {
				if (DinamicChoiseBool) {
					MainBloc.MainField.DinamicFieldTemp();
					MainBloc.MainField.DinamicOrganic();
				}
				int Limit = 500;
				if (SimplisticStyle == true) {
					Limit = 130000;
				}
				if (( int.Parse(CountFor.Text.ToString()) < 1 || int.Parse(CountFor.Text.ToString()) > Limit )) {
					MessageBox.Show("Счетчик должен быть в пределах [0," + Limit.ToString() + "]", "Ошибка");
					CountFor.Text = "100";
					CountFor.Refresh();
					return;
				}
				int Count = int.Parse(CountFor.Text.ToString());
				ProgressBar.Maximum = Count;
				ProgressBar.Value = 0;
				for (; 0 < Count; Count--) {
					work();
					ProgressBar.Value++;
				}
				Startbutton.Text = "Продолжить";
			}
			catch {
				MessageBox.Show("Ошибка введеных данных", "Ошибка");
				return;
			}
		}
		/// <summary>
		/// Сохранение интелекта в txt
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void LeaveSave_Click(object sender, EventArgs e) {
			for (int i = 0;i< MainBloc.MainField.N;i++) {
				for (int j = 0; j < MainBloc.MainField.N; j++) {
					if (MainBloc.MainField[ i, j ].CheckBotPlace) {
						MainBloc.SaveBrain(MainBloc.MainField[ i, j ].PLACE_BOT);
						return;
					}
				}
			}
		}
		/// <summary>
		/// Выход
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void LeaveNotSave_Click_1(object sender, EventArgs e) {
			this.Close();
		}
		/// <summary>
		/// Выбор упрощенной отрисовки
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void SimplePresent_CheckedChanged(object sender, EventArgs e) {
			if (SimplisticStyle == false) {
				SimplisticStyle = true;
				HelpMessage.Visible = true;
				return;
			}
			else
				SimplisticStyle = false;
			HelpMessage.Visible = false;
		}
		/// <summary>
		/// Триггер 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void StatistChoise_CheckedChanged(object sender, EventArgs e) {
			StatistChoiseBool = !StatistChoiseBool;
		}
		/// <summary>
		/// Генерирование файлов статистики в виде файла Excel
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void BackMenu_Click(object sender, EventArgs e) {
			try {
				OpenFileDialog TimeDialog = new OpenFileDialog();
				TimeDialog.Filter = "Текстовые файлы|Static*.txt|Все файлы|*.*";
				if (TimeDialog.ShowDialog() == DialogResult.OK) {
					Excel.Application ExAp = new Excel.Application();
					Excel.Workbook Book = ExAp.Workbooks.Add();
					Excel.Worksheet Sheet = Book.Worksheets.get_Item(1);
					Sheet.Name = "Sheet_1";
					StreamReader Read = new StreamReader(TimeDialog.FileName);
					string Text = Read.ReadToEnd();
					Read.Close();
					Sheet.Cells[ 1, 1 ] = "Имя бота";
					Sheet.Cells[ 1, 2 ] = "Колличество действий - еда";
					Sheet.Cells[ 1, 3 ] = "Колличество действий - движения";
					Sheet.Cells[ 1, 4 ] = "Колличество действий - убийство";
					Sheet.Cells[ 1, 5 ] = "Колличество действий - размножение";
					Sheet.Cells[ 1, 6 ] = "Возраст";
					Sheet.Cells[ 1, 7 ] = "Колличество энергии";
					int N = new Regex(@"[.]").Matches(Text).Count;
					for (int i = 0; i < N; i++) {
						string Str = Text.Split('\n')[ i ].ToString();
						Sheet.Cells[ i + 2, 1 ] = Str.Split('|')[ 0 ];
						Sheet.Cells[ i + 2, 2 ] = Str.Split('|')[ 1 ];
						Sheet.Cells[ i + 2, 3 ] = Str.Split('|')[ 2 ];
						Sheet.Cells[ i + 2, 4 ] = Str.Split('|')[ 3 ];
						Sheet.Cells[ i + 2, 5 ] = Str.Split('|')[ 4 ];
						Sheet.Cells[ i + 2, 6 ] = Str.Split('|')[ 5 ];
						Sheet.Cells[ i + 2, 7 ] = Str.Split('|')[ 6 ];
					}
					ExAp.GetSaveAsFilename(@"\Statist\Date.xlsx");
					ExAp.Quit();
				}
			}
			catch(Exception error) {
				MessageBox.Show("Ошибка чтение файла, возможно выбран не тот файл.\n" + error.Message,"Ошибка");
			}
			MessageBox.Show("Обработка заверешена успешно", "Информация");
		}
		#region Skip
		private void progressBar1_Click(object sender, EventArgs e) {

		}
		private void label1_Click(object sender, EventArgs e) {

		}
		private void ConsoleLive_TextChanged(object sender, EventArgs e) {

		}
		private void LeaveNotSave_Click(object sender, EventArgs e) {

		}
		private void Startbutton_Click(object sender, EventArgs e) {

		}
		private void MainForm_Load(object sender, EventArgs e) {

		}
		private void NumberIterText_Click(object sender, EventArgs e) {

		}
		private void Pause_Click(object sender, EventArgs e) {

		}
		private void Field_Two_Click(object sender, EventArgs e) {

		}
		private void Field_One_Click(object sender, EventArgs e) {

		}
		private void CountIter_TextChanged(object sender, EventArgs e) {

		}
		private void ConsoleLive_TextChanged_1(object sender, EventArgs e) {

		}
		private void CountFor_TextChanged(object sender, EventArgs e) {

		}
		private void PictureBoxTemp_Click(object sender, EventArgs e) {

		}
		#endregion
	}
}
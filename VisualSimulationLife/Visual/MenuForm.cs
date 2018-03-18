using System;
using System.IO;
using System.Windows.Forms;
using LifeSimulation.Present;

namespace LifeSimulation.Visual{
	/// <summary>
	/// Работа с меню до работы симуляции
	/// </summary>
	public partial class MenuForm : Form {
		/// <summary>
		/// Структура для передачи данных
		/// </summary>
		OutFirstForm OutData;
		/// <summary>
		/// Конструктор с ссылкой для передачи данных
		/// </summary>
		/// <param name="ForFirtsApp">Ссылка на измененные данные</param>
		public MenuForm(OutFirstForm ForFirtsApp) {
			this.DoubleBuffered = true;
			InitializeComponent();
			NumberBot.Maximum = 1000;
			NumberBot.Minimum = 1;
			NumberBot.Value = 25;
			CoefficientTrainig.Minimum = 2;
			CoefficientTrainig.Maximum = 10;
			CoefficientTrainig.Value = 3;
			OutData = ForFirtsApp;
			OutData.DinamicChoiseBool = false;
			AddresFile.Text = "Название файла";
		}
		/// <summary>
		/// Выбор динамического коофициента
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void DinamicChose_CheckedChanged(object sender, EventArgs e) {
			if (OutData.DinamicChoiseBool == false)
				OutData.DinamicChoiseBool = true;
			else
				OutData.DinamicChoiseBool = false;
		}
		/// <summary>
		/// Потверждение выбора файла
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void EnterFile_Click(object sender, EventArgs e) {
			OutData.FileNameBrain = AddresFile.Text;
		}
		/// <summary>
		/// Старт программы
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void START_Click(object sender, EventArgs e) {
			OutData.NumberBotInt = int.Parse(NumberBot.Value.ToString());
			OutData.LearningFactor = int.Parse(CoefficientTrainig.Value.ToString());
			this.Close();
		}
		#region Info_Box
		private void label1_Click(object sender, EventArgs e) {
			MessageBox.Show("Текстовый файл, сгенерированный в результате работы программы.\nЕсли нет таких файлов, оставить окно пустым.","Информация");
		}

		private void NumberBotText_Click(object sender, EventArgs e) {
			MessageBox.Show("Колличество ботов, изначально расположенных на поле и чило их генерации при смерти всех ботов.", "Информация");
		}

		private void label3_Click(object sender, EventArgs e) {
			MessageBox.Show("Каждый N синапс в сети изменяется при размножении ботов.", "Информация");
		}

		private void DinamicChoise_Click(object sender, EventArgs e) {
			MessageBox.Show("Случайная смена условий среды при просчетах.", "Информация");
		}
		#endregion
		/// <summary>
		/// Диалоговое окно выбора файла
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ChoiseFile_Click(object sender, EventArgs e) {
			OpenFileDialog dlg = new OpenFileDialog();
			dlg.Filter = "Текстовые файлы|*.txt|Все файлы|*.*";
			if (dlg.ShowDialog() == DialogResult.OK) {
				AddresFile.Text = dlg.FileName;
				StreamReader TimeFlow = new StreamReader(dlg.FileName);
				if (TimeFlow.ReadLine() != "BrainSaveFile:") {
					MessageBox.Show("Файл не является сохранением нейросети!", "Предупреждение");
					AddresFile.Text = ""; 
				}
				TimeFlow.Close();
			}
		}
		#region Skip

		private void CoefficientTrainig_ValueChanged(object sender, EventArgs e) {

		}

		private void NumberBot_ValueChanged(object sender, EventArgs e) {

		}

		private void MenuForm_Load(object sender, EventArgs e) {
			
		}

		private void AddresFile_TextChanged(object sender, EventArgs e) {
			
		}
		private void DescriptionProgram_Click(object sender, EventArgs e) {
			;
		}
		#endregion
		/// <summary>
		/// Чтение данных полученных от пользователя
		/// </summary>
		public OutFirstForm OUT_DATA {
			get {
				return OutData;
			}
		}
	}
}
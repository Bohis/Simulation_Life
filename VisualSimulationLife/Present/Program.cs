using System;
using System.Windows.Forms;
using LifeSimulation.Visual;

namespace LifeSimulation.Present {
	/// <summary>
	/// Структура передачи информации
	/// </summary>
	public struct OutFirstForm {
		public string FileNameBrain;
		public int NumberBotInt;
		public int LearningFactor;
		public bool DinamicChoiseBool;
	}
	static class Program {
		/// <summary>
		/// Главная точка входа для приложения.
		/// </summary>
		[STAThread]
		static void Main() {
			Present.ConsoleDebugging ConsoleControl = new Present.ConsoleDebugging();
			ConsoleControl.ClouseWindow();
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			//Экран загрузки с таймером
			StartScreen TimerPage = new StartScreen();
			DateTime Time = DateTime.Now + TimeSpan.FromSeconds(3);
			while (Time > DateTime.Now) {
				Application.DoEvents();
			}
			TimerPage.Close();
			TimerPage.Dispose();
			//Меню
			OutFirstForm ForFirtsApp = new OutFirstForm {
				DinamicChoiseBool = false,
				FileNameBrain = null,
				LearningFactor = 3,
				NumberBotInt = 50
			};
			MenuForm FirstApp = new MenuForm(ForFirtsApp);
			Application.Run(FirstApp);
			ForFirtsApp = FirstApp.OUT_DATA;
			FirstApp.Dispose();
			//Главная форма
			MainForm SecondApp = new MainForm(ForFirtsApp,ConsoleControl);
			Application.Run(SecondApp);
			SecondApp.Dispose();
		}
	}
}
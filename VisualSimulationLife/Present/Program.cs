using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VisualSimulationLife {
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
			ForFirtsApp = FirstApp.OutData;
			FirstApp.Dispose();
			//Главная форма
			MainForm SecondApp = new MainForm(ForFirtsApp);
			Application.Run(SecondApp);
			SecondApp.Dispose();
		}
	}
}

using System;
using System.IO;
using System.Collections;
using LifeSimulation_ConsoleVersion.NeuroBrainBor;
using System.Windows.Forms;

namespace LifeSimulation_ConsoleVersion.LifeSimulation {
	/// <summary>
	/// Управление логикой программы
	/// </summary>
	class WebCenter {
		public Field MainField;
		int Count;
		/// <summary>
		/// Имена файлов
		/// </summary>
		string FileNameToSave;
		string FileNameToStatist;
		/// <summary>
		/// Движение ботов
		/// </summary>
		MoveTo WorkBot;
		/// <summary>
		/// Число спавна ботов
		/// </summary>
		int NumberBot;
		/// <summary>
		/// Конструктор с параметрами по умолчанию
		/// </summary>
		/// <param name="FileNameToSave"></param>
		/// <param name="NumberBot"></param>
		/// <param name="DinamicChoiseBool"></param>
		/// <param name="FileNameToStatist"></param>
		public WebCenter(string FileNameToSave,int NumberBot = 10,bool DinamicChoiseBool = false, string FileNameToStatist = null){

			Random ForNameFile = new Random();

			if (FileNameToStatist == null)
				this.FileNameToStatist = @"Static" + DateTime.Today.Year.ToString() + "." + DateTime.Today.Month.ToString() + "." + DateTime.Today.Day.ToString() + "." + ForNameFile.Next(0,1000).ToString() + "_" + @".txt";
			else
				this.FileNameToStatist = FileNameToStatist;
			this.FileNameToSave = FileNameToSave;

			MainField = new Field(60,DinamicChoiseBool);

			Count = 0;

			WorkBot = new MoveTo();

			this.NumberBot = NumberBot;

			SetBotMain(MainField, this.NumberBot,ReadBrain());

			Directory.CreateDirectory("Statist");

			Directory.CreateDirectory("Brain");

			FileInfo File = new FileInfo(@"Statist\" + this.FileNameToStatist);

			File.Create().Close();

			this.FileNameToStatist = File.FullName;
		}
		/// <summary>
		/// Работа программы
		/// </summary>
		/// <param name="StatistChoiseBool"></param>
		public void WorkProject(bool StatistChoiseBool = false) {
			Count++;
			ICollection keys = MainField.ListBot.Keys;
			string[] HashName = new string[ keys.Count ];
			keys.CopyTo(HashName, 0);
			if (HashName.Length >= 1) {
				for (int i = 0; i < HashName.Length; i++) {
					Bot Object = (Bot)MainField.ListBot[ HashName[ i ] ];
					if (Object != null) {
						Object.ENERGY -= 10;
						if (!( Object.TempRange.MaxTemp >= MainField[ (int)Object.IG, (int)Object.JG ].PLACE_TEMP && Object.TempRange.MinTemp <= MainField[ (int)Object.IG, (int)Object.JG ].PLACE_TEMP )) {
							Object.ENERGY -= 5;
							Object.HP_GET -= 1;
						}
						if (Object.ENERGY <= 0)
							Object.HP_GET += 3 * Object.ENERGY / 2;
							if (Object.HP_GET <= 0) {

								MainField.ClearBot((int)Object.IG, (int)Object.JG);
							MainField.ListBot.Remove(HashName[ i ]);
							if (MainField.ListBot.Count == 0) {
								SetBotMain(MainField, NumberBot, Object.BRAIN);
								SetBotMain(MainField, 2, null);
							}
							if(StatistChoiseBool && HashName.Length == 1)
								GetDeadBot(Object);
							Object = null;
						}
						else {
							WorkBot.Move(WorkBot.LookAround(Object.JG, Object.IG, MainField), Object, MainField);
						}
					}
				}
			}
		}
		/// <summary>
		/// Установка бота в клетку с возможностьб наследования
		/// </summary>
		/// <param name="MainLink"></param>
		/// <param name="count"></param>
		/// <param name="Brain"></param>
		private void SetBotMain(Field MainLink, int count,NeuralNetwork Brain = null) {
			Random ForBotPlace = new Random();
			for (int k = 0,g = 0 ; k < count;g++) {
				int i = ForBotPlace.Next(0, MainField.N);
				int j = ForBotPlace.Next(0, MainField.N);
				if (MainLink.CheckPlaceBot(i, j, out bool Index) == false && Index == false) {
					new Bot(MainLink, i, j, 100, 100, 40, -50, 50, 100, Brain);
					k++;
				}
				if (g > 1000000)
					break;
			}
		}
		#region Свойства для чтения
		public string FILE_NAME_TO_SAVE{
			get {
				return FileNameToSave;
			}
			set {
				FileNameToSave = value;
			}
		}
		
		public int COUNT {
			get {
				return Count;
			}
		}
		#endregion
		/// <summary>
		/// Убийство бота в конкретной клетки
		/// </summary>
		/// <param name="bot"></param>
		/// <returns></returns>
		private bool GetDeadBot(Bot bot) {
			try {
				StreamWriter Flow = new StreamWriter(FileNameToStatist,true);
				Flow.WriteLine(bot.HashName + "|" + bot.Info.Eat + "|" + bot.Info.Move + "|" + bot.Info.Kill + "|" + bot.Info.Generation + "|" + bot.OldChet + "|" + bot.ENERGY + ".");
				Flow.Close();
				return true;
			}
			catch(Exception error) {
				MessageBox.Show(error.Message);
				return false;
			}
		}
		/// <summary>
		/// Сохранить бота в файл статистики
		/// </summary>
		/// <param name="bot"></param>
		/// <returns></returns>
		public  bool SaveBrain(Bot bot) {
			try {
				FileNameToSave = @"Brain_" + DateTime.Today.Day.ToString() + @".txt";
				StreamWriter Save = new StreamWriter(new FileInfo(@"Brain\" + FileNameToSave).Create());
				NeuralNetwork TimeDate = bot.BRAIN;
				double[,] Array = TimeDate.S_FIRST;
				Save.WriteLine("BrainSaveFile:");
				Save.WriteLine(TimeDate.TRAING_COOF);
				Save.WriteLine(Array.GetLength(0));
				Save.WriteLine(Array.GetLength(1));
				for (int i = 0; i < Array.GetLength(0); i++)
					for (int j = 0; j < Array.GetLength(1); j++)
						Save.WriteLine(Array[ i, j ]);
				Array = TimeDate.S_CECOND;
				Save.WriteLine(Array.GetLength(0));
				Save.WriteLine(Array.GetLength(1));
				for (int i = 0; i < Array.GetLength(0); i++)
					for (int j = 0; j < Array.GetLength(1); j++)
						Save.WriteLine(Array[ i, j ]);
				Array = TimeDate.S_THIRD;
				Save.WriteLine(Array.GetLength(0));
				Save.WriteLine(Array.GetLength(1));
				for (int i = 0; i < Array.GetLength(0); i++)
					for (int j = 0; j < Array.GetLength(1); j++)
						Save.WriteLine(Array[ i, j ]);
				Array = TimeDate.S_FORTH;
				Save.WriteLine(Array.GetLength(0));
				Save.WriteLine(Array.GetLength(1));
				for (int i = 0; i < Array.GetLength(0); i++)
					for (int j = 0; j < Array.GetLength(1); j++)
						Save.WriteLine(Array[ i, j ]);
				Save.Close();
				MessageBox.Show("Снимок нейросети сохранен", "Сообщение");
				return true;
			}
			catch {
				MessageBox.Show("Не удалось сохранить снимок нейросети","Ошибка");
				return false;
			}
		}
		/// <summary>
		/// Чтение из файла нейросети
		/// </summary>
		/// <returns></returns>
		private NeuralNetwork ReadBrain() {
			try {
				if (FileNameToSave == "Название файла" || FileNameToSave == null)
					return null;
				StreamReader Read = new StreamReader(FileNameToSave);
				if (Read.ReadLine() != "BrainSaveFile:")
					throw new Exception("Файл не является сохранением нейросети");
				int Coof = int.Parse(Read.ReadLine());
				int N = int.Parse(Read.ReadLine());
				int M = int.Parse(Read.ReadLine());
				double[,] Array1 = new double[ N, M ];
				for (int i = 0; i < N; i++)
					for (int j = 0; j < M; j++)
						Array1[ i, j ] = double.Parse(Read.ReadLine());
				N = int.Parse(Read.ReadLine());
				M = int.Parse(Read.ReadLine());
				double[,] Array2 = new double[ N, M ];
				for (int i = 0; i < N; i++)
					for (int j = 0; j < M; j++)
						Array1[ i, j ] = double.Parse(Read.ReadLine());
				N = int.Parse(Read.ReadLine());
				M = int.Parse(Read.ReadLine());
				double[,] Array3 = new double[ N, M ];
				for (int i = 0; i < N; i++)
					for (int j = 0; j < M; j++)
						Array3[ i, j ] = double.Parse(Read.ReadLine());
				N = int.Parse(Read.ReadLine());
				M = int.Parse(Read.ReadLine());
				double[,] Array4 = new double[ N, M ];
				for (int i = 0; i < N; i++)
					for (int j = 0; j < M; j++)
						Array4[ i, j ] = double.Parse(Read.ReadLine());
				Read.Close();
				MessageBox.Show("Чтение файла удалось", "Информация");
				return new NeuralNetwork(Coof, Array1, Array2, Array3, Array4);
			}
			catch(Exception error) {
				MessageBox.Show("Чтение файла не удалось " + error.Message,"Ошибка");
				return null;
			}
		}
	}
}
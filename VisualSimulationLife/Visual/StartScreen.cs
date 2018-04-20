using System;
using System.Drawing;
using System.Windows.Forms;

namespace LifeSimulation.Visual{
	/// <summary>
	/// Загрузочный экран
	/// </summary>
	public partial class StartScreen : Form {
		/// <summary>
		/// Конструктор с подстройкой разрешения под экран
		/// </summary>
		public StartScreen() {
			InitializeComponent();
			this.DoubleBuffered = true;
			Size SizeForm = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Size;
			if (SizeForm.Height <= 350)
				this.Height = SizeForm.Height - 50;
			if (SizeForm.Width <= 950)
				this.Width = SizeForm.Width - 50;
			TopLevel = true;
			TopMost = true;
			this.Show();
			Timer.Start();
		}
		/// <summary>
		/// Работа с таймером
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Timer_Tick(object sender, EventArgs e) {
			this.Opacity +=0.3;
			if (this.Opacity == 1) {
				Timer.Stop();
			}
		}
		#region skip
		private void StartScreen_Load(object sender, EventArgs e) {

		}
		#endregion
	}
}
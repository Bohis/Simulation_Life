namespace VisualSimulationLife {
	partial class MainForm {
		/// <summary>
		/// Обязательная переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && ( components != null )) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Код, автоматически созданный конструктором форм Windows

		/// <summary>
		/// Требуемый метод для поддержки конструктора — не изменяйте 
		/// содержимое этого метода с помощью редактора кода.
		/// </summary>
		private void InitializeComponent() {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.NumberIterText = new System.Windows.Forms.Label();
			this.Startbutton = new System.Windows.Forms.Button();
			this.LeaveNotSave = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.LeaveSave = new System.Windows.Forms.Button();
			this.CountIter = new System.Windows.Forms.TextBox();
			this.TextForCount = new System.Windows.Forms.Label();
			this.CountFor = new System.Windows.Forms.TextBox();
			this.Field_Two = new System.Windows.Forms.PictureBox();
			this.Field_One = new System.Windows.Forms.PictureBox();
			this.Field_Therd = new System.Windows.Forms.PictureBox();
			this.label1 = new System.Windows.Forms.Label();
			this.SimplePresent = new System.Windows.Forms.CheckBox();
			this.HelpMessage = new System.Windows.Forms.Label();
			this.StatistChoise = new System.Windows.Forms.CheckBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.ProgressBar = new System.Windows.Forms.ProgressBar();
			this.StatisticsMenu = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.Field_Two)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.Field_One)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.Field_Therd)).BeginInit();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// NumberIterText
			// 
			this.NumberIterText.AutoSize = true;
			this.NumberIterText.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.NumberIterText.ForeColor = System.Drawing.Color.Black;
			this.NumberIterText.Location = new System.Drawing.Point(3, 7);
			this.NumberIterText.Name = "NumberIterText";
			this.NumberIterText.Size = new System.Drawing.Size(182, 19);
			this.NumberIterText.TabIndex = 24;
			this.NumberIterText.Text = "Колличество просчетов";
			// 
			// Startbutton
			// 
			this.Startbutton.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Startbutton.ForeColor = System.Drawing.Color.Black;
			this.Startbutton.Location = new System.Drawing.Point(0, 35);
			this.Startbutton.Name = "Startbutton";
			this.Startbutton.Size = new System.Drawing.Size(214, 49);
			this.Startbutton.TabIndex = 23;
			this.Startbutton.Text = "СТАРТ";
			this.Startbutton.UseVisualStyleBackColor = true;
			this.Startbutton.Click += new System.EventHandler(this.Startbutton_Click_1);
			// 
			// LeaveNotSave
			// 
			this.LeaveNotSave.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.LeaveNotSave.ForeColor = System.Drawing.Color.Black;
			this.LeaveNotSave.Location = new System.Drawing.Point(380, 168);
			this.LeaveNotSave.Name = "LeaveNotSave";
			this.LeaveNotSave.Size = new System.Drawing.Size(214, 48);
			this.LeaveNotSave.TabIndex = 22;
			this.LeaveNotSave.Text = "Выйти без сохранения";
			this.LeaveNotSave.UseVisualStyleBackColor = true;
			this.LeaveNotSave.Click += new System.EventHandler(this.LeaveNotSave_Click_1);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label4.ForeColor = System.Drawing.Color.Black;
			this.label4.Location = new System.Drawing.Point(263, 7);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(106, 19);
			this.label4.TabIndex = 21;
			this.label4.Text = "Главное поле";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label3.ForeColor = System.Drawing.Color.Black;
			this.label3.Location = new System.Drawing.Point(374, 260);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(281, 19);
			this.label3.TabIndex = 20;
			this.label3.Text = "Дополнительное поле для освещения";
			// 
			// LeaveSave
			// 
			this.LeaveSave.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.LeaveSave.ForeColor = System.Drawing.Color.Black;
			this.LeaveSave.Location = new System.Drawing.Point(0, 115);
			this.LeaveSave.Name = "LeaveSave";
			this.LeaveSave.Size = new System.Drawing.Size(214, 47);
			this.LeaveSave.TabIndex = 19;
			this.LeaveSave.Text = "Сохранить снимок нейросети";
			this.LeaveSave.UseVisualStyleBackColor = true;
			this.LeaveSave.Click += new System.EventHandler(this.LeaveSave_Click);
			// 
			// CountIter
			// 
			this.CountIter.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.CountIter.Location = new System.Drawing.Point(191, 7);
			this.CountIter.Name = "CountIter";
			this.CountIter.Size = new System.Drawing.Size(88, 22);
			this.CountIter.TabIndex = 16;
			this.CountIter.TextChanged += new System.EventHandler(this.CountIter_TextChanged);
			// 
			// TextForCount
			// 
			this.TextForCount.AutoSize = true;
			this.TextForCount.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.TextForCount.ForeColor = System.Drawing.Color.Black;
			this.TextForCount.Location = new System.Drawing.Point(3, 87);
			this.TextForCount.Name = "TextForCount";
			this.TextForCount.Size = new System.Drawing.Size(269, 19);
			this.TextForCount.TabIndex = 26;
			this.TextForCount.Text = "Коллчество просчетов за один цикл";
			// 
			// CountFor
			// 
			this.CountFor.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.CountFor.Location = new System.Drawing.Point(278, 87);
			this.CountFor.Name = "CountFor";
			this.CountFor.Size = new System.Drawing.Size(77, 22);
			this.CountFor.TabIndex = 25;
			this.CountFor.TextChanged += new System.EventHandler(this.CountFor_TextChanged);
			// 
			// Field_Two
			// 
			this.Field_Two.BackColor = System.Drawing.Color.OldLace;
			this.Field_Two.Location = new System.Drawing.Point(360, 282);
			this.Field_Two.Name = "Field_Two";
			this.Field_Two.Size = new System.Drawing.Size(300, 300);
			this.Field_Two.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.Field_Two.TabIndex = 14;
			this.Field_Two.TabStop = false;
			this.Field_Two.Click += new System.EventHandler(this.Field_Two_Click);
			// 
			// Field_One
			// 
			this.Field_One.BackColor = System.Drawing.Color.OldLace;
			this.Field_One.Location = new System.Drawing.Point(12, 29);
			this.Field_One.Name = "Field_One";
			this.Field_One.Size = new System.Drawing.Size(600, 600);
			this.Field_One.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.Field_One.TabIndex = 13;
			this.Field_One.TabStop = false;
			this.Field_One.Click += new System.EventHandler(this.Field_One_Click);
			// 
			// Field_Therd
			// 
			this.Field_Therd.BackColor = System.Drawing.Color.OldLace;
			this.Field_Therd.Location = new System.Drawing.Point(0, 282);
			this.Field_Therd.Name = "Field_Therd";
			this.Field_Therd.Size = new System.Drawing.Size(300, 300);
			this.Field_Therd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.Field_Therd.TabIndex = 27;
			this.Field_Therd.TabStop = false;
			this.Field_Therd.Click += new System.EventHandler(this.PictureBoxTemp_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label1.ForeColor = System.Drawing.Color.Black;
			this.label1.Location = new System.Drawing.Point(1, 260);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(299, 19);
			this.label1.TabIndex = 28;
			this.label1.Text = "Дополнительное поле для температуры";
			this.label1.Click += new System.EventHandler(this.label1_Click);
			// 
			// SimplePresent
			// 
			this.SimplePresent.AutoSize = true;
			this.SimplePresent.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.SimplePresent.ForeColor = System.Drawing.Color.Black;
			this.SimplePresent.Location = new System.Drawing.Point(380, 3);
			this.SimplePresent.Name = "SimplePresent";
			this.SimplePresent.Size = new System.Drawing.Size(275, 23);
			this.SimplePresent.TabIndex = 29;
			this.SimplePresent.Text = "Упрощенный режим отображения";
			this.SimplePresent.UseVisualStyleBackColor = true;
			this.SimplePresent.CheckedChanged += new System.EventHandler(this.SimplePresent_CheckedChanged);
			// 
			// HelpMessage
			// 
			this.HelpMessage.AutoSize = true;
			this.HelpMessage.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.HelpMessage.ForeColor = System.Drawing.Color.Black;
			this.HelpMessage.Location = new System.Drawing.Point(381, 87);
			this.HelpMessage.Name = "HelpMessage";
			this.HelpMessage.Size = new System.Drawing.Size(274, 38);
			this.HelpMessage.TabIndex = 30;
			this.HelpMessage.Text = "При упрощенном стиле \r\nможно выбирать значения до 130000";
			// 
			// StatistChoise
			// 
			this.StatistChoise.AutoSize = true;
			this.StatistChoise.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.StatistChoise.ForeColor = System.Drawing.Color.Black;
			this.StatistChoise.Location = new System.Drawing.Point(380, 32);
			this.StatistChoise.Name = "StatistChoise";
			this.StatistChoise.Size = new System.Drawing.Size(256, 23);
			this.StatistChoise.TabIndex = 31;
			this.StatistChoise.Text = "Генерировать файл статистики";
			this.StatistChoise.UseVisualStyleBackColor = true;
			this.StatistChoise.CheckedChanged += new System.EventHandler(this.StatistChoise_CheckedChanged);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.ProgressBar);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.StatisticsMenu);
			this.panel1.Controls.Add(this.Field_Therd);
			this.panel1.Controls.Add(this.SimplePresent);
			this.panel1.Controls.Add(this.HelpMessage);
			this.panel1.Controls.Add(this.StatistChoise);
			this.panel1.Controls.Add(this.Field_Two);
			this.panel1.Controls.Add(this.Startbutton);
			this.panel1.Controls.Add(this.NumberIterText);
			this.panel1.Controls.Add(this.CountIter);
			this.panel1.Controls.Add(this.TextForCount);
			this.panel1.Controls.Add(this.LeaveNotSave);
			this.panel1.Controls.Add(this.CountFor);
			this.panel1.Controls.Add(this.LeaveSave);
			this.panel1.Location = new System.Drawing.Point(618, 29);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(663, 600);
			this.panel1.TabIndex = 32;
			// 
			// ProgressBar
			// 
			this.ProgressBar.Location = new System.Drawing.Point(0, 223);
			this.ProgressBar.Name = "ProgressBar";
			this.ProgressBar.Size = new System.Drawing.Size(655, 23);
			this.ProgressBar.TabIndex = 34;
			this.ProgressBar.Click += new System.EventHandler(this.progressBar1_Click);
			// 
			// StatisticsMenu
			// 
			this.StatisticsMenu.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.StatisticsMenu.ForeColor = System.Drawing.Color.Black;
			this.StatisticsMenu.Location = new System.Drawing.Point(0, 168);
			this.StatisticsMenu.Name = "StatisticsMenu";
			this.StatisticsMenu.Size = new System.Drawing.Size(214, 49);
			this.StatisticsMenu.TabIndex = 33;
			this.StatisticsMenu.Text = "Программа обработки статистики";
			this.StatisticsMenu.UseVisualStyleBackColor = true;
			this.StatisticsMenu.Click += new System.EventHandler(this.BackMenu_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.BackColor = System.Drawing.Color.BlanchedAlmond;
			this.ClientSize = new System.Drawing.Size(1294, 640);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.Field_One);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Окно Симуляции";
			this.Load += new System.EventHandler(this.MainForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.Field_Two)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.Field_One)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.Field_Therd)).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label NumberIterText;
		private System.Windows.Forms.Button Startbutton;
		private System.Windows.Forms.Button LeaveNotSave;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button LeaveSave;
		private System.Windows.Forms.TextBox CountIter;
		private System.Windows.Forms.PictureBox Field_Two;
		private System.Windows.Forms.PictureBox Field_One;
		private System.Windows.Forms.Label TextForCount;
		private System.Windows.Forms.TextBox CountFor;
		private System.Windows.Forms.PictureBox Field_Therd;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.CheckBox SimplePresent;
		private System.Windows.Forms.Label HelpMessage;
		private System.Windows.Forms.CheckBox StatistChoise;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button StatisticsMenu;
		private System.Windows.Forms.ProgressBar ProgressBar;
	}
}


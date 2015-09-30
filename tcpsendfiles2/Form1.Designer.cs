namespace TcpSendFiles
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param message="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonStartServer = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.textBoxSend = new System.Windows.Forms.TextBox();
            this.buttonSendData = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonAddFile = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxIPserver = new System.Windows.Forms.TextBox();
            this.labelFileName = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxIPClient = new System.Windows.Forms.TextBox();
            this.textBoxClientPort = new System.Windows.Forms.TextBox();
            this.textBoxServerPort = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.DownloadPlace_button = new System.Windows.Forms.Button();
            this.time_label = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonStartServer
            // 
            this.buttonStartServer.Location = new System.Drawing.Point(292, 41);
            this.buttonStartServer.Name = "buttonStartServer";
            this.buttonStartServer.Size = new System.Drawing.Size(97, 20);
            this.buttonStartServer.TabIndex = 0;
            this.buttonStartServer.Text = "Старт сервер";
            this.buttonStartServer.UseVisualStyleBackColor = true;
            this.buttonStartServer.Click += new System.EventHandler(this.buttonStartServer_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(12, 141);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(377, 186);
            this.listBox1.TabIndex = 1;
            // 
            // buttonConnect
            // 
            this.buttonConnect.Location = new System.Drawing.Point(292, 67);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(97, 20);
            this.buttonConnect.TabIndex = 2;
            this.buttonConnect.Text = "Подключение";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBoxSend
            // 
            this.textBoxSend.Location = new System.Drawing.Point(229, 3);
            this.textBoxSend.Multiline = true;
            this.textBoxSend.Name = "textBoxSend";
            this.textBoxSend.Size = new System.Drawing.Size(60, 31);
            this.textBoxSend.TabIndex = 3;
            this.textBoxSend.Visible = false;
            // 
            // buttonSendData
            // 
            this.buttonSendData.Location = new System.Drawing.Point(143, 383);
            this.buttonSendData.Name = "buttonSendData";
            this.buttonSendData.Size = new System.Drawing.Size(111, 23);
            this.buttonSendData.TabIndex = 4;
            this.buttonSendData.Text = "Отправить сообщение";
            this.buttonSendData.UseVisualStyleBackColor = true;
            this.buttonSendData.Click += new System.EventHandler(this.buttonSendData_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 125);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Получение";
            // 
            // buttonAddFile
            // 
            this.buttonAddFile.Location = new System.Drawing.Point(12, 383);
            this.buttonAddFile.Name = "buttonAddFile";
            this.buttonAddFile.Size = new System.Drawing.Size(125, 23);
            this.buttonAddFile.TabIndex = 4;
            this.buttonAddFile.Text = "Добавить файл";
            this.buttonAddFile.UseVisualStyleBackColor = true;
            this.buttonAddFile.Click += new System.EventHandler(this.buttonAddFile_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "IP адрес сервера";
            // 
            // textBoxIPserver
            // 
            this.textBoxIPserver.Location = new System.Drawing.Point(110, 41);
            this.textBoxIPserver.Name = "textBoxIPserver";
            this.textBoxIPserver.Size = new System.Drawing.Size(109, 20);
            this.textBoxIPserver.TabIndex = 8;
            this.textBoxIPserver.Text = "127.0.0.1";
            this.textBoxIPserver.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelFileName
            // 
            this.labelFileName.Location = new System.Drawing.Point(6, 14);
            this.labelFileName.Name = "labelFileName";
            this.labelFileName.Size = new System.Drawing.Size(230, 16);
            this.labelFileName.TabIndex = 10;
            this.labelFileName.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelFileName);
            this.groupBox1.Location = new System.Drawing.Point(12, 345);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(377, 32);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Файл";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "IP адрес клиента";
            // 
            // textBoxIPClient
            // 
            this.textBoxIPClient.Location = new System.Drawing.Point(110, 67);
            this.textBoxIPClient.Name = "textBoxIPClient";
            this.textBoxIPClient.Size = new System.Drawing.Size(109, 20);
            this.textBoxIPClient.TabIndex = 12;
            this.textBoxIPClient.Text = "127.0.0.1";
            this.textBoxIPClient.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxClientPort
            // 
            this.textBoxClientPort.Location = new System.Drawing.Point(225, 67);
            this.textBoxClientPort.Name = "textBoxClientPort";
            this.textBoxClientPort.Size = new System.Drawing.Size(61, 20);
            this.textBoxClientPort.TabIndex = 15;
            this.textBoxClientPort.Text = "15000";
            this.textBoxClientPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxServerPort
            // 
            this.textBoxServerPort.Location = new System.Drawing.Point(225, 41);
            this.textBoxServerPort.Name = "textBoxServerPort";
            this.textBoxServerPort.Size = new System.Drawing.Size(61, 20);
            this.textBoxServerPort.TabIndex = 14;
            this.textBoxServerPort.Text = "15000";
            this.textBoxServerPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 428);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(377, 23);
            this.progressBar1.TabIndex = 16;
            this.progressBar1.Value = 75;
            // 
            // DownloadPlace_button
            // 
            this.DownloadPlace_button.Location = new System.Drawing.Point(301, 11);
            this.DownloadPlace_button.Name = "DownloadPlace_button";
            this.DownloadPlace_button.Size = new System.Drawing.Size(88, 23);
            this.DownloadPlace_button.TabIndex = 17;
            this.DownloadPlace_button.Text = "Загружать в...";
            this.DownloadPlace_button.UseVisualStyleBackColor = true;
            this.DownloadPlace_button.Click += new System.EventHandler(this.DownloadPlace_button_Click);
            // 
            // time_label
            // 
            this.time_label.AutoSize = true;
            this.time_label.Location = new System.Drawing.Point(12, 412);
            this.time_label.Name = "time_label";
            this.time_label.Size = new System.Drawing.Size(25, 13);
            this.time_label.TabIndex = 18;
            this.time_label.Text = "      ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 477);
            this.Controls.Add(this.time_label);
            this.Controls.Add(this.DownloadPlace_button);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.textBoxClientPort);
            this.Controls.Add(this.textBoxServerPort);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxIPClient);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxIPserver);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonAddFile);
            this.Controls.Add(this.buttonSendData);
            this.Controls.Add(this.textBoxSend);
            this.Controls.Add(this.buttonConnect);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.buttonStartServer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "TCP - отправка файлов по сети";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonStartServer;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.Button buttonSendData;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonAddFile;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxIPserver;
        public System.Windows.Forms.TextBox textBoxSend;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.Label labelFileName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxIPClient;
        private System.Windows.Forms.TextBox textBoxClientPort;
        private System.Windows.Forms.TextBox textBoxServerPort;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button DownloadPlace_button;
        private System.Windows.Forms.Label time_label;
    }
}


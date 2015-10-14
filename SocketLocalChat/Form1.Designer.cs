namespace SocketLocalChat
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Send = new System.Windows.Forms.Button();
            this.IP = new System.Windows.Forms.TextBox();
            this.ChatBox = new System.Windows.Forms.RichTextBox();
            this.Message = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Send
            // 
            this.Send.Location = new System.Drawing.Point(183, 12);
            this.Send.Name = "Send";
            this.Send.Size = new System.Drawing.Size(75, 23);
            this.Send.TabIndex = 0;
            this.Send.Text = "Отправить";
            this.Send.UseVisualStyleBackColor = true;
            this.Send.Click += new System.EventHandler(this.Send_Click);
            // 
            // IP
            // 
            this.IP.Location = new System.Drawing.Point(0, 12);
            this.IP.Name = "IP";
            this.IP.Size = new System.Drawing.Size(177, 20);
            this.IP.TabIndex = 1;
            this.IP.Tag = "Enter IP here";
            this.IP.Text = "127.0.0.1";
            this.IP.Enter += new System.EventHandler(this.IP_Enter);
            this.IP.Leave += new System.EventHandler(this.IP_Leave);
            // 
            // ChatBox
            // 
            this.ChatBox.Location = new System.Drawing.Point(0, 38);
            this.ChatBox.Name = "ChatBox";
            this.ChatBox.ReadOnly = true;
            this.ChatBox.Size = new System.Drawing.Size(177, 123);
            this.ChatBox.TabIndex = 2;
            this.ChatBox.Text = "";
            // 
            // Message
            // 
            this.Message.Location = new System.Drawing.Point(0, 167);
            this.Message.Name = "Message";
            this.Message.Size = new System.Drawing.Size(177, 48);
            this.Message.TabIndex = 3;
            this.Message.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(182, 49);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 41);
            this.button1.TabIndex = 4;
            this.button1.Text = "Отправить файл";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(1, 218);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(258, 23);
            this.progressBar1.TabIndex = 5;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(182, 105);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 40);
            this.button2.TabIndex = 6;
            this.button2.Text = "Старт сервера";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(261, 242);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Message);
            this.Controls.Add(this.ChatBox);
            this.Controls.Add(this.IP);
            this.Controls.Add(this.Send);
            this.Name = "Form1";
            this.Text = "SocketLocalChat";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Send;
        private System.Windows.Forms.TextBox IP;
        private System.Windows.Forms.RichTextBox ChatBox;
        private System.Windows.Forms.RichTextBox Message;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button button2;
    }
}


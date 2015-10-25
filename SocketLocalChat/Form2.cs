using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows;

namespace SocketLocalChat
{
    partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
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
            this.label1 = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.percent = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.fileName = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.sec = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Файл:";
            //this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(3, 60);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(279, 23);
            this.progressBar.TabIndex = 1;
            //this.progressBar.Click += new System.EventHandler(this.progressBar1_Click);
            // 
            // percent
            // 
            this.percent.AutoSize = true;
            this.percent.Location = new System.Drawing.Point(4, 26);
            this.percent.Name = "percent";
            this.percent.Size = new System.Drawing.Size(81, 13);
            this.percent.TabIndex = 2;
            this.percent.Text = "Размер:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Пришло:";
            // 
            // fileName
            // 
            this.fileName.AutoSize = true;
            this.fileName.Location = new System.Drawing.Point(50, 9);
            this.fileName.Name = "fileName";
            this.fileName.Size = new System.Drawing.Size(16, 13);
            this.fileName.TabIndex = 4;
            this.fileName.Text = "   ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(91, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(16, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "   ";
            // 
            // sec
            // 
            this.sec.AutoSize = true;
            this.sec.Location = new System.Drawing.Point(87, 44);
            this.sec.Name = "sec";
            this.sec.Size = new System.Drawing.Size(16, 13);
            this.sec.TabIndex = 6;
            this.sec.Text = "   ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 85);
            this.Controls.Add(this.sec);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.fileName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.percent);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Передача";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.ProgressBar progressBar;
        public System.Windows.Forms.Label percent;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label fileName;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.Label sec;

        public Thread myThread;

        /*private void progressBar1_Click(object sender, EventArgs e)
        {
            Thread.Sleep(Timeout.Infinite);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            myThread.Interrupt();
        }*/
    }
}


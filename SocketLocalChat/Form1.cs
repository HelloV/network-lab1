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
    public partial class Form1 : Form
    {
        int QuantityByteInStep = 1024*2;

        private void IP_Enter(object sender, EventArgs e)
        {
            if (IP.Text == (String)IP.Tag)
            {
                IP.Text = "";
            }
        }

        private void IP_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(IP.Text))
            {
                IP.Text = (String)IP.Tag;
            }
        }


        public Form1()
        {
            InitializeComponent();
        }

        //Метод потока
        protected void Receiver()
        {
            //и заведем заранее сокет
            Socket ReceiveSocket;
            //Создаем Listener на порт "по умолчанию"
            TcpListener Listen = new TcpListener(Int32.Parse(PORT.Text)-1);

            try
            {
                //Начинаем прослушку
                Listen.Start();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            while (true)
            {
                try
                {
                    //Пришло сообщение
                    ReceiveSocket = Listen.AcceptSocket();
                    Byte[] Receive = new Byte[QuantityByteInStep];
                    //Читать сообщение будем в поток
                    using (MemoryStream MessageR = new MemoryStream())
                    {
                        //Количество считанных байт
                        Int32 ReceivedBytes;
                        do
                        {//Собственно читаем
                            ReceivedBytes = ReceiveSocket.Receive(Receive, Receive.Length, 0);
                            //и записываем в поток
                            MessageR.Write(Receive, 0, ReceivedBytes);
                            //Читаем до тех пор, пока в очереди не останется данных
                        } while (ReceiveSocket.Available > 0);
                        //Добавляем изменения в ChatBox
                        ChatBox.BeginInvoke(AcceptDelegate, new object[] { "Сообщение принято. " + Encoding.Default.GetString(MessageR.ToArray()), ChatBox });
                    }
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    break;
                }

            }
        }

        //Метод потока
        protected void FileReceiver()
        {
            //Создаем Listener на порт "по умолчанию"
            TcpListener Listen = new TcpListener(Int32.Parse(PORT.Text));
            //и заведем заранее сокет
            Socket ReceiveSocket;
            try
            {
                //Начинаем прослушку
                Listen.Start();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            while (true)
            {
                try
                {
                    //Пришло сообщение
                    ReceiveSocket = Listen.AcceptSocket();
                    Byte[] Receive = new Byte[QuantityByteInStep];
                    //Читать сообщение будем в поток
                    using (MemoryStream MessageR = new MemoryStream())
                    {

                        //Количество считанных байт
                        Int32 ReceivedBytes;
                        Int32 FirestQuantityByteInStepBytes = 0;
                        String FilePath = "";
                        //Если true, то первые QuantityByteInStep прочитаны
                        bool firstBytes = false;

                        string resFilePath = "";
                        string resFileSize = "";


                        do
                        {//Собственно читаем
                            ReceivedBytes = ReceiveSocket.Receive(Receive, Receive.Length, 0);
                            //Разбираем первые QuantityByteInStep байт
                            if (FirestQuantityByteInStepBytes < QuantityByteInStep)
                            {
                                FirestQuantityByteInStepBytes += ReceivedBytes;
                                Byte[] ToStr = Receive;
                                //Учтем, что может возникнуть ситуация, когда они не могу передаться "сразу" все
                                if (FirestQuantityByteInStepBytes > QuantityByteInStep)
                                {
                                    Int32 Start = FirestQuantityByteInStepBytes - ReceivedBytes;
                                    Int32 CountToGet = QuantityByteInStep - Start;
                                    FirestQuantityByteInStepBytes = QuantityByteInStep;
                                    //В случае если было принято >QuantityByteInStep байт (двумя сообщениями к примеру)
                                    //Остаток (до QuantityByteInStep) записываем в "путь файла"
                                    ToStr = Receive.Take(CountToGet).ToArray();
                                    //А остальную часть - в будующий файл
                                    Receive = Receive.Skip(CountToGet).ToArray();
                                    MessageR.Write(Receive, 0, ReceivedBytes);
                                    firstBytes = true;
                                }
                                //Накапливаем имя файла
                                FilePath += Encoding.Default.GetString(ToStr);

                            }
                            else
                            {
                                if (firstBytes || FirestQuantityByteInStepBytes == QuantityByteInStep)
                                {
                                    //Уже можем прочитать имя и разме рфайла
                                    //Убираем лишние байты
                                    String resFilePathAndFileSize = FilePath.Substring(0, FilePath.IndexOf('\0'));
                                    char[] separators = { '^' };
                                    string[] words = resFilePathAndFileSize.Split(separators);
                                    resFilePath = words[0];
                                    resFileSize = words[1];
                                    firstBytes = false;
                                    FirestQuantityByteInStepBytes = QuantityByteInStep + 1;
                                    ChatBox.BeginInvoke(AcceptDelegate, new object[] { "Началось принятие файла. " + resFilePath, ChatBox });
                                }
                                //и записываем в поток
                                MessageR.Write(Receive, 0, ReceivedBytes);
                            }
                            //Читаем до тех пор, пока в очереди не останется данных
                        } while (ReceivedBytes > 0);

                        string tempFilePath;
                        if (filePath != "")
                        {
                            tempFilePath = filePath + "//" + resFilePath;
                        }
                        else
                        {
                            tempFilePath = resFilePath;
                        }

                        using (var File = new FileStream(tempFilePath, FileMode.Create))
                        {
                            //Записываем в файл
                            File.Write(MessageR.ToArray(), 0, MessageR.ToArray().Length);

                            //Уведомляем об этом
                            ChatBox.BeginInvoke(AcceptDelegate, new object[] { "Файл принят. " + File.Name, ChatBox });
                        }

                    }
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    break;
                }
            }
        }

        /// <summary>
        /// Отправляет сообщение в потоке на IP, заданный в контроле IP
        /// </summary>
        /// <param name="Message">Передаваемое сообщение</param>
        void ThreadSend(object Message)
        {
            try
            {
                //Проверяем входной объект на соответствие строке
                String MessageText = "";
                if (Message is String)
                {
                    MessageText = Message as String;
                }
                else
                    throw new Exception("На вход необходимо подавать строку");

                Byte[] SendBytes = Encoding.Default.GetBytes(MessageText);
                //Создаем сокет, коннектимся
                IPEndPoint EndPoint = new IPEndPoint(IPAddress.Parse(IP.Text), Int32.Parse(PORT.Text)-1);
                Socket Connector = new Socket(EndPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                Connector.Connect(EndPoint);
                Connector.Send(SendBytes);
                Connector.Close();
                //Изменяем поле сообщений (уведомляем, что отправили сообщение)

                ChatBox.BeginInvoke(AcceptDelegate, new object[] { "Send " + MessageText, ChatBox });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void showForm(object paramform)
        {
            //OpenFileDialog file = paramfile as OpenFileDialog;
            Form2 process = paramform as Form2;
            //Form2 process = new Form2();
            //process.fileName.Text = file.FileName;
            //process.Show();
            process.ShowDialog();
            //while (process.progressBar.Value != 100)
            //{
            //Thread.Sleep(1000);
            //}
            //Application.Run(process);
        }

        /// <summary>
        /// Отправляет файл в потоке на IP, заданный в контроле IP
        /// </summary>
        void ThreadFileSend(object paramfile)
        {
            //Получаем информацию о выбранном файле
            OpenFileDialog file = paramfile as OpenFileDialog;
            //Создаём и запускаем в отдельном потоке форму с информацией о передаче очередного файла
            Form2 process = new Form2();
            process.fileName.Text = file.FileName;
            process.label5.Text = "0";
            process.sec.Text = "0";
            process.progressBar.Value = 1;
            Thread processThread = new Thread(new ParameterizedThreadStart(showForm));
            processThread.Name = "processThread";
            process.myThread = processThread;
            processThread.Start(process);

            try
            {
                //Коннектимся
                IPEndPoint EndPoint = new IPEndPoint(IPAddress.Parse(IP.Text), Int32.Parse(PORT.Text));
                Socket Connector = new Socket(EndPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                Connector.Connect(EndPoint);
                //Получаем имя из полного пути к файлу
                StringBuilder FileName = new StringBuilder(file.FileName);
                //Выделяем имя файла
                int index = FileName.Length - 1;
                while (FileName[index] != '\\' && FileName[index] != '/')
                {
                    index--;
                }
                //Получаем имя файла
                String resFileName = "";
                for (int i = index + 1; i < FileName.Length; i++)
                    resFileName += FileName[i];

                //Записываем в лист
                List<Byte> FirstQuantityByteInStepBytes = Encoding.Default.GetBytes(resFileName).ToList();
                Int32 Diff = QuantityByteInStep - FirstQuantityByteInStepBytes.Count;

                //Приписываем размер файла
                long fileSize = (new FileInfo(file.FileName)).Length;
                List<Byte> bytefileSize = Encoding.Default.GetBytes("^" + fileSize.ToString() + "^").ToList();
                for (int i = 0; i < bytefileSize.Count; i++)
                    FirstQuantityByteInStepBytes.Add(bytefileSize[i]);
                Diff -= bytefileSize.Count;

                //Остаток заполняем нулями
                for (int i = 0; i < Diff; i++)
                    FirstQuantityByteInStepBytes.Add(0);

                //Начинаем отправку данных
                Byte[] ReadedBytes = new Byte[QuantityByteInStep];
                using (var FileStream = new FileStream(file.FileName, FileMode.Open))
                {
                    using (var Reader = new BinaryReader(FileStream))
                    {
                        Int32 CurrentReadedBytesCount;
                        Int32 NumCurrentReadedBytesCount = 0;
                        //Вначале отправим название файла
                        Connector.Send(FirstQuantityByteInStepBytes.ToArray());
                        do
                        {
                            //Затем по частям - файл
                            CurrentReadedBytesCount = Reader.Read(ReadedBytes, 0, ReadedBytes.Length);
                            Connector.Send(ReadedBytes, CurrentReadedBytesCount, SocketFlags.None);
                            NumCurrentReadedBytesCount += CurrentReadedBytesCount;

                            Thread.Sleep(1);
                            process.progressBar.BeginInvoke(AcceptDelegatePB, new object[] { (int)(((double)NumCurrentReadedBytesCount / (double)fileSize) * 100), process.progressBar });
                            process.sec.BeginInvoke(AcceptDelegate2, new object[] { NumCurrentReadedBytesCount.ToString() + " байт (" + (((double)NumCurrentReadedBytesCount / (double)fileSize) * 100).ToString() + "%)", process.sec });
                            process.label5.BeginInvoke(AcceptDelegate2, new object[] { fileSize.ToString() + " байт", process.label5 });
                        }
                        while (CurrentReadedBytesCount == ReadedBytes.Length);
                    }
                }
                //Завершаем передачу данных
                Connector.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //processThread.Abort();
        }

        //Делегат доступа к контролам формы
        delegate void SendMsg(String Text, RichTextBox Rtb);
        delegate void SendMsg2(String Text, Label Rtb);
        delegate void SetValue(int Value, ProgressBar PB);

        SendMsg AcceptDelegate = (String Text, RichTextBox Rtb) =>
        {
            Rtb.Text += Text + "\n";
        };

        SendMsg2 AcceptDelegate2 = (String Text, Label Rtb) =>
        {
            Rtb.Text = Text;
        };

        SetValue AcceptDelegatePB = (int Value, ProgressBar PB) =>
        {
            if (Value <= 100)
                PB.Value = Value;
        };

        //Обработчик кнопки
        private void Send_Click(object sender, EventArgs e)
        {
            Thread SendMessThread = new Thread(new ParameterizedThreadStart(ThreadSend));
            SendMessThread.Name = "SendMessThread";
            SendMessThread.Start(Message.Text);
            //new Thread(new ParameterizedThreadStart(ThreadSend)).Start(Message.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Добавим на форму OpenFileDialog и вызовем его
            OpenFileDialog curFileDialog = new OpenFileDialog();
            if (curFileDialog.ShowDialog() == DialogResult.OK)
            {
                Thread SendFileThread = new Thread(new ParameterizedThreadStart(ThreadFileSend));
                SendFileThread.Name = "ThreadFileSend";
                SendFileThread.Start(curFileDialog);
                //SendFileThread.Priority = ThreadPriority.Highest;
                //new Thread(new ParameterizedThreadStart(ThreadFileSend)).Name("ThreadFileSend").Start(curFileDialog);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Сервер
            button2.Enabled = false;
            button3.Enabled = false;
            // Получение имени компьютера.
            String host = System.Net.Dns.GetHostName();
            // Получение ip-адреса.
            System.Net.IPAddress ip = System.Net.Dns.GetHostByName(host).AddressList[0];
            IP.Text = ip.ToString();
            IP.Enabled = false;
            PORT.Enabled = false;
            button4.Enabled = true;
            button5.Enabled = true;

            //Создаем поток для приема сообщений
            Thread ThreadReceiver = new Thread(new ThreadStart(Receiver));
            ThreadReceiver.Name = "ThreadReceiver";
            ThreadReceiver.Start();

            Thread ThreadFileReceiver = new Thread(new ThreadStart(FileReceiver));
            ThreadFileReceiver.Name = "ThreadFileReceiver";
            ThreadFileReceiver.Start();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Клиент
            button2.Enabled = false;
            button3.Enabled = false;
            IP.Enabled = false;
            PORT.Enabled = false;
            Send.Enabled = true;
            button1.Enabled = true;
            Message.Enabled = true;
            button4.Enabled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Сброс
            button2.Enabled = true;
            button3.Enabled = true;
            IP.Enabled = true;
            PORT.Enabled = true;
            Send.Enabled = false;
            button1.Enabled = false;
            Message.Enabled = false;
            button5.Enabled = false;

        }

        private string filePath = "";
        private void button5_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                filePath = dlg.SelectedPath;
                button5.Enabled = false;
            }
        }

    }
}

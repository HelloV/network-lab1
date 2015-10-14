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

        int QuantityByteInStep = 1024 * 2;


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
            //Создаем Listener на порт "по умолчанию"
            TcpListener Listen = new TcpListener(7000);
            //Начинаем прослушку
            Listen.Start();
            //и заведем заранее сокет
            Socket ReceiveSocket;
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
                        ChatBox.BeginInvoke(AcceptDelegate, new object[] { "Received " + Encoding.Default.GetString(MessageR.ToArray()), ChatBox });
                    }
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.Message + "Error place 1");
                }

            }
        }

        /*//Метод потока
        protected void FileReceiver()
        {
            //Создаем Listener на порт "по умолчанию"
            TcpListener Listen = new TcpListener(6999);
            //Начинаем прослушку
            Listen.Start();
            //и заведем заранее сокет
            Socket ReceiveSocket;
            while (true)
            {
                try
                {
                    //Пришло сообщение
                    ReceiveSocket = Listen.AcceptSocket();
                    Byte[] Receive = new Byte[QuantityByteInStep];
                    int percent = 0;
                    //Читать сообщение будем в поток
                    int currentMemoryStream = 0;
                    int numberFile = 0;
                    MemoryStream[] MessageR = new MemoryStream[3];
                    try
                    {
                        //Количество считанных байт
                        Int32 ReceivedBytes;
                        Int32 FirestQuantityByteInStepBytes = 0;
                        String FilePath = "";
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
                                    Int32 Start = FirestQuantityByteInStepBytes - ReceivedBytes; //Количество байт, которые не относятся к названию
                                    Int32 CountToGet = QuantityByteInStep - Start; //Начиная с какой позиции в очередном сообщении закончилось передаваться название и начался файл
                                    FirestQuantityByteInStepBytes = QuantityByteInStep;
                                    //В случае если было принято >QuantityByteInStep байт (двумя сообщениями к примеру)
                                    //Остаток (до QuantityByteInStep) записываем в "путь файла"
                                    ToStr = Receive.Take(CountToGet).ToArray();
                                    //А остальную часть - в будующий файл
                                    Receive = Receive.Skip(CountToGet).ToArray();
                                    MessageR[currentMemoryStream] = new MemoryStream();
                                    numberFile++;
                                    MessageR[currentMemoryStream].Write(Receive, 0, ReceivedBytes);
                                }
                                 
                                //Накапливаем имя файла
                                FilePath += Encoding.Default.GetString(ToStr);
                            }
                            else
                            {
                                //и записываем в поток
                                if (MessageR[currentMemoryStream] == null)
                                {
                                    numberFile++;
                                    MessageR[currentMemoryStream] = new MemoryStream();
                                }
                                progressBar1.BeginInvoke(AcceptDelegate2, new object[] { percent = percent + 1, progressBar1 });
                                System.Threading.Thread.Sleep(10);
                                MessageR[currentMemoryStream].Write(Receive, 0, ReceivedBytes);
                            }
                            //Читаем до тех пор, пока в очереди не останется данных
                        } while (ReceivedBytes == Receive.Length);
                        //Убираем лишние байты
                        String resFilePath = FilePath.Substring(0, FilePath.IndexOf('\0'));
                        List<FileStream> File = new List<FileStream>();
                        File.Add(new FileStream(resFilePath, FileMode.Create));
                        try
                        {
                            //Записываем в файл
                            File[0].Write(MessageR[currentMemoryStream].ToArray(), 0, MessageR[currentMemoryStream].ToArray().Length);
                        }
                        finally
                        {
                            foreach (FileStream file in File)
                            {
                                file.Dispose();
                            }
                        }
                        
                        //Уведомим пользователя
                        ChatBox.BeginInvoke(AcceptDelegate, new object[] { "Received: " + resFilePath, ChatBox });
                    }
                    finally
                    {
                        for (int i = 0; i < numberFile; i++)
                        {
                            MessageR[i].Dispose();
                        }
                    }
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.Message + "Error place 2");
                }

            }
        }
        */
        protected void FileReceiver()
        {


            //Создаем Listener на порт "по умолчанию"
            TcpListener Listen = new TcpListener(6999);
            //Начинаем прослушку
            Listen.Start();
            //и заведем заранее сокет
            Socket ReceiveSocket;
            while (true)
            {
                try
                {
                    //Пришло сообщение
                    ReceiveSocket = Listen.AcceptSocket();
                    Byte[] Receive = new Byte[QuantityByteInStep];
                    double percent = 0;

                    Form loading = new Form();
                    System.Windows.Forms.ProgressBar progressBar = new ProgressBar();
                    loading.Controls.Add(progressBar);
                    loading.Name = "Form";
                    loading.Text = "Loading";
                    loading.AutoSize = true;
                    progressBar.Location = new System.Drawing.Point(1, 1);
                    progressBar.Name = "progressBar1";
                    progressBar.Size = new System.Drawing.Size(258, 23);
                    progressBar.TabIndex = 5;

                    double newPercent = 0;
                    //Читать сообщение будем в поток
                    int currentMemoryStream = -1;
                    int numberFile = 2;
                    int currentReceivedBytes = QuantityByteInStep;
                    MemoryStream[] MessageR = new MemoryStream[3];
                    try
                    {
                        //Количество считанных байт
                        Int32 ReceivedBytes = 0;
                        Int32 FirestQuantityByteInStepBytes = 0;
                        long allQuantityBytes = 0;
                        String FilePath = "";
                        int FileSize = 0;

                        OneStepReceive(ReceiveSocket, ref ReceivedBytes, new Byte[0], ref Receive);
                        FileSize = Convert.ToInt32(Encoding.Default.GetString(Receive));
                        //OneStepReceive(ReceiveSocket, ref ReceivedBytes, Receive, ref Receive);
                        //FilePath = Encoding.Default.GetString(Receive);

                        //loading.Show();
                        do
                        {

                            /*OneStepReceive(ReceiveSocket, ref ReceivedBytes, new Byte[0], ref Receive);
                            if (MessageR[currentMemoryStream] == null)
                            {
                                numberFile++;
                                MessageR[currentMemoryStream] = new MemoryStream();
                            }
                            newPercent = percent + (100 / ((double)FileSize / (double)QuantityByteInStep));
                            if ((int)percent < (int)newPercent)
                            {
                                progressBar1.BeginInvoke(AcceptDelegate2, new object[] { (int)newPercent, progressBar1 });
                                //progressBar.Value = (int)newPercent;
                                System.Threading.Thread.Sleep(50);
                            }
                            percent = newPercent;
                            MessageR[currentMemoryStream].Write(Receive, 0, ReceivedBytes);*/


                            //OneStepReceive(Socket ReceiveSocket, Int32 ReceivedBytes, Byte[] initialData, Byte[] result);

                            //Собственно читаем
                            //ReceivedBytes = ReceiveSocket.Receive(Receive, Receive.Length, 0);
                            ReceivedBytes = ReceiveSocket.Receive(Receive, currentReceivedBytes, 0);
                            allQuantityBytes += ReceivedBytes;
                            progressBar1.BeginInvoke(AcceptDelegate2, new object[] { (int)ReceivedBytes, progressBar1 });
                            //Разбираем первые QuantityByteInStep байт
                            if (FirestQuantityByteInStepBytes < QuantityByteInStep)
                            {
                                FirestQuantityByteInStepBytes += ReceivedBytes;
                                Byte[] ToStr = Receive;
                                //Учтем, что может возникнуть ситуация, когда они не могу передаться "сразу" все
                                if (FirestQuantityByteInStepBytes > QuantityByteInStep)
                                {
                                    Int32 Start = FirestQuantityByteInStepBytes - ReceivedBytes; //Количество байт, которые не относятся к названию
                                    Int32 CountToGet = QuantityByteInStep - Start; //Начиная с какой позиции в очередном сообщении закончилось передаваться название и начался файл
                                    FirestQuantityByteInStepBytes = QuantityByteInStep;
                                    //В случае если было принято >QuantityByteInStep байт (двумя сообщениями к примеру)
                                    //Остаток (до QuantityByteInStep) записываем в "путь файла"
                                    ToStr = Receive.Take(CountToGet).ToArray();
                                    //А остальную часть - в будующий файл
                                    Receive = Receive.Skip(CountToGet).ToArray();
                                    MessageR[currentMemoryStream] = new MemoryStream();
                                    numberFile++;
                                    MessageR[currentMemoryStream].Write(Receive, 0, ReceivedBytes);
                                }
                                //Накапливаем имя файла
                                FilePath += Encoding.Default.GetString(ToStr);
                            }
                            else
                            {
                                //и записываем в поток
                                newPercent = percent + (100 / ((double)FileSize / (double)QuantityByteInStep));
                                if ((int)percent < (int)newPercent)
                                {
                                    progressBar1.BeginInvoke(AcceptDelegate2, new object[] { (int)newPercent, progressBar1 });
                                    //progressBar.Value = (int)newPercent;
                                    System.Threading.Thread.Sleep(50);
                                }
                                percent = newPercent;

                                if (currentMemoryStream != -1 && MessageR[currentMemoryStream] == null)
                                {
                                    //numberFile++;
                                    MessageR[currentMemoryStream] = new MemoryStream();
                                }

                                if (ReceivedBytes < QuantityByteInStep && ReceivedBytes > 0) //Прочитали меньше чем QuantityByteInStep
                                {
                                    if (currentReceivedBytes != QuantityByteInStep) //Оказывается мы и хотели читать меньше чем QuantityByteInStep
                                    {
                                        if (currentReceivedBytes == ReceivedBytes) //Прочли ровно столько, сколько хотели
                                        {
                                            currentReceivedBytes = QuantityByteInStep; //В следующий раз читаем сколько положено изначально
                                            //next
                                            currentMemoryStream = (currentMemoryStream + 1) % numberFile;
                                        }
                                        else
                                        {
                                            currentReceivedBytes = currentReceivedBytes - ReceivedBytes;
                                        }
                                    }
                                    else
                                    {
                                        currentReceivedBytes = currentReceivedBytes - ReceivedBytes;
                                    }
                                }
                                else
                                {
                                    currentReceivedBytes = QuantityByteInStep; //В следующий раз читаем сколько положено изначально
                                    //next
                                    currentMemoryStream = (currentMemoryStream + 1) % numberFile;
                                }

                                if (currentMemoryStream != -1 && MessageR[currentMemoryStream] == null)
                                {
                                    //numberFile++;
                                    MessageR[currentMemoryStream] = new MemoryStream();
                                }

                                MessageR[currentMemoryStream].Write(Receive, 0, ReceivedBytes);
                            }
                            //Читаем до тех пор, пока в очереди не останется данных
                            //} while (ReceivedBytes == Receive.Length);
                        } while (ReceivedBytes > 0);
                        System.Threading.Thread.Sleep(0);
                        loading.Close();

                        //Убираем лишние байты
                        String resFilePath = FilePath.Substring(0, FilePath.IndexOf('\0'));
                        List<FileStream> File = new List<FileStream>();
                        File.Add(new FileStream(resFilePath, FileMode.Create));
                        File.Add(new FileStream(resFilePath + "22222", FileMode.Create));
                        try
                        {
                            //Записываем в файл
                            File[0].Write(MessageR[0].ToArray(), 0, MessageR[0].ToArray().Length);
                            File[1].Write(MessageR[1].ToArray(), 0, MessageR[1].ToArray().Length);
                        }
                        finally
                        {
                            foreach (FileStream file in File)
                            {
                                file.Dispose();
                            }
                        }

                        //Уведомим пользователя
                        System.Threading.Thread.Sleep(0);
                        ChatBox.BeginInvoke(AcceptDelegate, new object[] { "Received: " + resFilePath + ". Original size: " + FileSize / 1024 + ". Size: " + allQuantityBytes / 1024, ChatBox });
                    }
                    finally
                    {
                        for (int i = 0; i < numberFile; i++)
                        {
                            MessageR[i].Dispose();
                        }
                    }
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.Message + "Error place 2");
                }

            }
        }

        /// <summary>
        /// Осуществляет приём ровно QuantityByteInStep байт
        /// </summary>
        /// <param name="Receive">Открытый сокет</param>
        /// <param name="ReceivedBytes">Количество прочитанных байт</param>
        /// <param name="initialData">Начало массива байтов</param>
        /// <param name="result">Прочитанные байты</param>
        protected void OneStepReceive(Socket ReceiveSocket, ref Int32 ReceivedBytes, Byte[] initialData, ref Byte[] result)
        {
            Byte[] Receive = new Byte[QuantityByteInStep];
            Int32 FirestQuantityByteInStepBytes = 0;

            ReceivedBytes = ReceiveSocket.Receive(Receive, Receive.Length - ReceivedBytes, 0);
            //Разбираем первые QuantityByteInStep байт
            if (FirestQuantityByteInStepBytes < QuantityByteInStep)
            {
                FirestQuantityByteInStepBytes += ReceivedBytes;
                Byte[] ToStr = Receive;
                //Учтем, что может возникнуть ситуация, когда они не могу передаться "сразу" все
                /*if (FirestQuantityByteInStepBytes > QuantityByteInStep)
                {
                    Int32 Start = FirestQuantityByteInStepBytes - ReceivedBytes; //Количество байт, которые не относятся к названию
                    Int32 CountToGet = QuantityByteInStep - Start; //Начиная с какой позиции в очередном сообщении закончилось передаваться название и начался файл
                    FirestQuantityByteInStepBytes = QuantityByteInStep;
                    //В случае если было принято >QuantityByteInStep байт (двумя сообщениями к примеру)
                    //Остаток (до QuantityByteInStep) записываем в "путь файла"
                    ToStr = Receive.Take(CountToGet).ToArray();
                    //А остальную часть - в будующий файл
                    Receive = Receive.Skip(CountToGet).ToArray();
                    MessageR[currentMemoryStream] = new MemoryStream();
                    numberFile++;
                    MessageR[currentMemoryStream].Write(Receive, 0, ReceivedBytes);
                }*/
                //Накапливаем имя файла
                //FilePath += Encoding.Default.GetString(ToStr);
                result = Receive;
            }
            else
            {
                result = Receive.Concat(initialData).ToArray();
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
                IPEndPoint EndPoint = new IPEndPoint(IPAddress.Parse(IP.Text), 7000);
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

        //Делегат доступа к контролам формы
        delegate void SendMsg(String Text, RichTextBox Rtb);

        SendMsg AcceptDelegate = (String Text, RichTextBox Rtb) =>
            {
                Rtb.Text += Text + "\n";
            };

        delegate void SendMsg2(int Text, ProgressBar Rtb);

        SendMsg2 AcceptDelegate2 = (int Text, ProgressBar Rtb) =>
        {
            if (Text <= 100)
            {
                Rtb.Value = Text;
                //Rtb.Update();
            }
        };

        //Обработчик кнопки
        private void Send_Click(object sender, EventArgs e)
        {

            Thread SendThread = new Thread(new ParameterizedThreadStart(ThreadSend));
            SendThread.Start(Message.Text);
            SendThread.Priority = ThreadPriority.Lowest;
        }

        private void button1_Click(object sender, EventArgs e)
        {//Отправляем файл
            //Добавим на форму OpenFileDialog и вызовем его
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Thread SendFileThread = new Thread(new ThreadStart(ThreadSendFile));
                SendFileThread.Start();
                SendFileThread.Priority = ThreadPriority.Highest;
            }
        }

        void ThreadSendFile()
        {
            try
            {
                //Коннектимся
                IPEndPoint EndPoint = new IPEndPoint(IPAddress.Parse(IP.Text), 6999);
                Socket Connector = new Socket(EndPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                Connector.Connect(EndPoint);
                //Получаем имя из полного пути к файлу
                StringBuilder FileName = new StringBuilder(openFileDialog1.FileName);
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
                //Остаток заполняем нулями
                for (int i = 0; i < Diff; i++)
                    FirstQuantityByteInStepBytes.Add(0);

                long fileSize = (new FileInfo(openFileDialog1.FileName)).Length;
                List<Byte> FirstQuantityByteInStepBytes2 = Encoding.Default.GetBytes(fileSize.ToString()).ToList();
                Diff = QuantityByteInStep - FirstQuantityByteInStepBytes2.Count;
                //Остаток заполняем нулями
                for (int i = 0; i < Diff; i++)
                    FirstQuantityByteInStepBytes2.Add(0);

                //Начинаем отправку данных
                Byte[] ReadedBytes = new Byte[QuantityByteInStep];

                FileStream FileStream2 = new FileStream(openFileDialog1.FileName, FileMode.Open);
                FileStream FileStream3 = new FileStream(openFileDialog1.FileName + "2", FileMode.Open);
                BinaryReader Reader2 = new BinaryReader(FileStream2);
                BinaryReader Reader3 = new BinaryReader(FileStream3);

                try
                {
                    Int32 CurrentReadedBytesCount;
                    //Вначале отправим размер и название файла
                    Connector.Send(FirstQuantityByteInStepBytes2.ToArray());
                    Connector.Send(FirstQuantityByteInStepBytes.ToArray());
                    do
                    {
                        //Затем по частям - файл
                        CurrentReadedBytesCount = Reader2.Read(ReadedBytes, 0, ReadedBytes.Length);
                        Connector.Send(ReadedBytes, CurrentReadedBytesCount, SocketFlags.None);

                        if (CurrentReadedBytesCount != ReadedBytes.Length)
                        {
                            List<Byte> tempList = new List<Byte>();
                            Diff = QuantityByteInStep - CurrentReadedBytesCount;
                            //Остаток заполняем нулями
                            for (int i = 0; i < Diff; i++)
                                tempList.Add(0);
                            Connector.Send(tempList.ToArray());
                        }

                        CurrentReadedBytesCount = Reader3.Read(ReadedBytes, 0, ReadedBytes.Length);
                        Connector.Send(ReadedBytes, CurrentReadedBytesCount, SocketFlags.None);
                    }
                    while (CurrentReadedBytesCount == ReadedBytes.Length);

                }
                finally
                {
                    FileStream2.Dispose();
                    Reader2.Dispose();
                }
                //Завершаем передачу данных
                Connector.Close();
            }
            catch (Exception ex)
            {
                ChatBox.BeginInvoke(AcceptDelegate, new object[] { "Error: " + ex.Message, ChatBox });
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Создаем поток для приема сообщений
            Thread ReceiverThread = new Thread(new ThreadStart(Receiver));
            ReceiverThread.Start();
            Thread FileReceiverThread = new Thread(new ThreadStart(FileReceiver));
            FileReceiverThread.Start();
            FileReceiverThread.Priority = ThreadPriority.Lowest;
        }
    }
}

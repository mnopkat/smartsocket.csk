using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.IO.Ports;

namespace ConsoleApplication1
{
    class Program
    {
        private static string _port;

        public static void Main()
        {
            // Получаем COM порт Arduino
            SerialPort por1 = new SerialPort();
            string[] ports = SerialPort.GetPortNames();
            foreach (string port in ports)
                _port = port;

            // Устанавливаем для сокета локальную конечную точку
            IPAddress ipAddr = IPAddress.Parse("0.0.0.0");
            IPEndPoint ipEndPoint = new IPEndPoint(ipAddr, 10000);
            // Создаем сокет Tcp/Ip
            Socket sListener = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            // Назначаем сокет локальной конечной точке и слушаем входящие сокеты
            try
            {
                sListener.Bind(ipEndPoint);
                sListener.Listen(1);

                // Начинаем слушать соединения
                while (true)
                {
                    por1.PortName = _port;
                    por1.BaudRate = 9600;
                    por1.DataBits = 8;
                    por1.Open();
                    Console.WriteLine("Ожидаем соединение через порт {0}", ipEndPoint);

                    // Программа приостанавливается, ожидая входящее соединение
                    Socket handler = sListener.Accept();
                    string data = null;

                    // Мы дождались клиента, пытающегося с нами соединиться

                    byte[] bytes = new byte[1024];
                    int bytesRec = handler.Receive(bytes);

                    data += Encoding.UTF8.GetString(bytes, 0, bytesRec);

                    // Показываем данные на консоли
                    Console.Write("Полученный текст: " + data + "\n\n");
                    if (data == "on")
                    {
                        por1.Write("on");
                        // Отправляем ответ клиенту
                        Thread.Sleep(400);
                        string reply = por1.ReadExisting();
                        Console.WriteLine(reply);
                        byte[] msg = Encoding.UTF8.GetBytes(reply);
                        handler.Send(msg);
                    }
                    else if (data == "off")
                    {
                        por1.Write("of");
                        // Отправляем ответ клиенту
                        Thread.Sleep(400);
                        string reply = por1.ReadExisting();
                        Console.WriteLine(reply);
                        byte[] msg = Encoding.UTF8.GetBytes(reply);
                        handler.Send(msg);
                    }
                    else if (data == "get_state")
                    {
                        por1.Write("st");
                        // Отправляем ответ клиенту
                        Thread.Sleep(400);
                        string reply = por1.ReadExisting();
                        Console.WriteLine(reply);
                        byte[] msg = Encoding.UTF8.GetBytes(reply);
                        handler.Send(msg);
                    }
                    else
                    {
                        // Отправляем ответ клиенту\
                        string reply = "error";
                        Console.WriteLine(reply);
                        byte[] msg = Encoding.UTF8.GetBytes(reply);
                        handler.Send(msg);
                    }

                    if (data.IndexOf("<TheEnd>") > -1)
                    {
                        Console.WriteLine("Сервер завершил соединение с клиентом.");
                        break;
                    }

                    handler.Shutdown(SocketShutdown.Both);
                    handler.Close();
                    por1.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                Console.ReadLine();
            }
        }
    }
}

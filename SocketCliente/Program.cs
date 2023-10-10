using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace SocketCliente
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string servidorIP = "127.0.0.1"; 
            int puerto = 11200; 

            Socket clienteSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            // Conectar al servidor
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(servidorIP), puerto);
            clienteSocket.Connect(endPoint);

            // Enviar datos al servidor
            string mensaje = "¡Hola, servidor!";
            byte[] mensajeBytes = Encoding.ASCII.GetBytes(mensaje);
            clienteSocket.Send(mensajeBytes);

            // Recibir respuesta del servidor
            byte[] buffer = new byte[1024];
            int bytesRecibidos = clienteSocket.Receive(buffer);
            string respuesta = Encoding.ASCII.GetString(buffer, 0, bytesRecibidos);
            Console.WriteLine($"Respuesta del servidor: {respuesta}");

            // Cerrar el socket del cliente
            clienteSocket.Close();
            Console.ReadKey();
        }
    }
}

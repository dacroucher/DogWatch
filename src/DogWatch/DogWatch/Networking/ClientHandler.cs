using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace DogWatch.Networking
{
    public class ClientHandler
    {
        private Broadcaster clientNotifications;
        private Dictionary<int,Client> masterList;

        public ClientHandler()
        {
            masterList = new Dictionary<int, Client>();
            clientNotifications = new Broadcaster();
        }

        public void NewClient(Socket s)
        {
            Client c = new Client(s);
            masterList.Add(c.ID, c);
            clientNotifications.AddClient(c);
        }

    }
}

using Backend.Models;

namespace Backend.Repository
{
    public class ClientRepo:IClientRepo
    {
        private readonly ClientDBContext context;

        public ClientRepo(ClientDBContext context)
        {
            this.context = context;
        }

        public Client AddNewClient(Client client)
        {
            context.Clients.Add(client);
            context.SaveChanges();
            return client;
        }

        public Client LoginClient(Client client)
        {
            foreach (var client1 in context.Clients)
            {
                if (client1.clientEmail == client.clientEmail && client1.password == client.password)
                {
                    return client1;
                }
            }
            return null;
        }

        public Client ChangePassword(Client client)
        {
            var x = 0;
            foreach (var client1 in context.Clients)
            {
                if (client1.clientEmail == client.clientEmail && client1.clientPhone == client.clientPhone && client1.clientName.ToUpper() == client.clientName.ToUpper())
                {
                    client1.password = client.password;
                    x=1;
                }
            }
            if(x==1)
            {
                context.SaveChanges();
                return client;
            }
            else
            {
                return null;
            }
        }

    }
}

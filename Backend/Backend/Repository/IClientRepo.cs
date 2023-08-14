using Backend.Models;

namespace Backend.Repository
{
    public interface IClientRepo
    {
        Client AddNewClient(Client client);

        Client LoginClient(Client client);

        Client ChangePassword(Client client);
    }
}

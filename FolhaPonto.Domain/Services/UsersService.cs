using FolhaPonto.Domain.Interfaces;
using FolhaPonto.Domain.Models;
using FolhaPonto.Domain.Resquest;
using System.Text;

namespace FolhaPonto.Domain.Services
{
    public class UsersService : IUsersServices
    {
        private readonly IUsersRepository _usersRepository;

        public UsersService(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public async Task<bool> Autorizar(UsersRequest users)
        {
            users.Password = Criptografar(users.Password);
            var usuarios = await _usersRepository.GetAll();

            if (usuarios.Any(x => x.UserName == users.UserName) && usuarios.Any(x => x.Password == users.Password))
                return true;

            return false;
        }

        public async Task<IEnumerable<Users>> BuscarAll()
        {
            var result = await _usersRepository.GetAll();

            foreach (var item in result)
            {
                item.Password = Descriptografar(item.Password);  
            };

            return result;
        }

        public async Task<Users> BuscarId(Guid usersId)
        {
            var result = await _usersRepository.GetById(usersId);
            result.Password = Descriptografar(result.Password);

            return result;
        }

        public async Task<bool> Post(UsersRequest request)
        {
            var usuarios = await _usersRepository.GetAll();

            if (usuarios.Any(x => x.UserName == request.UserName) && usuarios.Any(x => x.Password == Criptografar(request.Password)))
                return false;

            Users users = new()
            {
                UserName = request.UserName,
                Password = Criptografar(request.Password),
                CreatedAt = DateTime.UtcNow,
                UpdateAt = DateTime.UtcNow
            };

            _usersRepository.Add(users);

            return true;
        }

        public async Task<Users?> Put(Guid uderId, UsersRequest request)
        {
            var usuarios = await _usersRepository.GetById(uderId);

            if (usuarios.UserName == request.UserName && usuarios.Password == Criptografar(request.Password))
                return null;

            var item = await BuscarId(uderId);

            if (item != null)
            {
                item.UserName = request.UserName;
                item.Password = Criptografar(request.Password);
                item.CreatedAt = DateTime.UtcNow;
                item.UpdateAt = DateTime.UtcNow;

                _usersRepository.Update(item);
            }

            return item;
        }

        public async Task<Users> Delete(Guid uderId)
        {
            var item = await BuscarId(uderId);

            if (item != null)
            {
                item.DeleteAt = DateTime.UtcNow;
                item.UpdateAt = DateTime.Now;

                _usersRepository.Update(item);
            }

            return item;
        }

        private string Criptografar(string texto)
        {
            StringBuilder textoCriptografado = new();

            foreach (char c in texto)
                textoCriptografado.Append((char)(c + 10));
            
            return textoCriptografado.ToString();
        }

        private string Descriptografar(string textoCriptografado)
        {
            StringBuilder textoDescriptografado = new();
            foreach (char c in textoCriptografado)
                textoDescriptografado.Append((char)(c - 10));
            
            return textoDescriptografado.ToString();
        }

    }
}

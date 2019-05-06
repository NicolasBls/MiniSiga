using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using MiniSIGA.Models;
namespace MiniSIGA.Security
{
    public class ProvedorDeSeguranca : RoleProvider
    {
        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {
            var bd = new MiniSigaEntities();


            //captura o id da pessoa e converte para inteiro
            var idPessoa = Convert.ToInt32(username);

            //busca no banco pela pessoa mencionada no username
            var usuario = bd.Pessoa.FirstOrDefault(x => x.PessoaId == idPessoa);

            var acesso = bd.Acesso.FirstOrDefault(x => x.AcessoId == usuario.AcessoId);
            //busca por todos os acessos salvos

            var acessosSalvos = acesso.Descricao;

            string[] vs = new string[1];
            vs[0] = acessosSalvos;

            return vs;

            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}
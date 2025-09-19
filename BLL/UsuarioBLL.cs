using DAL;
using model;
using System;
using System.Collections.Generic;
using System.Net.Mail;

namespace BLL
{
    public class UsuarioBLL
    {
        private UsuarioDAL usuarioDAL = new UsuarioDAL();

        private string ValidarUsuario(Usuario usuario)
        {
            if (string.IsNullOrWhiteSpace(usuario.Nome))
                return "Informe o nome do usuário.";

            if (string.IsNullOrWhiteSpace(usuario.Email))
                return "Informe o e-mail do usuário.";

            if (string.IsNullOrWhiteSpace(usuario.Senha))
                return "Informe a senha do usuário.";

            if (usuario.Login.Contains(" "))
                return "Usuário não pode conter espaços em branco.";

            if (usuario.Email.Contains(" "))
                return "E-mail não pode conter espaços em branco.";

            if (usuario.Senha.Contains(" "))
                return "Senha não pode conter espaços em branco.";

            if (IsValidEmail(usuario.email))
                return "E-mail inválido.";

            return "OK";
        }

        public static bool IsValidEmail(string email)
        {
            try
            {
                MailAddress mailAddress = new MailAddress(email);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        public bool VerificarCredenciais(string usuario, string senha)
        {
            Usuario user = usuarioDAL.ObterUsuarioPorLogin(usuario);

            if (user != null)
            {
                string senhaCriptografadaDoBanco = user.Senha;

                if (senhaCriptografadaDoBanco != null)
                {
                    // Verificar a senha
                    if (BCrypt.Net.BCrypt.Verify(senha, senhaCriptografadaDoBanco))
                    {
                        return true; // Credenciais válidas
                    }
                }
            }

            return false; // Credenciais inválidas
        }

        public string CadastrarUsuario(Usuario usuario)
        {
            string validacao = ValidarUsuario(usuario);
            if (validacao != "OK") return validacao;

            try
            {
                usuarioDAL.InserirUsuario(usuario);
                return "Sucesso";
            }
            catch (Exception ex)
            {
                return $"Erro ao cadastrar: {ex.Message}";
            }
        }

        public string EditarUsuario(Usuario usuario)
        {
            string validacao = ValidarUsuario(usuario);
            if (validacao != "OK") return validacao;

            try
            {
                usuarioDAL.EditarUsuario(usuario);
                return "Sucesso";
            }
            catch (Exception ex)
            {
                return $"Erro ao cadastrar: {ex.Message}";
            }
        }

        public List<Usuario> GetUsuarios()
        {
            return usuarioDAL.GetUsuarios();
        }
    }
}

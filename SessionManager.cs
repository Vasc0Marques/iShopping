using System;

namespace iShopping
{
    /// <summary>
    /// Gerencia a sessão do utilizador atual logado
    /// </summary>
    public static class SessionManager
    {
        public static int IdUtilizadorAtual { get; set; }
        public static string UsernameUtilizadorAtual { get; set; }

        /// <summary>
        /// Inicia uma nova sessão com os dados do utilizador
        /// </summary>
        public static void IniciarSessao(int idUtilizador, string username)
        {
            IdUtilizadorAtual = idUtilizador;
            UsernameUtilizadorAtual = username;
        }

        /// <summary>
        /// Encerra a sessão atual
        /// </summary>
        public static void EncerrarSessao()
        {
            IdUtilizadorAtual = 0;
            UsernameUtilizadorAtual = null;
        }

        /// <summary>
        /// Verifica se há uma sessão ativa
        /// </summary>
        public static bool EstaLogado()
        {
            return IdUtilizadorAtual > 0;
        }
    }
}

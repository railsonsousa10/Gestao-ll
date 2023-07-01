using Models;
using System;
using System.IO;

namespace DAL
{
    public static class Conexao
    {
        public static string StringDeConexao
        {
            get
            {
                return @"User ID=SA;Inital catalog=Configuracao;Data Souce=.\SQLEXPRESS2019;Password=Senailab02";

               /* if (String.IsNullOrEmpty(Constantes.StringDeConexao))
                {
                    if (File.Exists(Constantes.DiretorioStringConexao + Constantes.NomeArquivoConexao))
                        Constantes.StringDeConexao = File.ReadAllText(Constantes.DiretorioStringConexao + Constantes.NomeArquivoConexao);
                    else
                        throw new Exception("É preciso criar a string de conexão") { Data = { { "Id", 1 } } };
                }
                return Constantes.StringDeConexao;*/
            }
        }
    }
}
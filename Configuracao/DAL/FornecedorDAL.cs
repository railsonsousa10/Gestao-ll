using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class FornecedorDAL
    {
        public void Inserir(Fornecedor _fornecedor)
        {

            SqlConnection cn = new SqlConnection(Conexao.StringDeConexao);
            try
            {
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = @"INSERT INTO Fornecedor(Nome, Fone, Email, Site) 
                                               VALUES (@Nome, @Fone, @Email, @Site)";

                cmd.CommandType = System.Data.CommandType.Text;

                cmd.Parameters.AddWithValue("@Nome", _fornecedor.Nome);
                cmd.Parameters.AddWithValue("@Fone", _fornecedor.Fone);
                cmd.Parameters.AddWithValue("@Email", _fornecedor.Email);
                cmd.Parameters.AddWithValue("Site", _fornecedor.Site);

                cmd.Connection = cn;
                cn.Open();

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao tentar inserir um cliente no banco de dados.", ex) { Data = { { "Id", -1 } } };
            }
            finally
            {
                cn.Close();
            }
        }
        public List<Fornecedor> BuscarTodos()
        {
            List<Fornecedor> FornecedorList = new List<Fornecedor>();
            Fornecedor Fornecedor = new Fornecedor();
            SqlConnection cn = new SqlConnection(Conexao.StringDeConexao);
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = @"SELECT Nome, Fone, Email, Site  FROM Fornecedor";
                cmd.CommandType = System.Data.CommandType.Text;

                cn.Open();
                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        Fornecedor.Id = (int)rd["Id"];
                        Fornecedor.Nome = rd["Name"].ToString();
                        Fornecedor.Fone = rd["Fone"].ToString();
                        Fornecedor.Email = rd["Email"].ToString();
                        Fornecedor.Site = rd["Site"].ToString();
                      
                        FornecedorList.Add(Fornecedor);
                    }
                }
                return FornecedorList;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao tentar buscar Fornecedor no banco de dados", ex) { Data = { { "Id", 16 } } };
            }
            finally
            {
                cn.Close();
            }

        }

        public Fornecedor BuscarPorID(int _id)
        {
            Fornecedor Fornecedor = new Fornecedor();
            SqlConnection cn = new SqlConnection(Conexao.StringDeConexao);
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = @"SELECT Nome, CPF, RG, Email, Fone  FROM Fornecedor WhERE Id = @Id ";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@Id", _id);

                cn.Open();
                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        Fornecedor.Id = (int)rd["Id"];
                        Fornecedor.Nome = rd["Nome"].ToString();
                        Fornecedor.Fone = rd["Fone"].ToString();
                        Fornecedor.Email = rd["Email"].ToString();
                        Fornecedor.Site = rd["Site"].ToString();
                    }
                }
                return Fornecedor;

            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao tentar buscar Fornecedor por id no banco de dados", ex) { Data = { { "Id", 18 } } };
            }
            finally
            {
                cn.Close();
            }
        }

        public List<Fornecedor> BuscarPorNome(string _nome)
        {
            List<Fornecedor> FornecedorList = new List<Fornecedor>();
            Fornecedor Fornecedor = new Fornecedor();
            SqlConnection cn = new SqlConnection(Conexao.StringDeConexao);
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = @"SELECT Nome, Email, Fone, Site  FROM Fornecedor WhERE Nome LIKE @Nome";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("Nome", "%" + _nome + "%");

                cn.Open();
                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        Fornecedor = new Fornecedor();
                        Fornecedor.Id = (int)rd["Id"];
                        Fornecedor.Nome = rd["Nome"].ToString();
                        Fornecedor.Email = rd["Email"].ToString();
                        Fornecedor.Fone = rd["Fone"].ToString();
                        Fornecedor.Site = rd["Site"].ToString();
                     
                        FornecedorList.Add(Fornecedor);
                    }
                }
                return FornecedorList;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao tentar buscar Fornecedor por nome no banco de dados", ex) { Data = { { "Id", 17 } } };
            }
            finally
            {
                cn.Close();
            }
        }

        public List<Fornecedor> BuscarPorSite(string _site)
        {
            List<Fornecedor> FornecedorList = new List<Fornecedor>();
            Fornecedor Fornecedor = new Fornecedor();
            SqlConnection cn = new SqlConnection(Conexao.StringDeConexao);
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = @"SELECT Nome, Fone, Email, Site  FROM Fornecedor";
                cmd.CommandType = System.Data.CommandType.Text;

                cn.Open();
                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        Fornecedor.Id = (int)rd["Id"];
                        Fornecedor.Nome = rd["Name"].ToString();
                        Fornecedor.Fone = rd["Fone"].ToString();
                        Fornecedor.Email = rd["Email"].ToString();
                        Fornecedor.Site = rd["Site"].ToString();

                        FornecedorList.Add(Fornecedor);
                    }
                }
                return FornecedorList;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao tentar buscar Fornecedor no banco de dados", ex) { Data = { { "Id", 16 } } };
            }
            finally
            {
                cn.Close();
            }

        }

        public void Alterar(Fornecedor _Fornecedor)
        {
            SqlConnection cn = new SqlConnection(Conexao.StringDeConexao);
            try
            {
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = @"UPDATE Fornecedor SET Nome = @Nome, Nome = @Nome, 
                                    Email = @Email, Site = @Site,
                                    WHERE Id = @Id";

                cmd.CommandType = System.Data.CommandType.Text;

                cmd.Parameters.AddWithValue("@Nome", _Fornecedor.Nome);
                cmd.Parameters.AddWithValue("@Fone", _Fornecedor.Fone);
                cmd.Parameters.AddWithValue("@Email", _Fornecedor.Email);
                cmd.Parameters.AddWithValue("@Site", _Fornecedor.Site);
                cmd.Parameters.AddWithValue("@Id", _Fornecedor.Id);

                cmd.Connection = cn;
                cn.Open();

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu erro ao tentar alterar um fornecedor no banco de dados.", ex);
            }
            finally
            {
                cn.Close();
            }
        }
        public void Excluir(int _id)
        {

        }

    }
} 

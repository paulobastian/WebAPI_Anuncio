using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace AspNetWebApi_AprendaDotNet.Models
{
    public class SelecaoDal : ISelecaoDal
    {
        readonly string _connectionString;

        public SelecaoDal(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("DefaultConnection");
        }

        //Método que obtem todos as selecoes
        public IEnumerable<Selecao> ObterSelecoes()
        {
            var selecaosList = new List<Selecao>();
            using (var con = new SqlConnection(_connectionString))
            {

                var query =
                    $"SELECT * FROM Anuncio ";
                var cmd = new SqlCommand(query, con);

                con.Open();
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var employee = new Selecao
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        IdMarca = Convert.ToInt32(reader["IdMarca"]),
                        IdModelo = Convert.ToInt32(reader["IdModelo"].ToString()),
                        AnoVeiculo = reader["AnoVeiculo"].ToString(),
                        ValorCompra = Convert.ToInt32(reader["ValorCompra"]),
                        ValorVenda = Convert.ToInt32(reader["ValorVenda"].ToString()),
                        Cor = reader["Cor"].ToString(),
                        TipoCombustivel = reader["TipoCombustivel"].ToString(),
                        DataVenda = Convert.ToDateTime(reader["DataVenda"])
                    };

                    selecaosList.Add(employee);
                }
                con.Close();
            }
            return selecaosList;
        }

        //Inclusao de uma nova selecao 
        public int IncluirSelecao(Selecao selecao)
        {
            try
            {
                return 1;                
            }
            catch (Exception)
            {
                return 0;
            }

        }

        //Atualizar uma selecao
        public int AtualizarSelecao(Selecao selecao)
        {

            return 0;

        }

        //Obter selecao por id
        public Selecao ObterSelecaoPorId(int id)
        {
            var selecao = new Selecao();

            using (var con = new SqlConnection(_connectionString))
            {
                var query =
                    $"SELECT * FROM Anuncio WHERE Id = {id}";
                var cmd = new SqlCommand(query, con);

                con.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        selecao.Id = Convert.ToInt32(reader["Id"]);
                        selecao.IdMarca = Convert.ToInt32(reader["IdMarca"]);
                        selecao.IdModelo = Convert.ToInt32(reader["IdModelo"].ToString());
                        selecao.AnoVeiculo = reader["AnoVeiculo"].ToString();
                        selecao.ValorCompra = Convert.ToInt32(reader["ValorCompra"]);
                        selecao.ValorVenda = Convert.ToInt32(reader["ValorVenda"].ToString());
                        selecao.Cor = reader["Cor"].ToString();
                        selecao.TipoCombustivel = reader["TipoCombustivel"].ToString();
                        selecao.DataVenda = Convert.ToDateTime(reader["DataVenda"]);
                    }
                }
                else
                    return null;
            }
            return selecao;
        }

        //Excluir selecao por id
        public int ExcluirSelecao(int id)
        {
            return 0;

        }

    }
}

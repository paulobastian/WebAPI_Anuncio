using System;

namespace AspNetWebApi_AprendaDotNet.Models
{
    public class Selecao{

        public int Id { get; set; }

        public int IdMarca { get; set; }

        public int IdModelo { get; set; }

        public string AnoVeiculo { get; set; }

        public Double ValorCompra { get; set; }

        public Double ValorVenda { get; set; }

        public string Cor { get; set; }

        public string TipoCombustivel { get; set; }

        public DateTime DataVenda { get; set; }
    }
}

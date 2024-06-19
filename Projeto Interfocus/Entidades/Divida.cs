﻿using System.ComponentModel.DataAnnotations;

namespace ProjetoInterfocus.Entidades
{
    public class Divida
    {
        [Required]
        public int Id { get; set; }


        private int valor;

        [Required(ErrorMessage = "É necessário incluir um vaor")]
        public int Valor
        {
            get { return valor; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("value", "Valor deve ser maior que 0");
                }
                valor = value;
            }
        }

        private bool situacao;
        public bool Situacao
        {
            get { return situacao; }
            set
            {

            }
        }

        private DateTime datacriacao;
        public DateTime DataCriacao
        {
            get { return datacriacao; }
            set
            {
                // if (datacriacao.CompareTo(DateTime.Now) > 0)
                // {
                //     throw new ArgumentException("Data de criação ")
                // }
                if (datacriacao.CompareTo(DataPagamento) > 0)
                {
                    throw new ArgumentException("Data de criação não pode ocorrer após a data de pagamento");
                }
                datacriacao = value;
            }
        }

        private DateTime? datapagamento;
        public DateTime? DataPagamento {get {return datapagamento;} set {
            if (datapagamento.HasValue && datapagamento.Value.CompareTo(DataCriacao) > 0)
                {
                    throw new ArgumentException("Data de criação não pode ocorrer após a data de pagamento");
                }
                datapagamento = value;
        }}

        [Required(ErrorMessage ="É necessário fornecer descrição para a divida")]
        public string Descricao {get; set;}


        [Required(ErrorMessage = "É necessário informar o dono da dívida")]
        public int Id_cliente {get; set;}

    }
}
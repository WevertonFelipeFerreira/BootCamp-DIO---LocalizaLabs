using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDeSeries.Modelos
{
    public class Serie : EntidadeBase
    {
        private Genero genero { get; set; }
        private string Titulo { get; set; }
        private string Descricao { get; set; }
        private int Ano { get; set; }
        private bool Excluido { get; set; }
        private string ClassificacaoIndicativa { get; set; }
        private int Estrelas { get; set; }
        
        public Serie(int id, Genero Genero, string titulo, string descricao, int ano, string classificacao)
        {
            genero = Genero;
            Titulo = titulo;
            Descricao = descricao;
            Ano = ano;
            Id = id;
            ClassificacaoIndicativa = classificacao;
            Excluido = false;
        }
        public override string ToString()
        {
            string ret = "";
            ret += "Titulo: " + Titulo + Environment.NewLine;
            ret += "Genero: " + genero + Environment.NewLine;
            ret += "Descrição: " + Descricao + Environment.NewLine;
            ret += "Ano: " + Ano + Environment.NewLine;
            ret += "Excluido: " + Excluido + Environment.NewLine;
            ret += "Classificação indicativa: " + ClassificacaoIndicativa + Environment.NewLine;
            ret += "Estrelas: " + ExibeEstrelas() + Environment.NewLine;
            return ret;
        }
        public string retornaTitulo()
        {
            return Titulo;
        }
        public int retornaID()
        {
            return Id;
        }
        public void Exclui()
        {
            this.Excluido = true;
        }
        public bool RetornaExcluido()
        {
            return Excluido;
        }
        public void InsereEstrela(int estrelasQuantidade)
        {
            Estrelas = estrelasQuantidade;
        }
        public string ExibeEstrelas()
        {
            string estrela;
            if (Estrelas == 1)
            {
                return estrela = "* 1 Estrela";
            }
            else if (Estrelas == 2)
            {
                return estrela = "** 2 Estrelas";
            }
            else if (Estrelas == 3)
            {
                return estrela = "*** 3 Estrelas";
            }
            else if (Estrelas == 4)
            {
                return estrela = "**** 4 Estrelas";
            }
            else if (Estrelas == 5)
            {
                return estrela = "***** 5 Estrelas";
            }
            else return estrela = "Sem avaliação!";
        }
    }
}

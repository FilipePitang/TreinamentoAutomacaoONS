using System;

namespace TreinamentoAutomacaoONS
{
    public abstract class ItemBiblioteca
    {
        #region Propriedades
        private int id;
        private string titulo;
        private string autor;
        private int anoPublicacao;
        #endregion Propriedades

        #region Construtores
        public ItemBiblioteca() { }
        public ItemBiblioteca(int id, string titulo, string autor, int anoPublicacao)
        {
            this.id = id;
            this.titulo = titulo;
            this.autor = autor;
            this.anoPublicacao = anoPublicacao;
        }
        #endregion Construtores

        #region Encapsulamento
        public int Id { get => id; set => id = value; }
        public string Titulo { get => titulo; set => titulo = value; }
        public string Autor { get => autor; set => autor = value; }
        public int AnoPublicacao { get => anoPublicacao; set => anoPublicacao = value; }
        #endregion Encapsulamento

        #region Métodos
        public virtual void ExibirDetalhes()
        {
            Console.WriteLine("\nID: {0}", Id);
            Console.WriteLine("Título: {0}", Titulo);
            Console.WriteLine("Autor: {0}", Autor);
            Console.WriteLine("Ano de Publicação: {0}", AnoPublicacao);
        }
        #endregion Métodos
    }
}
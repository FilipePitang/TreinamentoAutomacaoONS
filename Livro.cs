using System;

namespace TreinamentoAutomacaoONS
{
    public class Livro : ItemBiblioteca
    {
        #region Propriedades
        private bool disponivel;
        #endregion Propriedades

        #region Construtores
        public Livro() { }
        public Livro(bool disponivel)
        {
            this.disponivel = disponivel;
        }
        #endregion Construtores

        #region Encapsulamento
        public bool Disponivel { get => disponivel; set => disponivel = value; }
        #endregion Encapsulamento

        #region Métodos
        public void EmprestarLivro()
        {
            if (Disponivel)
            {
                Disponivel = false;
                Console.WriteLine("\nO livro '{0}' foi emprestado.", Titulo);
            }
            else
            {
                Console.WriteLine("\nO livro '{0}' não está disponível para ser emprestado.", Titulo);
            }
        }
        public void DevolverLivro()
        {
            if (!Disponivel)
            {
                Disponivel = true;
                Console.WriteLine("\nO livro '{0}' foi devolvido.", Titulo);
            }
            else
            {
                Console.WriteLine("\nO livro '{0}' já está na biblioteca.", Titulo);
            }
        }
        //public override void ExibirDetalhes()
        //{
        //    base.ExibirDetalhes();
        //    Console.WriteLine(Disponivel ? "O livro ESTÁ disponível para ser emprestado" : "O livro NÃO ESTÁ disponível para ser emprestado");
        //}

        public override void ExibirDetalhesFilhos()
        {
            Console.WriteLine(Disponivel ? "O livro ESTÁ disponível para ser emprestado" : "O livro NÃO ESTÁ disponível para ser emprestado");
        }
        #endregion Métodos
    }
}
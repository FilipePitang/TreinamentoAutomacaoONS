using System;
using System.Collections.Generic;

namespace TreinamentoAutomacaoONS
{
    public class Biblioteca
    {
        #region Propriedades
        private List<ItemBiblioteca> itens = new List<ItemBiblioteca>();
        #endregion Propriedades

        #region Construtores
        public Biblioteca() { }
        public Biblioteca(List<ItemBiblioteca> itens)
        {
            this.itens = itens;
        }
        #endregion Construtores

        #region Encapsulamento
        public List<ItemBiblioteca> Itens { get => itens; set => itens = value; }
        #endregion Encapsulamento

        #region Métodos
        public void AdicionarItem(ItemBiblioteca item)
        {
            Itens.Add(item);
        }
        public void ListarItens()
        {
            if (Itens.Count == 0)
            {
                Console.WriteLine("\nNão há itens na biblioteca.");
            }

            foreach (ItemBiblioteca item in Itens)
            {
                item.ExibirDetalhes();
            }
        }
        public void BuscarPorTitulo(string titulo)
        {
            List<ItemBiblioteca> resultados = Itens.FindAll(item => item.Titulo.Equals(titulo, StringComparison.OrdinalIgnoreCase));

            if (resultados.Count > 0)
            {
                foreach (ItemBiblioteca item in resultados)
                {
                    item.ExibirDetalhes();
                }
            }
            else
            {
                Console.WriteLine("\nNenhum livro ou revista com o Titulo '{0}' foi encontrado.", titulo);
            }
        }
        public void BuscarPorAutor(string autor)
        {
            List<ItemBiblioteca> resultados = Itens.FindAll(item => item.Autor.Equals(autor, StringComparison.OrdinalIgnoreCase));

            if (resultados.Count > 0)
            {
                foreach (ItemBiblioteca item in resultados)
                {
                    item.ExibirDetalhes();
                }
            }
            else
            {
                Console.WriteLine("\nNenhum livro ou revista com o Autor '{0}' foi encontrado.", autor);
            }
        }
        #endregion Métodos
    }
}
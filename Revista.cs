using System;

namespace TreinamentoAutomacaoONS
{
    public class Revista : ItemBiblioteca
    {
        #region Propriedades
        private int edicao;
        #endregion Propriedades

        #region Construtores
        public Revista() { }
        public Revista(int edicao)
        {
            this.edicao = edicao;
        }
        #endregion Construtores

        #region Encapsulamento
        public int Edicao { get => edicao; set => edicao = value; }
        #endregion Encapsulamento

        #region Métodos
        public override void ExibirDetalhes()
        {
            base.ExibirDetalhes();
            Console.WriteLine("Edição: {0}", Edicao);
        }
        #endregion Métodos
    }
}
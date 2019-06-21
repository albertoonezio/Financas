using Financas.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Financas.DAO
{
    public class MovimentacaoDAO
    {
        private FinancasContext context;

        public MovimentacaoDAO(FinancasContext context)
        {
            this.context = context;
        }

        public void Adiciona(Movimentacao movimentacao)
        {
            context.Movimentacoes.Add(movimentacao);
            context.SaveChanges();
        }

        public IList<Movimentacao> Lista()
        {
            return context.Movimentacoes.ToList();
        }

        public IList<Movimentacao> BuscaPorUsuario(int? usuarioId)
        {
            return context.Movimentacoes.Where(m => m.UsuarioId == usuarioId).ToList();
        }

        public IList<Movimentacao> Busca(decimal? valorMinimo, decimal? valorMaximo, DateTime? dataMinima, DateTime? dataMaxima, Tipo? tipo, int? usuarioId)
        {
            IQueryable<Movimentacao> busca = context.Movimentacoes;
            if (valorMinimo.HasValue)
            {
                busca = busca.Where(m => m.Valor >= valorMinimo);
            }

            if (valorMaximo.HasValue)
            {
                busca = busca.Where(m => m.Valor <= valorMaximo);
            }

            if (dataMinima.HasValue)
            {
                busca = busca.Where(m => m.Data >= dataMinima);
            }

            if (dataMaxima.HasValue)
            {
                busca = busca.Where(m => m.Data <= dataMaxima);
            }
        }
    }
}
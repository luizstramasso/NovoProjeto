using NovoProjeto.Domain.Models;
using System;
using System.Collections.Generic;

namespace NovoProjeto.Infra.Data.Context
{
    public static class DataSeed
    {
        public static List<AcaoInvestimento> AcaoInvestimento()
        {
            return new List<AcaoInvestimento>()
            {
                new AcaoInvestimento() { ID = Guid.NewGuid(), Validacao = true, RazaoSocial = "Apple Inc.", CodigoAcao = "AAPL" },
                new AcaoInvestimento() { ID = Guid.NewGuid(), Validacao = true, RazaoSocial = "Amazon.com, Inc.", CodigoAcao = "AMZN" },
                new AcaoInvestimento() { ID = Guid.NewGuid(), Validacao = true, RazaoSocial = "Alphabet Inc.", CodigoAcao = "GOOG" },
                new AcaoInvestimento() { ID = Guid.NewGuid(), Validacao = true, RazaoSocial = "Meta Platforms, Inc.", CodigoAcao = "FB" },
                new AcaoInvestimento() { ID = Guid.NewGuid(), Validacao = true, RazaoSocial = "Tesla, Inc.", CodigoAcao = "TSLA" },
                new AcaoInvestimento() { ID = Guid.NewGuid(), Validacao = true, RazaoSocial = "Netflix Inc.", CodigoAcao = "NFLX" },
                new AcaoInvestimento() { ID = Guid.NewGuid(), Validacao = true, RazaoSocial = "International Business Machines Corporation", CodigoAcao = "IBM" }
            };
        }
    }
}
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
                new AcaoInvestimento() { ID = Guid.NewGuid(), RazaoSocial = "Apple Inc.", CodigoAcao = "AAPL" },
                new AcaoInvestimento() { ID = Guid.NewGuid(), RazaoSocial = "Amazon.com, Inc.", CodigoAcao = "AMZN" },
                new AcaoInvestimento() { ID = Guid.NewGuid(), RazaoSocial = "Alphabet Inc.", CodigoAcao = "GOOG" },
                new AcaoInvestimento() { ID = Guid.NewGuid(), RazaoSocial = "Meta Platforms, Inc.", CodigoAcao = "FB" },
                new AcaoInvestimento() { ID = Guid.NewGuid(), RazaoSocial = "Tesla, Inc.", CodigoAcao = "TSLA" },
                new AcaoInvestimento() { ID = Guid.NewGuid(), RazaoSocial = "Netflix Inc.", CodigoAcao = "NFLX" },
                new AcaoInvestimento() { ID = Guid.NewGuid(), RazaoSocial = "International Business Machines Corporation", CodigoAcao = "IBM" }
            };
        }
    }
}
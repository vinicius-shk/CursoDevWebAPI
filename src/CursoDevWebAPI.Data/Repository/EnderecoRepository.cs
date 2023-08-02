﻿using CursoDevWebAPI.Business.Intefaces;
using CursoDevWebAPI.Business.Models;
using CursoDevWebAPI.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CursoDevWebAPI.Data.Repository
{
    public class EnderecoRepository : Repository<Endereco>, IEnderecoRepository
    {
        public EnderecoRepository(MeuDbContext context) : base(context) { }

        public async Task<Endereco> ObterEnderecoPorFornecedor(Guid fornecedorId)
        {
            return await Db.Enderecos.AsNoTracking()
                .FirstOrDefaultAsync(f => f.FornecedorId == fornecedorId);
        }
    }
}
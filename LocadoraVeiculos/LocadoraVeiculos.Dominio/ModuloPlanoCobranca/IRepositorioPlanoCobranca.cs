﻿using LocadoraVeiculos.Dominio.Compartilhado;
using System;
using System.Collections.Generic;

namespace LocadoraVeiculos.Dominio.ModuloPlanoCobranca
{
    public interface IRepositorioPlanoCobranca : IRepositorio<PlanoCobranca>
    {
        bool GrupoVeiculosDuplicado(Guid idPlanoCobranca, Guid idGrupoVeiculos);
        List<PlanoCobranca> BuscarPeloIdGrupoVeiculos(Guid idGrupoVeiculos);
    }
}

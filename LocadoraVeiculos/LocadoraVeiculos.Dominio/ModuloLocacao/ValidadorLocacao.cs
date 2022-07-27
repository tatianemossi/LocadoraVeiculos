﻿using FluentValidation;

namespace LocadoraVeiculos.Dominio.ModuloLocacao
{
    public class ValidadorLocacao : AbstractValidator<Locacao>
    {
        public ValidadorLocacao()
        {
            RuleFor(x => x.Cliente).NotEmpty();
            RuleFor(x => x.GrupoVeiculos).NotEmpty();
            RuleFor(x => x.PlanoCobranca).NotEmpty();
            RuleFor(x => x.Taxa).NotEmpty();
            RuleFor(x => x.Veiculo).NotEmpty();
            RuleFor(x => x.DataLocacao).NotEmpty();
            RuleFor(x => x.DataPrevistaEntrega).NotEmpty();
            RuleFor(x => x.ValorPrevisto).NotEmpty();
        }
    }
}

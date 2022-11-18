namespace TALLER_17_11.UTILS
{
    using FluentValidation;
    using TALLER_17_11.DTOs;

    public class SancionesValidation : AbstractValidator<SancionesDTO>
    {
        public SancionesValidation()
        {
            RuleFor(s => s.SANCION).NotEmpty()
                .WithMessage("sancion Obligatoria");
            RuleFor(s => s.SANCION).Length(30)
                .WithMessage("Excede los 20 Caracteres");
            RuleFor(s => s.OBSERVACION).NotEmpty()
                .WithMessage("Observacion Obligatoria");
            RuleFor(s => s.OBSERVACION).Length(100)
                .WithMessage("Excede los 100 Caracteres");
        }

    }
}

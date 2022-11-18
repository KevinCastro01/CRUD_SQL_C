namespace TALLER_17_11.UTILS
{
    using FluentValidation;
    using TALLER_17_11.DTOs;

    public class ConductorValidation : AbstractValidator<ConductorDTO>
    {
        public ConductorValidation()
        {
            RuleFor(s => s.IDENTIFICACION).NotEmpty()
                .WithMessage("Identificacion Obligatorio");
            RuleFor(s => s.IDENTIFICACION).Length(20)
                .WithMessage("Excede los 20 Caracteres");
            RuleFor(s => s.TELEFONO).NotEmpty()
                .WithMessage("Telefono Obligatorio");
            RuleFor(s => s.TELEFONO).Length(10)
                .WithMessage("Excede los 10 Caracteres");
        }
    }
}

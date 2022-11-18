namespace TALLER_17_11.UTILS
{
    using FluentValidation;
    using TALLER_17_11.DTOs;

    public class MatriculaValidation : AbstractValidator<MatriculaDTO>
    {
        public MatriculaValidation()
        {
            RuleFor(s => s.NUMERO).NotEmpty()
                .WithMessage("Numero Obligatorio");
            RuleFor(s => s.NUMERO).Length(5)
                .WithMessage("Excede los 20 Caracteres");
            RuleFor(s => s.FECHAEXPEDICION).NotEmpty()
                .WithMessage("Fecha Obligatoria");
            RuleFor(s => s.ESTADO).NotEmpty()
                .WithMessage("Estado Obligatorio");
        }
    }
}

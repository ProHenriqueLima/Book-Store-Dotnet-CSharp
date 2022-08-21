using FluentValidation;
using Livraria.WebAPI.Models;

namespace Livraria.WebAPI.Validators
{
    public class EditoraValidator : AbstractValidator<Editora>
    {
        public EditoraValidator()
        {
            RuleFor(m => m.NameEditora)
                .NotEmpty()
                    .WithMessage("O campo nome da editora não pode está vazio")
                .MinimumLength(3)
                    .WithMessage("O Nome da editora tem que possuir mais do que 3 Caracteres")
                .MaximumLength(30)
                    .WithMessage("O Nome da editora tem que possuir menos do que 30 Caracteres");
            
            RuleFor(n => n.CidadeEditora)
                .NotEmpty()
                    .WithMessage("O campo cidade não pode está vazio")
                .MinimumLength(3)
                    .WithMessage("A cidade da editora tem que possuir mais do que 3 Caracteres")
                .MaximumLength(30)
                    .WithMessage("A cidade da editora tem que possuir menos do que 30 Caracteres");
        }
    }
}
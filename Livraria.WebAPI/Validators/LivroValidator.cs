using FluentValidation;
using Livraria.WebAPI.Models;

namespace Livraria.WebAPI.Validators
{
    public class LivroValidator : AbstractValidator<Livro>
    {
        public LivroValidator()
        {
            RuleFor(m => m.NomeLivro)
                .NotEmpty()
                    .WithMessage("O campo nome do livro não pode está vazio !")
                 .MinimumLength(3)
                    .WithMessage("O Nome da editora tem que possuir mais do que 3 Caracteres")
                .MaximumLength(30)
                    .WithMessage("O Nome da editora tem que possuir menos do que 30 Caracteres");
            RuleFor(n => n.AutorLivro)
                .NotEmpty()
                    .WithMessage("O campo autor do livro não pode está vazio !")
                .MinimumLength(3)
                    .WithMessage("O Nome da editora tem que possuir mais do que 3 Caracteres")
                .MaximumLength(30)
                    .WithMessage("O Nome da editora tem que possuir menos do que 30 Caracteres");
            RuleFor(o => o.LancamentoLivro)
                .NotEmpty()
                    .WithMessage("O Lançamento não pode está vazio !");
             RuleFor(q => q.EditoraID)
                .NotEmpty()
                    .WithMessage("A Editora deve ser válida !");
            
            
               
        }
    }
}
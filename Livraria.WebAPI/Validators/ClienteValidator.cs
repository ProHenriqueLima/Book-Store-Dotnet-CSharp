using FluentValidation;
using Livraria.WebAPI.Models;

namespace Livraria.WebAPI.Validations
{
    public class ClienteValidator : AbstractValidator<Cliente>
    {
        public ClienteValidator()
        {
            RuleFor(m => m.NomeCliente)
                .NotEmpty()
                    .WithMessage("Tem que ter algo contido no Campo Nome !!")
                .MinimumLength(3)
                    .WithMessage("O Nome do cliente tem que possuir mais do que 3 Caracteres")
                .MaximumLength(50)
                    .WithMessage("O Nome do cliente tem que possuir menos do que 50 Caracteres");       
                    
             RuleFor(n => n.CidadeCliente)
                .NotEmpty()
                    .WithMessage("Tem que ter algo contido no Campo Nome da cidade !!")
                .MinimumLength(3)
                    .WithMessage("O Nome da cidade tem que possuir mais do que 3 Caracteres")
                .MaximumLength(30)
                    .WithMessage("O Nome da cidade tem que possuir menos do que 30 Caracteres");

            RuleFor(o => o.EnderecoCliente)
                .NotEmpty()
                    .WithMessage("Tem que ter algo contido no Campo Endereço!!")
                .MinimumLength(3)
                    .WithMessage("O Endereço tem que possuir mais do que 3 Caracteres")
                .MaximumLength(30)
                    .WithMessage("O Endereço tem que possuir menos do que 30 Caracteres");

            RuleFor(o => o.EmailCliente)
                .NotEmpty()
                    .WithMessage("Tem que ter algo contido no Campo Email!!")
                .MinimumLength(3)
                    .WithMessage("O Email tem que possuir mais do que 3 Caracteres")
                .EmailAddress()
                    .WithMessage("Esse não é o formato de email válido");
                
        
         }
    }
}
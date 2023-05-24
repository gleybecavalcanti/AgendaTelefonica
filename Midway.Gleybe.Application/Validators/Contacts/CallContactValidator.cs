using FluentValidation;
using Midway.Gleybe.Application.CQRS.Commands.Contacts.Call;
using Midway.Gleybe.Domain.Constants;
using Midway.Gleybe.Domain.Interfaces.Services;

namespace Midway.Gleybe.Application.Validators.Contacts
{
    public class CallContactValidator : AbstractValidator<CallContactCommand>
    {
        public CallContactValidator(IContactService contactService)
        {
            RuleFor(q => q._Id)
            .NotEmpty()
            .WithMessage(Messages.DefaultIdentifyEmpty);

            RuleFor(q => q._Id)
            .Custom((_Id, validator) => {
                var contact = contactService.GetContactById(_Id).Result; 
                if(contact == null) {
                    validator.AddFailure("Id", Messages.DefaultNotFoundContact);
                }
            });
        }
    }
}

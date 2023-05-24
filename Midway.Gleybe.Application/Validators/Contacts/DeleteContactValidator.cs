using FluentValidation;
using Midway.Gleybe.Application.CQRS.Commands.Contacts.Delete;
using Midway.Gleybe.Domain.Constants;
using Midway.Gleybe.Domain.Interfaces.Services;

namespace Midway.Gleybe.Application.Validators.Contacts
{
    public class DeleteContactValidator : AbstractValidator<DeleteContactCommand>
    {
        public DeleteContactValidator(IContactService contactService)
        {
            RuleFor(q => q._Id)
            .NotEmpty()
            .WithMessage(Messages.DefaultIdentifyEmpty);

            RuleFor(q => q._Id)
            .Custom((_Id, validator) => {
                var document = contactService.GetContactById(_Id).Result;
                if(document == null) {
                    validator.AddFailure("_Id", Messages.DefaultNotFoundContact);
                }
            });
        }
    }
}

using FluentValidation;
using Midway.Gleybe.Application.CQRS.Commands.Contacts.Put;
using Midway.Gleybe.Domain.Constants;
using Midway.Gleybe.Domain.Enums;
using Midway.Gleybe.Domain.Interfaces.Services;

namespace Midway.Gleybe.Application.Validators.Contacts
{
    public class PutContactValidator : AbstractValidator<PutContactCommand>
    {
        public PutContactValidator(IContactService contactService)
        {
            RuleFor(q => q._Id)
            .Custom((_Id, validator) => {
                var document = contactService.GetContactById(_Id).Result;
                if(document == null) {
                    validator.AddFailure("_Id", Messages.DefaultNotFoundContact);
                }
            });

            RuleFor(q => q.Name)
            .Custom((name, validator) => {
                if (string.IsNullOrEmpty(name))
                {
                    validator.AddFailure("Nome", Messages.UpdateContactNameEmpty);
                }
            });


            RuleFor(q => q.PhoneNumbers)
            .Custom((phoneList, validator) => {
                if (phoneList != null && !phoneList.Any())
                {
                    validator.AddFailure("Phone", Messages.UpdateContactHasNotAnyPhone);
                }
                else
                {
                    phoneList?.ForEach(phone => {
                        if (string.IsNullOrEmpty(phone.Number)) {
                            validator.AddFailure("Phone.Number", Messages.UpdateContactEmptyNumber);
                        }

                        if (!phone.Classification.HasValue)
                        {
                            validator.AddFailure("Phone.Classification", Messages.UpdateContactEmptyPhoneClassification);
                        }
                        else
                        {
                            if (!Enum.IsDefined(typeof(ClassificationEnum), phone.Classification.Value))
                            {
                                validator.AddFailure("Phone.Classification", Messages.UpdateContactPhoneClassOutOfRange) ;
                            }
                        }
                    });
                }
            });

            RuleFor(q => q.Address)
            .Custom((addressList, validator) => {
                if (addressList != null && addressList.Any())
                {
                    addressList.ForEach(address => {
                        if (!address.Classification.HasValue)
                        {
                            validator.AddFailure("Address.Classification", Messages.UpdateContactEmptyAddressClassification);
                        }
                        else
                        {
                            if (!Enum.IsDefined(typeof(ClassificationEnum), address.Classification.Value))
                            {
                                validator.AddFailure("Address.Classification", Messages.UpdateContactAddressClassOutOfRange);
                            }
                        }
                    });
                }
            });
        }
    }
}

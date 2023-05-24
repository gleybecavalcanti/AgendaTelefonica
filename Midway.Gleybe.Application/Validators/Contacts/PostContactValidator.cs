using FluentValidation;
using Midway.Gleybe.Application.CQRS.Commands.Contacts.Post;
using Midway.Gleybe.Domain.Constants;
using Midway.Gleybe.Domain.Enums;

namespace Midway.Gleybe.Application.Validators.Contacts
{
    public class PostContactValidator : AbstractValidator<PostContactCommand>
    {
        public PostContactValidator()
        {

            RuleFor(q => q.Name)
            .Custom((name, validator) => {
                if(string.IsNullOrEmpty(name)) {
                    validator.AddFailure("Nome", Messages.InsertContactNameEmpty);
                }
            });


            RuleFor(q => q.PhoneNumbers)
            .Custom((phoneList, validator) => {
                if(phoneList != null && !phoneList.Any()) {
                    validator.AddFailure("Phone", Messages.InsertContactHasNotAnyPhone);
                }
                else
                {
                    phoneList?.ForEach(phone => {
                        if (string.IsNullOrEmpty(phone.Number)) {
                            validator.AddFailure("Phone.Number", Messages.InsertContactEmptyNumber);
                        }

                        if (!phone.Classification.HasValue) {
                            validator.AddFailure("Phone.Classification", Messages.InsertContactEmptyPhoneClassification);
                        }
                        else
                        {
                            if(!Enum.IsDefined(typeof(ClassificationEnum), phone.Classification.Value)) {
                                validator.AddFailure("Phone.Classification", Messages.InsertContactPhoneClassOutOfRange);
                            }
                        }
                    });
                }
            });

            RuleFor(q => q.Address)
            .Custom((addressList, validator) => {
                if(addressList != null && addressList.Any()) {
                    addressList.ForEach(address => {
                        if (!address.Classification.HasValue) {
                            validator.AddFailure("Address.Classification", Messages.InsertContactEmptyAddressClassification);
                        }
                        else
                        {
                            if (!Enum.IsDefined(typeof(ClassificationEnum), address.Classification.Value)){
                                validator.AddFailure("Address.Classification", Messages.InsertContactAddressClassOutOfRange);
                            }
                        }
                    });
                }
            });
        }
    }
}

namespace Midway.Gleybe.Domain.Constants
{
    public static class Messages
    {
        public const string DefaultLoadDataSucces                   = "Dados carregados com sucesso.";
        public const string DefaultNotFoundContact                  = "Não foi possível encontrar o contato.";
        public const string DefaultIdentifyEmpty                    = "Identificador vazio.";
        public const string DefaultDeleteContact                    = "Contato excluído com sucesso.";
        public const string DefaultAddContact                       = "Contato adicionado com sucesso.";
        public const string DefaultUpdateContact                    = "Contato atualizado com sucesso.";
        public const string DefaultValidationErrors                 = "A solicitação contém erros de validação.";
        public const string DefaultNotDefined                       = "Não definido";

        /* Post validation messages */
        public const string InsertContactNameEmpty                  = "Não é possível inserir um contato sem o nome";
        public const string InsertContactHasNotAnyPhone             = "Insira no mínimo um número de telefone";
        public const string InsertContactEmptyNumber                = "Não é possível inserir um número de telefone vazio.";
        public const string InsertContactEmptyPhoneClassification   = "Não é possível inserir um número de telefone sem classificação.";
        public const string InsertContactPhoneClassOutOfRange       = "A classificação do telefone deve ser definida entre: (1 - Casa, 2 - Trabalho, 3 - Outros)";
        public const string InsertContactEmptyAddressClassification = "Não é possível inserir um endereço sem classificação.";
        public const string InsertContactAddressClassOutOfRange     = "A classificação do endereço deve ser definida entre: (1 - Casa, 2 - Trabalho, 3 - Outros)";


        /* Update validation messages*/
        public const string UpdateContactNameEmpty                  = "Não é possível atualizar um contato sem o nome";
        public const string UpdateContactHasNotAnyPhone             = "Insira no mínimo um número de telefone";
        public const string UpdateContactEmptyNumber                = "Não é possível alterar o número de telefone para vazio.";
        public const string UpdateContactEmptyPhoneClassification   = "Não é possível alterar um número de telefone sem determinar sua classificação.";
        public const string UpdateContactPhoneClassOutOfRange       = "A classificação do telefone deve ser definida entre: (1 - Casa, 2 - Trabalho, 3 - Outros)";
        public const string UpdateContactEmptyAddressClassification = "Não é possível alterar um endereço sem determinar sua classificação.";
        public const string UpdateContactAddressClassOutOfRange     = "A classificação do endereço deve ser definida entre: (1 - Casa, 2 - Trabalho, 3 - Outros)";
        public const string KafkaStreamError                        = "Erro ao enviar uma chamada para o Kafka";
    }
}

# Gleybe | Solução de Agenda Telefonica.
Este projeto foi criado para atender a uma necessidade de gerenciar rapidamente contatos de uma agenda telefonica.
Para ajudar no desenvolvimento e projeção da solução, foram utilizadas as seguintes tecnologias e conceitos.

- .NET 6.0
- MongoDb (Cluster on MongoDb Atlas)
- MediatR
- Clean Architecture
- CQRS Pattern 
- Repository Pattern
- Fluent Validation
- Kafka (Cluster on Confluent)


Obs: Ao tentar testar o projeto em um endereço externo, o MongoDb Atlas apresentou timeout de rede acredito que por alguma validação de IP necessária na ferramenta de cluster, e que não tenho tanto conhecimento. 
Para testar a solução, talvez seja necessário modificar a connectionString no arquivo appsettings.json


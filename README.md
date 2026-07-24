# API REST Em C# Integrada Com Redis, utilizando Docker e Hospedada na AWS

## Objetivos
 Desenvolver uma API que permita armazenar e recuperar URLs de vídeos utilizando o Redis como banco de cache.
A solução deverá estar publicada na AWS, com a comunicação entre a API e o Redis ocorrendo na infraestrutura em nuvem.

## Descrição
O projeto consiste em uma API REST desenvolvida em ASP.NET 8, com duas operações principais: POST e GET por ID. A aplicação utiliza o Redis, por meio da biblioteca StackExchange.Redis, para persistência dos dados e é totalmente containerizada com Docker, facilitando sua execução.

A solução foi estruturada seguindo os princípios de Domain-Driven Design (DDD), organizando o código em camadas para promover a separação de responsabilidades, facilitar a manutenção e melhorar a escalabilidade da aplicação.

## Tecnologias usadas
ASP .NET 8.0 para backend, Redis para integração com o Database, Docker para containerização da aplicação e biblioteca ''commitizen'' para padronizar os commits de forma interativa,
seguindo os padrões dos conventional commits.

## Arquiterura/estrutura do projeto
```text
├── Dockerfile
├── docker-compose.yml
├── NeuAI.VideoURL.sln
└── src
    ├── NeuAI.Video.API
    ├── NeuAI.Video.Application
    ├── NeuAI.Video.Domain
    └── NeuAI.Video.Infrastructure
```

## Requisitos / Checklist
- [x] Backend C#
- [x] .NET 8.0
- [x] ASP NET Core Web API
- [x] Integração funcional com Redis
- [x] Endpoints obrigatórios (POST - /api/cache || GET - /api/cache/{id})
- [x] Aplicação containerizada com Docker
- [x] Docker compose
- [x] Dockerfile
- [] Integração com AWS
- [] URL pública da API Hospedade na AWS
- [x] Clean architeture usando DDD(Domain Driven Design)

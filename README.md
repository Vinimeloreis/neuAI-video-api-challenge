# API REST Em C# Integrada Com Redis, utilizando Docker e Hospedada na AWS

## Objetivos
 Desenvolver uma API que permita armazenar e recuperar URLs de vídeos utilizando o Redis como banco de cache.
A solução deverá estar publicada na AWS, com a comunicação entre a API e o Redis ocorrendo na infraestrutura em nuvem.

## Descrição
O projeto consiste em uma API relativamente simples com duas funções CRUD, GET(id) e POST desenvolvido usando ASP .NET 8.0, o sistema possui integração
com a Stack do Redis para persistência de dados e componentização/containerização utilizando docker. A aplicação segue a arquitetura Domain Driven Design
(DDD) afim de separar as responsabilidades dos arquivos baseado no estudo de camadas da arquitetura estabelecida.

## Tecnologias usadas
ASP .NET 8.0 para backend, Redis para integração com o Database, Docker para containerização da aplicação e biblioteca ''commitizen'' para padronizar os commits de forma interativa
seguindo os padrões dos conventional commits.
## Arquiterura


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

# API REST em C# integrada com Redis, utilizando Docker e hospedada na AWS

## Objetivos

Desenvolver uma API que permita armazenar e recuperar URLs de vídeos utilizando o Redis como banco de cache.
A solução deverá estar publicada na AWS, com a comunicação entre a API e o Redis ocorrendo na infraestrutura em nuvem.

## Descrição

O projeto consiste em uma API REST desenvolvida em ASP.NET Core 8, com duas operações principais: POST e GET por ID. A aplicação utiliza o Redis, por meio da biblioteca StackExchange.Redis, para persistência dos dados e é totalmente containerizada com Docker, facilitando sua execução.

A solução foi estruturada seguindo uma Clean Architecture simplificada e inspirada em Domain-Driven Design (DDD), organizando o código em camadas para promover a separação de responsabilidades, facilitar a manutenção e melhorar a escalabilidade da aplicação.

## Tecnologias usadas

ASP.NET Core 8.0 para backend, Redis para integração com o database, Docker para containerização da aplicação e biblioteca `commitizen` para padronizar os commits de forma interativa, seguindo os padrões dos conventional commits, e um serviço de health mapeado para o endpoint "/health".

## Arquitetura / estrutura do projeto

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

## Camadas

**NeuAI.Video.API**
Camada responsável pelos controllers, configuração da aplicação e exposição dos endpoints HTTP.

**NeuAI.Video.Application**
Camada responsável pelos serviços de aplicação e contratos usados pelos casos de uso.

**NeuAI.Video.Domain**
Camada responsável pelas entidades principais do domínio.

**NeuAI.Video.Infrastructure**
Camada responsável pela integração com recursos externos, neste caso o Redis.

## Como executar com Docker

Na raiz do projeto, execute:

```bash
docker compose up --build
```

A API ficará disponível em:

```text
http://localhost:5187
```

O Docker Compose sobe dois containers:

- API ASP.NET Core
- Redis

Dentro do ambiente Docker, a API se comunica com o Redis usando a connection string:

```text
redis:6379
```

## Endpoints

### POST /api/cache

Armazena a URL de um vídeo no Redis usando o identificador informado.

Request:

```http
POST http://localhost:5187/api/cache
Content-Type: application/json
```

Body:

```json
{
  "id": "video-001",
  "url": "https://youtube.com/xxxx"
}
```

Response:

```json
{
  "status": "Criado com sucesso",
  "id": "video-001",
  "url": "https://youtube.com/xxxx"
}
```

### GET /api/cache/{id}

Recupera a URL correspondente ao identificador informado.

Request:

```http
GET http://localhost:5187/api/cache/video-001
```

Response:

```json
{
  "id": "video-001",
  "url": "https://youtube.com/xxxx"
}
```

Caso o registro não exista, a API retorna:

```text
HTTP 404 Not Found
```

## Configuração

A connection string local do Redis fica em `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "Redis": "localhost:6379"
  }
}
```

No Docker Compose, essa configuração é sobrescrita por conta da prioridade de variável de ambiente:

```yaml
ConnectionStrings__Redis=redis:6379
```

## Requisitos / Checklist

- [x] Backend C#
- [x] .NET 8.0
- [x] ASP.NET Core Web API
- [x] Integração funcional com Redis
- [x] Endpoints obrigatórios (POST - /api/cache || GET - /api/cache/{id})
- [x] Aplicação containerizada com Docker
- [x] Docker Compose
- [x] Dockerfile
- [x] Integração com AWS
- [x] URL pública da API hospedada na AWS
- [x] Clean Architecture simplificada inspirada em DDD (Domain-Driven Design)
- [x] Uso de variáveis de ambiente
- [ ] Github Actions
- [ ] Testes unitários
- [ ] Tratamento global de exceções
- [ ] Uso de health checks

> Endpoint público da VM: http://54.207.171.67:5187
> 
> Exemplo de requisição GET:
> 
> http://54.207.171.67:5187/api/cache/video-001

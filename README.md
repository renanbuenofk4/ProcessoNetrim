# 📚 SchoolManagement API

API REST desenvolvida com arquitetura Clean usando ASP.NET Core e Entity Framework, containerizada com Docker e pronta para CI/CD no GitHub Actions.

---

## 🚀 Tecnologias utilizadas

- ASP.NET Core 8.0
- Entity Framework Core
- SQL Server (via Docker)
- Docker + Docker Compose
- GitHub Actions (CI/CD)
- Swagger (documentação automática)

---

## ▶️ Como executar com Docker

```bash
docker compose up --build


🛠️ Como rodar localmente
Configure a connection string no appsettings.Development.json

Execute a aplicação com o Visual Studio ou dotnet run

🧪 Endpoints principais
GET /api/pessoa
GET /api/escola
GET /api/turma
POST /api/inscricao

📂 Estrutura
Domain: entidades de negócio
Application: services, interfaces, DTOs
Infrastructure: persistência e EF Core
API: controllers

🔁 CI/CD com GitHub Actions
Automatização de build via ci-cd.yml localizado em .github/workflows.

👤 Autor: Renan de Jesus Bueno da Silva
Projeto desenvolvido para avaliação técnica com foco em arquitetura limpa e boas práticas.

# sic-sinop

UNIFASIPE - Projeto Interdisciplinar IV

### Instalação

 * Baixe o [.NET SDK](https://dotnet.microsoft.com/download).
 * Baixe e instale o [PostgreSQL](https://www.postgresql.org/download/).

```bash
# Clone este repositorio
git clone https://github.com/guilhermemrk/sic-sinop

# Instale o EF no powershell
dotnet tool install --global dotnet-ef

# Edite as configurações do banco no arquivo appsettings.json / appsettings.Development.json
# "PostgreSQL": "Host=localhost;Port=5432;Pooling=true;Database=sicsinop;User Id=seu_usuario_do_postgres_aqui;Password=sua_senha_do_postgres_aqui;"

# Na pasta do projeto rode o comando abaixo (depois de configurar o postgres corretamente)
dotnet ef database update -p SICSinop.API

# Inicie o projeto
dotnet run
```
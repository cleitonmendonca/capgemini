# [Capgemini] - Aplicação para importar dados de um documento excel
## Dependências

* .Net 5.0
* SignalR
* EntityFrameworkCore (5.0.0)
* Swashbuckle.AspNetCore (5.6.3)
* AutoMapper (10.0.1)
* MediatR (9.0.0)
* SqlLite

## Documentação

Após clonar o projeto, configurar o appsettings conforme seu ambiente de development/staging/production.

## Criação da base de dados

Esse projeto estar sendo desenvolvido utilizando migration para mais detalhes acesse o link [https://docs.microsoft.com/pt-br/ef/core/managing-schemas/migrations/?tabs=dotnet-core-cli](https://docs.microsoft.com/pt-br/ef/core/managing-schemas/migrations/?tabs=dotnet-core-cli)

Para criação da para de dados é preciso executar o seguinte com:

Usando .NET Core CLI:

```
dotnet ef database update
```

Usando Visual Studio:

```
Update-Database
```
### Executar o projeto

```
dotnet run -p src/Api/.Api.csproj
```

### Compilar e usar o hot-reloads para desenvolvimento

```
dotnet watch run -p src/Api/Api.csproj
```
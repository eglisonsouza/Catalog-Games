# INSTRUÇÕES

**Antes de iniciar o projeto, é necessário a criação da estrutura de banco de dados.**

Na pasta raiz da solução, execute os comandos abaixo:

__Comando vai criar criar o banco de dados e suas tabelas para a aplicação com o nome **games_catalog**__
```shel
dotnet ef database update --project CatalogGames.Infra/
```

**O banco de dados pode ser configurado em `CatologGames.Shared/Settings.cs`**

Após isso basta inicar a aplicação.

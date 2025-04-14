# DesafioTecnicoMVC

Aplicação web desenvolvida com ASP.NET Core MVC para gerenciamento de produtos.
Este projeto permite realizar operações CRUD (Create, Read, Update, Delete) em uma entidade `Produto`, utilizando Entity Framework Core com SQLite como banco de dados.

## 🚀 Tecnologias Utilizadas

- .NET 8
- ASP.NET Core MVC
- Entity Framework Core
- SQLite
- Razor Pages
- Bootstrap (para estilização)

## 📦 Como Rodar o Projeto

1. **Clonar o repositório**
   ```bash
   git clone https://github.com/gio98nn/DesafioTecnicoMVC.git
   cd DesafioTecnicoMVC
   ```

2. **Restaurar os pacotes NuGet**
   ```bash
   dotnet restore
   ```

3. **Aplicar as migrações e criar o banco de dados**
   ```bash
   dotnet ef database update
   ```

4. **Rodar o projeto**
   ```bash
   dotnet run
   ```

5. **Acessar no navegador**
   ```
   https://localhost:5001
   ```
   A interface estará disponível para interagir com os produtos.

## 📌 Funcionalidades Disponíveis

- Listar todos os produtos
- Visualizar detalhes de um produto
- Criar um novo produto
- Editar um produto existente
- Deletar um produto

## 🧪 Exemplo de Objeto Produto

```json
{
  "id": 1,
  "nome": "Teclado Gamer",
  "descricao": "Teclado mecânico com RGB",
  "preco": 199.90
}
```

## 🗃️ Estrutura do Projeto

```
DesafioTecnicoMVC/
├── Controllers/
│   └── ProdutoController.cs
├── Models/
│   └── Produto.cs
├── Views/
│   └── Produto/
│       ├── Index.cshtml
│       ├── Create.cshtml
│       ├── Edit.cshtml
│       ├── Details.cshtml
│       └── Delete.cshtml
├── wwwroot/
│   └── (arquivos estáticos como CSS, JS, imagens)
├── appsettings.json
├── Program.cs
└── produtoMVC.csproj
```

## ⚙️ Observações

- O banco de dados utilizado é SQLite, e o arquivo `.db` será criado automaticamente na primeira execução.
- Certifique-se de que você possui o .NET 8 SDK instalado.
- As views utilizam Razor Pages com Bootstrap para estilização.

---

Este projeto foi desenvolvido como parte de um desafio técnico, demonstrando habilidades em ASP.NET Core MVC, Entity Framework Core e SQLite.

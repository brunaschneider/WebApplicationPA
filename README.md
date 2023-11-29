# Documentação do Projeto

## WebApplicationPA

WebApplicationPA é um projeto de aplicação web desenvolvido em ASP.NET Core.

### Estrutura de Pastas

- **Pages**: Contém as páginas Razor (.cshtml) que compõem as views da aplicação.
  - **Albums**: Páginas relacionadas à funcionalidade de álbuns.
    - **Index.cshtml**: Página principal de listagem de álbuns.
    - **Create.cshtml**: Página de criação de novos álbuns.
    - **Edit.cshtml**: Página de edição de álbuns existentes.
    - **Delete.cshtml**: Página de exclusão de álbuns existentes.
  - **Tracks**: Páginas relacionadas à funcionalidade de faixas.
    - **Index.cshtml**: Página principal de listagem de faixas de um álbum.
- **wwwroot**: Contém arquivos estáticos como CSS, JavaScript e imagens.
  - **css**: Estilos CSS personalizados.
  - **lib**: Bibliotecas de terceiros, como o Bootstrap.
  - **js**: Scripts JavaScript.
- **Models**: Classes que representam os objetos de dados da aplicação.
  - **AlbumInfo.cs**: Modelo para informações de álbuns.
  - **TrackInfo.cs**: Modelo para informações de faixas.

### Configuração do Banco de Dados

A aplicação utiliza o banco de dados MySQL para armazenar informações sobre álbuns e faixas. A string de conexão está definida no código.

### Páginas Principais

- **Index**: Página principal que fornece uma visão geral da aplicação e links para outras partes.

### Funcionalidades Principais

1. **Álbuns**
    - **Listagem de Álbuns**: A página "Index" em "Albums" exibe uma lista de álbuns cadastrados.
    - **Criação de Álbuns**: A página "Create" em "Albums" permite adicionar novos álbuns.
    - **Edição de Álbuns**: A página "Edit" em "Albums" permite editar informações de álbuns existentes.
    - **Exclusão de Álbuns**: A página "Delete" em "Albums" permite excluir álbuns existentes.

2. **Faixas**
    - **Listagem de Faixas**: A página "Index" em "Tracks" exibe uma lista de faixas de um álbum específico.

### Estilos

A aplicação utiliza estilos inspirados no esquema de cores do Spotify, com verde predominante (#1DB954) e fundo escuro (#191414).

### Execução do Projeto

1. Clone o repositório: `git clone https://github.com/brunaschneider/WebApplicationPA.git`
2. Abra o projeto em um ambiente de desenvolvimento compatível com ASP.NET Core.
3. Configure a conexão do banco de dados no código, se necessário.
4. Execute o projeto.

### Considerações Finais

Esta documentação fornece uma visão geral básica da estrutura e funcionalidades do projeto. Certifique-se de fornecer informações adicionais conforme o desenvolvimento progride.

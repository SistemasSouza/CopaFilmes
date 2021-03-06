# Copa de Filmes

O projeto realiza a competição entre filmes baseado nas notas dadas pelos usuários. Onde o filme mais bem avaliado será o grande campeão.

## Projeto Backend

Desenvolvido utilizando .NET Core na versão 3.1 com template de projeto Web Api.

Os arquivos fontes podem ser encontrados na pasta `src/backend`.


## Frontend

Desenvolvido utilizando React JS, HTML 5 e CSS, o mesmo consome a Api desenvolvida no backend via axios.

Os arquivos fontes podem ser encontrados na pasta `src/frontend`

## Executando testes automatizados
O projetos backend e frontend são cobertos por testes automatizados, para rodar os mesmos execute os comandos abaixo no terminal.

- backend
  - `dotnet test src/backend/CopaFilmes.Tests`
- frontend 

  - `cd src/frontend && yarn` ou `cd src/frontend && npm install` (recuperar dependências do projeto) 
  - `cd src/frontend && npm run test`
   ou 
  - `cd src/frontend && yarn test`


## Rodando o projeto no terminal

Caso queira apenas testar o projeto, baixe a pasta `publish` para  a máquina local e executar o seguinte comando no terminal a partir da raiz do projeto.

`cd publish && dotnet CopaFilmes.Api.dll`

após executar o comando o projeto será executado no localhost  na porta 5000

[Clique para acessar o projeto](http://localhost:5000)

ao executar o projeto,  o mesmo subirá tanto o frontend quanto o backend simultaneamente.

## Realizando o campeonato

Após acessar a url, o usuário verá a tela com os filmes participantes do campeonato, o mesmo deve selecionar 8 filmes e clicar no botão **Gerar meu campeonato**, ao clicar no botão as filmes serão enviados para o backend no qual realizar o campeonato e devolverá o resultado do vencedor e o segundo lugar.

![Alt Text](https://media.giphy.com/media/hRyAVX1q7bQwSLKLLb/giphy.gif)

Em caso de dúvidas, entre em contato comigo no e-mail: denyssouza1@hotmail.com

# Copa de Filmes

O projeto realiza a competição entre filmes baseado na nota dada pelos usuários. Onde o filme mais bem avaliado será o grande campeão.

## Projeto Backend

Desenvolvido utilizando .NET Core na versão 3.1 com template de projeto Web Api, os arquivos fontes pode ser encontrados dentro da dentro da pasta `src/backend`.


## Frontend

Desenvolvido utilizando React JS, HTML 5 e CSS, o mesmo consome a Api desenvolvida no backend via axios.

## Rodando o projeto no terminal

Para testar o projeto, pode ser baixar a pasta `publish` para  a máquina local e executar o seguinte comando no terminal a partir da publish.

**dotnet copafilmes.api.dll**

após executar o comando o projeto será executado no localhost com a  porta 5000

**localhost:5000**

ao executar o projeto,  o mesmo subirá tanto o frontend quanto o backend simultaneamente.

## Realizando o campeonato

Após acessar a url, o usuário verá a tela com os filmes participantes do campeonato, o mesmo deve selecionar 8 filmes e clicar no botão **Gerar meu campeonato**, ao clicar no botão as filmes serão enviados para o backend no qual realizar o campeonato e devolverá o resultado do vencedor e o segundo lugar.

![Alt Text](https://media.giphy.com/media/hRyAVX1q7bQwSLKLLb/giphy.gif)

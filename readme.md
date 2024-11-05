# Windows Service - Conex�o com Dynamics CRM

Este projeto � um Servi�o do Windows desenvolvido em .NET que executa um gatilho a cada 1 minuto. O servi�o cria um arquivo de log em texto na pasta `bin` e realiza uma conex�o com o Dynamics CRM para atualizar registros em uma entidade espec�fica.

## Funcionalidades

- **Gatilho**: Executado a cada 1 minuto.
- **Arquivo de Log**: Cria um arquivo `.txt` na pasta `bin` para monitoramento do servi�o. A cada execu��o, insere a data e hora no arquivo.
- **Conex�o com Dynamics CRM**: Conecta-se ao Dynamics CRM e atualiza um registro em uma entidade especificada.

## Configura��o do Ambiente

1. **Instalar o SDK do .NET**: Baixe a vers�o mais recente do SDK do .NET da [p�gina de download da Microsoft](https://dotnet.microsoft.com/download).
2. **IDE (Ambiente de Desenvolvimento)**: Use o Visual Studio (recomendado para Windows) ou Visual Studio Code com as extens�es C#.

## Como Utilizar

### Altera��es no C�digo

1. **Configura��o de Conex�o**: No arquivo `App.config`, insira as configura��es de conex�o com o Dynamics CRM.
2. **Entidade e Coluna**:
   - No arquivo `Program.cs`, adicione o nome da entidade e a coluna que deseja alterar.
   - No arquivo `Service1.cs`, configure tamb�m o nome da entidade e a coluna para garantir que o servi�o execute as atualiza��es corretas.

### Instalando o Servi�o

1. **Compilar o Projeto**: Compile o projeto no Visual Studio.
2. **Abrir o CMD como Administrador**:
   - Navegue at� a pasta do .NET, geralmente localizada em `C:\Windows\Microsoft.NET\Framework64\v`.
3. **Instalar o Servi�o**:
   - Copie o caminho do execut�vel gerado pelo seu projeto.
   - No CMD, execute o comando para instalar o servi�o:
     ```bash
     InstallUtil.exe caminhoDoPrograma
     ```
   - Exemplo:
     ```bash
     InstallUtil.exe C:\WindowsServiceModelo\bin\Debug\WindowsServiceModelo.exe
     ```

### Executando o Servi�o

1. **Abrir o Console de Servi�os**:
   - Abra o "Servi�os" no Windows, encontre o servi�o pelo nome exibido no `DisplayName`.
2. **Iniciar o Servi�o**:
   - Clique com o bot�o direito sobre o servi�o e selecione **Iniciar**.

## Criando o Projeto do Zero

1. **Criar o Projeto no Visual Studio**:
   - Abra o Visual Studio e clique em **Criar um Novo Projeto**.
   - Pesquise e selecione **Servi�o do Windows (.NET Core)** ou **Worker Service**.
   - Nomeie o projeto e clique em **Criar**.

2. **Configurar o Instalador**:
   - Clique com o bot�o direito na tela do designer e selecione **Adicionar instalador**.
   - No m�todo `InitializeComponent()` do `ProjectInstaller`, ajuste as configura��es do servi�o, incluindo nome e propriedades.

3. **Adicionar L�gica do Servi�o**:
   - No arquivo principal do projeto (ex.: `Service1.cs`), insira o c�digo que ser� executado em cada gatilho.

## Solu��o de Problemas

Se encontrar um erro de permiss�o ou privacidade ao instalar ou executar o servi�o:
1. Clique com o bot�o direito no arquivo `.exe`, v� em **Propriedades > Seguran�a** e garanta que seu usu�rio tem permiss�es totais.



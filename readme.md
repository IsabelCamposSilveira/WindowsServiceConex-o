# Windows Service - Conexão com Dynamics CRM

Este projeto é um Serviço do Windows desenvolvido em .NET que executa um gatilho a cada 1 minuto. O serviço cria um arquivo de log em texto na pasta `bin` e realiza uma conexão com o Dynamics CRM para atualizar registros em uma entidade específica.

## Funcionalidades

- **Gatilho**: Executado a cada 1 minuto.
- **Arquivo de Log**: Cria um arquivo `.txt` na pasta `bin` para monitoramento do serviço. A cada execução, insere a data e hora no arquivo.
- **Conexão com Dynamics CRM**: Conecta-se ao Dynamics CRM e atualiza um registro em uma entidade especificada.

## Configuração do Ambiente

1. **Instalar o SDK do .NET**: Baixe a versão mais recente do SDK do .NET da [página de download da Microsoft](https://dotnet.microsoft.com/download).
2. **IDE (Ambiente de Desenvolvimento)**: Use o Visual Studio (recomendado para Windows) ou Visual Studio Code com as extensões C#.

## Como Utilizar

### Alterações no Código

1. **Configuração de Conexão**: No arquivo `App.config`, insira as configurações de conexão com o Dynamics CRM.
2. **Entidade e Coluna**:
   - No arquivo `Program.cs`, adicione o nome da entidade e a coluna que deseja alterar.
   - No arquivo `Service1.cs`, configure também o nome da entidade e a coluna para garantir que o serviço execute as atualizações corretas.

### Instalando o Serviço

1. **Compilar o Projeto**: Compile o projeto no Visual Studio.
2. **Abrir o CMD como Administrador**:
   - Navegue até a pasta do .NET, geralmente localizada em `C:\Windows\Microsoft.NET\Framework64\v`.
3. **Instalar o Serviço**:
   - Copie o caminho do executável gerado pelo seu projeto.
   - No CMD, execute o comando para instalar o serviço:
     ```bash
     InstallUtil.exe caminhoDoPrograma
     ```
   - Exemplo:
     ```bash
     InstallUtil.exe C:\WindowsServiceModelo\bin\Debug\WindowsServiceModelo.exe
     ```

### Executando o Serviço

1. **Abrir o Console de Serviços**:
   - Abra o "Serviços" no Windows, encontre o serviço pelo nome exibido no `DisplayName`.
2. **Iniciar o Serviço**:
   - Clique com o botão direito sobre o serviço e selecione **Iniciar**.

## Criando o Projeto do Zero

1. **Criar o Projeto no Visual Studio**:
   - Abra o Visual Studio e clique em **Criar um Novo Projeto**.
   - Pesquise e selecione **Serviço do Windows (.NET Core)** ou **Worker Service**.
   - Nomeie o projeto e clique em **Criar**.

2. **Configurar o Instalador**:
   - Clique com o botão direito na tela do designer e selecione **Adicionar instalador**.
   - No método `InitializeComponent()` do `ProjectInstaller`, ajuste as configurações do serviço, incluindo nome e propriedades.

3. **Adicionar Lógica do Serviço**:
   - No arquivo principal do projeto (ex.: `Service1.cs`), insira o código que será executado em cada gatilho.

## Solução de Problemas

Se encontrar um erro de permissão ou privacidade ao instalar ou executar o serviço:
1. Clique com o botão direito no arquivo `.exe`, vá em **Propriedades > Segurança** e garanta que seu usuário tem permissões totais.



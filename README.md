# 🧠 PoryGuard

**PoryGuard** é um software desenvolvido em C# que detecta, em tempo real, estímulos visuais potencialmente perigosos para pessoas com epilepsia fotossensível. Ele analisa os frames capturados da tela e aplica censura gráfica sobre áreas com flashes intensos, oferecendo uma camada de proteção visual em ambientes digitais.

## ⚙️ Funcionalidades

- 📸 Captura contínua da tela em tempo real com múltiplas threads
- 🧠 Análise inteligente de padrões visuais (luminância, variação de cor e vermelho crítico)
- 🔲 Detecção de quadrantes perigosos
- 🛡️ Censura automática com sobreposição visual personalizada
- 🔁 Persistência de configurações em JSON
- 🖱️ Interface gráfica em Windows Forms com controles ajustáveis
- 🚀 Início automático com o Windows (opcional)
- 🧪 Baseado em critérios clínicos de risco para estímulos fotossensíveis

## 🧪 Critérios de Análise Clínica

- Limiar de luminosidade e variação de vermelho crítico baseados em literatura médica
- Análise segmentada em múltiplos quadrantes para maior precisão
- Frequência mínima e máxima de flashes configuráveis (3-30 Hz)
- Identificação de "flashes perigosos" por contraste súbito de luminância ou vermelho
- Duração mínima de censura de 2 segundos para garantir segurança
- Tempo entre análise, identificação e censura não superior a 1 segundo

## 🖥️ Tecnologias Utilizadas

- **C# / .NET Framework 4.8**
- **Windows Forms**
- **MaterialSkin.2** 
- **Syncfusion Tools**
- Arquitetura MVC (Model - View - Controller)

## 📁 Estrutura do Projeto

```
PoryGuard/
├── Controller/               # Captura de tela, análise e censura
│   ├── CapturaDeTela.cs     # Gerenciamento de captura otimizada
│   ├── AnaliseDeCapturas.cs # Análise de padrões visuais
│   └── Censura.cs           # Sistema de overlay compartilhado
├── Model/                    # Estruturas de dados e sobreposição
│   ├── Monitor.cs           # Informações do monitor
│   └── OverlayCensura.cs    # Janela de sobreposição transparente
├── Properties/               # Metadados e configurações
├── App.config               # Configurações da aplicação
├── PoryGuard.cs             # Interface principal (UI)
├── Program.cs               # Ponto de entrada
├── ConfiguraçãoPersistente.json  # Configurações salvas
├── setup.exe                # Instalador (na raiz do repositório)
└── README.md
```

## 🚀 Como Executar

### Opção 1: Instalador (Recomendado)

1. Baixe o arquivo `setup.exe` disponível na raiz do repositório
2. Execute o instalador e siga as instruções
3. O PoryGuard será instalado e estará pronto para uso

### Opção 2: Compilação Manual

1. Clone o repositório:
   ```bash
   git clone https://github.com/LiderAstral/PoryGuard.git
   ```

2. Abra o arquivo `PoryGuard.sln` no Visual Studio 2019 ou superior

3. Restaure os pacotes NuGet:
   - Clique com botão direito na solução → "Restaurar Pacotes NuGet"

4. Adquira uma [licença gratuita SyncFusion](https://www.syncfusion.com/products/communitylicense) e a adicione no Program.cs, em:
```SyncfusionLicenseProvider.RegisterLicense("");```

5. Compile e execute o projeto (F5)

### ✅ Requisitos

- Windows 10 ou superior (64 bits)
- .NET Framework 4.8
  
## 🎮 Como Usar

1. **Iniciar o Programa**: Execute PoryGuard através do atalho criado ou do instalador

2. **Configurar Variáveis**:
   - Ajuste todas as variáveis do programa conforme a sua preferência, como o limite de variação no brilho e no vermelho que preferir/suportar
   - Alternativamente, clique em "RESTAURAR PADRÃO" para voltar às configurações recomendadas com base nas diretrizes internacionais
   
3. **Ativar Proteção**:
   - Use o switch "Em execução" para ativar/desativar
   - Marque "Início Automático" para executar com o Windows

## ⚠️ Aviso Importante

**ATENÇÃO**: As configurações deste software devem ser ajustadas com base em orientação e laudo médico profissional. O uso inadequado é de inteira responsabilidade do usuário. Este software não substitui acompanhamento médico especializado.

## 🔬 Objetivo

O projeto visa mitigar os riscos causados por estímulos visuais perigosos, como flashes rápidos e contrastes altos, a indivíduos com epilepsia fotossensível, promovendo segurança digital e acessibilidade. Seu desenvolvimento é embasado em literatura médica e recomendações técnicas sobre gatilhos visuais de crises epilépticas.

### Contribuindo

Contribuições são bem-vindas! Por favor:
1. Fork o projeto
2. Crie uma branch para sua feature (`git checkout -b feature/NovaFuncionalidade`)
3. Commit suas mudanças (`git commit -m 'Adiciona nova funcionalidade'`)
4. Push para a branch (`git push origin feature/NovaFuncionalidade`)
5. Abra um Pull Request

## 📬 Contato

Desenvolvido por:
- [LiderAstral](https://github.com/LiderAstral)
- [RafaelaTonon](https://github.com/RafaelaTonon)

Para dúvidas, sugestões ou relatos de problemas, abra uma [issue](https://github.com/LiderAstral/PoryGuard/issues) no repositório.

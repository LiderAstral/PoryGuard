# 🧠 PoryGuard

**PoryGuard** é um software desenvolvido em C# que detecta, em tempo real, estímulos visuais potencialmente perigosos para pessoas com epilepsia fotossensível. Ele analisa os frames capturados da tela e aplica censura gráfica sobre áreas com flashes intensos, oferecendo uma camada de proteção visual em ambientes digitais.

## ⚙️ Funcionalidades

- 📸 Captura contínua da tela em tempo real com múltiplas threads
- 🧠 Análise inteligente de padrões visuais (luminância, variação de cor e vermelho crítico)
- 🔲 Detecção de quadrantes perigosos
- 🛡️ Censura automática com sobreposição visual personalizada
- 🔁 Persistência de configurações em JSON
- 🖱️ Interface gráfica em Windows Forms
- 🧪 Baseado em critérios clínicos de risco para estímulos fotossensíveis

## 🧪 Critérios de Análise Clínica

- Limiar de luminosidade e variação de vermelho crítico baseados em literatura médica
- Análise segmentada em múltiplos quadrantes para maior precisão
- Frequência mínima e máxima de flashes configuráveis
- Identificação de "flashes perigosos" por contraste súbito ou excesso de vermelho

## 🖥️ Tecnologias Utilizadas

- **C# / .NET Framework 4.8**
- **Windows Forms**
- Arquitetura MVC (Model - View - Controller)

## 📁 Estrutura do Projeto

```
PoryGuard/
├── Controller/               # Captura de tela, análise e censura
│   ├── CapturaDeTela.cs
│   ├── AnaliseDeCapturas.cs
│   └── Censura.cs
├── Model/                    # Estruturas de dados e sobreposição
│   ├── Monitor.cs
│   └── OverlayCensura.cs
├── Properties/               # Metadados e configurações
├── App.config
├── PoryGuard.cs              # Interface principal (UI)
├── Program.cs                # Ponto de entrada
└── ConfiguraçãoPersistente.json
```
## 🚀 Como Executar

1. Clone o repositório:
   ```
   git clone https://github.com/LiderAstral/PoryGuard.git
   ```

2. Abra o arquivo `PoryGuard.sln` no Visual Studio 2019 ou superior.

3. Compile e execute o projeto.

### ✅ Requisitos

- .NET Framework 4.8
- Windows 10 ou superior

## 🔬 Objetivo

O projeto visa mitigar os riscos causados por estímulos visuais perigosos, como flashes rápidos e contrastes altos, a indivíduos com epilepsia fotossensível, promovendo segurança digital e acessibilidade. Seu desenvolvimento é embasado em literatura médica e recomendações técnicas sobre gatilhos visuais de crises epilépticas. Estudos sobre frequência de flashes, contraste e área de cobertura serão levados em conta para análise de risco.

## 📬 Contato

Desenvolvido por [LiderAstral](https://github.com/LiderAstral), [RafaelaTonon](https://github.com/RafaelaTonon).

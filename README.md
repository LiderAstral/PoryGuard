# 🧠 PoryGuard

**PoryGuard** é um software desenvolvido em C# que detecta, em tempo real, estímulos visuais potencialmente perigosos para pessoas com epilepsia fotossensível. Ele analisa os frames capturados da tela e aplica censura gráfica sobre áreas com flashes intensos, oferecendo uma camada de proteção visual em ambientes digitais.

## ⚙️ Funcionalidades

- 📸 Captura de tela em tempo real
- 🧠 Análise de padrões visuais (ex: flashes intensos)
- 🛡️ Censura automática sobre áreas perigosas
- 🧪 Baseado em critérios clínicos de risco para estímulos fotossensíveis

## 🖥️ Tecnologias Utilizadas

- **C# / .NET Framework 4.8**
- **Windows Forms**
- Arquitetura MVC (Model - View - Controller)

## 📁 Estrutura do Projeto

PoryGuard/  
├── Controller/           → Lógica de controle  
├── Model/                → Estruturas de dados  
├── Properties/           → Configurações do projeto  
├── App.config            → Configurações da aplicação  
├── PoryGuard.cs          → Interface principal  
├── Program.cs            → Ponto de entrada  
└── PoryGuard.sln         → Solução do Visual Studio  

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

O projeto visa mitigar os riscos causados por estímulos visuais perigosos — como flashes rápidos e contrastes altos — a indivíduos com epilepsia fotossensível, promovendo segurança digital e acessibilidade. Seu desenvolvimento é embasado em literatura médica e recomendações técnicas sobre gatilhos visuais de crises epilépticas. Estudos sobre frequência de flashes, contraste e área de cobertura serão levados em conta para análise de risco.

## 📬 Contato

Desenvolvido por [LiderAstral](https://github.com/LiderAstral)  

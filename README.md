DESAFIO TÉCNICO – BOOTCAMP WEB FRONT (ANGULAR + ASP.NET)
Objetivo
Desenvolver uma aplicação web simples para cadastro e gerenciamento de tarefas,
utilizando Angular no front-end, ASP.NET Core Web API no back-end e SQL
Server como banco de dados.
O objetivo do desafio é avaliar conhecimentos básicos de desenvolvimento web,
integração front-end e back-end, e lógica de programação, considerando um nível
júnior.

Tecnologias obrigatórias
 Front-end: Angular
 Back-end: ASP.NET Core Web API (C#)
 Banco de dados: SQL Server
 ORM: Entity Framework Core
 Comunicação: API REST (JSON)

Escopo do Projeto
Entidade principal: Tarefa
A aplicação deverá trabalhar com a entidade Tarefa, contendo os seguintes campos:
Campo Tipo
Id int (gerado
automaticamente)

Título string
Descrição string
Status string (Pendente /
Concluída)

Data de
Criação DateTime

Funcionalidades obrigatórias
Back-end (API)
 Criar uma API REST para gerenciar tarefas
 Implementar os seguintes endpoints:
o GET – Listar todas as tarefas

o GET/{id} – Buscar tarefa por ID
o POST – Criar nova tarefa
o PUT/{id} – Atualizar uma tarefa
o DELETE/{id} – Excluir uma tarefa
 Persistir os dados no SQL Server
 Utilizar Entity Framework Core

Front-end (Angular)
 Tela para listar tarefas
 Tela/formulário para criar tarefa
 Possibilidade de editar tarefa
 Possibilidade de excluir tarefa
 Consumo da API utilizando HttpClient
 Organização básica em componentes e services

Requisitos não obrigatórios (opcionais)
(Não eliminam se não forem feitos)
 Validação simples de formulário
 Mensagens de sucesso ou erro
 Filtro de tarefas por status
 Layout simples (não será avaliado design avançado)

Critérios de Avaliação
Os candidatos serão avaliados com base nos seguintes critérios:
Obrigatórios
 Funcionamento correto do CRUD
 Comunicação entre Angular e API
 Organização básica do código
 Uso correto de HTTP (GET, POST, PUT, DELETE)
 Projeto compila e executa corretamente

Diferenciais (não obrigatórios)

 Código limpo e bem organizado
 Validações básicas
 Tratamento simples de erros
 README explicando como rodar o projeto
 Commits organizados no Git

O que não será avaliado
 Design avançado
 Autenticação / login
 Arquitetura complexa
 Padrões avançados (DDD, CQRS, etc.)

Carga horária estimada
80 horas, distribuídas entre:
 Planejamento
 Desenvolvimento back-end
 Desenvolvimento front-end
 Integração
 Ajustes finais

Entrega
 Código-fonte em repositório Git (GitHub, GitLab ou similar)
 README com instruções para execução do projeto

# Projeto Assistência Técnica Web

## Sobre o Projeto

O Projeto Assistência Técnica Web é um sistema desenvolvido para auxiliar o gerenciamento de uma assistência técnica de equipamentos eletrônicos. A aplicação permite controlar clientes, produtos, peças, funcionários, ordens de serviço e orçamentos, centralizando todas as informações necessárias para o atendimento e acompanhamento dos consertos.

O objetivo do sistema é tornar o processo de manutenção mais organizado, permitindo o registro de equipamentos, abertura de ordens de serviço, acompanhamento do status dos reparos e geração de orçamentos para os clientes.

---

## Funcionalidades

### Cadastro de Clientes

* Cadastro completo de clientes.
* Controle de dados pessoais e informações de contato.
* Busca por nome, CPF/CNPJ e telefone.
* Controle de clientes ativos e inativos.

### Cadastro de Funcionários

* Cadastro de funcionários responsáveis pelos atendimentos.
* Controle de situação ativa ou inativa.
* Associação de funcionários às ordens de serviço e peças cadastradas.

### Cadastro de Produtos

* Registro dos equipamentos pertencentes aos clientes.
* Associação entre cliente e produto.
* Controle de marca, modelo e informações do equipamento.

### Cadastro de Peças

* Cadastro de peças utilizadas nos reparos.
* Controle de estoque.
* Controle de valor de compra e valor de revenda.
* Registro do funcionário responsável pelo cadastro.

### Ordens de Serviço

* Abertura de novas ordens de serviço.
* Geração automática de número de atendimento.
* Controle de equipamento através de ticket identificador.
* Associação com cliente, produto e funcionário.
* Registro do defeito informado pelo cliente.
* Controle de acessórios entregues junto ao equipamento.

### Controle de Status

O sistema permite acompanhar o andamento do conserto através de diferentes estados:

* Em Análise
* Esperando Confirmação de Orçamento
* Aguardando Cliente Retirar
* Finalizado

### Finalização de Ordem de Serviço

Ao finalizar uma ordem de serviço é possível registrar:

* Data do conserto
* Descrição do serviço realizado
* Técnico responsável
* Valor base do conserto
* Percentual do estabelecimento
* Percentual do técnico
* Valor das peças utilizadas
* Valor adicional
* Valor total do serviço

### Orçamentos

* Criação e gerenciamento de orçamentos.
* Associação com funcionários responsáveis.
* Controle de valores e descrição dos serviços.

### Geração de PDF

* Geração automática de orçamento em PDF.
* Informações do cliente, equipamento, serviço e valores.
* Facilita o envio do orçamento ao cliente.

### Relatórios

* Quantidade de ordens de serviço em análise.
* Quantidade de ordens finalizadas.
* Itens consertados no mês.
* Dashboard simples na tela inicial para acompanhamento das atividades.

---

## Tecnologias Utilizadas

### Backend

* ASP.NET Core MVC
* Entity Framework Core
* C#

### Banco de Dados

* MySQL

### Frontend

* Razor Pages
* HTML5
* CSS
* Bootstrap

### Bibliotecas

* QuestPDF (Geração de PDF)

---

## Estrutura do Sistema

O sistema é composto pelos seguintes módulos:

* Clientes
* Funcionários
* Produtos
* Peças
* Ordens de Serviço
* Orçamentos
* Relatórios

---

## Objetivo Acadêmico

Este projeto foi desenvolvido como atividade acadêmica da disciplina de Desenvolvimento Web, com o objetivo de aplicar conceitos de:

* Programação Orientada a Objetos
* Desenvolvimento Web com ASP.NET Core MVC
* Persistência de Dados
* Entity Framework Core
* Modelagem de Banco de Dados
* Arquitetura MVC
* Requisitos Funcionais e Não Funcionais

---

## Autores

Desenvolvido por:

* Filipe Voigt
* Vinicius Correa Miranda
* Vitor Pazda

Instituto Federal de Santa Catarina (IFSC)
Curso Superior de Análise e Desenvolvimento de Sistemas

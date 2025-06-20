# EFProject

Sistema de Gerenciamento de Agência de Turismo

Este repositório contém o **trabalho final acadêmico** desenvolvido para a disciplina **Desenvolvimento Web com .NET e Bases de Dados**, cursada no semestre 2025.1 na [Faculdade Infnet](https://www.infnet.edu.br/).

O projeto consiste em uma aplicação web full-stack baseada em **ASP.NET Core com Razor Pages** e banco de dados **SQL Server**, modelando um sistema de **agência de turismo** com funcionalidades como cadastro de pacotes turísticos, reservas e controle de disponibilidade.


# Objetivo do Projeto

O sistema foi desenvolvido como parte da avaliação final da disciplina, com o propósito de demonstrar domínio sobre:
- ASP.NET Core com Razor Pages
- Entity Framework Core (EF Core)
- Programação orientada a objetos (C#)
- Manipulação de arquivos com System.IO
- Autenticação e autorização manual com Identity
- Utilização de delegates, events e expressões lambda


# Tecnologias e Ferramentas Utilizadas

- **ASP.NET Core 8.0** com Razor Pages
- **Entity Framework Core** para ORM
- **SQL Server** como banco de dados relacional
- **Migrations** para versionamento do esquema
- Relacionamentos um-para-muitos e muitos-para-muitos via EF Core


# Autenticação:
- **Autenticação com Cookies**
- **Middleware de autenticação e autorização**
- Páginas protegidas com `[Authorize]`
- Login manual via formulário

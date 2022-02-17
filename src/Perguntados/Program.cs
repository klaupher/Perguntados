﻿using Core.Entities;
using Perguntados.Controllers;
using Perguntados.Helpers;
using System.Text.Json;

namespace Perguntados
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SelecionarOpcao();
        }

        private static void SelecionarOpcao()
        {
            int escolha = 0;

            do
            {
                escolha = MenuUsuario();

                switch (escolha)
                {
                    case 1:
                        ListaPerguntas();
                        break;

                    case 2:
                        InserirPergunta();
                        break;

                    case 3:
                        DeletarPergunta();
                        break;

                    case 4:
                        Sair();
                        break;

                    default:
                        Console.WriteLine("Opção nao cadastrada no sistema");
                        break;
                }
            } while (escolha != 4);
        }

        private static void Sair()
        {
            Console.WriteLine("Obrigado por ter utilizado a aplicação");
        }

        private static void DeletarPergunta()
        {
            Console.WriteLine("Informe a pergunta que vc deseja escluir");
            Console.Write("Informe o ID: ");

            int idQuestao = Convert.ToInt32(Console.ReadLine());
            GeneralController generalController = new GeneralController();

            generalController.ExcluiPergunta(idQuestao);

            Console.WriteLine("----- Pergunta Excluida com sucesso -----");
        }

        private static void InserirPergunta()
        {
            Console.Clear();

            Console.WriteLine("Informe os dados solicitados");

            int perguntaId = 0;
            bool result = false;

            do
            {
                Console.Write("Numero da Questao: ");
                result = Int32.TryParse(Console.ReadLine(), out perguntaId);

            } while (result == false);

            Console.Write("Descrição da Questao: ");

            string? questao = Console.ReadLine();

            Console.WriteLine("Informe as alternativa da questão");
            int contador = 1;
            string? resp = "S";

            var respostas = new List<Resposta>();

            do
            {
                respostas.Add(InsereRespostas(contador));
                contador++;

                Console.Write("Continua (S/N) ?");
                resp = Console.ReadLine();
            }
            while (!resp.ToUpper().Equals("N"));

            Pergunta pergunta = new(
                id: perguntaId,
                questao: questao,
                respostas: respostas);

            GeneralController generalController = new GeneralController();
            generalController.InserePergunta(pergunta);

            Console.WriteLine("----- Dados gravados com sucesso -----");
        }

        private static Resposta InsereRespostas(int id)
        {
            int perguntaId = id;
            Console.Write($"Resposta {id}: ");
            string? resp = Console.ReadLine();

            Resposta resposta = new Resposta(
                id: perguntaId,
                resp: resp);

            return resposta;
        }

        private static void ListaPerguntas()
        {
            var jsonInput = Helper.GetJSON();
            var perguntas = JsonSerializer.Deserialize<List<Pergunta>>(jsonInput, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                WriteIndented = true
            });

            if (perguntas is not null)
            {
                foreach (var perg in perguntas)
                {
                    Console.WriteLine($"{perg.Id} - {perg.Questao}");
                }
            }

            Console.WriteLine();
        }

        static int MenuUsuario()
        {
            int resp;

            do
            {
                Console.WriteLine("******** SELECIONE UMA OPÇÃO ***********");
                Console.WriteLine();
                Console.WriteLine("1 - Listar todas as perguntas");
                Console.WriteLine("2 - Inserir nova pergunta");
                Console.WriteLine("3 - Excluir uma pergunta");
                Console.WriteLine("4 - Sair");
                Console.Write("Digite sua opção: ");

                if (Int32.TryParse(Console.ReadLine(), out int value))
                {
                    resp = value;
                }
                else
                {
                    Console.WriteLine("Vc não informou um número! Pressione uma tecla para informar um numero novamente.");
                    Console.ReadKey();
                    resp = 5;
                }

                Console.Clear();

            } while ((resp != 1) && (resp != 2) && (resp != 3) && (resp != 4));

            return resp;
        }
    }
}
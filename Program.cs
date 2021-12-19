using System;
using dotNet_DIO;

    namespace program
    {
        class program
        {
            public static void Main(string[] args)
            {
                Aluno[] alunos = new Aluno[5];
                int indiceAluno = 0;
               string opcaoUsuario = obterOpcaoUsuario();

                while (opcaoUsuario.ToUpper() != "X")
                {
                    switch (opcaoUsuario)
                    {
                        case "1":
                        Console.WriteLine("Informe o nome do aluno:");
                        var aluno = new Aluno();
                        aluno.Nome = Console.ReadLine();

                        Console.WriteLine("Informe a nota do Aluno:");

                        if (decimal.TryParse(Console.ReadLine(), out decimal nota))
                        {
                            aluno.Nota = nota;
                        }
                        else
                        {
                            throw new ArgumentException("Valor da nota deve ser decimal.");
                        }
                        alunos[indiceAluno] = aluno;
                        indiceAluno++;
                        

                        break;
                        case "2":
                        foreach (var a in alunos)
                        {
                            if(!string.IsNullOrEmpty(a.Nome))
                            {                           
                            Console.WriteLine($"ALUNO: {a.Nome} - NOTA: {a.Nota}");
                            }
                        }

                        break;
                        case "3":
                        decimal Notatotal = 0;
                        var nrAlunos = 0;

                        for(int i =0; i < alunos.Length; i++)
                        {
                            if(!string.IsNullOrEmpty(alunos[i].Nome))
                            {
                                Notatotal = Notatotal + alunos[i].Nota;
                                nrAlunos++;
                            }
                        }
                        var mediaGeral = Notatotal / nrAlunos;
                        Conceitos conceitoGeral;
                        if(mediaGeral < 2)
                        {
                            conceitoGeral = Conceitos.E;
                        }
                        else if (mediaGeral < 4)
                        {
                           conceitoGeral = Conceitos.D;
                        }
                        else if (mediaGeral < 6)
                        {
                           conceitoGeral = Conceitos.C;
                        }
                        else if (mediaGeral < 8)
                        {
                           conceitoGeral = Conceitos.B;
                        }
                        else
                        {
                            conceitoGeral=Conceitos.A;
                        }


                        Console.WriteLine($"MEDIA GERAL: {mediaGeral} - CONCEITO: {conceitoGeral}");
                        break;
                        
                        default:
                        throw new ArgumentOutOfRangeException();
                    }

                opcaoUsuario = obterOpcaoUsuario();
                }   
            }

            private static string obterOpcaoUsuario()
            {
                Console.WriteLine();
                Console.WriteLine("Informe a opcao desejada:");
                Console.WriteLine("1 - Inserir novo Aluno");
                Console.WriteLine("2 - Listar Alunos");
                Console.WriteLine("3 - Calcular Média Geral");
                Console.WriteLine("X - Sair");
                Console.WriteLine();

                string opcaoUsuario = Console.ReadLine();
                return opcaoUsuario;
            }
        }
    }


Algoritmo "semnome"
// Disciplina   : [Linguagem e Lógica de Programação]
// Professor   : Antonio Carlos Nicolodi
// Descrição   : Aqui você descreve o que o programa faz! (função)
// Autor(a)    : Nome do(a) aluno(a)
// Data atual  : 4/7/2022
Var
// Seção de Declarações das variáveis
   //Declara var
   n1,n2 : inteiro
   media : real

Inicio
// Seção de Comandos, procedimento, funções, operadores, etc...
   //Input
   escreval("Digite a primeira nota:")
     leia(n1)

   escreval("Digite a segunda nota:")
     leia(n2)

   //Process
   media <- (n1 + n2)/2

   //Verificando a nota e imprimindo
   se (media >= 7) entao
      escreval("Aprovado")
   senao
        se(media >=5) entao
          escreval("Recuperação")
        senao
          escreval("Reprovado...")
        fimse
   fimse
Fimalgoritmo
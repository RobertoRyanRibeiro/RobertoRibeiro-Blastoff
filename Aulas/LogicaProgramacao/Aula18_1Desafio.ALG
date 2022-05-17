Algoritmo "semnome"
// Disciplina   : [Linguagem e Lógica de Programação]
// Professor   : Antonio Carlos Nicolodi 
// Descrição   : Aqui você descreve o que o programa faz! (função)
// Autor(a)    : Nome do(a) aluno(a)
// Data atual  : 4/7/2022
Var
// Seção de Declarações das variáveis 
   //Declarando var
   notas : vetor[0..3] de real
   nota,media,somaN : real
   contador : inteiro
   
Inicio
// Seção de Comandos, procedimento, funções, operadores, etc... 
   //Input & Loop
   para contador de 0 ate 3 passo 1 faça
        escreval("digite o",contador+1,"º valor")
          leia(nota)
        notas[contador] <- nota
        somaN <- somaN + notas[contador]
   fimpara
   
   //Process
   media <- somaN/4
   escreval("===========================")

   //Output
   para contador de 0 ate 3 passo 1 faça
        escreval("A",contador+1,"º Nota:",notas[contador])
   fimpara

   escreval("Media: ",media)
   
Fimalgoritmo
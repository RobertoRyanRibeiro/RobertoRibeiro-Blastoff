Algoritmo "semnome"
// Disciplina   : [Linguagem e L�gica de Programa��o]
// Professor   : Antonio Carlos Nicolodi 
// Descri��o   : Aqui voc� descreve o que o programa faz! (fun��o)
// Autor(a)    : Nome do(a) aluno(a)
// Data atual  : 4/7/2022
Var
// Se��o de Declara��es das vari�veis 
   //Declarando var
   notas : vetor[0..3] de real
   nota,media,somaN : real
   contador : inteiro
   
Inicio
// Se��o de Comandos, procedimento, fun��es, operadores, etc... 
   //Input & Loop
   para contador de 0 ate 3 passo 1 fa�a
        escreval("digite o",contador+1,"� valor")
          leia(nota)
        notas[contador] <- nota
        somaN <- somaN + notas[contador]
   fimpara
   
   //Process
   media <- somaN/4
   escreval("===========================")

   //Output
   para contador de 0 ate 3 passo 1 fa�a
        escreval("A",contador+1,"� Nota:",notas[contador])
   fimpara

   escreval("Media: ",media)
   
Fimalgoritmo
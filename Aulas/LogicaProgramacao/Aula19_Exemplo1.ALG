Algoritmo "semnome"
// Disciplina   : [Linguagem e L�gica de Programa��o]
// Professor   : Antonio Carlos Nicolodi 
// Descri��o   : Aqui voc� descreve o que o programa faz! (fun��o)
// Autor(a)    : Nome do(a) aluno(a)
// Data atual  : 4/7/2022
Var
// Se��o de Declara��es das vari�veis 
   //Declarando Var
   x,y,aux : inteiro

Inicio
// Se��o de Comandos, procedimento, fun��es, operadores, etc... 
   //Inciando Var
   x <- 20
   y <- 10

   //Exibindo valores
   escreval("X vale", x)
   escreval("y vale", y)
   
   escreval("Vamos trocar os valores entre x e y")
   
   //Process
   aux <- x
   x <- y
   y <- aux
   
   //Output
   escreval("X vale", x)
   escreval("y vale", y)
Fimalgoritmo
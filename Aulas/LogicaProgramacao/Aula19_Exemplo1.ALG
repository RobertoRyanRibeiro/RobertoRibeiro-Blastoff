Algoritmo "semnome"
// Disciplina   : [Linguagem e Lógica de Programação]
// Professor   : Antonio Carlos Nicolodi 
// Descrição   : Aqui você descreve o que o programa faz! (função)
// Autor(a)    : Nome do(a) aluno(a)
// Data atual  : 4/7/2022
Var
// Seção de Declarações das variáveis 
   //Declarando Var
   x,y,aux : inteiro

Inicio
// Seção de Comandos, procedimento, funções, operadores, etc... 
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
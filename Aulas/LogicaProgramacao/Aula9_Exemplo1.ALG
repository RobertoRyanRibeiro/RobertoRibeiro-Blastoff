Algoritmo "semnome"
// Disciplina   : [Linguagem e L�gica de Programa��o]
// Professor   : Antonio Carlos Nicolodi 
// Descri��o   : Aqui voc� descreve o que o programa faz! (fun��o)
// Autor(a)    : Nome do(a) aluno(a)
// Data atual  : 4/7/2022
Var
// Se��o de Declara��es das vari�veis 
   //Declarando Var
   v,f,res : logico

Inicio
// Se��o de Comandos, procedimento, fun��es, operadores, etc... 

   //Iniciando Var
   v <- Verdadeiro
   f <- Falso

   //Exibindo os valores inicais
   escreval("V:",v)
   escreval("F:",f)

   //Op E
   res <- v e f
     //Exibindo res
     escreval("Resultado de [v e f]:",res)

   //Op ou
   res <- v ou f
     //Exibindo res
     escreval("Resultado de [v ou f]:",res)

   //Op nao e
   res <-  v e nao f
     //Exibindo res
     escreval("Resultado de [v e nao f]:",res)
     
   //Op nao ou
   res <- nao v ou f
     //Exibindo res
     escreva("Resultado de [nao v ou f]:",res)
   
Fimalgoritmo
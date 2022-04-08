Algoritmo "semnome"

Var
   num,cont : inteiro
   continua : caracter
Inicio

continua <- "s"
enquanto (continua = "s") faca
  //Input
  escreval("Digite um numero")
  leia(num)
  //Process
  para cont de 0 ate 10 faca
       escreval(num," *",cont,"=",num*cont)
  fimpara
  //Op
  escreval("Deseja fazer dnv? s / n")
  leia(continua)
fimenquanto

Fimalgoritmo
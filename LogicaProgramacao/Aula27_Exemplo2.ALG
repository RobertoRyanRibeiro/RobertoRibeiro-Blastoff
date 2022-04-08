Algoritmo "semnome"

Var
 //Declarando var
 i,res :inteiro

 funcao cubo (x : inteiro) : inteiro
   var resultado : inteiro
  inicio
   resultado <- x*x*x
   retorne resultado
 fimfuncao

Inicio

para i de 1 ate 10 faca
  res <- cubo(i)
  escreval("O cubo de",i," é",res)
fimpara

Fimalgoritmo
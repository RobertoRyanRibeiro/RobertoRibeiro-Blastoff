Algoritmo "semnome"

Var
 //Declarando Var
valor : inteiro
 //Fatorial
 funcao fibonacci( x : inteiro ) : inteiro
   var
   inicio
       //Process
        se ((x = 0) ou (x = 1)) entao
           retorne x
        senao
           retorne fibonacci(x - 1) + fibonacci(x - 2)
        fimse
 fimfuncao

inicio
//Input
escreva("Digite um valor:")
leia(valor)
escreval("O fibonacci e:",fibonacci(valor))
Fimalgoritmo
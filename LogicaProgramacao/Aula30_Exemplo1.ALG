Algoritmo "semnome"

Var
 //Declarando Var
valor : inteiro
 //Fatorial
 funcao fatorial( x : inteiro ) : inteiro
   var
   inicio
       //Process
        se x <= 1 entao
           retorne 1
        senao
           retorne x * fatorial(x-1)
        fimse
 fimfuncao
 
inicio
//Input
escreva("Digite um valor:")
leia(valor)
escreval("O fatorial e:",fatorial(valor))
Fimalgoritmo
Algoritmo "semnome"

Var
 //Declarando var
 n,res :inteiro
 
 funcao cubo (x : inteiro) : inteiro
   var resultado : inteiro
  inicio
   resultado <- x*x*x
   retorne resultado
 fimfuncao
 
Inicio

escreval("Digite um n�mero para calcular seu cubo")
leia(n)
res <- cubo(n)
escreval("O cubo calculado �:",res)

Fimalgoritmo
Algoritmo "semnome"

Var
//Declaração de var
n : caracter
m : inteiro

procedimento texto(nome : caracter)
inicio
      escreval("Bom dia",nome)
fimprocedimento

Inicio

escreval("Digite o nome")
leia(n)

 se (n = "") ou(n = " ")  entao
       escreval("Digite um nome valido")
 senao
      texto(n)
 fimse

Fimalgoritmo
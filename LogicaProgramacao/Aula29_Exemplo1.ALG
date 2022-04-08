Algoritmo "semnome"

Var
   //Declarando var
   num,num_aleat : inteiro
   resultado : inteiro
   texto : caracter
Inicio

//Input
escreval("Digite um numero:")
leia(num)

//Numeros aleatorios de 1 a 10
escreva("Numero escolhido pelo computador:")
aleatorio 0,10
leia(num_aleat)
aleatorio off
escreval()

//Multiplicando num_aleat com num
resultado <- num * num_aleat

//Output
escreval("O produto dos numeros e",resultado)
escreval()

pausa

//String Aleatoria
escreval("Gerando string de texto aleatoria:")
aleatorio on
leia(texto)
aleatorio off

pausa

//Numeros Aleatorios
escreval("Gerando muitos numeros de forma aleatória:")
pausa
aleatorio on
para num de 1 ate 100 faca
  leia(num_aleat)
fimpara
aleatorio off
Fimalgoritmo
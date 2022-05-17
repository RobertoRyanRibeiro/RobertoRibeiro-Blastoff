Algoritmo "semnome"

Var
   //Declarando Var
   vet : vetor[0..2] de real
   num,numPesq : real
   cont,posicao : inteiro

Inicio

   //Input
   para cont de 0 ate 2 faca
        escreva("Insira o",cont+1,"º valor ")
          leia(num)
        vet[cont] <- num
   fimpara

   //Valor a pesquisar
   escreval("Digite o valor que deseja pesquisar")
     leia(numPesq)
     posicao <- 0

   //Loop incrementando a pos
   enquanto posicao < 2 e (vet[posicao] <> numPesq) faca
            posicao <- posicao + 1
   fimenquanto
   
   //Verificando se achou o numero
   se vet[posicao] = numPesq entao
      escreval("Valor encontrando na posição",posicao+1)
   senao
      escreval("Valor não encontrado")
   fimse
Fimalgoritmo
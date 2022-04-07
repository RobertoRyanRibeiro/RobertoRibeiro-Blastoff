Algoritmo "semnome"

Var
   //Declarando var
   vet : vetor[0..2] de real
   num,aux : real
   corrent,prox,cont : inteiro
   
Inicio

   //Input
   para cont de 0 ate 2 faca
        escreval("Digite o",cont+1,"º valor")
        leia(num)
        vet[cont] <- num
   fimpara

   //Process
   // for(int corrent = 1;corrent <= vet[].Max-1;corrent++)
   para corrent de 0 ate 1 faca
   // for(int prox = corrent+1;prox <= vet[].Max;prox++)
        para prox de corrent+1 ate 2 faca
             se vet[corrent] > vet[prox] entao
                aux <- vet[corrent]
                vet[corrent] <- vet[prox]
                vet[prox] <- aux
             fimse
        fimpara
   fimpara

   //Output
   para cont de 0 ate 2 faca
        escreva(vet[cont]," ")
   fimpara

Fimalgoritmo
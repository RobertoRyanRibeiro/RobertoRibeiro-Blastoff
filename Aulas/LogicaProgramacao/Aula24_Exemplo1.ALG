Algoritmo "semnome"

Var
   //Declaração de Var
   mat : vetor[0..3,0..2] de real
   lin,col : inteiro
   
Inicio

  //Input
  para lin de 0 ate 3 faca
    para col de 0 ate 2 faca
      escreval("Digite o valor")
      leia(mat[lin,col])
    fimpara
  fimpara

  limpatela
  //Output
  para lin de 0 ate 3 faca
    para col de 0 ate 2 faca
      se col >= 2 entao
         escreval(mat[lin,col])
      senao
         escreva(mat[lin,col])
      fimse
    fimpara
  fimpara

Fimalgoritmo
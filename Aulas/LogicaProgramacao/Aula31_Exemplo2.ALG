Algoritmo "semnome"

Var
   //Declarando Var
   quant_num, contador : inteiro
   anterior,atual,prox : inteiro
Inicio
  //Input
  escreval("Digite a quantidade de numeros para somar")
  leia (quant_num)
  
  anterior <- 0
  atual <- 1
  prox <- 1
  
  para contador de 1 ate quant_num faca
        escreval(prox)
        proximo <- atual + anterior
        anterior <- atual
        atual <- proximo
  fimpara
Fimalgoritmo
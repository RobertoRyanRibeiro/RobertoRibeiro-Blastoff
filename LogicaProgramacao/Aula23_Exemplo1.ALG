Algoritmo "semnome"

Var
  //Declarando var
    //Vetor
    vet : vetor[0..20] de real
    //Order
    current,prox : inteiro
    //Num e NumBuscar
    num,numBuscar : real
    //Min e Max
    inicial,final : inteiro
    //Aux
    cont,op,posNum : inteiro
    aux : real
    //Bool achou
    achou : logico
    //Debug
    codNum : real
Inicio

  //Inciando var
  inicial <- 0
  final <- 0
  op <- 0
  cont <- 0
  achou <- Falso

  //Input
  enquanto op <> 1 faca
    escreval("Digite o valor da posição",cont+1)
      leia(num)
    vet[cont] <- num
    final <- final + 1
    cont <- cont + 1
    escreval("Deseja adicionar um novo valor ? 0-s 1-n")
      leia(op)
    limpatela
  fimenquanto
  
  //Ordenando vetor
  para current de inicial ate final - 1 faca
    para prox de current + 1 ate final faca
         se vet[current] > vet[prox] entao
              aux <- vet[prox]
              vet[prox] <- vet[current]
              vet[current] <- aux
         fimse
    fimpara
  fimpara
  
  escreval("=======================================") // Quebrando linha

  //Exibindo o vetor ordenado
  para cont de inicial ate final faca
       escreva(vet[cont], "")
  fimpara
  escreval("")
  escreval("=======================================") // Quebrando linha
  
  //Buscar num
  escreval("Digite o numero que deseja pesquisar")
    leia(numBuscar)

  //Process
  enquanto (inicial <= final) e nao achou faca
      posNum <- (inicial + final) DIV 2
      codNum <- vet[posNum]

      se vet[posNum] = numBuscar entao
        achou <- Verdadeiro
      fimse

      se vet[posNum] > numBuscar entao
        final <- posNum - 1
      senao
        inicial <- posNum + 1
      fimse
  fimenquanto
  
  se achou entao
    escreval("O numero foi achado na posição:",posNum)
  senao
    escreval("O numero não existe na lista")
  fimse
Fimalgoritmo
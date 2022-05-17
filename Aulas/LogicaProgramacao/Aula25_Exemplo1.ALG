Algoritmo "semnome"
Var
   //Declaração de var
   x : literal
   
Inicio

  //Input
  escreva("Digite uma letra:")
    leia(x)
  limpatela

  //Tratamento x n e letra
  enquanto (x = " ") ou (x = "") faca

    //Verificando se o valor está vazio ou espaço
    se (x = " ") ou (x = "") entao
      escreval("Error: O campo esta vazio...Aperte qualquer tecla para continuar")
    fimse

    //Digitando o Valor Novamente
    escreva("Digite uma letra")
      leia(x)
    limpatela
  fimenquanto

  escolha x
         caso "a"
              escreval("Voce digito a")
         caso "b"
              escreval("Voce digito b")
         caso "c"
              escreval("Voce digito c")
         outrocaso
              escreval("Não exite tal letra")
  fimescolha

Fimalgoritmo
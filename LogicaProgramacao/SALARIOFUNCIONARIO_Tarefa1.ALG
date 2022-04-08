Algoritmo "SalarioFuncionario"
//Uma Empresa de desenvolvimento de softwares paga a seu vendedor um fixo
//de R$ 500,00 por mês, mais um bônus de R$ 50,00 por sistema vendido.
//Faça um programa que leia quantos softwares o funcionário vendeu
//e determine o salário total do funcionário.
//Mostre o salário final do vendedor.
   
//Verificando para inteiro e tratamento
funcao isInt(variable : caracter) : logico
   var
  //Declarando Var
  //Retorno
  result : logico
  //Variavel que armazena o cod Ascii da string
  varAscii : inteiro
  //Debug var para ver a copia
  dbgVar : caracter
  dbgSingleVar : caracter
  //Tamanho max da string
  length : inteiro
  //Verificador se a string é numerica
  isNumeric : logico
  //Contador
  c : inteiro
  inicio
    //Iniciando var
    length <- compr(variable)
    isNumeric <- Falso

    //Verificando se o valor não está nulo
    escolha variable
      caso ""
        escreval("É obrigatorio digitar um valor")
        variable <- variable + " "

    //Verificando se o valor é um espaço vazio
      caso " "
        escreval("O valor está vazio")
      outrocaso

    //Transformando string em cod Ascii
      varAscii <- asc(variable)
      dbgVar <- copia(variable,c+1,1)
    //Verificando todos os valores na string
      para c de 1 ate length faca
        //Verificando se o caracter é uma letra
        se (varAscii >= 48) e (varAscii <= 57) entao
          //Passando para prox var
          se c < length entao
            dbgVar <- copia(variable,c+1,1)
            varAscii <- asc(copia(variable,c+1,1))
          fimse
          //Se todos os valores forem revisados então a string é numerica
          se c = length entao
            isNumeric <- Verdadeiro
          fimse
        senao
          interrompa
        fimse
      fimpara //Fim para
      
    //Verificando se a string é numerica
      se (isNumeric) entao
        result <- isNumeric
    //Se não for
      senao
        result <- Falso
        escreval("O valor digitado precisa ser numerico")
      fimse

    fimescolha //Fim Switch

    //Return
    retorne result
fimfuncao //Fim isInt

//Verificando para float e tratamento
funcao isFloat(variable : caracter) : logico
   var
  //Declarando Var
  //Retorno
  result : logico
  //Variavel que armazena o cod Ascii da string
  varAscii : inteiro
  //Debug var para ver a copia
  dbgVar : caracter
  dbgSingleVar : caracter
  //Tamanho max da string
  length : inteiro
  //Verificador se a string é numerica
  isNumeric : logico
  //Contador
  c : inteiro
  inicio
    //Iniciando var
    length <- compr(variable)
    isNumeric <- Falso

    //Verificando se o valor não está nulo
    escolha variable
      caso ""
        escreval("É obrigatorio digitar um valor")
        variable <- variable + " "

    //Verificando se o valor é um espaço vazio
      caso " "
        escreval("O valor está vazio")
      outrocaso

    //Transformando string em cod Ascii
      varAscii <- asc(variable)
      dbgVar <- copia(variable,c+1,1)
    //Verificando todos os valores na string
      para c de 1 ate length faca
        //Verificando se o caracter é uma letra
        se (varAscii >= 48) e (varAscii <= 57) ou (varAscii = 46) entao
          //Passando para prox var
          se c < length entao
            dbgVar <- copia(variable,c+1,1)
            varAscii <- asc(copia(variable,c+1,1))
          fimse
          //Se todos os valores forem revisados então a string é numerica
          se c = length entao
            isNumeric <- Verdadeiro
          fimse
        senao
          interrompa
        fimse
      fimpara //Fim para

    //Verificando se a string é numerica
      se (isNumeric) entao
        result <- isNumeric
    //Se não for
      senao
        result <-  Falso
        escreval("O valor digitado precisa ser numerico")
      fimse

    fimescolha //Fim Switch

    //Return
    retorne result
fimfuncao //Fim isFloat


//Total de Salario do Funcionario
funcao salTotal(salFunc : real ; bonus : real ; quantVend : inteiro) : real
  var
  //Total
  result : real
  inicio
  //Process
  result <- salFunc + (bonus * quantVend)
  //Return
  retorne result
fimfuncao //Fim salTotal

//Main
Var
 //Declarando var
 //Salario
 slFc : caracter
 salFunc : real
 //Bonus
 bon : caracter
 bonus : real
 //Quantidade de Vendas
 qtVend : caracter
 quantVend : inteiro
 //Auxiliar opção
 op : caracter
Inicio
repita
     //Tratando
     repita
        escreval("======================================")
        //Configurando
        escreva("Insira o Salario fixo:")
        leia(slFc)
        escreva("Insira o valor do bonus por venda:")
        leia(bon)
        limpatela //Limpando a tela
     ate (isFloat(slFc)) e (isFloat(bon))
     //Atualizando var
     salFunc <- caracpnum(slFc)
     bonus <- caracpnum(bon)
     //Exibir Valores
     escreval("")
     escreval("======================================")
     escreval("Salario Fixo:R$",salFunc)
     escreval("Bonus p/Venda:R$",bonus)
     escreval("======================================")
     //Input
     repita
     escreva("Insira a quantidade de vendas desse mes:")
     leia(qtVend)
     ate (isInt(qtVend))
     //Atualizando var
     quantVend <- caracpnum(qtVend)
     escreval("")
     escreval("======================================")
     escreval("O Total:R$",salTotal(salFunc,bonus,quantVend))
     
     //Verificando o Loop
     escreval("")
     escreval("")
     escreval("======================================")
     escreval("Deseja refazer ? s/n")
     leia(op)
     limpatela //limpatela
     //Tratando op
     repita
       se (op <> "s") e (op <> "n") entao
         escreval("Op invalida")
         escreval("======================================")
         escreval("Deseja refazer ? s/n")
         leia(op)
         limpatela
      fimse
     ate (op = "s") ou (op = "n") //fim repita
     
ate (op <> "s")
Fimalgoritmo
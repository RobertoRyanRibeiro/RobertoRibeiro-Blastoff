Algoritmo "Cheque"
//Fazer uma p�gina que leia o saldo inicial de cliente do banco e leia tamb�m um
//cheque que entrou, ANALISE se o cheque poder� ser descontado ou n�o, j� que
//este cliente n�o possui limite. Se o cheque n�o for descontado, mostre essa
//informa��o, caso contr�rio, desconte o cheque e informe o saldo ATUAL na tela.

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
  //Verificador se a string � numerica
  isNumeric : logico
  //Contador
  c : inteiro
  inicio
    //Iniciando var
    length <- compr(variable)
    isNumeric <- Falso

    //Verificando se o valor n�o est� nulo
    escolha variable
      caso ""
        escreval("� obrigatorio digitar um valor")
        variable <- variable + " "

    //Verificando se o valor � um espa�o vazio
      caso " "
        escreval("O valor est� vazio")
      outrocaso

    //Transformando string em cod Ascii
      varAscii <- asc(variable)
      dbgVar <- copia(variable,c+1,1)
    //Verificando todos os valores na string
      para c de 1 ate length faca
        //Verificando se o caracter � uma letra
        se (varAscii >= 48) e (varAscii <= 57) entao
          //Passando para prox var
          se c < length entao
            dbgVar <- copia(variable,c+1,1)
            varAscii <- asc(copia(variable,c+1,1))
          fimse
          //Se todos os valores forem revisados ent�o a string � numerica
          se c = length entao
            isNumeric <- Verdadeiro
          fimse
        senao
          interrompa
        fimse
      fimpara //Fim para

    //Verificando se a string � numerica
      se (isNumeric) entao
        result <- isNumeric
    //Se n�o for
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
  //Verificador se a string � numerica
  isNumeric : logico
  //Contador
  c : inteiro
  inicio
    //Iniciando var
    length <- compr(variable)
    isNumeric <- Falso

    //Verificando se o valor n�o est� nulo
    escolha variable
      caso ""
        escreval("� obrigatorio digitar um valor")
        variable <- variable + " "

    //Verificando se o valor � um espa�o vazio
      caso " "
        escreval("O valor est� vazio")
      outrocaso

    //Transformando string em cod Ascii
      varAscii <- asc(variable)
      dbgVar <- copia(variable,c+1,1)
    //Verificando todos os valores na string
      para c de 1 ate length faca
        //Verificando se o caracter � uma letra
        se (varAscii >= 48) e (varAscii <= 57) ou (varAscii = 46) entao
          //Passando para prox var
          se c < length entao
            dbgVar <- copia(variable,c+1,1)
            varAscii <- asc(copia(variable,c+1,1))
          fimse
          //Se todos os valores forem revisados ent�o a string � numerica
          se c = length entao
            isNumeric <- Verdadeiro
          fimse
        senao
          interrompa
        fimse
      fimpara //Fim para

    //Verificando se a string � numerica
      se (isNumeric) entao
        result <- isNumeric
    //Se n�o for
      senao
        result <-  Falso
        escreval("O dado digitado precisa ser um valor numerico positivo")
      fimse

    fimescolha //Fim Switch

    //Return
    retorne result
fimfuncao //Fim isFloat


//Total de Cheque
funcao cheque(contaCli : real ; ChequeValor : real ; contaEmi : real) : real
  var
  //Total
  result : real
  inicio
  //Process
  se ChequeValor = 0 entao
     escreval("Cheque invalido, � necessario inserir um valor")
     result <- contaCli
  senao
     se ChequeValor > contaEmi entao
       escreval("Cheque invalido porque o emissor n�o possui tal valor")
       result <- contaCli
     senao
       result <- contaCli + ChequeValor
     fimse
  fimse
  //Return
  retorne result
fimfuncao //Fim cheque

//Main
Var
 //Declarando var
 //Conta Cliente
 ctcli : caracter
 contaCli : real
 //Cheque
 chq : caracter
 ChequeValor : real
 //Conta Emissor
 ctemi : caracter
 contaEmi : inteiro
 //Auxiliar op��o
 op : caracter
Inicio
repita
     //Tratando
     repita
        escreval("======================================")
        //Configurando
        escreva("Insira o valor da conta Emissora fixo:")
        leia(ctemi)
        escreva("Insira o valor do cheque :")
        leia(chq)
        limpatela //Limpando a tela
     ate (isFloat(chq)) e (isFloat(ctemi))
     //Atualizando var
     contaEmi <- caracpnum(ctemi)
     ChequeValor <- caracpnum(chq)
     //Input
     repita
     //Exibir Valores
     escreval("")
     escreval("======================================")
     escreval("Conta Emissor:R$",contaEmi)
     escreval("Cheque:R$",ChequeValor)
     escreval("======================================")
     escreva("Insira o valor da conta do cliente:")
     leia(ctcli)
     limpatela
     ate (isInt(ctcli))
     //Atualizando var
     contaCli <- caracpnum(ctcli)
     escreval("")
     escreval("======================================")
     escreval("Valor da conta Atual:R$",cheque(contaCli,ChequeValor,contaEmi))

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
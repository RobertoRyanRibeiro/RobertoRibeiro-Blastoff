Algoritmo "Financiamento"
//Fa�a uma p�gina que receba o valor do sal�rio de uma pessoa e o valor de um
//financiamento pretendido. Caso o financiamento seja menor ou igual a 5 vezes o
//sal�rio da pessoa, a p�gina dever� escrever "Financiamento Concedido"; sen�o,
//escrever� "Financiamento Negado". Independente de conceder ou n�o o
//financiamento, a p�gina escrever� depois a frase "Obrigado por nos consultar."

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


//Financiamento
procedimento financiamento(sal : real ; financ : real)
  var
  inicio
  //Process
     se ((sal * 5) >= financ) entao
        escreval("Financiamento Concedido")
     senao
        escreval("Financiamento Negado")
     escreval("")
     fimse
     escreval("Obrigado por nos consultar")
     
fimprocedimento //Fim financiamento

//Main
Var
 //Declarando var
 //Salario
 sl : caracter
 salario : real
 //financiamento
 finac : caracter
 financiar : real
 //Auxiliar op��o
 op : caracter
Inicio
repita
     //Tratando
     repita
        escreval("======================================")
        //Configurando
        escreva("Insira o Salario :")
        leia(sl)
        escreva("Insira o valor do Financiamento:")
        leia(finac)
        limpatela //Limpando a tela
     ate (isFloat(sl)) e (isFloat(finac))
     //Atualizando var
     salario <- caracpnum(sl)
     financiar <- caracpnum(finac)
     
     //Exibir Valores
     escreval("")
     escreval("======================================")
     escreval("Salario:R$",salario)
     escreval("Financiamento:R$",financiar)
     escreval("======================================")

     //Process
     financiamento(salario,financiar)

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
     ate (op <> "s") ou (op <> "n") //fim repita

ate (op <> "s")
Fimalgoritmo
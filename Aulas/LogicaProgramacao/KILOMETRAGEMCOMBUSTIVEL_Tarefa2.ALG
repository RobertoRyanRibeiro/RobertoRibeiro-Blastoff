Algoritmo "KilometragemCombustivel"
//Realizarei uma viagem de v�rios dias em meu autom�vel, e gostaria de saber a
//quilometragem m�dia por litro de gasolina.Para isto, anotarei a quilometragem
//no veloc�metro ao sair de viagem, e depois ao chegar;amb�m vou somar toda a
//gasolina que comprar para o carro. Fa�a uma p�gina que com estes dados mostre
//quantos km fiz,em m�dia, por litro de gasolina.

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


//kmPLitro
funcao kmPLitro(kmInicial : real ;kmFinal : real ; lit : real ) : real
  var
  //Total
  result : real
  inicio
  //Process
  result <- (kmFinal - kmInicial)/lit
  //Return
  retorne result
fimfuncao //Fim kmPLitro

//Main
Var
 //Declarando var
 //Salario
 kmIn : caracter
 kmInicial : real
 //Bonus
 kmFl : caracter
 kmFinal : real
 //Quantidade de Vendas
 lit : caracter
 litros : real
 //Auxiliar op��o
 op : caracter
Inicio
repita
     //Tratando
     repita
        escreval("======================================")
        //Configurando
        escreva("Insira a kilometragem inicial:")
        leia(kmIn)
        escreva("Insira a kilometragem final:")
        leia(kmFl)
        limpatela //Limpando a tela
     ate (isFloat(kmIn)) e (isFloat(kmFl))
     //Atualizando var
     kmInicial <- caracpnum(kmIn)
     kmFinal <- caracpnum(kmFl)
     //Input
     repita
     //Exibir Valores
     escreval("")
     escreval("======================================")
     escreval("Kilometragem Inicial:",kmInicial,"Km")
     escreval("Kilometragem Final:",kmFinal,"Km")
     escreval("======================================")
     escreva("Insira a quantidade de combustivel que foi colocada:")
     leia(lit)
     limpatela
     ate (isInt(lit))
     //Atualizando var
     litros <- caracpnum(lit)
     escreval("")
     escreval("======================================")
     escreval("Kilometragem p/Litro:R$",kmPLitro(kmInicial,kmFinal,litros),"Km/L")

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
Algoritmo "semnome"

Var
   //Declarando Var
   valor : caracter
   convertida : caracter
   comprimento : inteiro
   data,dia,mes,ano : caracter
   palavra,sequencia : caracter
   posicao : inteiro
   numeroConvertido: caracter
   numero : inteiro
Inicio
   //Input
   escreval("Digite um nome:")
   leia(valor)
   escreval("Digite uma data no formato dd/mm/aaaa:")
   leia(data)
   escreval("Digite uma palavra:")
   leia(palavra)
   escreval("Digite um letra ou uma sequencia de caracter:")
   leia(sequencia)
   escreval("Digite um número:")
   leia(numero)
   //Process
   dia <- copia(data;1;2)
   mes <- copia(data;4;2)
   ano <- copia(data;7;4)
   convertida <- maiusc(valor)
   comprimento <- compr(valor)
   posicao <- Pos(sequencia,palavra)
   numeroConvertido <- NumpCarac(numero)
   //Output
   escreval("Palavra Convertida para maiusculo:",convertida)
   escreval("Comprimento da Palavra:",comprimento)
   escreval("Dia:",dia)
   escreval("Mes:",mes)
   escreval("Ano:",ano)
   escreval("Data:",dia,"/",mes,"/",ano)
   escreval("O caracter foi encontrado na posição:",posicao)
   escreval("O numero convertido para caracter e:",numeroConvertido)
Fimalgoritmo
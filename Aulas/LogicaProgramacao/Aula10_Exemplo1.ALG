Algoritmo "semnome"
// Disciplina   : [Linguagem e L�gica de Programa��o]
// Professor   : Antonio Carlos Nicolodi 
// Descri��o   : Aqui voc� descreve o que o programa faz! (fun��o)
// Autor(a)    : Nome do(a) aluno(a)
// Data atual  : 4/7/2022
Var
// Se��o de Declara��es das vari�veis 
   //Declara��o de var
   n1,n2 : inteiro
   media : real
Inicio
// Se��o de Comandos, procedimento, fun��es, operadores, etc... 
   //Input
   escreval("Digite o 1� valor")
    leia(n1)

   escreval("DIgite o 2� valor")
    leia(n2)
    
   //Process
   media<- (n1+n2) / 2
   
   //Verificando a media
   se (media >= 7) entao
      escreval("Aluno aprovado")
   fimse

   escreval("Media:",media)

Fimalgoritmo
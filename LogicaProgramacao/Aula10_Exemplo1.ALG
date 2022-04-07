Algoritmo "semnome"
// Disciplina   : [Linguagem e Lógica de Programação]
// Professor   : Antonio Carlos Nicolodi 
// Descrição   : Aqui você descreve o que o programa faz! (função)
// Autor(a)    : Nome do(a) aluno(a)
// Data atual  : 4/7/2022
Var
// Seção de Declarações das variáveis 
   //Declaração de var
   n1,n2 : inteiro
   media : real
Inicio
// Seção de Comandos, procedimento, funções, operadores, etc... 
   //Input
   escreval("Digite o 1º valor")
    leia(n1)

   escreval("DIgite o 2º valor")
    leia(n2)
    
   //Process
   media<- (n1+n2) / 2
   
   //Verificando a media
   se (media >= 7) entao
      escreval("Aluno aprovado")
   fimse

   escreval("Media:",media)

Fimalgoritmo
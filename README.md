# SqTec

### Abaixo algumas informações importantes a respeito da solução a ser desenvolvida:

1.Aplicação:
* Ler um arquivo txt com os dados dos clientes do ERP e salvar essas informações em um arquivo json.
* Qualquer erro ocorrido na aplicação deverá ser logado em um arquivo txt.
* O arquivo txt que contém os dados dos clientes a serem importados, o arquivo txt que conterá o log e o arquivo json que conterá os dados da aplicação devem ter seus caminhos lidos no arquivo de configuração (App.config).
* Todos os campos do cliente são obrigatórios. Se uma linha do arquivo txt com os dados de um cliente estiver inválida, uma exceção do tipo "LinhaInvalidaException" (Tipo presente em SqTec.Spec) deve ser logada e a leitura do arquivo txt deve continuar normalmente.
* Os dados dos clientes devem ser exibidos ordenados pelo nome do cliente.
* Os dados sumarizados por região devem ser exibidos ordenados pela região.
* Não se preocupe com concorrência de execuções, apenas uma instância do sistema irá rodar por vez.
* Durante uma transação na aplicação, se ocorrer qualquer exceção a transação deverá ser encerrada imediatamente e os dados nela contidos deverão ser descartados.

2.Cálculo das medalhas de bronze, prata e ouro:
* De acordo a pontuação do cliente, ele terá medalhas de bronze, prata e ouro.
* A cada 10.000 pontos, conta-se uma medalha de ouro
* A cada 1.000 pontos, conta-se uma medalha de prata
* A cada 100 pontos, conta-se uma medalha de bronze
* EX: 35.734 pontos = 3 medalhas de ouro, 5 de prata e 7 de bronze

3.Cálculo do desconto:
* Fórmula: Cn,p+(2*x)
  * C = Combinação
  * n = Total de medalhas de ouro do cliente
  * p = Parte inteira da metade das medalhas de ouro do cliente
  * x = Idade do cliente
* Exemplo de um cliente com 9 medalhas de ouro e 20 anos de idade:
  * Medalhas de ouro = 9
  * Medalhas de ouro / 2 = 4,5 (Parte inteira = 4)
  * Idade = 20
  * Fórmula: C9,4 + (2*20) 
  * C9,4 = 126
  * 2*20 = 40
  * 126 + 40 = 166 (centavos)
  * Desconto final = R$1,66
* **Importante: O desconto máximo é de R$30,00. Se o cálculo retornar um valor maior, o valor de R$30,00 deve ser considerado.**

4.Avaliação:
* Você será avaliado pela implementação correta dessas interfaces e também pela estrutura final da sua solução. Fique à vontade para incluir demais projetos que julgar necessário para solucionar o problema.

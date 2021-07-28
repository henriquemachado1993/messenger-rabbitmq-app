# mensageriaApp

Projeto de estudo de mensageria utilizando RabbitMQ

Sobre os projetos
- Tipo: Console Application
- Framework: .net core 3.1

Bibliotecas utilizadas
- RabbitMQ.Client
- Newtonsoft.Json

Como funciona?
- Pressupondo que você já tenha o RabbitMq instalado na sua máquina local. Caso não tenha sugiro acessar o site oficial e realizar o tutorial de instalação. [RabbitMQ Download](https://www.rabbitmq.com/download.html)
- Basta rodar os dois projetos ao mesmo tempo, Produtor e Consumidor. Você verá o funcionamento do produtor criando a fila e as mensagens e em seguida o consumidor resgatando e exibindo a mensagem criada pelo produtor.

## credencias gmail

Para utilização do smtp do gmail, sem necessidade de utilizar a api do Gmail (google cloud).

Senhas de app permitem que você faça login na sua Conta do Google a partir de apps em dispositivos que não sejam compatíveis com a verificação em duas etapas.
- [apppasswords](https://myaccount.google.com/apppasswords)

selecionar app: E-mail


selecionar dispositivo: 'outro.nome'

## static class SecretsValues
É uma classe estática da aplicação que utiliza informações confidenciais.
 - No ambiente de desenvolvimento as informações dessa classe é gerenciada em 'Manage User Secrets'.
 - Em produção seus valores são oriundos de 'Settings/Configuration/Application settings' no padrão key:value

Exemplo Local (secrets.json):
```
    "ConnectionStrings": {
        "DefaultConnection": "string-db-connection"
  }
```

Exemplo Azure (secrets.json): 
    
```
    name: ConnectionStrings__DefaultConnection
    value: string-db-connection
```

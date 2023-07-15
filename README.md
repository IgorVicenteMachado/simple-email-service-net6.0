### Para gerar credencias Gmail (user e password)
https://myaccount.google.com/apppasswords

### Secrets Values
É uma classe estática que utiliza informações confidenciais.
 - No ambiente de desenvolvimento as informações dessa classe é gerenciada em 'Manage User Secrets'.
 - Em produção seus valores são oriundos de 'Settings/Configuration/Application settings' no padrão key:value

    Exemplo Local (secrets.json):
```Git
    "ConnectionStrings": {
        "DefaultConnection": "string-db-connection"
  }
```
    Exemplo Azure: 
```Git
    name: ConnectionStrings__DefaultConnection
    value: string-db-connection
```
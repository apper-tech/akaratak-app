nswag run
echo 'Applying Json Result'

(Get-Content ..\app\shared\services\service.base.ts).replace('this.jsonParseReviver);', 'this.jsonParseReviver).result;') | Set-Content ..\app\shared\services\service.base.ts
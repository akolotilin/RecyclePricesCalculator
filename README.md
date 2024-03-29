# RecyclePricesCalculator

```
VmsInform.Common = Infrastructure (В более поздних версиях переехал в отдельный репозиторий, подключаемый как сабмодуль под именем [Core.Backend])
VmsInform.Business = Application
VmsInform.DAL = Infrastructure.Database (в более поздних версиях было разделено на [Core.Backend.DAL] - общие сервисы и [Backend.{ServiceName}.Domain] - доменная модель конкретного сервиса)
VmsInform.DbMigration - отдельный проект для хранения миграций БД
VmsInform.Web.Dto - модели данных WebApi
VmsInformWeb - Приложение WebApi
```

# Основные изменения, сделанные в более поздних проектах, основанных на данной архитектуре:

1) Добавился модуль Core.Backend.Web, содержащий типовой "скелет" сервиса, включая базовые контроллеры (HelthCheck и т.п.). Основной фукнционал модуля: а) обеспечение централизованного контроля прав доступа с использованием стандартных средвств asp.net core на стороне сервиса и собственного сервиса PermissionService в качестве бекэнда для всех сервисов. b) мониторинг действия пользователя. с) обеспечение единообразной инициализации инфраструктуры сервиса: сваггер, авторизация, логирование и т.п.
   Пример инициализации минимально функционального сервиса, интегрированного в общую эксосистему (Program.cs в net6):

```C#
    await new WebApp()
       .AddDI<WebAppModule()
       .RunAsync(args);
```

   Пример инициализации сервиса с кастомизацией поведения:
```C#
     await new WebApp()
       .AddDI<WebAppModule>()
       .NoSwagger()
       .NoAudit()
       .RunAsync(args);
```
   Пример кастомизированной инициализации сервиса:

```C#
   await new WebApp()
       .OnInit(builder => builder.SomeCustomCall())
       .OnAfterInit(app => app.SomeCustomCall())
       .RunAsync(args);
```

2) В данной версии используются Generic-репозитории, которые предоставляют прямой доступ к IQueriable на уровне бизнес-логики, что не вполне корректно. В более поздней версии от этого отказались и перешли на спецификации
     Пример было:
   ```C#
       var data = await _repository.Query()
         .Where(a => a.ClientId == clientId && a.IsConfirmed)
         .ToListAsync(cancellationToken);
   ```

   Пример стало:
   ```C#
     var data = await _repository.Query() // Тут вместо IQueriable<T> возвращается IQueryContext<T>, который напрямую доступа к IQueriable не дает
       .ByClient(clientId)
       .OnlyPayed()
       .ToListAsync(cancellationToken);
   ```
   При этом спецификация в виде экстеншн-метода находится в DAL-модуле сервиса и выглядит так

```C#
   public statiс IQueryContext<SomeEntity> ByClient(this IQueryContext<SomeEntity> context, long clientId)
   {
       return context.DoSpec(q => q.Where(a => a.ClientId = clientId)); // Экстеншн-метод, доступный только в этой сборке
   }
```


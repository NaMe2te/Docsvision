# Тестовое задание
Pазработать прототип системы для регистрации входящих писем, адресованных сотрудникам компании.
Каждое письмо имеет следующие атрибуты:
- Название
- Дата
- Адресат (сотрудник компании)
- Отправитель (сотрудник компании)
- Содержание
## Компоненты системы, которые используются в проекте:
- База данных на MS SQL Server
- Веб-сервис (на ASP.NET Core) на C# для работы с базой
- Клиентское приложение для ввода писем на С# WPF
- Была добавлена простая Аутентификация для возможности входа в аккаунт

Небольшая дока перед запуском:
1) Поменять ссылку на подключение к БД
![image](https://github.com/NaMe2te/Docsvision/assets/107889193/edf4c18d-35fd-46ae-868f-0277b67268fb)
2) Вставить нужную url в Client/App.config для связи с сервером
![image](https://github.com/NaMe2te/Docsvision/assets/107889193/70a0b93f-2d25-4816-94b1-0db1f6ac6c67)
3) При запуске приложения создается 3 аккаунта со следующими данными для входа
   - email: root@mail.ru пароль: root
   - email: string@mail.ru пароль: string
   - email: prik@mail.ru пароль: prik
  Можно использовать однин из этих аккаунтов или зарегистрировать новый
4) Написание сообщения происходит двумя способами:
   1) Перейти на страницу Сообщения и нажать там на кнопку "Написать новое сообщения"
      ![image](https://github.com/NaMe2te/Docsvision/assets/107889193/0dc58276-8e60-4801-a8d9-d6d33b5235b8)
   3) Перейти во вкладку пользователи и два раза кликнуть на работника, которому нужно написать сообщение, левой кнопкой мыши.
      ![image](https://github.com/NaMe2te/Docsvision/assets/107889193/0e2d063c-c028-4dfc-8042-a2ff5f6901fa)


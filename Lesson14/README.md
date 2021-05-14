ДЗ к уроку 14. Нарисовать бизнес процесс с помощью BPMN.

1. Тема: "Разработка программного эмулятора контроллеров системы контроля и управления доступом".

2. Описание предметной области.
2.1.Элементы системы.
2.1.1. Контроллер. Аппаратное устройство со своей памятью и настройками. Обрабатывает внешние события (проходы через контролируемую точку доступа,
тревожные события и т.д.) и записывает эти события во внутреннюю память. Также обрабатывает команды, полученные от управляющего ПО.
Контроллеры физически подключаются по интерфейсу RS-485. Для подключения к ПК необходимо использовать преобразователь интерфейса.
2.1.2. Преобразователь интерфейса. Необходим для подключения контроллеров к ПК. Может быть вариант USB/RS485 и Ethernet/RS485.
Для Ethernet преобразователя возможна работа в режиме TCP-сервера и в режиме TCP-клиента.
2.1.3. Управляющее ПО. Выполняет функции конфигурации контроллеров (записи в них необходимой информации), выдачи контроллерам команд и оперативного
мониторинга событий контроллера. Подключение к контроллерам постоянное. Проторол работы с контроллерами подразумевает, что инициатором обмена
может быть только ПО, поэтому оно осуществляет постоянный опрос всех подключенных контроллеров.
2.2. Задача разработки.
Для тестирования стабильности работы управляющего ПО в условиях высокой нагрузки (большое количество преобразователей и контроллеров, 
а также высокая интенсивность возникновения событий) необходимо реализовать программный эмулятор контроллеров (и преобразователей).

3. Описание диаграммы.
На диаграмме представлен примерный алгоритм работы эмулятора одного преобразователя интерфейса и подключенных к нему контроллеров.
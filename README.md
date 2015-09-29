# network-lab1

## Вариант № 2

### 1. Описание задачи
Необходимо разработать клиентскую и серверную части приложения для обмена файлами между различными узлами сети с использованием блокирующих сокетов, протокола TCP.

### 2. Требования к реализации
*	(Сделано) Приложение должно выполнять как функции передачи файла, так и функции приема.
*	(Сделано) Графический интерфейс
*	(-) Ввод IP-адреса принимающего/передающего узла
*	(-) Ввод номера порта принимающего/передающего экземпляра приложения
*	Выбор передаваемого файла на диске
*	(-) Выбор места сохранения полученного файла
*	(-) Отображать прогресс передачи/приема файла
*	(-) Считать и отображать время передачи файла.
*	(?) Отображать сообщения о возникающих ошибках и корректно их обрабатывать.
*	(?) Приложение должно уметь обнаруживать и корректно обрабатывать не только любое завершение клиентской/серверной частей приложения, но и разрывы физического соединения абонентов.

### 3. Требования к надежности
К приложению предъявляются следующие требования по надежности:
-	(?) Не допускается зависание приложения при любых действиях пользователя.
-	(?) Не допускается аварийное завершение приложения при любых действиях пользователя.
-	(?) Любая ошибочная ситуация должна корректно обрабатываться с выводом соответствующего сообщения.
-	(?) Не допускается утечка памяти/дескрипторов в процессе эксплуатации приложения.
-	(?) Не допускается полная загрузка процессора приложением в пассивном состоянии.
-	(?) Графический интерфейс не должен зависать во время передачи/приема файлов, а также во время ожидания подключения клиента к серверу (многопоточное приложение).

### 4. Дополнительные требования
(Забить на это) Реализовать параллельную передачу/прием нескольких файлов.

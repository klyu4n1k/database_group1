# Тестування працездатності системи

## Засоби тестування
Тестування CRUD застосунку здійснюється за допомогою онлайн інструменту Postman. Перед тестуванням запитів на локальному сервері необхідно встановити Postman Agent.

### Отримання інформації по всім User-ам

<img src="./media/Users_1.jpg">

<img src="./media/Users_2.jpg">

### Отримання інформації по id User-а

<img src="./media/User_id.jpg">

### Створення нового юзера

<img src="./media/User_create.jpg">

### Вміст таблиці 'User' у базі 'quiz' даних після видалення юзеру

<img src="./media/User_create_sql.jpg">

### Помилка створення юзера по причині: "Пошта вже існує"

<img src="./media/User_email.jpg">

### Помилка створення юзера по причині: "Такий нікнейм вже існує"

<img src="./media/User_nickname.jpg">

### Видалення юзеру

<img src="./media/User_delete.jpg">

### Помилка видалення юзеру по причині: "Такого юзеру не знайдено"

<img src="./media/User_delete_not_found.jpg">

### Вміст таблиці 'User' у базі 'quiz' даних після видалення юзеру

<img src="./media/User_delete_sql.jpg">

### Оновлення юзеру

<img src="./media/User_update.jpg">

### Вміст таблиці 'User' у базі 'quiz'  даних після виконання усіх операцій

<img src="./media/Users_sql.jpg">
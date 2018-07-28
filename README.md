# Academy-2018-UWP



Для написанного ранее API (Аэропорт) написать простой клиент, используя десктопную технологию UWP. Если кратко, то должен быть реализован весь функционал из предыдущего задания по Angular. Архитектура приложения мало чем отличается от клиента на Angular. Есть слой представления данных (Views), слой бизнес логики (Code behind (когда вы пишете обработчики событий в файлах .xaml.cs) или реализация MVVМ), и слой работы с сервером (Services). Для работы с сервером используйте уже знакомый HttpClient. Все действия пользователя должны быть асинхронными (используйте async/await).

Что должно быть выполнено:

Сделать меню, которое позволяет перемещаться между коллекциями.
При переходе на пункт меню, приложение должно загружать коллекцию с сервера.
Для каждой коллекции написать страницу для вывода списка элементов с базовой информацией (информация зависит от конкретной коллекции, но необходимо разместить 1-2 основных поля в строке списка).
При нажатии на элемент списка, справа должен появится блок с детальной информацией об элементе списка.
В блоке с детальной информацией добавить возможность редактировать и удалять элементы.
Желательно попробовать responsive UI в UWP (если уменьшаем или увеличиваем размеры окна, элементы перестраиваются).
Если будет время и желание, то будет большим плюсом использование MVVM. ВАЖНО! Сначала напишите простой вариант (View - .xaml, и ее обработчики - .xaml.cs) для одной коллекции. Оцените свои силы, если получается легко - попробуйте добавить MVVM Light. Если не получается, не тратьте время, самое главное (будет достаточно для получения 10) - реализовать функционал любым способом.

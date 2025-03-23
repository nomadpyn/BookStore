# BookStore (Design Patterns)

Данный репозиторий содержит приложение для инвентаризации книг в книжном магазине.

В нем будет реализована демонстрация паттернов проектирование, таких как MVP (Minimal Viable Product) и SOLID.

1) На первом этапе реализовано консольное приложение с возможностью добавлять книги, изменять их количество.

    Для комманд выполнения реализован паттерн "Абстрактая фабрика".
    S - класс вывода интерфейса реализован отдельно, т.к. он выполняет свою "единственную ответственность";
    O - классы команд, закрыты для изменения, но открыты для модификации (реализован абстрактный класс, а модификация это производные классы);
    L - только в некоторые команды реализуют GetParameters, и это реализовано проверкой на интерфейс;
    I - только классы добавления и обновления будут использовать интерфейс IParameteriesCommand;
    D - интерфейс пользователя и комманды зависят друг от друга через интерфейсы, а не через реализацию.

2) На втором этапе в консольном приложении реализован механизм DI, с помощью которого необходимые объекты создаются с разным жизненным циклом(Singleton, Scoped, Transiet). Это позволяет улучшить читаемость и обновление кода. Создан локальный репозиторий в памяти, для проверки работоспособности приложения и записи в него данных из разных потоков приложения.

3) На третьем этапе создан веб интерфейс, для расширенного управления продуктами и категориями, используя паттерны MVP(Model - View - Presentation) и MVC (Model-View-Controller). Реализованы чтения и запись продуктов и категории из локальной БД (Postgres, развернутой к контейнере Docker).
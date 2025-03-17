#region Usings
using BookStore.InventoryManagement.CommandFactory;
using BookStore.InventoryManagementClient.ConsoleUserInterface;
#endregion


Console.WriteLine("Добро пожаловать в BookStore!");

var userInterface = new ConsoleUserInterface();
var commandFactory = new InventoryCommandFactory(userInterface);

var response = commandFactory.GetCommand("?").RunCommand();

while (!response.shouldQuit)
{
    // look at this mistake with the ToLower()
    var input = userInterface.ReadValue("> ").ToLower();
    var command = commandFactory.GetCommand(input);

    response = command.RunCommand();

    if (!response.wasSuccess)
    {
        userInterface.WriteMessage("Enter ? to view options.");
    }
}
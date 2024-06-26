namespace csharp_design_patterns.SOLID.DIP
{
    public class Database
    {
        // does some database operations
    }
    public class UserController
    {
        private Database database; // tightly coupled to UserController class
        public UserController(Database database)
        {
            this.database = database;
        }
    }

    //^^^ BEFORE ^^^

    // vvv AFTER vvv

    // abstraction
    public interface IDataStorage
    {
        void SaveData(string data);
        string LoadData();
    }

    // low-level
    public class DatabaseOperations : IDataStorage
    {
        public string LoadData()
        {
            // logic
            return "logic";
        }

        public void SaveData(string data)
        {
            // logic
        }
    }

    // high-level
    public class NewUserController
    {
        public IDataStorage _dataStorage;
        public NewUserController(IDataStorage dataStorage)
        {
            _dataStorage = dataStorage;
        }

        // logic
    }

}


/*
Notes:
    - high-level modules should not depend on low-level modules, rather both should depend on abstractions
    - abstractions should not depend on details, rather details should depend on abstractions
 */
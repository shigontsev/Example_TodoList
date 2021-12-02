using BLL;
using BLL.Interfaces;
using DAL.Interfaces;
using DAL.JsonDAL;

namespace Dependencies
{
    public class DependencyResolver
    {
        private static DependencyResolver _instance;

        public static DependencyResolver Instance
        {
            get
            {
                if (_instance is null)
                {
                    _instance = new DependencyResolver();
                }
                return _instance;
            }
        }

        private ITodoListDAO TodoListDAO => new TodoListDAO();

        public ITodoListLogic TodoListLogic => new TodoListLogic(TodoListDAO);

        private IСompletedTasksDAO СompletedTasksDAO => new СompletedTasksDAO();

        public ICompletedTasksLogic CompletedTasksLogic => new CompletedTasksLogic(СompletedTasksDAO);
    }
}

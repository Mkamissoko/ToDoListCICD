using System.Collections.Generic;

namespace ConsoleApplication1
{
    public class ToDoList
    {
        public User user;

        public int nbrMaxItem = 10;

        public int interval = 30;

        public List<Item> items = new List<Item>();
    

        public bool addItemToToDoList(Item item, IEmailSenderService emailSenderService)
        {
            if (user.isValid())
            {
                if (items.Count >= nbrMaxItem) return false;
                if (items.Find((x) => x.name == item.name) != null) return false;
                if (item.content.Length > 1000) return false;
                if (items.Count > 0 && items[items.Count-1].dateTime.AddMinutes(interval) > item.dateTime) return false;
                if (items.Count == 7) emailSenderService.sendEmail(user, "ToDoList", "Vous avez 8 items dans votre todolist");
                items.Add(item);
                return true;
            }
            return false;
        }
    }
}
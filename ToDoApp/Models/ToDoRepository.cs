namespace ToDoApp.Models
{
    public static class ToDoRepository
    {
        /// <summary>
        /// Initialize the List Of the TODO Items.
        /// </summary>
        private static List<ToDoModel>items = new List<ToDoModel>()
        {
            new ToDoModel{Id=1,Name="Item1"},
            new ToDoModel{Id=2,Name="Item2"},
            new ToDoModel{Id=3,Name="Item3"},
            new ToDoModel{Id=4,Name="Item4"},
        };

        /// <summary>
        /// Executes to add the new ToDo item to the List.
        /// </summary>
        /// <param name="item"></param>
        public static void AddItem(ToDoModel item)
        {
            if(items.Count > 0)
            {
                var maxId = items.Max(x => x.Id);
                item.Id = maxId + 1;
                items.Add(item);
            }
            else
            {
                item.Id = 1;
                items.Add(item);
            }
        }

        /// <summary>
        /// Search and Retrives the ToDo item by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static ToDoModel? GetItemById(int id)
        {
            var item = items.FirstOrDefault(x => x.Id == id);

            if (item != null)
            {
                return new ToDoModel { Id = item.Id, Name = item.Name };
            }

            return null;
        }

        /// <summary>
        /// Get's all the item from the ToDo Task even it is completed.
        /// </summary>
        /// <returns></returns>
        public static List<ToDoModel> GetItems()
        {
            var sortedItems = items.OrderBy(x => x.IsCompleted).ThenByDescending(x => x.Id).ToList();

            return sortedItems;
        }

        /// <summary>
        /// Updates the ToDo item to the Items List.
        /// </summary>
        /// <param name="itemId"></param>
        /// <param name="item"></param>
        public static void UpdateItem(int itemId,ToDoModel item)
        {
            if (itemId != item.Id) return;

            var itemToUpdate = items.FirstOrDefault(x => x.Id == itemId);

            if(itemToUpdate != null)
            {
                itemToUpdate.Name = item.Name;
            }
        }

        /// <summary>
        /// Deletes the Selected ToDo item in the List.
        /// </summary>
        /// <param name="itemId"></param>
        public static void DeleteItem(int itemId)
        {
            var itemToDelete = items.FirstOrDefault(x => x.Id == itemId);

            if (itemToDelete != null)
            {
                items.Remove(itemToDelete);
            }
        }

        /// <summary>
        /// Search the TODO items in the List.
        /// </summary>
        /// <param name="itemFilter"></param>
        /// <returns></returns>
        public static List<ToDoModel>SearchItems(string itemFilter)
        {
            return items.Where(s => s.Name.Contains(itemFilter, StringComparison.OrdinalIgnoreCase)).ToList();
        }
    }
}

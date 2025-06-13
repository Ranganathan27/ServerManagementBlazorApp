namespace ToDoApp.Models
{
    public class ToDoModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public bool IsCompleted 
        { 
            get => _isCompleted; 
          
            set
            {
                _isCompleted = value;

                if(value)
                    DateCompleted = DateTime.Now;
            } 
        }

        private bool _isCompleted;
        public DateTime DateCompleted { get; set; }
    }
}

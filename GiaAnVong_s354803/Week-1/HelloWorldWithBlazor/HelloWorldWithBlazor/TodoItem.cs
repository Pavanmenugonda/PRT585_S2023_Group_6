namespace HelloWorldWithBlazor
{
    public class TodoItem
    {
        public string? Title { get; set; }
        public bool IsDone { get; set; } = false;

        private void checkIsDone(string? title)
        {
            IsDone = true;
        }
    }
}

namespace Api.Domain.Model
{
    public class Season(DateOnly start, DateOnly end)
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public DateOnly Start { get; private set; } = start;
        public DateOnly End { get; private set; } = end;

        public override string ToString()
        {
            return $"Id={Id} Start={Start} End={End}";
        }
    }
}
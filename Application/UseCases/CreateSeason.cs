using Api.Domain.Model;
using Api.Infrastructure.Database;

namespace Api.Application.UseCases
{
    public class CreateSeason(ApiDbContext dbContext, ILogger<CreateSeason> logger)
    {

        public async Task<CreateSeasonOutput> Execute(CreateSeasonInput input)
        {
            var season = new Season(input.Start, input.End);

            logger.LogInformation($"Creating a new Season {season}");

            await dbContext.Seasons.AddAsync(season);

            await dbContext.SaveChangesAsync();

            return new CreateSeasonOutput(season);
        }

    }

    public readonly record struct CreateSeasonInput
    {
        public required DateOnly Start { get; init; }
        public required DateOnly End { get; init; }
    }
    public record struct CreateSeasonOutput(Season Season) { }
}
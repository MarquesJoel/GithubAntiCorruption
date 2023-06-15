namespace GithubAntiCorruption.Application.Services.GetBranchesRepository
{
    public class BrancheResponse
    {
        public string Name { get; init; }
        public BrancheCommit Commit { get; init; }
        public bool Protected { get; init; }
    }
}

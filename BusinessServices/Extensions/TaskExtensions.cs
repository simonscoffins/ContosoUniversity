using System.Threading.Tasks;

namespace BusinessServices.Extensions {

    public static class TaskExtensions {
        public static readonly Task CompletedTask = Task.FromResult(true);
    }
}
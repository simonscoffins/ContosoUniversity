using System.Threading.Tasks;

namespace BusinessServices {


    public interface ICommandProcessor {

        void Process(ICommand command);

        Task ProcessAsync(ICommand command);
    }
}
using System.Threading.Tasks;
using System.Windows.Input;

namespace AsyncAwait
{
    public interface IAsyncCommand : ICommand
    {
        Task ExecuteAsync();
        bool CanExecute();
    }
}
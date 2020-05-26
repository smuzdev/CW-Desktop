using GalaSoft.MvvmLight.Views;

namespace KlingenRestaurant
{
    public interface IFrameNavigationService : INavigationService
    {
        object Parameter { get; }
    }
}

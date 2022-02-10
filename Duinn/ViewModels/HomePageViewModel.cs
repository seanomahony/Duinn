namespace Duinn.ViewModels
{
    class HomePageViewModel : BasePageViewModel
    {
        private static HomePageViewModel _instance;

        public HomePageViewModel() : base()
        {
           
        }

        public static HomePageViewModel Instance 
        { 
            get 
            { 
                if(_instance == null)
                {
                    _instance = new HomePageViewModel();
                }
                
                return _instance;
            } 
        }

        
    }
}

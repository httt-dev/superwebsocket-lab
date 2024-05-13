using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace YoutubeViewers.WPF.ViewModels
{
    public class YoutubeViewersViewModel : ViewModelBase
    {
        public YoutubeViewersListingViewModel YoutubeViewersListingViewModel { get; set; }
        public YoutubeViewersDetailViewModel YoutubeViewersDetailViewModel { get; set; }    
        public ICommand AddYoutubeViewersCommand { get; }

        public YoutubeViewersViewModel() 
        { 
            YoutubeViewersListingViewModel  = new YoutubeViewersListingViewModel();
            YoutubeViewersDetailViewModel = new YoutubeViewersDetailViewModel();

        }
    }
}

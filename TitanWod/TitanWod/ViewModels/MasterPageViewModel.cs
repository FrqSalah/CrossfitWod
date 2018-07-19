using System;
using System.Collections.Generic;
using System.Text;

namespace TitanWod.ViewModels
{
    class MasterPageViewModel
    {
        public string UserAvatar { get; set; }
        public MasterPageViewModel()
        {
            UserAvatar = "homeSlide1.jpg";
        }
    }
}

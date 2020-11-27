using System;
using System.Collections.Generic;
using System.Text;

namespace WhoWantsToBeAMillionaire.ViewModels
{
    class AskAudienceViewModel : BaseViewModel
    {

        private int _maximumHeight;
        public int MaximumHeight
        {
            get
            {
                return _maximumHeight;
            }
            set
            {
                _maximumHeight = value;
                OnPropertyChanged(nameof(MaximumHeight));
            }
        }

        private int _rectangleAHeight;
        public int RectangleAHeight
        {
            get
            {
                return _rectangleAHeight;
            }
            set
            {
                _rectangleAHeight = value;
                OnPropertyChanged(nameof(RectangleAHeight));
            }
        }

        private int _rectangleBHeight;
        public int RectangleBHeight
        {
            get
            {
                return _rectangleBHeight;
            }
            set
            {
                _rectangleBHeight = value;
                OnPropertyChanged(nameof(RectangleBHeight));
            }
        }

        private int _rectangleCHeight;
        public int RectangleCHeight
        {
            get
            {
                return _rectangleCHeight;
            }
            set
            {
                _rectangleCHeight = value;
                OnPropertyChanged(nameof(RectangleCHeight));
            }
        }

        private int _rectangleDHeight;
        public int RectangleDHeight
        {
            get
            {
                return _rectangleDHeight;
            }
            set
            {
                _rectangleDHeight = value;
                OnPropertyChanged(nameof(RectangleDHeight));
            }
        }

        public AskAudienceViewModel()
        {
            MaximumHeight = 300;
            RectangleAHeight = 300;
            RectangleBHeight = 30;
            RectangleCHeight = 100;
            RectangleDHeight = 200;
        }
    }
}

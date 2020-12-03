using System.Collections.Generic;

namespace WhoWantsToBeAMillionaire.ViewModels
{
    public class AskAudienceViewModel : BaseViewModel
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

        public AskAudienceViewModel(List<int> results)
        {
            // Inaltimea maxima la care poate ajunge un dreptunghi
            MaximumHeight = 300;

            // Constructorul a primit ca parametru de intrare lista cu rezultate in urma sondajului.
            // Lista consta din 4 valori ce reprezinta procentajele din public ce a votat pentru fiecare optiune.
            // Exemplu: results[0] = 30     pentru optiunea A au votat 30% din public.
            // Exemplu: results[1] = 10     pentru optiunea B au votat 10% din public.

            // Avand lungimea maxima a dreptunghiului, putem calcula cum poate fi reprezentat procentajul (de la 1 la 100)
            // intr-o alta valoare de la 1 la MaximumHeight.

            RectangleAHeight = MaximumHeight * results[0] / 100;
            RectangleBHeight = MaximumHeight * results[1] / 100;
            RectangleCHeight = MaximumHeight * results[2] / 100;
            RectangleDHeight = MaximumHeight * results[3] / 100;
        }
    }
}

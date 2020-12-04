using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;
using WhoWantsToBeAMillionaire.Models;
using WhoWantsToBeAMillionaire.Services;
using WhoWantsToBeAMillionaire.Views;

namespace WhoWantsToBeAMillionaire.ViewModels
{
    class GameViewModel : BaseViewModel
    {
        private Question _currentQuestion;
        public Question CurrentQuestion
        {
            get
            {
                return _currentQuestion;
            }
            set
            {
                _currentQuestion = value;
                OnPropertyChanged(nameof(CurrentQuestion));
            }
        }

        private int _secondsPerQuestion;
        public int SecondsPerQuestion
        {
            get { return _secondsPerQuestion; }
            set
            {
                _secondsPerQuestion = value;
                OnPropertyChanged(nameof(SecondsPerQuestion));
            }
        }

        private bool _op0IsEnabled;
        public bool Op0IsEnabled
        {
            get { return _op0IsEnabled; }
            set
            {
                _op0IsEnabled = value;
                OnPropertyChanged(nameof(Op0IsEnabled));
            }
        }

        private bool _op1IsEnabled;
        public bool Op1IsEnabled
        {
            get { return _op1IsEnabled; }
            set
            {
                _op1IsEnabled = value;
                OnPropertyChanged(nameof(Op1IsEnabled));
            }
        }

        private bool _op2IsEnabled;
        public bool Op2IsEnabled
        {
            get { return _op2IsEnabled; }
            set
            {
                _op2IsEnabled = value;
                OnPropertyChanged(nameof(Op2IsEnabled));
            }
        }

        private bool _op3IsEnabled;
        public bool Op3IsEnabled
        {
            get { return _op3IsEnabled; }
            set
            {
                _op3IsEnabled = value;
                OnPropertyChanged(nameof(Op3IsEnabled));
            }
        }

        private bool _btRetreatIsEnabled;
        public bool BtRetreatIsEnabled
        {
            get { return _btRetreatIsEnabled; }
            set
            {
                _btRetreatIsEnabled = value;
                OnPropertyChanged(nameof(BtRetreatIsEnabled));
            }
        }

        public GameService GameService { get; set; }
        
        private AudioService _audioService { get; set; }

        public GameView _gameView;

        public DispatcherTimer ellapsedTime;
        public DateTime start;
        
        private Style lastItemStyle = null;
        
        public List<Label> PrizeLabels { get; set; }

        public GameViewModel(GameView gameView)
        {
            Op0IsEnabled = Op1IsEnabled = Op2IsEnabled = Op3IsEnabled = BtRetreatIsEnabled = true;

            _gameView = gameView;
            _audioService = AudioService.GetInstace();

            // Cream o instanta a clasei GameService, Acolo se contine cea mai mare parte a logicii
            // din spatele jocului.
            GameService = GameService.GetInstace();
            SecondsPerQuestion = 60; 

            // Afisam stiva premiilor
            PrizeLabels = new List<Label>();
            var Prizes = Game.PrizeList;
            var SafePoints = Game.SafePoints;

            // Pentru fiecare premiu este creat un label si un row in grid-ul
            // dedicat afisarii premiilor.
            for (int i = Prizes.Count-1; i>=0; i--)
            {
                Label lbPrize = new Label { Content = Prizes[i] };

                // Premiile de $1000, $32000 si $1000000 vor avea alta culoare
                string styleIdentifier = "PrizeItemStyle";
                if (SafePoints.Contains(lbPrize.Content.ToString()))
                    styleIdentifier = "SafePrizeItemStyle";
                lbPrize.Style = Application.Current.TryFindResource(styleIdentifier) as Style;

                // Inserarea premiului in grid
                gameView.prizeStack.RowDefinitions.Add(new RowDefinition());
                Grid.SetRow(lbPrize, gameView.prizeStack.RowDefinitions.Count - 1);
                lbPrize.HorizontalContentAlignment = HorizontalAlignment.Center;
                lbPrize.VerticalAlignment = VerticalAlignment.Stretch;
                gameView.prizeStack.Children.Add(lbPrize);

                PrizeLabels.Add(lbPrize);
            }
            
            lastItemStyle = PrizeLabels[PrizeLabels.Count - 1].Style;
            
            // Marcam premiul curent in stiva
            PrizeLabels[PrizeLabels.Count - 1].Style = Application.Current.TryFindResource("CurrentPrize") as Style;

            // Selectam prima intrebare
            CurrentQuestion = GameService.Game.Questions[0];

            // Initializam un timer pentru contorizarea timpului la fiecare intrebare.
            ellapsedTime = new DispatcherTimer(TimeSpan.FromSeconds(1), DispatcherPriority.Background,
                   t_Tick, Dispatcher.CurrentDispatcher); ellapsedTime.IsEnabled = true;
            start = DateTime.Now;

            // Melodia de inceput
            _audioService.PlayAudio(_audioService.LetsPlay);
        }

        private void t_Tick(object sender, EventArgs e)
        {
            // Extragem diferenta de timp dintre momentul actual si cel in care a fost afisata intrebarea
            var difference = DateTime.Now.Subtract(start);
            _gameView.timer.Content = difference.ToString(@"mm\:ss");

            // Daca mai raman 5 secunde - timer-ul devine rosu
            // 30 secunde - timer-ul galben
            // > 30 secunde - timer-ul alb
            if (difference.Seconds > SecondsPerQuestion - 5)
                _gameView.timer.Foreground = Brushes.Red;
            else if (difference.Seconds > SecondsPerQuestion - 30)
                _gameView.timer.Foreground = Brushes.Yellow;
            else
                _gameView.timer.Foreground = Brushes.White;

            // Cazul in care expira timpul:
            if (difference > TimeSpan.FromSeconds(SecondsPerQuestion))
            {
                ellapsedTime.Stop();
                GameService.AddToEllapsedTime(DateTime.Now.Subtract(start));
                GameOver();
                return;
            }
        }

        public async void OptionSubmitted(Button btOption)
        {
            // Oprim contorizarea timpului si dezactivam butoanele
            ellapsedTime.Stop();
            ButtonsSetIsEnabledTo(false);
            _audioService.PlayAudio(_audioService.FinalAnswer);

            btOption.Style = Application.Current.TryFindResource("OptionSelected") as Style;

            await Task.Delay(3000);

            string feedBack = CheckSubmittedOption(int.Parse(btOption.Tag.ToString()), DateTime.Now.Subtract(start));
            switch (feedBack)
            {
                case "Success!":
                    // Raspuns corect
                    btOption.Style = Application.Current.TryFindResource("RightOptionSelected") as Style;
                    _audioService.PlayAudio(_audioService.CorrectAnswer);
                    break;

                default:
                    // Raspuns gresit
                    btOption.Style = Application.Current.TryFindResource("WrongOptionSelected") as Style;
                    GameOver();
                    return;
            }

            // Daca am ajuns pana aici, inseamna ca raspunsul a fost corect.
            await Task.Delay(3000);

            // Daca nu mai exista intrebari - afisam rezultatele.
            // Daca mai exista - pregatim terenul pentru urmatoarea intrebare.
            if (!PickNextQuestion())
                SaveAndDisplayResults();
            else
            {
                ButtonsSetIsEnabledTo(true);
                btOption.Style = Application.Current.TryFindResource("OptionPolygon") as Style;
                start = DateTime.Now;
                _gameView.timer.Content = "00:00";
                ellapsedTime.Start();
            }
        }

        public string CheckSubmittedOption(int optionId, TimeSpan ellapsedTimeForQuestion)
        {
            if (GameService.CheckOption(optionId, ellapsedTimeForQuestion))
                return "Success!";
            else
                return "NotSuccess";
        }

        public bool PickNextQuestion()
        {
            CurrentQuestion = GameService.PickNext();

            if (CurrentQuestion == null)
                return false; // Nu mai sunt intrebari

            MarkCurrentPrizeWithinPrizeStack();
            _audioService.PlayAudioAccordingToPriceRange(GameService.CurrentQuestionId);
            
            return true;
        }

        public void MarkCurrentPrizeWithinPrizeStack()
        {
            // Evidentiaza premiul curent in stiva premiilor, iar premiul care a fost evidentiat revine la stilul sau normal.
            var previousPrize = PrizeLabels[PrizeLabels.Count - GameService.CurrentQuestionId];
            var currentPrize = PrizeLabels[PrizeLabels.Count - 1 - GameService.CurrentQuestionId];

            previousPrize.Style = lastItemStyle;
            lastItemStyle = currentPrize.Style;
            currentPrize.Style = Application.Current.TryFindResource("CurrentPrize") as Style;
        }

        public void SaveAndDisplayResults()
        {
            GameService.SaveResults();
            ((MainWindow)System.Windows.Application.Current.MainWindow).UpdateView("Results");
        }

        private void ButtonsSetIsEnabledTo(bool flag)
        {
            // Dezactiveaza / Activeaza (in dependenta de valoarea flag-ului) optiunile de raspuns si cele ajutatoare.
            Op0IsEnabled = Op1IsEnabled = Op2IsEnabled = Op3IsEnabled = BtRetreatIsEnabled = flag;

            for (int i = 0; i < 3; i++)
                (_gameView.lifeLinesGrid.Children[i] as Button).IsEnabled = flag;
        }

        public void Retreat()
        {
            GameService.Retreat();
            GameOver();
        }

        public void GameOver()
        {
            _audioService.PlayAudio(_audioService.WrongAnswer);

            // Oprim timer-ul, dezactivam butoanele si afisam eplicatia privind raspunsul corect.
            ellapsedTime.Stop();
            ButtonsSetIsEnabledTo(false);

            _gameView.RowForAdditionalInformation.Height = GridLength.Auto;
            _gameView.panelExplications.Visibility = Visibility.Visible;
            string explanations = CurrentQuestion.Explanations;

            if (explanations != null && explanations.Length > 0)
                _gameView.tbExplications.Text = explanations;
            else
                _gameView.tbExplications.Height = 0;

            MarkCorrectOption();
        }

        public void MarkCorrectOption()
        {
            // Identifica care este butonul ce contine raspunsul corect si ii atribuie stilul RightOptionSelected 
            var btCorrectOption = (_gameView.optionsGrid.Children[CurrentQuestion.CorrectOptionIndex] as Grid).Children[0] as Button;
            btCorrectOption.Style = Application.Current.TryFindResource("RightOptionSelected") as Style;
        }

        public void FiftyFifty()
        {
            start = DateTime.Now;
            GameService.FiftyFifty();
            OnPropertyChanged(nameof(CurrentQuestion));

            _gameView.FiftyFiftyUsed.Visibility = Visibility.Visible;
            _gameView.btFiftyFifty.IsEnabled = false;

            Op0IsEnabled = _gameView.option0.IsEnabled;
            Op1IsEnabled = _gameView.option1.IsEnabled;
            Op2IsEnabled = _gameView.option2.IsEnabled;
            Op3IsEnabled = _gameView.option3.IsEnabled;
        }

        public void AskAudience()
        {
            start = DateTime.Now;
            List<int> results = GameService.AskAudience();
            var window = new AskAudienceView(results);
            window.ShowDialog();

            _gameView.AskAudienceUsed.Visibility = Visibility.Visible;
            _gameView.btAskAudience.IsEnabled = false;
        }

        public void CallFriend()
        {
            start = DateTime.Now;
            var window = new PhoneCallView(CurrentQuestion, GameService.Results.PlayerName);
            window.ShowDialog();

            _gameView.PhoneCallUsed.Visibility = Visibility.Visible;
            _gameView.btPhoneCall.IsEnabled = false;
        }
    }
}

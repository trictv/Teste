namespace Teste
{
    public partial class MainPage : ContentPage
    {
        Button _btnAnterior;

        public MainPage()
        {
            InitializeComponent();
            grdPrinc.Children.Insert(0, GetViewAleatoria());
        }

        private void OnButtonClicked(object sender, EventArgs e)
        {
            if (sender is Button clickedButton)
            {
                if (_btnAnterior != null && (Button)sender != _btnAnterior)
                {
                    _btnAnterior.TranslateTo(0, 0, 250, Easing.SpringOut);
                    VisualStateManager.GoToState(_btnAnterior, "UnSelected");
                }

                clickedButton.TranslateTo(0, -30, 250, Easing.SpringOut);

                _btnAnterior = clickedButton;
                VisualStateManager.GoToState(_btnAnterior, "Selected");

                if (grdPrinc.Children.Count == 3)
                {
                    grdPrinc.Children.RemoveAt(0);
                }
                grdPrinc.Children.Insert(0, GetViewAleatoria());
            }
        }


        public static ContentView GetViewAleatoria()
        {
            Random random = new Random();
            Color randomColor = Color.FromRgb(random.Next(256), random.Next(256), random.Next(256));

            ContentView contentView = new ContentView
            {
                BackgroundColor = randomColor,
                Content = new Label
                {
                    Text = "Teste",
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Center,
                    TextColor = Colors.White
                }
            };

            return contentView;
        }
    }

}

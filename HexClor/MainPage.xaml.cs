namespace HexClor
{
    public partial class MainPage : ContentPage
    {
        int cnt = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnHexChanged(object sender, EventArgs e)
        {
            string hex = Hex.Text;

            // Check if HEX is valid (#RRGGBB format)
            if (!string.IsNullOrEmpty(hex) && hex.StartsWith("#") && hex.Length == 7)
            {
                //Convert HEX to Color
                Color color = Color.FromArgb(Hex.Text);

                //Update background
                Displaycolor.BackgroundColor = color;

                //Update sliders
                RSlider.Value = (int)(color.Red * 255);
                GSlider.Value = (int)(color.Green * 255);
                BSlider.Value = (int)(color.Blue * 255);
            }
            else if (string.IsNullOrEmpty(hex) || !hex.StartsWith("#"))
            {
                DisplayAlert("Input Error", "Please input the hex code with '#' followed by 6 hexadecimal characters.", "OK");
            }

            else
            {
                //Incorrect Input
                DisplayAlert("Input Error", "Please enter a valid HEX code in the format '#RRGGBB'.", "OK");
            }
        }

        // When user moves RGB sliders
        private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            // Get RGB from sliders
            int r = (int)RSlider.Value;
            int g = (int)GSlider.Value;
            int b = (int)BSlider.Value;

            // Create color
            Color color = Color.FromRgb(r, g, b);

            // Update background
            Displaycolor.BackgroundColor = color;

            // Update HEX field
            Hex.Text = color.ToHex();
        }

        // Random Button Click
        private void OnRandomClicked(object sender, EventArgs e)
        {
            Random random = new Random();
            int r = random.Next(256);
            int g = random.Next(256);
            int b = random.Next(256);

            // Create random color
            Color color = Color.FromRgb(r, g, b);

            // Update UI
            Displaycolor.BackgroundColor = color;
            RSlider.Value = r;
            GSlider.Value = g;
            BSlider.Value = b;
            Hex.Text = color.ToHex();
        }
    }
}

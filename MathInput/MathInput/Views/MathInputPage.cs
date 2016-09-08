using MathInput.Models;
using MathInput.Resources;
using Xamarin.Forms;
using Xam.FormsPlugin.Abstractions;
using System.Threading.Tasks;

namespace MathInput
{
    public class MathInputPage : ContentPage
    {
        public static Entry entry = new Entry { Placeholder = Language.EntryPlaceholder, HorizontalOptions = LayoutOptions.Fill, Keyboard = Keyboard.Default };
        public MathInputPage()
        {
            Title = Language.MathInput;
            SizeChanged += (s, e) =>
            {
                Content = setOrientation(Width);
            };
        }

        private StackLayout setOrientation(double Width)
        {
            StackLayout stackLayout = new StackLayout();
            int totalButton = (int)System.Math.Round(Width / 59);
            if (totalButton == 0) totalButton = 6;
            stackLayout = LandscapeInit(totalButton);
            return stackLayout;
        }

        private StackLayout LandscapeInit(int columnTotal)
        {
            Symbols.OperatorInit();
            StackLayout mainLayout = new StackLayout();
            var width = 50;
            Grid gridLayout = new Grid()
            {
                ColumnDefinitions =
                {
                    new ColumnDefinition { Width=width },
                    new ColumnDefinition { Width=width },
                    new ColumnDefinition { Width=width },
                    new ColumnDefinition { Width=width },
                    new ColumnDefinition { Width=width },
                    new ColumnDefinition { Width=width },
                    new ColumnDefinition { Width=width },
                    new ColumnDefinition { Width=width },
                    new ColumnDefinition { Width=width },
                    new ColumnDefinition { Width=width },
                    new ColumnDefinition { Width=width },
                    new ColumnDefinition { Width=width },
                    new ColumnDefinition { Width=width },
                    new ColumnDefinition { Width=width },
                    new ColumnDefinition { Width=width }
                }
            };
            gridLayout.Padding = new Thickness(15, 0, 0, 0);
            int rowCount = 0, columnCount = 0;
            ScrollView scrollButtons = new ScrollView() { VerticalOptions = LayoutOptions.CenterAndExpand };
            foreach (var item in Symbols.Operators)
            {
                string toolTip = item.Key;
                string text = item.Value;
                if (toolTip.Contains("label"))
                {
                    Label labelContent = new Label() { Text = item.Value, HorizontalOptions = LayoutOptions.Fill, HorizontalTextAlignment = TextAlignment.Center };
                    labelContent.TranslationY = 20;
                    if (columnCount % columnTotal != 0)
                        rowCount++;
                    columnCount = 0;
                    gridLayout.Children.Add(labelContent, columnCount, rowCount);
                    Grid.SetColumnSpan(labelContent, columnTotal);
                    rowCount++;
                }
                else
                {
                    Button btnSymbol = new Button() { Text = text };
                    btnSymbol.Clicked +=async (s, e) =>
                                    {
                                        entry.Text += btnSymbol.Text;
                                        await btnSymbol.ScaleTo(1.3, 200, Easing.BounceOut);
                                        btnSymbol.Scale = 1;
                                    };
                    gridLayout.Children.Add(btnSymbol, columnCount++, rowCount);
                    if (columnCount % columnTotal == 0)
                    {
                        columnCount = 0;
                        rowCount += 1;
                    }
                }
            }
            scrollButtons.Content = gridLayout;
            mainLayout.Children.Add(entry);
            mainLayout.Children.Add(new AdMobView() { AdUnitId = "ca-app-pub-3832805953811556/8555016221" });
            mainLayout.Children.Add(scrollButtons);
            return mainLayout;
        }
    }
}

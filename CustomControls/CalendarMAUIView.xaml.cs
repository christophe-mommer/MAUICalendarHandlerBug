namespace CalendarHandlerBug.CustomControls;

public partial class CalendarMAUIView : ContentPage
{
    public CalendarMAUIView()
    {
        InitializeComponent();
        BindingContext = new CalendarMAUIViewModel();
    }
}
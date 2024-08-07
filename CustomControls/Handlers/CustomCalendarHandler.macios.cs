namespace MaPremiereApplicationMAUI.Toolbox.CustomControls.Handlers;

using CalendarHandlerBug.CustomControls;
using Foundation;
using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;
using UIKit;

public partial class CustomCalendarHandler : ViewHandler<ICalendar, UICalendarView>, IDisposable
{
    private UICalendarSelectionSingleDate? _calendarSelection;

    protected override UICalendarView CreatePlatformView()
    {
        var calendarView = new UICalendarView();
        _calendarSelection = new UICalendarSelectionSingleDate(new CalendarSelectionSingleDateDelegate(VirtualView, calendarView));
        calendarView.SelectionBehavior = _calendarSelection;
        return calendarView;
    }

    static void MapSelectedDate(CustomCalendarHandler handler, ICalendar virtualView)
    {
        if (handler._calendarSelection is not null)
        {
            if (virtualView.SelectedDate is null)
            {
                handler._calendarSelection.SetSelectedDate(null, true);
                return;
            }
            var iosDate = new NSDateComponents
            {
                Day = virtualView.SelectedDate.Value.Day,
                Month = virtualView.SelectedDate.Value.Month,
                Year = virtualView.SelectedDate.Value.Year
            };
            handler._calendarSelection.SetSelectedDate(iosDate, true);
        }
    }

    public void Dispose()
    {
        _calendarSelection?.Dispose();
    }

}
public sealed class CalendarSelectionSingleDateDelegate : UICalendarSelectionSingleDateDelegate
{
    private readonly ICalendar _calendar;

    public CalendarSelectionSingleDateDelegate(
        ICalendar calendar, UICalendarView native) : base(native.ClassHandle)
    {
        _calendar = calendar;
    }
    public override void DidSelectDate(UICalendarSelectionSingleDate selection, NSDateComponents? date)
    {
        selection.SelectedDate = date;
        _calendar.SelectedDate = date?.Date.ToDateTime();
        _calendar.OnSelectedDateChanged(_calendar.SelectedDate);
    }

}

namespace CalendarHandlerBug.CustomControls;

public interface ICalendar : IView
{
    DateTimeOffset? SelectedDate { get; set; }
    void OnSelectedDateChanged(DateTimeOffset? selectedDate);
}

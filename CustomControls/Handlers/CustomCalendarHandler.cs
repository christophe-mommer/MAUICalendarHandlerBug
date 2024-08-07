namespace CalendarHandlerBug.CustomControls.Handlers;

public partial class CustomCalendarHandler
{
    public CustomCalendarHandler(
        IPropertyMapper mapper,
        CommandMapper? commandMapper = null) : base(mapper, commandMapper)
    {
    }

    public CustomCalendarHandler()
        : this(PropertyMapper, CommandMapper) { }

    public static IPropertyMapper<ICalendar, CustomCalendarHandler> PropertyMapper
         = new PropertyMapper<ICalendar, CustomCalendarHandler>
         {
             [nameof(ICalendar.SelectedDate)] = MapSelectedDate
         };

    public static CommandMapper<ICalendar, CustomCalendarHandler> CommandMapper = new(ViewCommandMapper);
}

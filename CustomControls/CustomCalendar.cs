using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarHandlerBug.CustomControls;

public class CustomCalendar : View, ICalendar
{
    public static readonly BindableProperty SelectedDateProperty
        = BindableProperty.Create(
            propertyName: nameof(SelectedDate),
            returnType: typeof(DateTimeOffset?),
            declaringType: typeof(CustomCalendar),
            defaultBindingMode: BindingMode.TwoWay
            );

    public DateTimeOffset? SelectedDate
    {
        get => (DateTimeOffset?)GetValue(SelectedDateProperty);
        set => SetValue(SelectedDateProperty, value);
    }

    public event EventHandler<SelectedDateChangedEventArgs>? SelectedDateChanged;

    void ICalendar.OnSelectedDateChanged(DateTimeOffset? selectedDate)
    {
        SelectedDateChanged?.Invoke(this, new(selectedDate));
    }
}

public class SelectedDateChangedEventArgs(DateTimeOffset? selectedDate) : EventArgs
{
    public DateTimeOffset? SelectedDate { get; set; } = selectedDate;
}

using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarHandlerBug.CustomControls;

public partial class CalendarMAUIViewModel : ObservableObject
{
    [ObservableProperty]
    private DateTimeOffset? _date;

    [ObservableProperty]
    private string _dateLbl = "Pas de date";

    partial void OnDateChanged(DateTimeOffset? value)
    {
        if (value is not null)
            DateLbl = value.Value.ToString("dd/MM/yyyy");
        else
        {
            DateLbl = "Pas de date";
        }
    }
}

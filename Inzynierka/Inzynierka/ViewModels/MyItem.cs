using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

public class MyItem : INotifyPropertyChanged
{
    bool _switch = false;
    public bool Switch
    {
        get
        {
            return _switch;
        }
        set
        {
            if (_switch != value)
            {
                _switch = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Switch"));
            }
        }

    }
    public int Addend1 { get; set; }
    public int Addend2 { get; set; }
    public int Result
    {
        get
        {
            return Addend1 + Addend2;
        }
    }
    public string Summary
    {
        get
        {
            return Addend1 + " + " + Addend2 + " = " + Result;
        }
    }
    public event PropertyChangedEventHandler PropertyChanged;
}
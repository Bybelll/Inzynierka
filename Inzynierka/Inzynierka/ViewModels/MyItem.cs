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
    public string Date { get; set; }
    public int Time { get; set; }
    public double Cost { get { return Time * 1.20; } }
    public double LenghtRoute { get; set; }
    public string StartPoint { get; set; }
    public string FinishPoint { get; set; }


    //public int Result
    //{
    //    get
    //    {
    //        return Addend1 + Addend2;
    //    }
    //}
    //public string Summary
    //{
    //    get
    //    {
    //        return Addend1 + " + " + Addend2 + " = " + Result;
    //    }
    //}
    public event PropertyChangedEventHandler PropertyChanged;
}
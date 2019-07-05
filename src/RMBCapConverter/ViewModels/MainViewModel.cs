using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;

namespace RMBCapConverter.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private ObservableCollection<KeyValuePair<string, string>> _charMapping;

        public ObservableCollection<KeyValuePair<string, string>> CharMapping
        {
            get => _charMapping;
            set { _charMapping = value; RaisePropertyChanged(); }
        }

        public MainViewModel()
        {
            CharMapping = new ObservableCollection<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("0","零"),
                new KeyValuePair<string, string>("1","壹"),
                new KeyValuePair<string, string>("2","贰"),
                new KeyValuePair<string, string>("3","叁"),
                new KeyValuePair<string, string>("4","肆"),
                new KeyValuePair<string, string>("5","伍"),
                new KeyValuePair<string, string>("6","陆"),
                new KeyValuePair<string, string>("7","柒"),
                new KeyValuePair<string, string>("8","捌"),
                new KeyValuePair<string, string>("9","玖"),
                new KeyValuePair<string, string>("10","拾"),
                new KeyValuePair<string, string>("百","佰"),
                new KeyValuePair<string, string>("千","仟"),
                new KeyValuePair<string, string>("万","万"),
                new KeyValuePair<string, string>("亿","亿")
            };
        }
    }
}

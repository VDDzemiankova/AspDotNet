using Lab1.Commands;
using Lab1.Data;
using Lab1.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace Lab1.ViewModels
{
    class StationeryViewModel : ViewModelBase
    {
        private IDialogService dialogService;

        public StationeryViewModel(IDialogService dialogService)
        {
            this.dialogService = dialogService;
            Stationeries = new ObservableCollection<Stationery>(
                new List<Stationery>
                {
                    new Stationery
                    {
                        Name = "Черноморские",
                        Producer = "Спартак",
                        Price = 1.30m,
                        SaleDate = DateTime.Now

                    },
                    new Stationery
                    {
                        Name = "Сливочные",
                        Producer = "Комунарка",
                        Price = 1.30m,
                        SaleDate = DateTime.Now

                    },
                    new Stationery
                    {
                        Name = "Лимонные",
                        Producer = "Рошен",
                        Price = 1.43m,
                        SaleDate = DateTime.Now,
                        Elected = true

                    }
                }
            );

        }

        public ObservableCollection<Stationery> Stationeries { get; set; }

        public ObservableCollection<Stationery> ElectStationeries
        {
            get
            {
                return new ObservableCollection<Stationery>(Stationeries.Where(item => item.Elected));
            }
        }

        private Stationery _selected;

        public Stationery Selected
        {
            get { return _selected; }
            set
            {
                _selected = value;
                if(_selected != null)
                {
                    FormValue = _selected;
                    DetailsShowed = true;
                    FormEnabled = false;
                }
                OnPropertyChanged();
            }
        }


        private Stationery _formValue;

        public Stationery FormValue
        {
            get { return _formValue; }
            set
            {
                _formValue = value;
                OnPropertyChanged();
            }
        }

        private bool _detailsShowed;

        public bool DetailsShowed
        {
            get { return _detailsShowed; }
            set
            {
                _detailsShowed = value;
                OnPropertyChanged();
            }
        }

        private bool _formEnabled;

        public bool FormEnabled
        {
            get { return _formEnabled; }
            set
            {
                _formEnabled = value;
                OnPropertyChanged();
            }
        }

        private ICommand _hideDetailsCommand;

        public ICommand HideDetailsCommand
        {
            get
            {
                return _hideDetailsCommand ?? (_hideDetailsCommand = new DelegateCommand(() =>
                {
                    Selected = null;
                    DetailsShowed = false;
                }));
            }
        }

        private ICommand _addCommand;

        public ICommand AddCommand
        {
            get
            {
                return _addCommand ?? (_addCommand = new DelegateCommand(() =>
                {
                    Selected = null;
                    FormValue = new Stationery()
                    {
                        SaleDate = DateTime.Now
                    };                
                    DetailsShowed = true;
                    FormEnabled = true;
                }));
            }
        }

        private ICommand _saveCommand;

        public ICommand SaveCommand
        {
            get
            {
                return _saveCommand ?? (_saveCommand = new DelegateCommand(async () =>
                {
                    await dialogService.ShowMessage("Подтверждение сохранения", "Вы действительно хотите сохранить", "Да", "Нет", result =>
                    {
                        if(result)
                        {
                            Stationeries.Add(FormValue);
                            OnPropertyChanged("ElectStationeries");
                            DetailsShowed = false;
                        }
                    });
                }));
            }
        }

    }
}

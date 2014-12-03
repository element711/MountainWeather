using System;
using Silkweb.Mobile.MountainWeather.Services;
using Silkweb.Mobile.MountainWeather.Models;
using System.Collections.Generic;
using System.Linq;
using Silkweb.Mobile.Core.ViewModels;
using Silkweb.Mobile.Core.Interfaces;

namespace Silkweb.Mobile.MountainWeather.ViewModels
{
    public class MountainAreasViewModel : ViewModelBase
    {
        private IEnumerable<MountainAreaViewModel> _areas;
        private readonly IMountainWeatherService _mountainWeatherService;
        private readonly Func<Location, MountainAreaViewModel> _areaViewModelFactory;
        private readonly IDialogProvider _dialogProvider;

        public MountainAreasViewModel(
            IMountainWeatherService mountainWeatherService, 
            Func<Location, MountainAreaViewModel> areaViewModelFactory,
            IDialogProvider dialogProvider)
        {
            this._dialogProvider = dialogProvider;
            _areaViewModelFactory = areaViewModelFactory;
            _mountainWeatherService = mountainWeatherService;
            Title = "Mountain Areas";
            SetAreas();
        }

        public IEnumerable<MountainAreaViewModel> Areas
        {
            get  { return _areas; }
            set  { SetProperty(ref _areas, value); }
        }

        private async void SetAreas()
        {
            try
            {
                var locations = await _mountainWeatherService.GetAreas();

                if (locations == null)
                    return;

                Areas = locations
                    .Select(location =>  _areaViewModelFactory(location))
                    .ToList();
            }
            catch (Exception ex)
            {
                var result = await _dialogProvider.DisplayActionSheet(ex.Message, "Cancel", null, "Retry");

                if (result == "Retry")
                    SetAreas();
            }
        }
    }
}


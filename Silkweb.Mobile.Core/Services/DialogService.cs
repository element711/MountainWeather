using System;
using Silkweb.Mobile.Core.Services;
using Xamarin.Forms;
using System.Threading.Tasks;
using Silkweb.Mobile.Core.Interfaces;

namespace Silkweb.Mobile.Core.Services
{
    public class DialogService : IDialogProvider
    {
        private readonly IPage _page;

        public DialogService(IPage page)
        {
            _page = page;            
        }

        public Task DisplayAlert( string title, string message, string cancel)
        {
            return _page.DisplayAlert(title, message, cancel);
        }

        public async Task<bool> DisplayAlert(string title, string message, string accept, string cancel)
        {
            return await _page.DisplayAlert(title, message, accept, cancel);
        }

        public async Task<string> DisplayActionSheet(string title, string cancel, string destruction, params string[] buttons)
        {
            return await _page.DisplayActionSheet(title, cancel, destruction, buttons);
        }
    }
}


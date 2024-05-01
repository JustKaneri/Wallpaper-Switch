using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wallpaper_Switch.Tools
{
    public static class Notification
    {
        private static NotificationForm _form;

        public static void Show(NotificationForm.NotificationStatus status, string message)
        {
            if(_form != null)
            {
                _form.Close();
                _form.Dispose();
                _form = null;
            }

            _form = new NotificationForm(status, message);
            _form.Show();
        }
    }
}

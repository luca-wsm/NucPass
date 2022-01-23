using NucPass.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NucPass.Services
{

    public enum MessageBoxType
    {
        INFORMATION,
        ERROR,
        WARNING,
        SUCCESS,
    }

    public class MessageBoxService
    {
        public void send(MessageBoxType type, string content)
        {

            switch(type)
            {
                case MessageBoxType.INFORMATION:
                    MessageBox.Show(content, MessageConstants.MESSAGEBOX_TITLE_INFORMATION, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case MessageBoxType.ERROR:
                    MessageBox.Show(content, MessageConstants.MESSAGEBOX_TITLE_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case MessageBoxType.WARNING:
                    MessageBox.Show(content, MessageConstants.MESSAGEBOX_TITLE_WARNING, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case MessageBoxType.SUCCESS:
                    MessageBox.Show(content, MessageConstants.MESSAGEBOX_TITLE_SUCCESS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
            }
        }
    }
}

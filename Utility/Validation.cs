using System.Web.UI.WebControls;

namespace Utility
{
    public class Validation
    {
        public static bool CheckTextBox(TextBox textBox, string contolText, out int id, out string message)
        {
            string s = textBox.Text;
            message = string.Empty;
            id = 0;
            if (string.IsNullOrWhiteSpace(s))
            {
                message = contolText + Message.NotBlank.ToFriendlyString();
                return false;
            }
            if (!int.TryParse(s, out id))
            {
                message = "Input " + contolText + " properly";
                return false;
            }
            return true;
        }

    }
}

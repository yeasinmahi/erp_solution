using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace Utility
{
    public static class ImageHelper
    {
        public static bool SetImage(this Image image, byte[] bytes) 
        {
            if (bytes.Length > 0)
            {
                try
                {
                    image.ImageUrl = "data:image;base64," + Convert.ToBase64String(bytes);
                    return true;
                }
                catch(Exception ex)
                {
                    return false;
                }
                
            }
            return false;
        }
    }
}

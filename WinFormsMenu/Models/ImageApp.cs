using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace WinFormsMenu.Models
{
    public class ImageApp
    {
        public readonly string path;
        private readonly List<string> btnName;
        public Dictionary<string, Image> btnImage { get; private set; }
        public Dictionary<string, Image> langImage { get; private set; }

        public ImageApp()
        {
            path = setPathImg(Environment.CurrentDirectory);
            btnName = new List<string>() { "clear", "GoogleChromeLogo", "iconopen", "newtab", "refresh", "save", "search", "setting" };

            setImg(btnName);
        }

        private string setPathImg(string path) => path.Substring(0, path.IndexOf("bin")) + "Resources\\";

        private void setImg(in List<string> imgnames)
        {
            btnImage = new Dictionary<string, Image>();

            foreach (string imgname in imgnames)
            {
                btnImage.Add(imgname, getFromFile(path + imgname + ".png"));
            }

            Image getFromFile(in string path)
            {
                try
                {
                    return Image.FromFile(path);
                }
                catch
                {
                    return null;
                }
            }
        }
    }
}

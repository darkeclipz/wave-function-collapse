using System.Drawing;

namespace WFC
{
    public class Tileset
    {
        public Image Image { get; private set; }
        
        public Tileset(string filepath)
        {
            Image = Bitmap.FromFile(filepath);
        }
    }
}
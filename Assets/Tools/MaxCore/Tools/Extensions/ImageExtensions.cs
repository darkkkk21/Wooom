using UnityEngine.UI;

namespace Tools.MaxCore.Tools.Extensions
{
    public static class ImageExtensions
    {
        public static void SetAlpha(this Image image, float alpha)
        {
            var color = image.color;
            color.a = alpha;
            image.color = color;
        }
    }
}
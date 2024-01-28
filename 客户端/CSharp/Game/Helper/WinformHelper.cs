using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Helper
{
    public class WinformHelper
    {
        public static int CalculateScreenWidth(out int minX, out int maxX)
        {
            var horizontalPixels = new HashSet<int>();
            minX = int.MaxValue;
            maxX = int.MinValue;

            foreach (var screen in Screen.AllScreens)
            {
                if (screen.Bounds.Left < minX) minX = screen.Bounds.Left;
                if (screen.Bounds.Right > maxX) maxX = screen.Bounds.Right;

                for (int x = screen.Bounds.Left; x < screen.Bounds.Right; x++)
                {
                    // 只有当横向像素点尚未被加入集合时，才将其加入
                    horizontalPixels.Add(x);
                }
            }

            // 最终的总宽度即为集合中像素点的个数
            return horizontalPixels.Count;
        }

        public static void Open<T>(params object[]? args) where T : Form
        {
            Form openedForm = Application.OpenForms.OfType<T>().FirstOrDefault();

            if (openedForm != null)
            {
                openedForm.Show();
                openedForm.Activate();
            }
            else
            {
                // 使用反射创建带参数的窗体实例
                var form = (T)Activator.CreateInstance(typeof(T), args);
                form.Show();
            }
        }
    }
}

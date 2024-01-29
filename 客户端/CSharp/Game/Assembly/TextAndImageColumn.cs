using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Game.Assembly
{
    public class TextAndImageColumn : DataGridViewTextBoxColumn
    {
        private Image imageValue;
        private Size imageSize;
        public TextAndImageColumn()
        {
            this.CellTemplate = new TextAndImageCell();
        }

        public override object Clone()
        {
            TextAndImageColumn c = base.Clone() as TextAndImageColumn;
            c.imageValue = this.imageValue;
            c.imageSize = this.imageSize;
            return c;
        }

        public Image Image
        {
            get
            {
                return this.imageValue;
            }
            set
            {
                if (this.Image != value)
                {
                    this.imageValue = value;
                    this.imageSize = value.Size;
                    if (this.InheritedStyle != null)
                    {
                        Padding inheritedPadding = this.InheritedStyle.Padding;
                        this.DefaultCellStyle.Padding = new Padding(imageSize.Width, inheritedPadding.Top, inheritedPadding.Right, inheritedPadding.Bottom);
                    }
                }
            }
        }

        private TextAndImageCell TextAndImageCellTemplate
        {
            get
            {
                return this.CellTemplate as TextAndImageCell;
            }
        }
        internal Size ImageSize
        {
            get
            {
                return imageSize;
            }
        }
    }

    public class TextAndImageCell : DataGridViewTextBoxCell
    {
        private Image imageValue;

        private Size imageSize;

        public override object Clone()
        {
            TextAndImageCell c = base.Clone() as TextAndImageCell;
            c.imageValue = this.imageValue;
            c.imageSize = this.imageSize;
            return c;
        }

        public Image Image
        {
            get
            {
                if (this.OwningColumn == null || this.OwningTextAndImageColumn == null)
                {
                    return imageValue;
                }
                else if (this.imageValue != null)
                {
                    return this.imageValue;
                }
                else
                {
                    return this.OwningTextAndImageColumn.Image;
                }
            }
            set
            {
                if (this.imageValue != value)
                {
                    this.imageValue = value;
                    this.imageSize = value.Size;
                    Padding inheritedPadding = this.InheritedStyle.Padding;
                    this.Style.Padding = new Padding(imageSize.Width, inheritedPadding.Top, inheritedPadding.Right, inheritedPadding.Bottom);
                }
            }
        }

        protected override void Paint(Graphics graphics, Rectangle clipBounds, Rectangle cellBounds, int rowIndex, DataGridViewElementStates cellState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
        {
            // Paint the base content
            base.Paint(graphics, clipBounds, cellBounds, rowIndex, cellState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts);
            if (this.Image != null)
            {
                Size imageSize = new Size(16, 16);

                // 计算图像在垂直方向上居中的位置
                int imageTop = cellBounds.Top + (cellBounds.Height - imageSize.Height) / 2;

                // 图像定位在单元格的左侧，垂直居中
                Point imageLocation = new Point(cellBounds.Left, imageTop);

                // 保存当前的图形状态
                System.Drawing.Drawing2D.GraphicsContainer container = graphics.BeginContainer();

                // 设置剪辑区域以避免绘制超出单元格的内容
                graphics.SetClip(cellBounds);

                // 绘制图像，不考虑图像的原始大小，强制拉伸到16x16像素
                graphics.DrawImage(this.Image, new Rectangle(imageLocation, imageSize));

                // 恢复之前的图形状态
                graphics.EndContainer(container);
            }
        }

        private TextAndImageColumn OwningTextAndImageColumn
        {
            get
            {
                return this.OwningColumn as TextAndImageColumn;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Entity
{
    public class WorldMessageEntity
    {
        public string Channel { get; set; } = "";
        public Data Data { get; set; } = new Data();
    }

    public class Data
    {
        public int Id { get; set; } = 0;
        public string Name { get; set; } = "世界";
        public int Notice { get; set; } = 0;
        public Message Message { get; set; } = new Message();
    }

    public class Message
    {
        public int Id { get; set; } = 0;
        public From From { get; set; } = new From();
        public Color Color { get; set; } = new Color();
        public string Event { get; set; } = "";
        public Content Content { get; set; } = new Content();
        public string Time { get; set; } = "20:59:59";
    }

    public class From
    {
        public string Uid { get; set; } = "";
        public string Title { get; set; } = "";
        public string Area { get; set; } = "";
        public string Name { get; set; } = "";
    }

    public class Color
    {
        public string Title { get; set; } = "#000000";
        public string Name { get; set; } = "#000000";
        public string Message { get; set; } = "#000000";
        public string Area { get; set; } = "#000000";
        public string Time { get; set; } = "#000000";
    }

    public class Content
    {
        public string Type { get; set; } = "text";
        public string Data { get; set; } = "";
    }
}

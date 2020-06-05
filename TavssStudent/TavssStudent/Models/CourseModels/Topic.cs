using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TavssStudent.Models
{
    public enum TopicType
    {
        Video,
        Docx,
        PDF,
        MD,
        PPT,
        PICS
    }

    public class Topic
    {
        public string Id { get; set; }
        public string Discription { get; set; }
        public TopicType Type { get; set; }
        public string Name { get; set; }
        public int Position { get; set; }
        public string Path { get; set; }
    }
}

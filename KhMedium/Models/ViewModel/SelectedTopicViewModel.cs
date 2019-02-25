using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KhMedium.Entities;

namespace KhMedium.Models
{
    public class SelectedTopicViewModel
    {
        public List<Topic> Topics { get; set; }
        public List<String> SelectedTopics { get; set; }
    }
}
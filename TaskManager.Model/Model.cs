﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Model
{
    public class TaskModel
    {
        public System.Guid Task_ID { get; set; }
        public System.Guid Parent_ID { get; set; }
        public string Task { get; set; }
        public System.DateTime Start_Date { get; set; }
        public System.DateTime End_Date { get; set; }
        public int Priority { get; set; }
        public int Action { get; set; }
    }

    public class ParentTaskModel
    {
        public System.Guid Parent_ID { get; set; }
        public string Parent_Task { get; set; }
    }

    public class APIResponse
    {
        public string errorInfo { get; set; }
        public bool status { get; set; }
    }

}
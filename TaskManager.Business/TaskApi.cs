﻿using System;
using System.Collections.Generic;
using System.Linq;
using TaskManager.Business.Extenstion;
using TaskManager.DataAccess;
using TaskManager.Model;

namespace TaskManager.Business
{
    public class TaskApi
    {
        /// <summary>
        /// Get parent task details
        /// </summary>
        /// <returns>List of parent task</returns>
        public IEnumerable<PARENT_TASK> GetParentTask()
        {
            var parentTasks = DataAccessManager.GetParentTasks();
            if (parentTasks != null && parentTasks.Any())
                return parentTasks.Select(p => new PARENT_TASK()
                {
                    Parent_ID= p.Parent_ID.ToString(),
                    Parent_Task= p.Parent_Task
                }).ToList();
            return null;
        }
        
        /// <summary>
        /// Get task details
        /// </summary>
        /// <returns>List of Task</returns>
        public IEnumerable<TASK_DETAILS> GetTaskDetails()
        {
            var tasks = DataAccessManager.GetTasks();
            if (tasks != null && tasks.Any())
                return tasks.Select(t => new TASK_DETAILS()
                {
                    Parent_ID = t.Parent_ID.ToString(),
                    Task_ID= t.Task_ID.ToString(),
                    Task=t.Task1,
                    Start_Date=t.Start_Date.ToCustomDate(),
                    End_Date=t.End_Date.ToCustomDate(),
                    IsActive=t.End_Date.IsActiveTask(),
                    Priority=t.Priority
                }).ToList();
            return null;
        }

        /// <summary>
        /// Add task detail
        /// </summary>
        /// <param name="taskDetail"></param>
        /// <returns>Transcation status</returns>
        public bool AddTaskDetail(TASK_DETAILS taskDetail)
        {
            Task task = new Task();
            if (taskDetail.Parent_ID != null)
            {
                task.Parent_ID = taskDetail.Parent_ID.ToGuid();
                var parentTask = DataAccessManager.GetTask(taskDetail.Parent_ID.ToGuid());
                //if (parentTask == null)
                //{
                //    //Return invalid parent task
                //}
            }
            task.Task_ID = Guid.NewGuid();
            task.Task1 = taskDetail.Task;
            task.Start_Date = DateTime.Parse(taskDetail.Start_Date);
            task.End_Date =DateTime.Parse(taskDetail.End_Date);
            task.Priority = taskDetail.Priority;
            return DataAccessManager.AddTask(task);
        }


        /// <summary>
        /// Include task detail
        /// </summary>
        /// <param name="taskDetail"></param>
        /// <returns>Transcation status</returns>
        public bool UpdateTaskDetail(TASK_DETAILS taskDetail)
        {
            Task task = new Task();
            if (taskDetail.Parent_ID != null)
            {
                task.Parent_ID = taskDetail.Parent_ID.ToGuid();
                var parentTask = DataAccessManager.GetTask(taskDetail.Parent_ID.ToGuid());
                //if (parentTask == null)
                //{
                //    //Return invalid parent task
                //}
            }
            task.Task_ID = taskDetail.Task_ID.ToGuid();            
            task.Task1 = taskDetail.Task;
            task.Start_Date = taskDetail.Start_Date.ToDateTime();
            task.End_Date = taskDetail.End_Date.ToDateTime();
            task.Priority = taskDetail.Priority;
            return DataAccessManager.UpdateTask(task);
        }


        /// <summary>
        /// Set end task status
        /// </summary>
        /// <param name="taskDetail"></param>
        /// <returns></returns>
        public bool UpdateEndTask(TASK_DETAILS taskDetail)
        {
            Task task = new Task();
            task.Task_ID = taskDetail.Task_ID.ToGuid();
            return DataAccessManager.UpdateEndTask(task);
        }
    }
}


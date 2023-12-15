using System;
using System.Collections.Generic;
using System.Linq;

public class Task
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string Status { get; set; }
    public DateTime DueDate { get; set; }

    public override string ToString()
    {
        return $"Title: {Title}\nDescription: {Description}\nStatus: {Status}\nDue Date: {DueDate}\n";
    }
}

public class TaskManager
{
    private List<Task> tasks;

    public TaskManager()
    {
        tasks = new List<Task>();
    }

    public void AddTask(Task task)
    {
        tasks.Add(task);
        Console.WriteLine("Task added successfully!");
    }

    public void ViewTasks()
    {
        if (tasks.Count == 0)
        {
            Console.WriteLine("No tasks available.");
        }
        else
        {
            foreach (var task in tasks)
            {
                Console.WriteLine(task);
            }
        }
    }

    public void EditTask(string title)
    {
        Task taskToEdit = tasks.Find(t => t.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
        if (taskToEdit != null)
        {
            Console.WriteLine("Current Task Details:");
            Console.WriteLine(taskToEdit);

            Console.WriteLine("Enter new details:");

            Console.Write("New title (press Enter to keep existing): ");
            string newTitle = Console.ReadLine();
            if (!string.IsNullOrEmpty(newTitle))
            {
                taskToEdit.Title = newTitle;
            }

            Console.Write("New description (press Enter to keep existing): ");
            string newDescription = Console.ReadLine();
            if (!string.IsNullOrEmpty(newDescription))
            {
                taskToEdit.Description = newDescription;
            }

            Console.Write("New status (press Enter to keep existing): ");
            string newStatus = Console.ReadLine();
            if (!string.IsNullOrEmpty(newStatus))
            {
                taskToEdit.Status = newStatus;
            }

            Console.Write("New due date (press Enter to keep existing): ");
            string newDueDateStr = Console.ReadLine();
            if (!string.IsNullOrEmpty(newDueDateStr))
            {
                if (DateTime.TryParse(newDueDateStr, out DateTime newDueDate))
                {
                    taskToEdit.DueDate = newDueDate;
                }
                else
                {
                    Console.WriteLine("Invalid date format. Due date not updated.");
                }
            }

            Console.WriteLine("Task edited successfully!");
        }
        else
        {
            Console.WriteLine($"Task '{title}' not found.");
        }
    }

    public void RemoveTask(string title)
    {
        Task taskToRemove = tasks.Find(t => t.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
        if (taskToRemove != null)
        {
            tasks.Remove(taskToRemove);
            Console.WriteLine($"Task '{title}' removed successfully.");
        }
        else
        {
            Console.WriteLine($"Task '{title}' not found.");
        }
    }
}

class Program
{
    static void Main()
    {
        TaskManager taskManager = new TaskManager();

        while (true)
        {
            Console.WriteLine("Task Management Application");
            Console.WriteLine("1. Add Task");
            Console.WriteLine("2. View Tasks");
            Console.WriteLine("3. Edit Task");
            Console.WriteLine("4. Remove Task");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Task newTask = new Task();

                    Console.Write("Enter task title: ");
                    newTask.Title = Console.ReadLine();

                    Console.Write("Enter task description: ");
                    newTask.Description = Console.ReadLine();

                    Console.Write("Enter task status: ");
                    newTask.Status = Console.ReadLine();

                    Console.Write("Enter task due date (optional, press Enter to skip): ");
                    string dueDateStr = Console.ReadLine();
                    if (!string.IsNullOrEmpty(dueDateStr) && DateTime.TryParse(dueDateStr, out DateTime dueDate))
                    {
                        newTask.DueDate = dueDate;
                    }

                    taskManager.AddTask(newTask);
                    break;

                case "2":
                    taskManager.ViewTasks();
                    break;

                case "3":
                    Console.Write("Enter the title of the task to edit: ");
                    string titleToEdit = Console.ReadLine();
                    taskManager.EditTask(titleToEdit);
                    break;

                case "4":
                    Console.Write("Enter the title of the task to remove: ");
                    string titleToRemove = Console.ReadLine();
                    taskManager.RemoveTask(titleToRemove);
                    break;

                case "5":
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

            Console.WriteLine("\nPress Enter to continue...");
            Console.ReadLine();
            Console.Clear();
        }
    }
}

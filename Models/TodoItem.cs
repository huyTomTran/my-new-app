using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

public class TodoItem 
{

    public int id { get; set; }

    public int user_id { get; set; }

    public string title { get; set; }
    
    public string description { get; set; }
}
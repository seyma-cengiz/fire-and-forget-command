﻿namespace FireForgetDatabaseCommand.Entities;

public class Book
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int PublicationYear { get; set; }
    public string Author { get; set; }
}

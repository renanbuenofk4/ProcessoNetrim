﻿namespace SchoolManagement.Application.Queries;

public class PagedQuery
{
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}
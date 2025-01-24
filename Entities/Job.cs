using WebLab2024.Entities;

public class Job
{

public int Id {get;set;}

public string Title {get;set;}
public string Description {get;set;}
public bool IsActive {get;set;}
public decimal Salary {get;set;}

public DateTime CreateDate {get;set;}
public DateTime ModifiedDate {get;set;}
public User AddedBy  {get;set;}
public int AddedById  {get;set;}



}
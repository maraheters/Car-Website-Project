namespace Server.Models.DTOs.GetDtos;

public class GetImageInfoDto
{
    public Guid Id {get; set;}

    public List<string> Urls {get; set;} = [];

    public Guid CarId {get;set;}
}
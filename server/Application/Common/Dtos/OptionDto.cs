namespace server.Application.Common.Dtos;

public class OptionDto : IdentifierDto
{
    public string Value { get; init; } = "";
    public string Label { get; init; } = "";
}

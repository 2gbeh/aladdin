namespace server.Shared.Enums;

public enum TransactionStatusEnum
{
    [Display(Name = "default")]
    Default,

    [Display(Name = "draft")]
    Draft,

    [Display(Name = "hidden")]
    Hidden,
}
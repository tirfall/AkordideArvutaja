using AkordideArvutaja.Models;

namespace AkordideArvutaja.ViewModels;

public class LuguViewModel
{
    public string ChordsInput { get; set; } = string.Empty;
    public string OutputFormat { get; set; } = "numbers";
    public IReadOnlyList<TaktInfo> Taktid { get; set; } = [];
    public string? ErrorMessage { get; set; }
}

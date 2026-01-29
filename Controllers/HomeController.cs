using AkordideArvutaja.Models;
using AkordideArvutaja.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AkordideArvutaja.Controllers;

public class HomeController : Controller
{
    [HttpGet]
    public IActionResult Index([FromQuery] string? chords, [FromQuery] string? format)
    {
        var model = new LuguViewModel
        {
            ChordsInput = chords?.Trim() ?? string.Empty,
            OutputFormat = NormalizeFormat(format)
        };

        if (!string.IsNullOrWhiteSpace(model.ChordsInput))
        {
            try
            {
                var lugu = LuguParser.FromChordInput(model.ChordsInput);
                model.Taktid = lugu.GetTaktidInfo();
            }
            catch (ArgumentException ex)
            {
                model.ErrorMessage = ex.Message;
            }
        }

        return View(model);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    private static string NormalizeFormat(string? format)
    {
        return string.Equals(format, "names", StringComparison.OrdinalIgnoreCase) ? "names" : "numbers";
    }
}

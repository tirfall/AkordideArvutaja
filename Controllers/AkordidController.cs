using AkordideArvutaja.Models;
using Microsoft.AspNetCore.Mvc;

namespace AkordideArvutaja.Controllers;

[ApiController]
[Route("api/akordid")]
public class AkordidController : ControllerBase
{
    [HttpGet]
    public IActionResult Get([FromQuery] string chords, [FromQuery] string? format)
    {
        if (string.IsNullOrWhiteSpace(chords))
        {
            return BadRequest(new { Error = "Chord input cannot be empty." });
        }

        try
        {
            var lugu = LuguParser.FromChordInput(chords);
            var outputFormat = string.Equals(format, "names", StringComparison.OrdinalIgnoreCase) ? "names" : "numbers";
            var taktideInfo = lugu.GetTaktidInfo();

            return outputFormat switch
            {
                "names" => Ok(new { Taktid = taktideInfo.Select(t => new { t.Index, t.RootName, t.NoteNames }) }),
                _ => Ok(new { Taktid = taktideInfo.Select(t => new { t.Index, t.Root, t.Notes }) })
            };
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { Error = ex.Message });
        }
    }
}

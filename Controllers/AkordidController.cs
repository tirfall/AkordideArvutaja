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
        var lugu = new Lugu();
        var chordNames = chords.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

        foreach (var chordName in chordNames)
        {
            lugu.LisaTakt(new Kolmkola(chordName));
        }

        var outputFormat = (format ?? "numbers").Trim().ToLowerInvariant();
        var taktideInfo = lugu.Taktid.Select((kolmkola, index) => new
        {
            Index = index + 1,
            Root = kolmkola.Root,
            RootName = Kolmkola.MidiToName(kolmkola.Root),
            Notes = kolmkola.GetNotes(),
            NoteNames = kolmkola.GetNoteNames()
        });

        return outputFormat switch
        {
            "names" => Ok(new { Taktid = taktideInfo.Select(t => new { t.Index, t.RootName, t.NoteNames }) }),
            _ => Ok(new { Taktid = taktideInfo.Select(t => new { t.Index, t.Root, t.Notes }) })
        };
    }
}
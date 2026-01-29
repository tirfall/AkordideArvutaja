namespace AkordideArvutaja.Models;

public class Kolmkola
{
    private static readonly string[] NoteNames =
    [
        "C", "C#", "D", "Eb", "E", "F", "F#", "G", "G#", "A", "B", "H"
    ];

    private static readonly Dictionary<string, int> NameToOffset = new(StringComparer.OrdinalIgnoreCase)
    {
        { "C", 0 },
        { "C#", 1 },
        { "DB", 1 },
        { "D", 2 },
        { "EB", 3 },
        { "D#", 3 },
        { "E", 4 },
        { "F", 5 },
        { "F#", 6 },
        { "GB", 6 },
        { "G", 7 },
        { "G#", 8 },
        { "AB", 8 },
        { "A", 9 },
        { "B", 10 },
        { "BB", 10 },
        { "H", 11 }
    };

    public Kolmkola(int root)
    {
        Root = root;
    }

    public Kolmkola(string rootName)
    {
        Root = NameToMidi(rootName);
    }

    public int Root { get; }

    public int[] GetNotes() => [Root, Root + 4, Root + 7];

    public string[] GetNoteNames() => GetNotes().Select(MidiToName).ToArray();

    public static string MidiToName(int midiNumber)
    {
        var offset = ((midiNumber - 60) % 12 + 12) % 12;
        return NoteNames[offset];
    }

    public static int NameToMidi(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Chord name cannot be empty.", nameof(name));
        }

        var normalized = name.Trim().Replace("♭", "b", StringComparison.OrdinalIgnoreCase)
            .Replace("♯", "#", StringComparison.OrdinalIgnoreCase)
            .ToUpperInvariant();

        if (!NameToOffset.TryGetValue(normalized, out var offset))
        {
            throw new ArgumentException($"Unsupported chord name '{name}'.", nameof(name));
        }

        return 60 + offset;
    }
}
namespace AkordideArvutaja.Models;

public static class LuguParser
{
    public static Lugu FromChordInput(string chordInput)
    {
        if (string.IsNullOrWhiteSpace(chordInput))
        {
            throw new ArgumentException("Chord input cannot be empty.", nameof(chordInput));
        }

        var chordNames = chordInput.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

        if (chordNames.Length == 0)
        {
            throw new ArgumentException("Chord input cannot be empty.", nameof(chordInput));
        }

        var lugu = new Lugu();

        foreach (var chordName in chordNames)
        {
            lugu.LisaTakt(Kolmkola.Create(chordName));
        }

        return lugu;
    }
}

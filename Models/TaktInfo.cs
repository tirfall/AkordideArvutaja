namespace AkordideArvutaja.Models;

public class TaktInfo
{
    public TaktInfo(int index, Kolmkola kolmkola)
    {
        Index = index;
        Root = kolmkola.Root;
        RootName = Kolmkola.MidiToName(kolmkola.Root);
        Notes = kolmkola.GetNotes();
        NoteNames = kolmkola.GetNoteNames();
    }

    public int Index { get; }
    public int Root { get; }
    public string RootName { get; }
    public int[] Notes { get; }
    public string[] NoteNames { get; }
}

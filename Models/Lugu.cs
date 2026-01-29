namespace AkordideArvutaja.Models;

public class Lugu
{
    private readonly List<Kolmkola> _taktid = [];

    public IReadOnlyList<Kolmkola> Taktid => _taktid;

    public void LisaTakt(Kolmkola kolmkola)
    {
        if (kolmkola is null)
        {
            throw new ArgumentNullException(nameof(kolmkola));
        }

        _taktid.Add(kolmkola);
    }
}
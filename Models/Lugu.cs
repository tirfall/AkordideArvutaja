namespace AkordideArvutaja.Models;

public class Lugu
{
    private readonly List<Kolmkola> _taktid = [];

    public IReadOnlyList<Kolmkola> Taktid => _taktid;

    public IReadOnlyList<TaktInfo> GetTaktidInfo()
    {
        return _taktid.Select((kolmkola, index) => new TaktInfo(index + 1, kolmkola)).ToList();
    }

    public void LisaTakt(Kolmkola kolmkola)
    {
        if (kolmkola is null)
        {
            throw new ArgumentNullException(nameof(kolmkola));
        }

        _taktid.Add(kolmkola);
    }
}

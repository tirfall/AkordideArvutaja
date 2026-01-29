using AkordideArvutaja.Models;
using Xunit;

namespace AkordideArvutaja.Tests;

public class KolmkolaTests
{
    [Fact]
    public void IntConstructor_ReturnsMajorTriadNotes()
    {
        var kolmkola = new Kolmkola(60);

        Assert.Equal(new[] { 60, 64, 67 }, kolmkola.GetNotes());
    }

    [Theory]
    [InlineData(60, "C")]
    [InlineData(61, "C#")]
    [InlineData(63, "Eb")]
    [InlineData(71, "H")]
    public void MidiToName_MapsNumbersToNames(int midi, string expected)
    {
        Assert.Equal(expected, Kolmkola.MidiToName(midi));
    }

    [Theory]
    [InlineData("C", 60)]
    [InlineData("F", 65)]
    [InlineData("G", 67)]
    [InlineData("Eb", 63)]
    public void NameToMidi_MapsNamesToNumbers(string name, int expected)
    {
        Assert.Equal(expected, Kolmkola.NameToMidi(name));
    }

    [Fact]
    public void Create_UsesSubclassForMajorChords()
    {
        Assert.IsType<CKolmkola>(Kolmkola.Create("C"));
        Assert.IsType<FKolmkola>(Kolmkola.Create("F"));
        Assert.IsType<GKolmkola>(Kolmkola.Create("G"));
    }
}

using AkordideArvutaja.Models;
using Xunit;

namespace AkordideArvutaja.Tests;

public class LuguParserTests
{
    [Fact]
    public void FromChordInput_BuildsLuguWithTaktid()
    {
        var lugu = LuguParser.FromChordInput("C,F,G");

        Assert.Equal(3, lugu.Taktid.Count);
        Assert.Equal(60, lugu.Taktid[0].Root);
        Assert.Equal(65, lugu.Taktid[1].Root);
        Assert.Equal(67, lugu.Taktid[2].Root);
    }

    [Fact]
    public void GetTaktidInfo_ReturnsNoteNames()
    {
        var lugu = LuguParser.FromChordInput("C");

        var info = lugu.GetTaktidInfo();

        Assert.Single(info);
        Assert.Equal(new[] { "C", "E", "G" }, info[0].NoteNames);
    }
}

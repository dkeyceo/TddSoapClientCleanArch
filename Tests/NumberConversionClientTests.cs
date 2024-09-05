using FluentAssertions;
using Infrastructure;

namespace Tests;

public class NumberConversionClientTests
{
    [Fact]
    public void NumberToWords_ShouldReturnWords()
    {
        var client = new NumberConversionClient();
        var number = 123;

        //Act
        var result = client.NumberToWords(number);

        //Assert
        result.Should().Be("one hundred and twenty three ");
    }
    
    [Fact]
    public async void NumberToWordsV2_ShouldReturnWords()
    {
        var client = new NumberConversionClientV2();
        var number = 123;

        //Act
        var result = await client.NumberToWords(number);

        //Assert
        result.Should().Be("one hundred and twenty three ");
    }
    
}
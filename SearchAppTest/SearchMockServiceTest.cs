using System;
using MockSearchService;
using Xunit;

namespace SearchAppTest
{
    public class SearchMockServiceTest
    {
        [Fact]
        public void ShouldThrowExceptionIfDataInConstructorIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new MoqSearchService(null));
        }

        [Fact]
        public void ShouldThrowExceptionIfParameterIsEmpty()
        {
            // arrange
            var service = new MoqSearchService();

            // act and assert
            Assert.Throws<ArgumentException>(() => service.GetSearchResult(string.Empty));
        }

        [Fact]
        public void ShouldThrowExceptionIfParameterIsNull()
        {
            // arrange
            var service = new MoqSearchService();

            // act and assert
            Assert.Throws<ArgumentNullException>(() => service.GetSearchResult(null));
        }

        [Fact]
        public void ShouldReturnNotEmptyArray()
        {
            // arrange
            var service = new MoqSearchService();
            var result = service.GetSearchResult("cat");

            // act and assert
            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldReturnEmptyArray()
        {
            // arrange
            var service = new MoqSearchService();
            var result = service.GetSearchResult("bull");
            Assert.Equal(0, result.Count);
        }
    }
}
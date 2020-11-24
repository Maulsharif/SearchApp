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
            var service = new MoqSearchService();
            Assert.Throws<ArgumentException>(() => service.GetSearchResult(string.Empty));
        }

        [Fact]
        public void ShouldThrowExceptionIfParameterIsNull()
        {
            var service = new MoqSearchService();
            Assert.Throws<ArgumentNullException>(() => service.GetSearchResult(null));
        }

        [Fact]
        public void ShouldReturnNotEmptyArray()
        {
            var service = new MoqSearchService();
            var result = service.GetSearchResult("cat");
            Assert.NotNull(result);
        }

        [Fact]
        public void ShouldReturnEmptyArray()
        {
            var service = new MoqSearchService();
            var result = service.GetSearchResult("bull");
            Assert.Equal(0, result.Count);
        }
    }
}
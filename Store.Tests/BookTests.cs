using System;
using Xunit;

namespace Store.Tests
{
    public class BookTests
    {

        [Fact]
        public void IsIsbn_WithNull_ReturnFalse()
        {
            var actual = Book.IsIsbn(null);

            Assert.False(actual);
        }

        [Fact]
        public void IsIsbn_WithBlankStrings_ReturnFalse()
        {
            var actual = Book.IsIsbn("    ");

            Assert.False(actual);
        }

        [Fact]
        public void IsIsbn_WithInvalidIsbn_ReturnFalse()
        {
            var invalidIsbn = "ISBN 123";
            var actual = Book.IsIsbn(invalidIsbn);

            Assert.False(actual);
        }

        
        [Fact]
        public void IsIsbn_WithIsbn10_ReturnTrue()
        {
            var validIsbn = "IsBn 123-123-123 0";
            var actual = Book.IsIsbn(validIsbn);

            Assert.True(actual);
        }

        [Fact]
        public void IsIsbn_WithIsbn13_ReturnTrue()
        {
            var validIsbn = "IsBn 123-123-123 0123";
            var actual = Book.IsIsbn(validIsbn);

            Assert.True(actual);
        }

        [Fact]
        public void IsIsbn_WithTrashStart_ReturnFalse()
        {
            var validIsbn = "xx IsBn 123-123-123 0123 yy";
            var actual = Book.IsIsbn(validIsbn);

            Assert.False(actual);
        }
    }
}

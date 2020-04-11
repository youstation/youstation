namespace YouStation.Platform.Infrastructure.UnitTests.Cryptography
{
    using FluentAssertions;
    using Infrastructure.Cryptography;
    using Xunit;

    public class SaltShakerProviderUnitTests
    {
        private const int SaltyValyeDefaultLength = 344;
        
        [Theory]
        [InlineData("user1@provider1.com")]
        [InlineData("user2@provider2.com")]
        [InlineData("user3@provider3.com")]
        [InlineData("user4@provider4.com")]
        [InlineData("user5@provider5.com")]
        [InlineData("1")]
        [InlineData("1345678")]
        [InlineData("*&¨%$#@")]
        [InlineData("R")]
        public void Must_Salinize_Various_Values_And_Salty_Value_Length_Should_Be_The_Same(string value)
        {
            var provider = new SaltShakerProvider(new RsaCryptoProvider(new X509CertificateFactory()));
            var saltyValue = provider.Salinize(value);

            saltyValue.Length.Should().Be(SaltyValyeDefaultLength);
        }
        
        [Theory]
        [InlineData("user1@provider1.com")]
        [InlineData("user2@provider2.com")]
        [InlineData("user3@provider3.com")]
        [InlineData("user4@provider4.com")]
        [InlineData("user5@provider5.com")]
        public void Must_Salinize_A_Value_Correctly(string value)
        {
            var provider = new SaltShakerProvider(new RsaCryptoProvider(new X509CertificateFactory()));
            var saltyValue = provider.Salinize(value);
            
            provider.Desalinate(value, saltyValue).Should().BeTrue();
        }
        
        [Theory]
        [InlineData("user1@provider1.com", "user1@provider1.net")]
        [InlineData("user2@provider2.com", "user2@provider2.net")]
        [InlineData("user3@provider3.com", "user3@provider3.net")]
        [InlineData("user4@provider4.com", "user4@provider4.net")]
        [InlineData("user5@provider5.com", "user5@provider5.net")]
        public void Must_Salinize_A_Value_Wrong(string value, string wrongValue)
        {
            var provider = new SaltShakerProvider(new RsaCryptoProvider(new X509CertificateFactory()));
            var saltyValue = provider.Salinize(value);

            provider.Desalinate(wrongValue, saltyValue).Should().BeFalse();
        }
    }
}

   using Xunit;

   namespace DevOpsLab.UnitTests;

   public class ScratchTests
   {
       [Fact]
       public void Scratch_AlwaysFails() => Assert.True(false);
   }
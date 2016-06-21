using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FropCorn.Services;
using System.Collections.Generic;
using FropCorn;
using System.Threading.Tasks;

namespace FropCornUnitTest
{
    [TestClass]
    public class VideoServiceTest
    {
        [TestMethod]
        [Timeout(10000)]//Maximum Timeout 10 Second
        public async Task TestMethod1()
        {
            VideoService videoService = new VideoService();
            var response = await videoService.GetAllVideosBySearchAsync("sanam", "fropcorn");
            Assert.IsInstanceOfType(response, typeof(List<VideosViewModel>));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Business;
using Domain;

namespace _MovieApi.Controllers
{
    [Route("api/[controller]")]
    public class MetadataController : Controller
    {
        private readonly IMetadata _metadata;
        private IHostingEnvironment _environment;

        public MetadataController(IMetadata metadata, IHostingEnvironment environment)
        {
            _metadata = metadata;
            _environment = environment;
        }

        [HttpPost]
        [Route("Metadata")]
        public IActionResult Metadata([FromBody]Metadata metadata)
        {
            _metadata.SaveMetadata(metadata);
            return Ok();
        }

        [HttpGet("{movieId}")]
        [Route("Metadata")]
        public IActionResult Metadata(int movieId)
        {
            var item = _metadata.GetMetada(movieId, _environment.WebRootFileProvider.GetFileInfo("files/metadata.csv")?.PhysicalPath);
            if (item.FirstOrDefault() == null) return NotFound();
            return Ok(item);
        }
    }
}
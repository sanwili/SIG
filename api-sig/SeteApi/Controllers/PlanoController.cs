using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Web.Http;

namespace WebApiSegura.Controllers
{
	public class PlanoController : ApiController
	{
		// GET api/<controller>
		public IEnumerable<string> Get()
		{
			return new string[] { "value1", "value2" };
		}

		// GET api/<controller>/5
		[HttpPost]
		[Route("OpenImages")]
		public string openImages(string distrito,string path)
		{
			string ruta = "\\\\compartidos\\Planos\\Pejibaye\\6-1351843-2009\\6-1351843-2009-A.tif";
			byte[] imageArray = File.ReadAllBytes(ruta);
			string base64ImageRepresentation = Convert.ToBase64String(imageArray);
			return "data:image/tif; base64,"+base64ImageRepresentation;

		}

		// POST api/<controller>
		public void Post([FromBody]string value)
		{
		}

		// PUT api/<controller>/5
		public void Put(int id, [FromBody]string value)
		{
		}

		// DELETE api/<controller>/5
		public void Delete(int id)
		{
		}
	}
}
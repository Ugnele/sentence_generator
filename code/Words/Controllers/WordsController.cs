﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Words.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WordsController : ControllerBase
    {
        public string GetResourcesPath()
        {
            string path = Directory.GetCurrentDirectory();
            string parentPath = Path.GetFullPath(Path.Combine(path, @"..\..\..\"));
            string resourcesPath = Path.GetFullPath(Path.Combine(parentPath, @"resources\"));
            
            return resourcesPath;
        }
        public string[] ReadFile(string path)
        {
            string[] words = System.IO.File.ReadAllLines($@"\Recourses\{path}.txt");
            return words;
        }
    }
}
